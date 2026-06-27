# HANDLER_INVENTORY.md

**Status:** Authoritative — Phase 1.2A MVP  
**Purpose:** Define every `IActionHandler` the initial build must implement. Agents must not invent additional menu handlers without reporting a gap.

All handlers live in `src/Fortress.Console/Components/Actions/Implementations/`.  
All handlers are registered in `Components/Bootstrapping/Modules/ActionsModule.cs` via `services.AddSingleton<IActionHandler, THandler>()`.

**Contract (all handlers):**

```csharp
string Name { get; }           // Plain label — no menu numbers (bootstrapping assigns numbers)
string Description { get; }
bool IsVisible(ActionContext context);
Task<bool> ExecuteAsync(ActionContext context, CancellationToken cancellationToken = default);
```

Every `ExecuteAsync` **must** begin with guard clauses (`context` null, cancellation, session) per `AGENTS.md` Rule 3.

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
| `ArchiveCompletedHandler` | Archive Completed Tasks | Remove completed tasks from the active list (archive/delete per storage design) | `context.Session is not null` **and** `context.Items.OfType<TaskItem>().Any(t => t.IsCompleted)` |
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

Optional: inject `ILoggingService` in any handler where logging adds value. Not required for MVP compliance.

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

| MVP Feature (see product scope) | Handlers |
|---------------------------------|----------|
| Task management | `AddTaskHandler`, `CompleteTaskHandler`, `ArchiveCompletedHandler` |
| Secure notes | `AddNoteHandler` |
| Credential vault | `AddCredentialHandler` |
| Goal tracking | `AddGoalHandler` |
| Unified search | `SearchItemsHandler` |
| View all data | `ListItemsHandler` |
| Export & backup | `ExportBackupHandler` |
| Session security | `LockSessionHandler` |
| Application exit | `ExitHandler` |

**Tagging & filtering:** Tags are captured on `TaskItem` at creation (`AddTaskHandler`). Dedicated tag-filter UI is **out of scope** for Phase 1.2A; use `SearchItemsHandler` for text search. Report as a documented gap if tag filtering is required in this build.

---

## Out of Scope for Phase 1.2A (do not implement unless instructed)

- Edit/delete handlers for individual notes, credentials, or goals
- Import backup handler
- Web, cloud sync, or collaboration features
- Separate per-type list handlers (use `ListItemsHandler` instead)

If an agent believes a missing handler is required, report it under **Gaps** in the build report — do not silently add handlers.

---

**Last Updated:** 2026-06-20