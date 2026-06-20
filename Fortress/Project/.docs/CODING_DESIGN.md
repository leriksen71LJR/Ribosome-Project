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

    public string Name => "1. Add Task";
    public string Description => "Create a new task with title, due date, and priority";

    public bool Execute(ActionContext context)
    {
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

            // Optional due date
            _console.WriteLine("Due date (yyyy-MM-dd or leave blank): ");
            var dueDateInput = _input.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(dueDateInput) && DateTime.TryParse(dueDateInput, out var dueDate))
            {
                task.DueDate = dueDate;
            }

            // Priority
            _console.WriteLine("Priority (1=High, 2=Medium, 3=Low): ");
            var priorityInput = _input.ReadLine()?.Trim();
            if (int.TryParse(priorityInput, out var priority) && priority is >= 1 and <= 3)
            {
                task.Priority = priority;
            }

            context.Items.Add(task);
            _storage.Save(context.Items);

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

### Contracts + Implementations

- `IEncryptionService` + `EncryptionService` (uses Argon2id + AES-256-GCM via SQLCipher)
- `ISessionService` + `SessionManager` (handles unlock/lock/timeout)

### Key Flows

- Master password → Argon2id key derivation → SQLCipher encryption key
- Session remains unlocked until manual lock or inactivity timeout (default 15 minutes)

---

## 4. Infrastructure Services Component – Detailed Design

### Contracts + Implementations

- `IStorageService` + `SqliteStorageService` (uses SQLCipher)
- `IConsole` + `SystemConsole`
- `IInputService` + `ConsoleInputService`
- `IConfigurationService` + `AppSettingsService`

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
