# AGENTS.md — Fortress

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

### 3. Coding Standards
- Keep classes and methods **small and focused**
- Use **early returns** aggressively to minimize nesting
- One primary coordinator method per class (e.g. `Execute()`)
- Every handler `Execute()` must begin with guard clauses

### 4. Unit Testing
- Full unit test coverage is required for all components
- Tests live in `tests/Fortress.Console.Tests/`
- Use **xUnit + Moq**
- Follow the same Implementation Order when writing tests

### 5. Phase 1.1 Requirements (Mandatory from Round 2)
All agents must follow the rules defined in:
- [.docs/Phases/PHASE_1_1_IMPROVEMENTS.md](.docs/Phases/PHASE_1_1_IMPROVEMENTS.md)

Key new requirements:
- Produce a build report in `.docs/Builds/` at the end of every build
- Explicitly document any deviations from the documented rules
- Use `ExecuteAsync` (not `Execute`) for `IActionHandler`

### 6. Documentation
- Treat `.docs/` as **read-only** during implementation
- Note any documentation improvements needed instead of editing files directly
- When in doubt, re-read `.docs/ARCHITECTURE.md`, `.docs/CODING_STANDARDS.md`, and `.docs/CODING_DESIGN.md`

---

## How to Work

1. Read the relevant documentation in `.docs/` first (including `PHASE_1_1_IMPROVEMENTS.md`).
2. Create a plan that respects the **Implementation Order**.
3. Implement bottom-up.
4. Write or update unit tests as part of the work.
5. Verify compliance with `.docs/CODING_STANDARDS.md`.
6. Produce a build report in `.docs/Builds/` when finished.

---

## Key Documents

| Document                              | Purpose                                      | When to Read |
|---------------------------------------|----------------------------------------------|--------------|
| `.docs/README.md`                     | Main documentation index                     | Always start here |
| `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md` | Phase 1.1 rules (self-documentation + deviation reporting) | Before every build (Round 2+) |
| `.docs/ARCHITECTURE.md`               | System architecture & patterns               | When working on structure |
| `.docs/CODING_STANDARDS.md`           | Coding rules and quality standards           | Before writing code |
| `.docs/CODING_DESIGN.md`              | Detailed implementation guidance             | When implementing features |
| `.docs/CODING_WORKFLOWS.md`           | How to add features and refactor             | When planning work |