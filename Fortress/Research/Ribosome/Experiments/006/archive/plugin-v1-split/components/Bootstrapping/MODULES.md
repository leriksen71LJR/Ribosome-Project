# Bootstrapping — DI Modules

**Path:** `src/Fortress.Console/Components/Bootstrapping/Modules/`

Module classes are an **approved exception** to the three-folder component pattern (`adr/0001-modules-folder-exception.md`).

---

## Module classes (Phase 1.2A)

| Module | Registers |
|--------|-----------|
| `ActionsModule` | All 11 `IActionHandler` implementations |
| `SecurityModule` | `IEncryptionService`, `ISessionService`, `IKeyDerivationService` |
| `InfrastructureModule` | `IStorageService`, `IConsole`, `IInputService`, `IConfigurationService` |
| `LoggingModule` | `ILoggingService` |

Handler registration source: `components/Actions/HANDLER-INVENTORY.md` → ActionsModule block.

Full matrix: `architecture/DI-REGISTRATION.md`.

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

Implementations (runner, menu loop): `BOOTSTRAPPER.md`, `architecture/COMPOSITION-ROOT.md`.