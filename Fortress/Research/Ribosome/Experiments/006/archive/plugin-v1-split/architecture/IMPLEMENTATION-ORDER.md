# Implementation Order (Mandatory)

All implementation work follows strict **bottom-up** dependency order. Never implement a layer before its dependencies exist.

| Order | Layer | What to build | Examples |
|-------|-------|---------------|----------|
| 1 | Contracts | Interfaces only | `IItem`, `IActionHandler`, `IStorageService`, `ISessionService` |
| 2 | Pure models | Records and data classes | `TaskItem`, `ActionContext`, `UserSession` |
| 3 | Infrastructure | External-facing services | `SqliteStorageService`, `SystemConsole`, `ConsoleInputService` |
| 4 | Security & session | Encryption and session | `EncryptionService`, `SessionManager`, `Argon2KeyDerivationService` |
| 5 | Domain services | Shared business logic | (Future) archival services |
| 6 | Action handlers | All `IActionHandler` impls | See `components/Actions/HANDLER-INVENTORY.md` |
| 7 | Bootstrapping | Modules + composition | `*Module.cs`, `Bootstrapper`, `Program.cs` |
| 8 | Tests | Unit tests | Mirror `tests/.../Components/` structure |

**Rules:**

- Never implement handlers before required services and contracts exist.
- Never implement services before contracts and models exist.
- When adding features, verify the dependency chain before coding.

Authority: `process/AGENTS.md` Rule 1.