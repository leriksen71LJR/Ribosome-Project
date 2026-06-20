# Fortress — Documentation Pointer

**This project follows a strict documentation-first approach.**

All architecture, coding standards, workflows, decisions, and agent instructions live in the `.docs/` folder.

**Primary Entry Point:** [.docs/README.md](../.docs/README.md)

---

This file exists for compatibility with AI coding tools. The real source of truth is `.docs/`.

## Critical Rules (Must Follow)

- **Documentation First**: Always read and follow `.docs/` before making changes. Never assume or invent rules.
- **Implementation Order**: Strictly follow bottom-up dependency order (Contracts → Models → Infrastructure → Handlers → Bootstrapping → Tests). See `ARCHITECTURE.md`.
- **Component Pattern**: All code lives under `src/Fortress.Console/Components/` using Contracts / Implementations / Model structure.
- **Granular Code**: Keep classes and methods small and focused. Use coordinator methods. Minimize public surface.
- **Defensive Programming**: Every `Execute()` method must use guard clauses + early returns + `ActionContext` for errors.
- **Unit Testing**: All components must have unit tests (xUnit + Moq). Write meaningful tests, not just coverage.
- **No Manual Refactoring**: If issues are found, improve the documentation in `.docs/` first, then regenerate.

**When in doubt, read `.docs/README.md` and `ARCHITECTURE.md`.**

*Last updated: June 2026*