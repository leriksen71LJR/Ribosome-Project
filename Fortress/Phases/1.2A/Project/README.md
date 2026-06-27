# Fortress

A secure, encrypted personal information manager built as a .NET console application.

**Features:** Tasks • Secure Notes • Credential Vault • Goals • Encrypted Storage

---

## Documentation

**All architecture, coding standards, component structure, and workflows are documented in the `.docs/` folder.**

**Start here for AI agents:** [AGENTS.md](AGENTS.md)  
For architecture and component design, see the `.docs/` folder.

**Phase index (Director / steward):** [PHASES.md](PHASES.md) — which agent packages exist under `Fortress/Project/`.

---

## Technology Stack

- .NET 8 (C#)
- Microsoft Dependency Injection + `IDependencyModule`
- SQLCipher + Argon2id for encrypted storage
- xUnit + Moq for testing
- Component-based architecture with strict patterns

---

## Getting Started

1. Read the documentation in `.docs/`
2. Follow the defined **Implementation Order** when adding features or refactoring
3. All components live under `src/Fortress.Console/Components/`

For detailed architecture, coding standards, and workflows, see the `.docs/` folder (start with `ARCHITECTURE.md` and `CODING_STANDARDS.md`).

---

**All data is encrypted at rest.** The master password is never stored.