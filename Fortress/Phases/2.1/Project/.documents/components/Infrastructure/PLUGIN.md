# Infrastructure Component - Build Plugin

**Plugin ID:** `components/Infrastructure`
**Depends on:** Data
**ADR refs:** adr/0004
**Status:** Phase 1.2A MVP

---


**Path:** `src/Fortress.Console/Components/Infrastructure/Implementations/SqliteStorageService.cs`

---

## IStorageService contract

```csharp
public interface IStorageService
{
    Task<IReadOnlyList<IItem>> LoadAsync(CancellationToken cancellationToken = default);
    Task SaveAsync(IEnumerable<IItem> items, CancellationToken cancellationToken = default);
    Task ExportBackupAsync(string destinationPath, CancellationToken cancellationToken = default);
}
```

---

## Database schema (SQLCipher)

Run on first-time setup after `InitializeDatabaseAsync`:

```sql
CREATE TABLE Tasks (
    Id TEXT PRIMARY KEY,
    Title TEXT NOT NULL,
    IsCompleted INTEGER NOT NULL DEFAULT 0,
    DueDate TEXT,
    Priority INTEGER DEFAULT 2,
    Tags TEXT,
    CreatedAt TEXT NOT NULL,
    UpdatedAt TEXT
);

CREATE TABLE Notes (
    Id TEXT PRIMARY KEY,
    Title TEXT NOT NULL,
    Content TEXT,
    CreatedAt TEXT NOT NULL,
    UpdatedAt TEXT
);

CREATE TABLE Credentials (
    Id TEXT PRIMARY KEY,
    Title TEXT NOT NULL,
    Username TEXT,
    Password TEXT,
    Url TEXT,
    Notes TEXT,
    CreatedAt TEXT NOT NULL,
    UpdatedAt TEXT
);

CREATE TABLE Goals (
    Id TEXT PRIMARY KEY,
    Title TEXT NOT NULL,
    Description TEXT,
    TargetDate TEXT,
    Progress INTEGER DEFAULT 0,
    CreatedAt TEXT NOT NULL,
    UpdatedAt TEXT
);

CREATE INDEX idx_tasks_due ON Tasks(DueDate);
CREATE INDEX idx_tasks_completed ON Tasks(IsCompleted);
```

**Schema bootstrap (pick one, state in build report §3):**

| Approach | When to use |
|----------|-------------|
| **Inline on first load** | `LoadAsync` or first `SaveAsync` runs `CREATE TABLE IF NOT EXISTS` / equivalent inside `SqliteStorageService` |
| **Explicit `EnsureSchema`** | Dedicated private method called from ctor, first unlock, or first storage access |

Both are MVP-acceptable per `adr/0004-storage-save-strategy.md`. Do not leave ownership implicit — name the approach in **Key Implementation Decisions → Storage**.

---

## Per-connection key application (mandatory)

`SqliteStorageService` opens a **new** connection on every `LoadAsync` / `SaveAsync`.

```csharp
await using var connection = new SqliteConnection($"Data Source={databasePath}");
await connection.OpenAsync(cancellationToken);
await _encryptionService.ApplyKeyAsync(connection, cancellationToken);
```

**Guard:** If `!_encryptionService.IsInitialized`, throw `InvalidOperationException`.

Detail: `components/Security/Storage bridge (below)`.

---

## Save strategy (MVP)

**Policy:** Full-table rewrite on `SaveAsync` — delete all rows per table, re-insert from `context.Items` (`adr/0004-storage-save-strategy.md`).

Incremental updates and migrations are **Phase 2+**.

---

## Archive semantics

`ArchiveCompletedHandler` removes completed tasks from `context.Items` and calls `SaveAsync`. Persisted effect: **hard delete** of completed task rows (`adr/0003-archive-semantics-mvp.md`).

---


**Path:** `src/Fortress.Console/Components/Infrastructure/`

## Contracts

```csharp
public interface IConsole
{
    void WriteLine(string message);
    void Write(string message);
}

public interface IInputService
{
    string? ReadLine();
}

public interface IConfigurationService
{
    string GetDatabasePath();
    string GetBackupDirectory();
    TimeSpan GetSessionTimeout();
}
```

## Implementations

- `SystemConsole` : `IConsole`
- `ConsoleInputService` : `IInputService`
- `ConfigurationService` : `IConfigurationService`

Handlers use `IConsole` / `IInputService` for all user I/O — no direct `Console.ReadLine` in handlers.

---
