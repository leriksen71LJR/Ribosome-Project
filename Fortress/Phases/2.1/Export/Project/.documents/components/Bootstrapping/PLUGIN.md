# Bootstrapping Component - Build Plugin

**Plugin ID:** `components/Bootstrapping`
**Depends on:** all other plugins
**Tension refs:** [0001](../../tensions/0001-modules-folder-exception.md), [0002](../../tensions/0002-exit-handler-vs-session-guard.md)
**Status:** Phase 2.1 MVP

---


**Path:** `src/Fortress.Console/Components/Bootstrapping/Modules/`

Module classes are an **approved exception** to the three-folder component pattern (`../../tensions/0001-modules-folder-exception.md`).

---

## Module classes (Phase 1.2A)

| Module | Registers |
|--------|-----------|
| `ActionsModule` | All 11 `IActionHandler` implementations |
| `SecurityModule` | `IEncryptionService`, `ISessionService`, `IKeyDerivationService` |
| `InfrastructureModule` | `IStorageService`, `IConsole`, `IInputService`, `IConfigurationService` |
| `LoggingModule` | `ILoggingService` |

Handler registration source: `components/Actions/handler inventory (below)` → ActionsModule block.

Full matrix: `DI registration (below)`.

---

## IDependencyModule

```csharp
public interface IDependencyModule
{
    void Register(IServiceCollection services);
}
```

---

## Discovery

`Program.cs` or `Bootstrapper` instantiates modules and calls `Register` — no handler/service registration in `Program.cs` directly.

Implementations (runner, menu loop): **Bootstrapper responsibilities** and **Main loop** sections below.

---


**Path:** `src/Fortress.Console/Components/Bootstrapping/Implementations/`

## Responsibilities

1. Register modules (or receive built `IServiceProvider`)
2. Initialize Log4Net
3. Master password prompt / first-time setup
4. Build initial `ActionContext` (session + loaded items)
5. Run main menu loop — see `composition root (below)`

## Main loop ownership

Bootstrapping owns:

- Resolving `IEnumerable<IActionHandler>`
- Filtering by `IsVisible`
- Assigning ephemeral menu numbers
- Dispatching `ExecuteAsync`

Handlers own visibility predicates and business logic only.

---


All registration goes through `IDependencyModule` in `Components/Bootstrapping/Modules/`. See `../../tensions/0001-modules-folder-exception.md`.

```csharp
public interface IDependencyModule
{
    void Register(IServiceCollection services);
}
```

---

## Master registration table (Phase 1.2A)

| Interface | Implementation | Lifetime | Module |
|-----------|----------------|----------|--------|
| `IActionHandler` | `AddTaskHandler` | Singleton | `ActionsModule` |
| `IActionHandler` | `AddNoteHandler` | Singleton | `ActionsModule` |
| `IActionHandler` | `AddCredentialHandler` | Singleton | `ActionsModule` |
| `IActionHandler` | `AddGoalHandler` | Singleton | `ActionsModule` |
| `IActionHandler` | `ListItemsHandler` | Singleton | `ActionsModule` |
| `IActionHandler` | `CompleteTaskHandler` | Singleton | `ActionsModule` |
| `IActionHandler` | `ArchiveCompletedHandler` | Singleton | `ActionsModule` |
| `IActionHandler` | `SearchItemsHandler` | Singleton | `ActionsModule` |
| `IActionHandler` | `ExportBackupHandler` | Singleton | `ActionsModule` |
| `IActionHandler` | `LockSessionHandler` | Singleton | `ActionsModule` |
| `IActionHandler` | `ExitHandler` | Singleton | `ActionsModule` |
| `IEncryptionService` | `EncryptionService` | Singleton | `SecurityModule` |
| `ISessionService` | `SessionManager` | Singleton | `SecurityModule` |
| `IKeyDerivationService` | `Argon2KeyDerivationService` | Singleton | `SecurityModule` |
| `IStorageService` | `SqliteStorageService` | Singleton | `InfrastructureModule` |
| `IConsole` | `SystemConsole` | Singleton | `InfrastructureModule` |
| `IInputService` | `ConsoleInputService` | Singleton | `InfrastructureModule` |
| `IConfigurationService` | `ConfigurationService` | Singleton | `InfrastructureModule` |
| `ILoggingService` | `Log4NetLoggingService` | Singleton | `LoggingModule` |

---

## Module invocation order (recommended)

```csharp
var modules = new IDependencyModule[]
{
    new LoggingModule(),
    new InfrastructureModule(),
    new SecurityModule(),
    new ActionsModule(),
};

foreach (var module in modules)
    module.Register(services);
```

Infrastructure before Security if `SqliteStorageService` constructor injects `IEncryptionService`.

---

## Resolution patterns

```csharp
// All handlers (Strategy by List<T>)
var handlers = serviceProvider.GetRequiredService<IEnumerable<IActionHandler>>();

// Single service
var storage = serviceProvider.GetRequiredService<IStorageService>();
```

**Forbidden:** `new` for injectable services inside handlers; registration in `Program.cs` body.

Handler list and `ActionsModule` source: `components/Actions/handler inventory (below)`.

---


`Program.cs` is the **only** composition root. It may discover and invoke `IDependencyModule` implementations — **no direct service registration** in `Program.cs`.

---

## Startup sequence

```csharp
// 1. SQLCipher native init — before any SqliteConnection
SQLitePCL.Batteries_V2.Init();

// 2. Build DI container via modules
var services = new ServiceCollection();
foreach (var module in modules)
    module.Register(services);

var serviceProvider = services.BuildServiceProvider();

// 3. Resolve bootstrapper / run main loop
var bootstrapper = serviceProvider.GetRequiredService<Bootstrapper>();
await bootstrapper.RunAsync(cancellationToken);
```

Module list and order: see **Module classes** section above in this plugin.

---

## Bootstrapper responsibilities

1. Initialize logging (Log4Net)
2. Prompt master password / first-time setup (see `Security plugin`)
3. Unlock session via `ISessionService`
4. Load items via `IStorageService.LoadAsync` (key applied per connection)
5. Create `ActionContext` with session + items
6. Run persistent menu loop

---

## Main loop pseudocode

```csharp
while (!cancellationToken.IsCancellationRequested)
{
    var handlers = serviceProvider.GetRequiredService<IEnumerable<IActionHandler>>();
    var visible = handlers.Where(h => h.IsVisible(context)).ToList();

    // Assign menu numbers 1..N at display time — never in handler Name
    for (var i = 0; i < visible.Count; i++)
        console.WriteLine($"{i + 1}. {visible[i].Name}");

    var selection = input.ReadLine();
    if (!int.TryParse(selection, out var index) || index < 1 || index > visible.Count)
        continue;

    var handler = visible[index - 1];
    await handler.ExecuteAsync(context, cancellationToken);

    // Display context.ExceptionErrors, refresh items if needed
}
```

**ExitHandler:** Always visible (`../../tensions/0002-exit-handler-vs-session-guard.md`). May run when session is locked.

**Menu numbering:** `components/Actions/handler inventory (below)` → Menu Numbering section.

---


Fortress Phase 1.2A uses **singleton** registration for all application services and handlers.

| Registration | Lifetime | Rationale |
|--------------|----------|-----------|
| `IActionHandler` (each handler) | Singleton | Resolved as `IEnumerable<IActionHandler>`; stateless handlers |
| `IEncryptionService`, `ISessionService` | Singleton | Holds in-memory key for session; one vault per process |
| `IStorageService`, `IConsole`, `IInputService`, `IConfigurationService` | Singleton | Shared infrastructure |
| `ILoggingService` | Singleton | Log4Net appender lifecycle |
| `IKeyDerivationService` | Singleton | Stateless crypto helper |

**Session scope:** `UserSession` lives in `ActionContext` / `ISessionService` — not a separate DI scope in MVP.

**Handlers:** Must not store mutable session state in fields; use `ActionContext` per loop iteration.

**Encryption key:** Lives in `EncryptionService` after unlock until `Clear()` on lock. See `components/Security/Storage bridge (below)`.

Registration matrix: `DI registration (below)`.

---
