# AGENTS.md — Fortress (Phase 1.1)

**This project follows a strict documentation-first approach.**

`.docs/` is the **single source of truth** for architecture, coding standards, component structure, and workflows.

**Start here:** [.docs/README.md](.docs/README.md)

---

## Critical Rules (Must Follow)

### 1. Implementation Order (Non-Negotiable)
Always build and refactor in this strict bottom-up order:

1. Contracts (interfaces)
2. Models
3. Infrastructure services
4. Security & Session services
5. Actions (handlers)
6. Bootstrapping
7. Tests

Never implement higher-level components before their dependencies exist.

### 2. Component Pattern
- All components must live under `src/Fortress.Console/Components/`
- Every component follows: `Contracts/` → `Implementations/` → `Model/`
- All dependency registration must go through `IDependencyModule` classes

### 3. Phase 1.1 Requirements (New)
See [.docs/Phases/PHASE_1_1_IMPROVEMENTS.md](.docs/Phases/PHASE_1_1_IMPROVEMENTS.md)

Key new mandatory behaviors:
- Produce a build report in `.docs/Builds/` at the end of every build
- Explicitly document any deviations from the documented rules
- Use `ExecuteAsync` on `IActionHandler` (synchronous `Execute` is now a deviation)

### 4. Coding Standards
- Keep classes and methods **small and focused**
- Use **early returns** aggressively to minimize nesting
- Every handler `ExecuteAsync()` must begin with guard clauses

### 5. Unit Testing
- Full unit test coverage is required for all components
- Tests live in `tests/Fortress.Console.Tests/`
- Use **xUnit + Moq**
- Follow the same Implementation Order when writing tests

---

## How to Work

1. Read the relevant documentation in `.docs/` first (especially `ARCHITECTURE.md`, `CODING_STANDARDS.md`, and `PHASE_1_1_IMPROVEMENTS.md`).
2. Create a plan that respects the **Implementation Order**.
3. Implement bottom-up.
4. At the end of the build, create the required build report in `.docs/Builds/`.
5. Explicitly call out any deviations from the documented rules.

---

## Key Documents

| Document                                      | Purpose                                      | When to Read |
|-----------------------------------------------|----------------------------------------------|--------------|
| `.docs/README.md`                             | Main documentation index                     | Always start here |
| `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md`      | Phase 1.1 rules (self-documentation + deviation reporting) | Before every build |
| `.docs/ARCHITECTURE.md`                       | System architecture & patterns               | When working on structure |
| `.docs/CODING_STANDARDS.md`                   | Coding rules and quality standards           | Before writing code |
| `.docs/CODING_DESIGN.md`                      | Detailed implementation guidance             | When implementing features |