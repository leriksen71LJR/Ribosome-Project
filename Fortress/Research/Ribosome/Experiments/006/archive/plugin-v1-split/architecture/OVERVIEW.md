# System Overview

**Fortress** is a secure, console-based personal command center. Architecture is **component-based** with **Microsoft Dependency Injection** and **Strategy by List<T>** for user interactions.

**Guiding principle:** Outside `Program.cs`, **if it's code, it's a Component**.

Each component uses:

- **Contracts/** — interfaces
- **Implementations/** — injectable stateless services and handlers
- **Model/** — pure data (not injectable)

All components live under `src/Fortress.Console/Components/`. `Program.cs` is the only code file outside `Components/`.

---

## Components (doc mirror)

| Component | Doc path |
|-----------|----------|
| Actions | `components/Actions/` |
| Data | `components/Data/` |
| Security | `components/Security/` |
| Infrastructure | `components/Infrastructure/` |
| Logging | `components/Logging/` |
| Bootstrapping | `components/Bootstrapping/` |

Process rules: `process/AGENTS.md`. Seam decisions: `adr/REGISTRY.md`.

---

## Architectural style

1. **Strategy by List<T>** via `IEnumerable<IActionHandler>` — mandatory for menu actions.
2. **IDependencyModule** — each component registers its own services; `Program.cs` discovers modules only.
3. **Dynamic menu** — handlers implement `IsVisible`; bootstrapping assigns numbers at display time.

---

## Technology stack

| Area | Technology |
|------|------------|
| Language | C# (.NET 8+) |
| DI | Microsoft.Extensions.DependencyInjection |
| Storage | SQLCipher (encrypted SQLite) |
| Encryption | AES-256-GCM via SQLCipher |
| KDF | Argon2id |
| Logging | Log4Net |
| Tests | xUnit + Moq |

---

## Main loop (summary)

1. Bootstrap DI and unlock vault
2. Build `ActionContext` with session + loaded items
3. Filter handlers by `IsVisible(context)`
4. Display numbered menu
5. Execute selected `ExecuteAsync`
6. Show errors from `ActionContext`; loop

Detail: `architecture/COMPOSITION-ROOT.md`, `components/Actions/HANDLER-INVENTORY.md`.