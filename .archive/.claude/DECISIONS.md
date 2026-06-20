# DECISIONS.md

## Architectural Decision Records (ADRs) for Forge Agent Team & Forge Task Manager

This log records all significant architectural, process, and team decisions. Every agent **must** reference relevant ADRs when making recommendations.

---

### ADR-001: Multi-Agent Team Structure (2026-05-24)

**Status**: Accepted

**Context**: Building a complex task management platform requires specialized expertise across planning, implementation, quality, and review. A single generalist agent leads to diluted focus and lower quality.

**Decision**: Adopt a 5-agent specialized team:
- Orchestrator (coordination & workflow)
- Planner (strategy & breakdown)
- Coder (implementation)
- Tester (verification & quality gates)
- Reviewer (standards enforcement & improvement)

**Rationale**:
- Strict separation of concerns improves output quality
- Clear accountability and feedback loops
- Mirrors real-world high-performing engineering teams
- Enables parallel work where safe (e.g., Planner can work on next epic while Coder finishes current)

**Consequences**:
- Requires strong orchestration and explicit handoff contracts
- Human remains the ultimate approver
- Documentation (this file + CLAUDE.md) becomes critical for consistency

---

### ADR-002: Documentation-First Approach (2026-05-24)

**Status**: Accepted

**Context**: Without a single source of truth, agents drift, repeat work, or make conflicting decisions.

**Decision**: 
- `CLAUDE.md` is the immutable central source of truth
- All agent files live under `.claude/agents/`
- Every decision recorded in DECISIONS.md
- All code changes must reference the relevant ADR or plan

**Rationale**: Traceability, auditability, and reduced hallucination / drift.

---

### ADR-003: Test-Driven Development Mandate (2026-05-24)

**Status**: Accepted

**Context**: Shipping untested code leads to regressions and technical debt. The Reviewer and Tester agents exist to prevent this.

**Decision**: 
- All new features require failing tests *before* implementation code is written
- Minimum 85% coverage (90%+ on new code)
- Tester Agent has veto power on insufficient test coverage

**Rationale**: Matches industry best practices for maintainable systems. Aligns with "Ship it, then iterate" only after quality gates.

---

### ADR-004: Human Override Supremacy (2026-05-24)

**Status**: Accepted

**Context**: AI agents, no matter how capable, can make mistakes or misinterpret intent.

**Decision**: At any point in the workflow, the human can:
- Pause execution
- Override any agent decision
- Force re-planning or re-implementation
- Directly edit code or docs
- Approve/reject without agent consensus

**Rationale**: Maintains human accountability and control. Prevents "AI runaway" scenarios.

---

### ADR-005: Python + FastAPI + React Stack (2026-05-24)

**Status**: Accepted

**Context**: Need modern, productive, type-safe stack for a collaborative web app with real-time potential.

**Decision**: 
- Backend: Python 3.12+ + FastAPI + SQLAlchemy 2.0 + PostgreSQL
- Frontend: React 18 + TypeScript + Vite + Tailwind + TanStack
- Testing: pytest + Playwright
- Tooling: black, ruff, mypy, prettier, eslint (enforced via pre-commit + CI)

**Rationale**: Excellent ecosystem, great developer experience, strong typing, async support, and mature testing tools.

---

*All future decisions must follow this template and be added chronologically. Agents should propose new ADRs via the Orchestrator when significant changes are needed.*