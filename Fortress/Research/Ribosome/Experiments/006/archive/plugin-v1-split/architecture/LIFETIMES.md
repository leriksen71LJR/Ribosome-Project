# Service Lifetimes

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

**Encryption key:** Lives in `EncryptionService` after unlock until `Clear()` on lock. See `components/Security/STORAGE-BRIDGE.md`.

Registration matrix: `architecture/DI-REGISTRATION.md`.