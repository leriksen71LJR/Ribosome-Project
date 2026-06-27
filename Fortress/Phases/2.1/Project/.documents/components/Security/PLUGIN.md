# Security Component - Build Plugin

**Plugin ID:** `components/Security`
**Depends on:** Data; Infrastructure contracts
**ADR refs:** adr/0006
**Status:** Phase 1.2A MVP

---


**Path:** `src/Fortress.Console/Components/Security/`  
**Executable pseudocode** — follow unless deviation reported.

Cross-component keying: `Storage bridge (below)`.

---

## Contracts

```csharp
public interface IKeyDerivationService
{
    byte[] DeriveKey(string password, string salt, KeyDerivationParameters parameters);
}

public interface IEncryptionService
{
    bool IsInitialized { get; }

    Task InitializeDatabaseAsync(string databasePath, byte[] key, CancellationToken cancellationToken = default);

    bool VerifyKey(string databasePath, byte[] key);

    Task ApplyKeyAsync(SqliteConnection connection, CancellationToken cancellationToken = default);

    void Clear();
}

public interface ISessionService
{
    UserSession? CurrentSession { get; }
    bool IsUnlocked { get; }
    Task<UserSession> UnlockAsync(string masterPassword, CancellationToken cancellationToken = default);
    Task LockAsync(CancellationToken cancellationToken = default);
    void RecordActivity();
}
```

**Acceptance criteria (`adr/0006-incomplete-contract-acceptance.md`):**

- `ApplyKeyAsync` **must** be on `IEncryptionService` — no static-only keying helper as substitute.
- Key cleared on `LockAsync` via `Clear()`; `IsInitialized` becomes false.
- Storage must not open connections when `!IsInitialized`.

### Model

```csharp
public class UserSession
{
    public DateTime UnlockedAt { get; init; } = DateTime.UtcNow;
    public DateTime LastActivityAt { get; set; } = DateTime.UtcNow;
}

public class KeyDerivationParameters
{
    public int MemorySizeKb { get; init; } = 65536;
    public int Iterations { get; init; } = 4;
    public int Parallelism { get; init; } = 1;
}
```

---

## NuGet packages

```xml
<PackageReference Include="Microsoft.Data.Sqlite.Core" Version="8.0.*" />
<PackageReference Include="SQLitePCLRaw.bundle_e_sqlcipher" Version="2.1.11" />
<PackageReference Include="Konscious.Security.Cryptography.Argon2" Version="1.3.*" />
```

---

## Application startup (once per process)

```csharp
SQLitePCL.Batteries_V2.Init();
```

---

## Argon2id defaults

| Parameter | Value |
|-----------|-------|
| Algorithm | Argon2id |
| Output length | 32 bytes |
| MemorySizeKb | 65536 |
| Iterations | 4 |
| Parallelism | 1 |
| Salt length | 16 bytes random per vault |

---

## Security metadata file

**Path:** `{databaseDirectory}/fortress.security.json`

```json
{
  "version": 1,
  "saltBase64": "<16-byte random salt, Base64>",
  "keyDerivation": {
    "memorySizeKb": 65536,
    "iterations": 4,
    "parallelism": 1
  }
}
```

Never store master password or derived key on disk.

---

## SQLCipher initialization

```csharp
public async Task InitializeDatabaseAsync(string databasePath, byte[] key, CancellationToken cancellationToken = default)
{
    var directory = Path.GetDirectoryName(databasePath)!;
    Directory.CreateDirectory(directory);

    await using var connection = new SqliteConnection($"Data Source={databasePath}");
    await connection.OpenAsync(cancellationToken);

    var hexKey = Convert.ToHexString(key).ToLowerInvariant();
    await using (var pragma = connection.CreateCommand())
    {
        pragma.CommandText = $"PRAGMA key = \"x'{hexKey}'\";";
        await pragma.ExecuteNonQueryAsync(cancellationToken);
    }

    await using (var verify = connection.CreateCommand())
    {
        verify.CommandText = "SELECT count(*) FROM sqlite_master;";
        await verify.ExecuteScalarAsync(cancellationToken);
    }
}
```

On success, store derived key in `EncryptionService`; `IsInitialized = true`.

`VerifyKey` uses same open + `PRAGMA key` + `sqlite_master` probe. Return `false` on `SqliteException`.

---

## Per-connection key application

```csharp
public async Task ApplyKeyAsync(SqliteConnection connection, CancellationToken cancellationToken = default)
{
    if (!IsInitialized)
        throw new InvalidOperationException("Encryption service is not initialized. Unlock first.");

    var hexKey = Convert.ToHexString(_key!).ToLowerInvariant();
    await using var pragma = connection.CreateCommand();
    pragma.CommandText = $"PRAGMA key = \"x'{hexKey}'\";";
    await pragma.ExecuteNonQueryAsync(cancellationToken);
}
```

---

## Lock and key clearing

```csharp
public async Task LockAsync(CancellationToken cancellationToken = default)
{
    _encryptionService.Clear();
    _currentSession = null;
}
```

---

## First-time setup flow

1. Prompt master password twice (confirm match).
2. Generate 16-byte random salt.
3. Derive 32-byte key with Argon2id.
4. Write `fortress.security.json`.
5. `InitializeDatabaseAsync` → run schema from `Infrastructure plugin`.
6. Discard password from local variables; retain derived key until lock.

---

## Subsequent unlock flow

1. Read `fortress.security.json`.
2. Prompt for master password.
3. Re-derive key.
4. `VerifyKey` / open with `PRAGMA key`.
5. On failure: **"Incorrect master password."** — no silent new-db creation.
6. On success: load items via `IStorageService` (each connection gets `ApplyKeyAsync`).

---

## Wrong-password behavior

| Scenario | Required behavior |
|----------|-------------------|
| Wrong password on existing vault | Error message; remain locked |
| Missing `fortress.security.json` but `fortress.db` exists | Report gap — corruption |
| Missing both files | First-time setup |

---

## Export backup

Copy encrypted `fortress.db` as-is. Backup remains encrypted; master password required to open.

---

## UX presentation (Era B seams)

| Topic | Requirement | If not met |
|-------|-------------|------------|
| Master password entry | Prefer masked input where platform/console allows; plain `ReadLine()` is a **low-severity deviation** — disclose in build report | Report under Deviations (UX) |
| First-time setup | Prompt twice for **confirm match** only during initial vault creation | Required |
| Subsequent unlock | **Single** password prompt — do not re-prompt for confirmation on unlock | Double-prompt is a **low-severity deviation** — disclose |
| Wrong password | Show **"Incorrect master password."** — never create a new DB silently | High-severity if violated |

Era B: all three agents used unmasked input; some double-prompted on unlock. Not MVP blockers — must be visible in disclosure if reproduced.

---

## Deviations (high severity)

Plain SQLite without SQLCipher, persisted master password, or PBKDF2 instead of Argon2id — report in build report.

---


**Seam type:** S1 (cross-component contract)  
**Purpose:** Close the T3 gap between security unlock spec and storage connection opens (Era B invention cluster: per-connection keying).

---

## Rule

After unlock, **every** `SqliteConnection` opened by `SqliteStorageService` must receive the in-memory derived key before any query runs.

| Step | Owner | Action |
|------|-------|--------|
| Unlock | `SessionManager` / `EncryptionService` | Derive key; `VerifyKey` or `InitializeDatabaseAsync`; set `IsInitialized = true` |
| Load/Save | `SqliteStorageService` | `OpenAsync` → `ApplyKeyAsync(connection)` → queries |
| Lock | `SessionManager` | `IEncryptionService.Clear()` → `IsInitialized = false` |
| Storage while locked | `SqliteStorageService` | Throw if `!IsInitialized` |

---

## Mandatory pattern (Infrastructure)

```csharp
await using var connection = new SqliteConnection($"Data Source={databasePath}");
await connection.OpenAsync(cancellationToken);
await _encryptionService.ApplyKeyAsync(connection, cancellationToken);
// ... run queries
```

`ExportBackupAsync` file copy does not require `ApplyKeyAsync` unless reading live DB.

---

## Who holds the key

- **Holder:** `EncryptionService` instance (singleton) — in memory only.
- **Applier:** `IEncryptionService.ApplyKeyAsync` on interface — not a static helper (`adr/0006`).
- **Consumer:** `SqliteStorageService` injects `IEncryptionService`.

---

## Acceptance criteria (Era C regression)

- All three agents implement `ApplyKeyAsync` on `IEncryptionService`.
- No storage connection opens without key when session is unlocked.
- `LockAsync` clears key; subsequent storage calls fail fast.

Related: `Infrastructure plugin`, `adr/0006-incomplete-contract-acceptance.md`.

---
