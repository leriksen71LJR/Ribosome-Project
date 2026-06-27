# ARCHITECTURE_SECURITY.md

## Overview
This document defines the security architecture for **Fortress**. It explains how data is protected both at rest and during use, following the Component Pattern (Contracts → Implementations → Model).

---

## Security Goals

- **Confidentiality at Rest**: All user data remains encrypted and unreadable without the master password when Fortress is not running.
- **Integrity**: Protect data from unauthorized modification using authenticated encryption.
- **Transparent Encryption**: Encryption is handled transparently via SQLCipher — the application does not need to manually encrypt/decrypt data.
- **Usability**: Strong security without forcing users to wait for decryption.

---

## Security Component

The Security Component follows the standard Component structure:

### Contracts

```csharp
/// <summary>
/// Derives an encryption key from the master password and stored salt/parameters.
/// </summary>
public interface IKeyDerivationService
{
    /// <summary>
    /// Derives the key used for SQLCipher.
    /// </summary>
    byte[] DeriveKey(string password, string salt, KeyDerivationParameters parameters);
}
```

- `IEncryptionService`
- `ISessionService`
- `IKeyDerivationService`

### Implementations
- `EncryptionService` (wraps SQLCipher operations)
- `SessionManager`
- `Argon2KeyDerivationService`

### Model
- `UserSession`
- Encryption key material (never persisted)
- Master password (never persisted)

---

## Master Password & Key Management

### Initial Setup (One-Time Process)
- On first launch, the user creates a strong master password.
- This password is used **only once** during setup to:
  - Generate a random salt
  - Derive the encryption key using **Argon2id**
  - Initialize the encrypted SQLite database (SQLCipher)
- After setup, the raw master password is immediately discarded from memory.

### Subsequent Use
- Only the salt and key derivation parameters are stored on disk.
- Every future launch, the user enters their master password.
- Fortress uses the stored salt + parameters to re-derive the **exact same encryption key**.
- The raw password is **never** stored at any point.

---

## Encryption at Rest (SQLCipher)

### Technology
- **SQLCipher** (encrypted SQLite)
- AES-256-GCM encryption
- Transparent encryption — all SQL operations work normally

### What Gets Encrypted
- All tables and data (tasks, notes, credentials, goals)
- The entire database file is encrypted at rest

### Key Derivation
- **Argon2id only** for Phase 1.2A (PBKDF2 is not permitted unless reported as a deviation)
- Parameters are defined in `CODING_DESIGN.md` (`KeyDerivationParameters` defaults)

---

## Implementation Specification (Phase 1.2A — Mandatory)

This section is **executable pseudocode** for the Security and Storage components. Agents must follow it unless a deviation is reported.

### NuGet Packages

Add to `src/Fortress.Console/Fortress.Console.csproj`:

```xml
<PackageReference Include="Microsoft.Data.Sqlite.Core" Version="8.0.*" />
<PackageReference Include="SQLitePCLRaw.bundle_e_sqlcipher" Version="2.1.11" />
<PackageReference Include="Konscious.Security.Cryptography.Argon2" Version="1.3.*" />
```

| Package | Purpose |
|---------|---------|
| `Microsoft.Data.Sqlite.Core` | ADO.NET provider (use `.Core` — not the default bundle — when pairing with SQLCipher native lib) |
| `SQLitePCLRaw.bundle_e_sqlcipher` | SQLCipher native library for `Microsoft.Data.Sqlite` ([Microsoft encryption docs](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/encryption)) |
| `Konscious.Security.Cryptography.Argon2` | Argon2id key derivation |

**Note:** `SQLitePCLRaw.bundle_e_sqlcipher` is marked legacy on NuGet but remains the documented Microsoft.Data.Sqlite pairing. If restore or build fails, report the deviation — do not substitute plain SQLite.

### Application Startup (once per process)

```csharp
// In Program.cs, before any SqliteConnection is opened:
SQLitePCL.Batteries_V2.Init();
```

### Argon2id Defaults (match `KeyDerivationParameters`)

| Parameter | Value | Notes |
|-----------|-------|-------|
| Algorithm | Argon2id | `Konscious.Security.Cryptography.Argon2` |
| Output length | 32 bytes | AES-256 key for SQLCipher |
| MemorySizeKb | 65536 | 64 MB |
| Iterations | 4 | |
| Parallelism | 1 | |
| Salt length | 16 bytes | Cryptographically random per vault |

```csharp
public byte[] DeriveKey(string password, string saltBase64, KeyDerivationParameters parameters)
{
    var salt = Convert.FromBase64String(saltBase64);
    using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
    argon2.Salt = salt;
    argon2.DegreeOfParallelism = parameters.Parallelism;
    argon2.MemorySize = parameters.MemorySizeKb;
    argon2.Iterations = parameters.Iterations;
    return argon2.GetBytes(32);
}
```

### Security Metadata File (persisted on disk)

Store **salt and KDF parameters only** — never the master password or derived key.

**Path:** `{databaseDirectory}/fortress.security.json` (same directory as `fortress.db`)

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

Create this file during first-time vault setup. Read it on every subsequent unlock.

### SQLCipher Initialization Pseudocode

Use the **derived 32-byte key** (not the raw master password) with SQLCipher `PRAGMA key`:

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

    // Verify key — wrong key throws or returns error on first read
    await using (var verify = connection.CreateCommand())
    {
        verify.CommandText = "SELECT count(*) FROM sqlite_master;";
        await verify.ExecuteScalarAsync(cancellationToken);
    }
}
```

`VerifyKey` uses the same open + `PRAGMA key` + `sqlite_master` probe. Return `false` on `SqliteException` (wrong password / wrong key). Do not catch-and-ignore.

### First-Time Setup Flow

1. Prompt user for master password (twice — confirm match).
2. Generate 16-byte random salt.
3. Derive 32-byte key with Argon2id.
4. Write `fortress.security.json`.
5. Call `InitializeDatabaseAsync` → run schema from `CODING_DESIGN.md`.
6. Discard password and key from local variables after `UnlockAsync` completes.

### Subsequent Unlock Flow

1. Read `fortress.security.json`.
2. Prompt for master password.
3. Re-derive key from password + stored salt/parameters.
4. Call `VerifyKey` / open database with `PRAGMA key`.
5. On failure: show **"Incorrect master password."** — do not create a new database or overwrite files.
6. On success: create `UserSession`, load items via `IStorageService.LoadAsync`.

### Wrong-Password Behavior (Mandatory)

| Scenario | Required behavior |
|----------|-------------------|
| Wrong password on existing vault | Show error message; remain locked; **no** silent new-db creation |
| Missing `fortress.security.json` but `fortress.db` exists | Treat as corruption — report gap; do not guess |
| Missing both files | First-time setup flow |

### Export Backup

`ExportBackupAsync` copies the encrypted `fortress.db` file as-is (already encrypted). Backup does **not** require re-encryption. User still needs the master password to open the backup.

### Deviations

Substituting plain `Microsoft.Data.Sqlite` (no SQLCipher), storing the master password, or using PBKDF2 instead of Argon2id are **high-severity violations** — report in the build report.

---

## Session Management

- Once the correct master password is entered, a `UserSession` is created.
- The session remains active until the user manually locks or the app is closed.
- Optional auto-lock after a configurable period of inactivity.

---

## Threat Model

**These security constraints are MANDATORY.**

### What We Protect Against
- Unauthorized access to the database file when Fortress is closed
- Offline brute-force attacks on the encrypted database
- Data exposure through file theft or sharing

### What We Do NOT Fully Protect Against
- Malware running while Fortress is unlocked
- Physical access while the app is unlocked
- Weak master passwords chosen by the user

---

## Data Backup & Recovery

- Users can create encrypted backups of the entire Fortress database.
- Recovery requires the master password.
- Clear warnings will be shown that the master password cannot be recovered.

---

## Summary
Fortress uses **SQLCipher** for transparent encryption at rest. The Security Component follows the standard Component Pattern and is responsible for master password handling, key derivation, and session management.

---

*This document should be read together with `ARCHITECTURE.md` and `CODING_DESIGN.md`. All implementation must strictly follow the rules defined here.*