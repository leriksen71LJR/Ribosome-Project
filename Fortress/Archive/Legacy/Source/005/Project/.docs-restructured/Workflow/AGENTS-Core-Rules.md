# AGENTS-Core-Rules.md

**Purpose:** Core behavioral rules and authority hierarchy for agents working in the Fortress project.

This file contains only the fundamental, non-negotiable rules that govern agent behavior. Process-specific strategies and detailed implementation guidance have been moved to separate strategy files.

## Core Principles

- Documentation in `.docs/` is the single source of truth.
- Implementation must follow strict bottom-up dependency order.
- All components must follow the Component Pattern (Contracts → Implementations → Model).
- Every handler `ExecuteAsync()` must begin with guard clauses.
- Deviations and high-severity assumptions must be explicitly reported.

## Authority Hierarchy

`AGENTS.md` (this core rules file) is the highest authority. When conflicts arise between documents, follow the authority hierarchy defined here.

## Implementation Order (Mandatory)

All work must follow this order:

1. Contracts
2. Models
3. Infrastructure services
4. Security & Session
5. Actions (handlers)
6. Bootstrapping
7. Tests

## Key Constraints

- Do not read or reference anything under `Research/`.
- Do not write files outside the assigned project root.
- Post-build Build Disclosure is mandatory (see `Workflow/Disclosure-Strategies/`).

---

*Process-specific strategies and detailed guidance have been extracted into separate files under `Workflow/Process-Strategies/` and other areas.*