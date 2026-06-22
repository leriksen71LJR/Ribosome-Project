# Security ↔ Infrastructure Bridge

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

Related: `components/Infrastructure/STORAGE.md`, `adr/0006-incomplete-contract-acceptance.md`.