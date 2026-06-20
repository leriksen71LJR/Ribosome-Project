# AGENTS.md — Fortress

**This project follows a strict documentation-first approach.**

`.docs/` is the **single source of truth**.

**Start here:** [.docs/README.md](.docs/README.md)

## Critical Rules (Must Follow)

### Phase 1.1 Requirements (New)
See `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md` for the current mandatory rules, including:
- Self-documentation requirement (build reports)
- Explicit deviation reporting
- Use of `ExecuteAsync`

### Implementation Order (Non-Negotiable)
Always build bottom-up:
1. Contracts
2. Models
3. Infrastructure
4. Security & Session
5. Actions (handlers)
6. Bootstrapping
7. Tests

### Component Pattern
- All components must live under `src/Fortress.Console/Components/`
- Every component follows: `Contracts/` → `Implementations/` → `Model/`
- All dependency registration must go through `IDependencyModule` classes

### Coding Standards
- Keep classes and methods small and focused
- Use early returns aggressively
- Every handler `ExecuteAsync()` must begin with guard clauses

