# Fortress

A secure, encrypted personal information manager built as a .NET console application.

**Features:** Tasks • Secure Notes • Credential Vault • Goals • Encrypted Storage

---

## Documentation

**All architecture, coding standards, component structure, and workflows are documented in the `.docs/` folder.**

**Start here:** [.docs/README.md](.docs/README.md)

For AI coding agents, see [AGENTS.md](AGENTS.md).

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

For detailed architecture, coding standards, and workflows, see [.docs/README.md](.docs/README.md).

---

**All data is encrypted at rest.** The master password is never stored.