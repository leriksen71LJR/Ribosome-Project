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

### 4. Phase 1.1 Requirements (New)
- At the end of every build, create a structured report in `.docs/Builds/`
- Filename format: `BUILD-YYYY-MM-DD-<Agent>.md`
- Explicitly report any deviations from the documentation
- See `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md` for details

### 5. Documentation
- Treat `.docs/` as **read-only** during implementation
- Note any documentation improvements needed instead of editing files directly

---

## Key Documents

| Document                        | Purpose                              | When to Read |
|--------------------------------|--------------------------------------|--------------|
| `.docs/README.md`              | Main documentation index             | Always start here |
| `.docs/ARCHITECTURE.md`        | System architecture & patterns       | When working on structure |
| `.docs/CODING_STANDARDS.md`    | Coding rules and quality standards   | Before writing code |
| `.docs/CODING_DESIGN.md`       | Detailed implementation guidance     | When implementing features |
| `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md` | Phase 1.1 self-documentation rules | Before finishing any build |
