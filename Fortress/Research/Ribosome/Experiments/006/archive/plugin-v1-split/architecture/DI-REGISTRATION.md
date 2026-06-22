# DI Registration Matrix

All registration goes through `IDependencyModule` in `Components/Bootstrapping/Modules/`. See `adr/0001-modules-folder-exception.md`.

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

Handler list and `ActionsModule` source: `components/Actions/HANDLER-INVENTORY.md`.