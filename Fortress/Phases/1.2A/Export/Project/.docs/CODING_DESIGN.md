# CODING_DESIGN.md

> This document provides the **detailed implementation** for each Component defined in `ARCHITECTURE.md`.  
> It follows the exact same Component structure for direct traceability and consistency.

**Important Note on Rules**  
All behavioral, process, and enforcement rules for the build agent are defined in `AGENTS.md`.  
This includes rules such as:
- Output Location Rule
- Violation / Deviation Reporting
- Deep Documentation Audit requirement
- Documentation Boundary Rule

This document (`CODING_DESIGN.md`) focuses **only** on implementation patterns and component design.

---

## 1. Actions Component – Detailed Design

### Contracts

```csharp
public interface IActionHandler
{
    string Name { get; }
    string Description { get; }

    /// <summary>
    /// Returns true if this handler should be visible in the current menu context.
    /// </summary>
    bool IsVisible(ActionContext context);

    /// <summary>
    /// Executes the action. Phase 1.1 requires async execution.
    /// </summary>
    Task<bool> ExecuteAsync(ActionContext context, CancellationToken cancellationToken = default);
}

public interface IItem
{
    Guid Id { get; }
    string Title { get; set; }
    DateTime CreatedAt { get; }
    DateTime? UpdatedAt { get; set; }
}
```

### Model

**`ActionContext`** (Data & State Container)

`ActionContext` is a **data and state container**, not a service locator. It can be a rich, complex object graph carrying the information needed during action execution (items, session state, errors, validation results, etc.).

**Important Rule:**  
All **services** (such as `IConsole`, `IInputService`, `IStorageService`, etc.) **must** be dependency injected into the `IActionHandler` implementations themselves. They should **not** be placed inside `ActionContext`.

```csharp
public class ActionContext
{
    public List<IItem> Items { get; set; } = new();
    public UserSession Session { get; set; }
    public List<Exception> ExceptionErrors { get; set; } = new();
    public List<string> ValidationErrors { get; set; } = new();

    // ActionContext may contain rich data graphs and state.
    // Services are injected into handlers via Dependency Injection, not here.
}
```

**Concrete Item Types** (Full Definitions)

```csharp
public class TaskItem : IItem
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime? DueDate { get; set; }
    public int Priority { get; set; } = 2; // 1=High, 2=Medium, 3=Low
    public List<string> Tags { get; set; } = new();
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public bool IsOverdue() => DueDate.HasValue && DueDate.Value < DateTime.Today && !IsCompleted;
}

public class NoteItem : IItem
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public class CredentialItem : IItem
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}

public class GoalItem : IItem
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? TargetDate { get; set; }
    public int Progress { get; set; } // 0-100
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
```

### Example Implementation: `AddTaskHandler`

Services are injected into the handler via constructor injection.

```csharp
public class AddTaskHandler : IActionHandler
{
    private readonly IConsole _console;
    private readonly IInputService _input;
    private readonly IStorageService _storage;

    public AddTaskHandler(IConsole console, IInputService input, IStorageService storage)
    {
        _console = console;
        _input = input;
        _storage = storage;
    }

    public string Name => "Add Task";
    public string Description => "Create a new task with title, due date, and priority";

    public bool IsVisible(ActionContext context) =>
        context?.Session is not null;

    public async Task<bool> ExecuteAsync(ActionContext context, CancellationToken cancellationToken = default)
    {
        if (context is null)
            return false;

        if (cancellationToken.IsCancellationRequested)
            return false;

        if (context.Session is null)
        {
            context.ValidationErrors.Add("No active session.");
            return false;
        }

        try
        {
            _console.WriteLine("Enter task title: ");
            var title = _input.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                context.ValidationErrors.Add("Title cannot be empty.");
                return false;
            }

            var task = new TaskItem { Title = title };

            _console.WriteLine("Due date (yyyy-MM-dd or leave blank): ");
            var dueDateInput = _input.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(dueDateInput) && DateTime.TryParse(dueDateInput, out var dueDate))
            {
                task.DueDate = dueDate;
            }

            _console.WriteLine("Priority (1=High, 2=Medium, 3=Low): ");
            var priorityInput = _input.ReadLine()?.Trim();
            if (int.TryParse(priorityInput, out var priority) && priority is >= 1 and <= 3)
            {
                task.Priority = priority;
            }

            context.Items.Add(task);
            await _storage.SaveAsync(context.Items, cancellationToken);

            _console.WriteLine("Task added successfully.");
            return true;
        }
        catch (Exception ex)
        {
            context.ExceptionErrors.Add(ex);
            return false;
        }
    }
}
```

---

## 2. Data Component – Detailed Design

### Model

All item classes defined above in the Actions Component.

### Database Schema (SQLCipher)

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

---

## 3. Security Component – Detailed Design

### Contracts

```csharp
public interface IKeyDerivationService
{
    byte[] DeriveKey(string password, string salt, KeyDerivationParameters parameters);
}

public interface IEncryptionService
{
    /// <summary>
    /// True after a key has been successfully derived and stored for per-connection use.
    /// </summary>
    bool IsInitialized { get; }

    /// <summary>
    /// Opens or creates the SQLCipher database using the derived key.
    /// Stores the key in memory for subsequent ApplyKeyAsync calls. Call once per unlock.
    /// </summary>
    Task InitializeDatabaseAsync(string databasePath, byte[] key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns true if the provided key opens the existing database.
    /// On success, stores the key in memory for subsequent ApplyKeyAsync calls.
    /// </summary>
    bool VerifyKey(string databasePath, byte[] key);

    /// <summary>
    /// Applies the in-memory derived key to an already-opened connection via PRAGMA key.
    /// Required because SqliteStorageService opens a new connection on every LoadAsync/SaveAsync.
    /// </summary>
    Task ApplyKeyAsync(SqliteConnection connection, CancellationToken cancellationToken = default);

    /// <summary>
    /// Clears in-memory key material. Called by SessionManager.LockAsync.
    /// </summary>
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

> **Contract note:** `SqliteConnection` is from `Microsoft.Data.Sqlite`. The encryption service holds the derived key **in memory only** after `InitializeDatabaseAsync` or successful `VerifyKey` — never persist the key or master password. `SessionManager.LockAsync` must call `Clear()`.

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

### Implementations

- `Argon2KeyDerivationService` : `IKeyDerivationService`
- `EncryptionService` : `IEncryptionService`
- `SessionManager` : `ISessionService`

### Key Flows

- Master password → Argon2id key derivation → SQLCipher encryption key
- `InitializeDatabaseAsync` or successful `VerifyKey` stores the derived key in `EncryptionService` (`IsInitialized` becomes true)
- `SqliteStorageService` calls `ApplyKeyAsync` on **every** connection opened after `OpenAsync` (see Infrastructure section)
- `SessionManager.LockAsync` calls `IEncryptionService.Clear()` before discarding the session
- Session remains unlocked until manual lock or inactivity timeout (default 15 minutes)
- Package, initialization, and unlock flows: see `ARCHITECTURE_SECURITY.md` → **Implementation Specification (Phase 1.2A)**

---

## 4. Infrastructure Services Component – Detailed Design

### Contracts

```csharp
public interface IStorageService
{
    Task<IReadOnlyList<IItem>> LoadAsync(CancellationToken cancellationToken = default);

    Task SaveAsync(IEnumerable<IItem> items, CancellationToken cancellationToken = default);

    Task ExportBackupAsync(string destinationPath, CancellationToken cancellationToken = default);
}

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

### Implementations

- `SqliteStorageService` : `IStorageService` (uses SQLCipher)
- `SystemConsole` : `IConsole`
- `ConsoleInputService` : `IInputService`
- `ConfigurationService` : `IConfigurationService`

### SqliteStorageService — Per-Connection Key Application

`SqliteStorageService` opens a **new** `SqliteConnection` on every `LoadAsync`, `SaveAsync`, and `ExportBackupAsync` call. SQLCipher requires the key on each connection individually.

**Mandatory pattern** after every `OpenAsync`:

```csharp
await using var connection = new SqliteConnection($"Data Source={databasePath}");
await connection.OpenAsync(cancellationToken);
await _encryptionService.ApplyKeyAsync(connection, cancellationToken);
// ... run queries
```

**Guard:** If `!_encryptionService.IsInitialized`, throw `InvalidOperationException` — storage must not run while locked.

`ExportBackupAsync` copies the encrypted file and does not open a connection for writes; no `ApplyKeyAsync` needed unless reading from the live database.

---

## 4.5. Logging Component – Detailed Design

### Contracts

```csharp
public interface ILoggingService
{
    void LogInfo(string message);

    void LogWarning(string message);

    void LogError(string message, Exception? exception = null);
}
```

### Implementations

- `Log4NetLoggingService` : `ILoggingService`

---

## 5. Bootstrapping Component – Detailed Design

All service registration is done through `IDependencyModule` implementations.  
Handlers receive their dependencies via constructor injection, not through `ActionContext`.

### Recommended Pattern

```csharp
// In Program.cs or Bootstrapper
var services = new ServiceCollection();

// Each module registers its own services
new ActionsModule().Register(services);
new SecurityModule().Register(services);
new InfrastructureModule().Register(services);
new LoggingModule().Register(services);

var serviceProvider = services.BuildServiceProvider();

// Resolve handlers (they receive their dependencies via constructor injection)
var handlers = serviceProvider.GetRequiredService<IEnumerable<IActionHandler>>();

// Start main loop
while (true)
{
    // Build visible menu dynamically using handlers
    // ... display numbered menu
    // ... execute selected handler
}
```

---

## Cross-Cutting Concerns

- Error handling strategy across all components (see `CODING_STANDARDS.md`)
- Logging with Log4Net (configured via `log4net.config`)
- Defensive programming rules (see `CODING_STANDARDS.md`)

---

*This document is the direct counterpart to `ARCHITECTURE.md`. Every section maps 1-to-1 for maximum clarity and traceability.*
