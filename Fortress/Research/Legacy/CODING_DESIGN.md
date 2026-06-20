# CODING_DESIGN.md

> This document provides the **detailed implementation** for each Component defined in `ARCHITECTURE.md`.  
> It follows the exact same Component structure for direct traceability and consistency.

---

## 1. Actions Component – Detailed Design

### Contracts

```csharp
public interface IActionHandler
{
    string Name { get; }
    string Description { get; }
    bool Execute(ActionContext context);
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

**`ActionContext`** (Expanded)

```csharp
public class ActionContext
{
    public List<IItem> Items { get; set; } = new();
    public UserSession Session { get; set; }
    public List<Exception> ExceptionErrors { get; set; } = new();
    public List<string> ValidationErrors { get; set; } = new();

    // Convenience properties
    public IConsole Console { get; set; }
    public IInputService Input { get; set; }
    public IStorageService Storage { get; set; }
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

```csharp
public class AddTaskHandler : IActionHandler
{
    public string Name => "1. Add Task";
    public string Description => "Create a new task with title, due date, and priority";

    public bool Execute(ActionContext context)
    {
        try
        {
            context.Console.WriteLine("Enter task title: ");
            var title = context.Input.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                context.ValidationErrors.Add("Title cannot be empty.");
                return false;
            }

            var task = new TaskItem { Title = title };

            // Optional due date
            context.Console.WriteLine("Due date (yyyy-MM-dd or leave blank): ");
            var dueDateInput = context.Input.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(dueDateInput) && DateTime.TryParse(dueDateInput, out var dueDate))
            {
                task.DueDate = dueDate;
            }

            // Priority
            context.Console.WriteLine("Priority (1=High, 2=Medium, 3=Low): ");
            var priorityInput = context.Input.ReadLine()?.Trim();
            if (int.TryParse(priorityInput, out var priority) && priority is >= 1 and <= 3)
            {
                task.Priority = priority;
            }

            context.Items.Add(task);
            context.Storage.Save(context.Items);

            context.Console.WriteLine("Task added successfully.");
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

### Exact Initialization Sequence

```csharp
// In Program.cs
var services = new ServiceCollection();

// Register all modules
new ActionsModule().Register(services);
new SecurityModule().Register(services);
new InfrastructureModule().Register(services);
new LoggingModule().Register(services);

var serviceProvider = services.BuildServiceProvider();

// Create context
var context = new ActionContext
{
    Console = serviceProvider.GetRequiredService<IConsole>(),
    Input = serviceProvider.GetRequiredService<IInputService>(),
    Storage = serviceProvider.GetRequiredService<IStorageService>()
};

// Load data
context.Items = context.Storage.LoadAll();

// Start main loop
var handlers = serviceProvider.GetRequiredService<IEnumerable<IActionHandler>>();

while (true)
{
    // Build visible menu dynamically
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
