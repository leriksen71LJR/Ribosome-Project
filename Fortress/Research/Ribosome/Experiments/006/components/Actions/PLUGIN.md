# Actions Component - Build Plugin

**Plugin ID:** `components/Actions`
**Depends on:** Data; Infrastructure; Security; Logging
**ADR refs:** adr/0002; adr/0003
**Status:** Phase 1.2A MVP

---


**Path:** `src/Fortress.Console/Components/Actions/Contracts/`

## IActionHandler

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
    /// Executes the action. Must be async (Phase 1.1+).
    /// </summary>
    Task<bool> ExecuteAsync(ActionContext context, CancellationToken cancellationToken = default);
}
```

**Requirements:**

- `ExecuteAsync` must begin with guard clauses (null `context`, cancellation, session) per `process/AGENTS.md` Rule 3.
- `ExitHandler` may omit session guard on execute when exiting — see `adr/0002-exit-handler-vs-session-guard.md`.
- Visibility rules per handler: `handler inventory (below)` table.

## IItem

Defined in Data component; referenced by Actions for handler item operations. See `Data plugin`.

---


**Path:** `src/Fortress.Console/Components/Actions/Model/`

## ActionContext

Execution context passed to every handler. Carries session state, loaded items, and collected errors.

```csharp
public class ActionContext
{
    public UserSession? Session { get; set; }
    public List<IItem> Items { get; } = new();
    public List<Exception> ExceptionErrors { get; } = new();
}
```

**Distinction:**

- `IItem` = domain entity the user manages
- `ActionContext` = per-iteration execution state for handlers

Handlers receive dependencies via **constructor injection**, not through `ActionContext`.

Item type definitions: `Data plugin`.

---


**Status:** Authoritative — Phase 1.2A MVP  
**Purpose:** Define every `IActionHandler` the initial build must implement. Do not invent additional menu handlers without reporting a gap.

All handlers live in `src/Fortress.Console/Components/Actions/Implementations/`.  
All handlers are registered in `Components/Bootstrapping/Modules/ActionsModule.cs` via `services.AddSingleton<IActionHandler, THandler>()`.

**Contract (all handlers):**

```csharp
string Name { get; }           // Plain label — no menu numbers (bootstrapping assigns numbers)
string Description { get; }
bool IsVisible(ActionContext context);
Task<bool> ExecuteAsync(ActionContext context, CancellationToken cancellationToken = default);
```

Every `ExecuteAsync` **must** begin with guard clauses (`context` null, cancellation, session) per `process/AGENTS.md` Rule 3.

**ExitHandler exception:** `ExitHandler` is always visible and may run when session is locked — see `adr/0002-exit-handler-vs-session-guard.md`.

---

## Required Handlers (11)

| Handler Class | `Name` | `Description` | `IsVisible` Rule |
|---------------|--------|---------------|------------------|
| `AddTaskHandler` | Add Task | Create a new task with title, due date, priority, and optional tags | `context.Session is not null` |
| `AddNoteHandler` | Add Note | Create a new secure note with title and content | `context.Session is not null` |
| `AddCredentialHandler` | Add Credential | Store a new credential (title, username, password, URL, notes) | `context.Session is not null` |
| `AddGoalHandler` | Add Goal | Create a new goal with title, description, and optional target date | `context.Session is not null` |
| `ListItemsHandler` | List Items | Display all items grouped by type (tasks, notes, credentials, goals) | `context.Session is not null` |
| `CompleteTaskHandler` | Complete Task | Mark an incomplete task as completed | `context.Session is not null` **and** `context.Items.OfType<TaskItem>().Any(t => !t.IsCompleted)` |
| `ArchiveCompletedHandler` | Archive Completed Tasks | Remove completed tasks from active storage (hard delete per `adr/0003-archive-semantics-mvp.md`) | `context.Session is not null` **and** `context.Items.OfType<TaskItem>().Any(t => t.IsCompleted)` |
| `SearchItemsHandler` | Search Items | Search across all item types by title (and note content where applicable) | `context.Session is not null` |
| `ExportBackupHandler` | Export Backup | Export an encrypted backup of the database | `context.Session is not null` |
| `LockSessionHandler` | Lock Session | Lock the vault and clear sensitive session state | `context.Session is not null` |
| `ExitHandler` | Exit | Exit the application | Always `true` |

---

## Handler Dependencies (typical constructor injection)

| Handler | Required Services |
|---------|-------------------|
| `AddTaskHandler` | `IConsole`, `IInputService`, `IStorageService` |
| `AddNoteHandler` | `IConsole`, `IInputService`, `IStorageService` |
| `AddCredentialHandler` | `IConsole`, `IInputService`, `IStorageService` |
| `AddGoalHandler` | `IConsole`, `IInputService`, `IStorageService` |
| `ListItemsHandler` | `IConsole`, `IStorageService` |
| `CompleteTaskHandler` | `IConsole`, `IInputService`, `IStorageService` |
| `ArchiveCompletedHandler` | `IConsole`, `IInputService`, `IStorageService` |
| `SearchItemsHandler` | `IConsole`, `IInputService`, `IStorageService` |
| `ExportBackupHandler` | `IConsole`, `IInputService`, `IStorageService`, `IConfigurationService` |
| `LockSessionHandler` | `IConsole`, `ISessionService`, `IStorageService` |
| `ExitHandler` | `IConsole` |

Optional: inject `ILoggingService` where logging adds value.

---

## ActionsModule Registration (complete list)

```csharp
public class ActionsModule : IDependencyModule
{
    public void Register(IServiceCollection services)
    {
        services.AddSingleton<IActionHandler, AddTaskHandler>();
        services.AddSingleton<IActionHandler, AddNoteHandler>();
        services.AddSingleton<IActionHandler, AddCredentialHandler>();
        services.AddSingleton<IActionHandler, AddGoalHandler>();
        services.AddSingleton<IActionHandler, ListItemsHandler>();
        services.AddSingleton<IActionHandler, CompleteTaskHandler>();
        services.AddSingleton<IActionHandler, ArchiveCompletedHandler>();
        services.AddSingleton<IActionHandler, SearchItemsHandler>();
        services.AddSingleton<IActionHandler, ExportBackupHandler>();
        services.AddSingleton<IActionHandler, LockSessionHandler>();
        services.AddSingleton<IActionHandler, ExitHandler>();
    }
}
```

---

## Menu Numbering (bootstrapping responsibility)

1. Resolve `IEnumerable<IActionHandler>` from DI.
2. Filter to handlers where `IsVisible(context)` is `true`.
3. Assign menu numbers **at display time** (1, 2, 3, …) — never hardcode numbers in handler `Name` properties.
4. On selection, call `await handler.ExecuteAsync(context, cancellationToken)`.

---

## MVP Coverage Mapping

| MVP Feature | Handlers |
|-------------|----------|
| Task management | `AddTaskHandler`, `CompleteTaskHandler`, `ArchiveCompletedHandler` |
| Secure notes | `AddNoteHandler` |
| Credential vault | `AddCredentialHandler` |
| Goal tracking | `AddGoalHandler` |
| Unified search | `SearchItemsHandler` |
| View all data | `ListItemsHandler` |
| Export & backup | `ExportBackupHandler` |
| Session security | `LockSessionHandler` |
| Application exit | `ExitHandler` |

---

## Out of Scope (Phase 1.2A)

- Edit/delete handlers for individual notes, credentials, or goals
- Import backup handler
- Web, cloud sync, or collaboration features
- Separate per-type list handlers

Report missing handlers under **Gaps** in the build report — do not silently add handlers.

**Last Updated:** 2026-06-21 (Experiment 06 — archive row patched per adr/0003)

---
