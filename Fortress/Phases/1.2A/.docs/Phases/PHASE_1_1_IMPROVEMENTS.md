# PHASE_1_1_IMPROVEMENTS.md

**Status:** Active — mandatory for all Phase 1.2A builds  
**Authority:** This document takes precedence over earlier patterns (including ADR-001 `Execute` returning `bool`) where they conflict.

---

## Purpose

Phase 1.1 introduces lightweight, high-value process requirements based on Phase 1 shootout findings. The goal is better agent discipline, transparent self-documentation, and explicit deviation reporting — without major architectural change.

---

## Mandatory Requirements

Every agent build **must** comply with all of the following.

### 1. Async Handlers (Non-Negotiable)

All `IActionHandler` implementations **must** use:

```csharp
Task<bool> ExecuteAsync(ActionContext context, CancellationToken cancellationToken = default);
```

- Every `ExecuteAsync` **must** begin with guard clauses (`AGENTS.md` Rule 3).
- Synchronous `Execute` is a **process violation** — report it if unavoidable.
- See `CODING_DESIGN.md` and `.docs/HANDLER_INVENTORY.md` for the canonical contract.

### 2. Mandatory Build Report

At the end of every build, produce **one combined report** in `.docs/Builds/`.

**Full specification:** [BuildDisclosure.md](../../BuildDisclosure.md) — naming, all build-report sections, Build Disclosure sections, Deep Documentation Audit template, and completion checklist.

Summary: `BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md` with build-record sections (what happened) plus Build Disclosure sections (how documentation performed). See **Report Naming** below and section 3 for deviation rules.

### 3. Explicit Deviation Reporting (Mandatory)

If you cannot follow any rule in `AGENTS.md`, `.docs/`, or the active build prompt, you **must** document it under **Deviations from Documentation**.

**Report every deviation including:**

- Component Pattern violations (wrong folder layout, missing `Contracts/` / `Implementations/` / `Model/`)
- Services registered outside `IDependencyModule`
- Implementation Order violations
- Missing or non-async `ExecuteAsync` on handlers
- Weak or missing guard clauses
- Substituting plain SQLite for SQLCipher, or PBKDF2 for Argon2id
- Silent assumptions on high-risk gaps (violates `AGENTS.md` Rule 11)
- Writing files outside the project root or outside allowed `.docs/Builds/`

**For each deviation, state:**

| Field | Required |
|-------|----------|
| Rule not followed | Quote or reference the specific rule |
| What was done instead | Concrete description |
| Why | Intentional, ambiguity, tooling limitation, or time constraint |
| Impact | Effect on correctness, security, or maintainability |

**Example:**

> **Deviations from Documentation**
> - Used synchronous `IStorageService.Save()` instead of `SaveAsync()`.
>   - Reason: Interface was implemented before async contract was finalized.
>   - Impact: Low for MVP console app; violates async convention; should be fixed in next pass.

**Do not** silently work around documented rules.

### 4. Conflict and Gap Visibility

Apply `AGENTS.md` Rules 10 and 11 in the build report:

- **Rule 10:** List any document contradictions encountered and which document you followed.
- **Rule 11:** List assumptions made due to missing or ambiguous documentation, with severity (High / Medium / Low).

### 5. Post-Build Build Disclosure (Mandatory — Final Step)

Per `AGENTS.md` Rule 12, Build Disclosure sections are **required in the same file** as the build report. Full section list and template: [BuildDisclosure.md](../../BuildDisclosure.md).

**Optional:** [AgentGamification.md](../../AgentGamification.md) — shared craft layer (Pride Points, Cartographer framing). Does not alter mandatory sections.

---

## Report Naming

See [BuildDisclosure.md](../../BuildDisclosure.md) → **Report Naming**. Pattern: `BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md` in `.docs/Builds/`.

---

## Handler and Security Compliance (Phase 1.2A)

- Implement **all 11 handlers** in `.docs/HANDLER_INVENTORY.md` — do not invent or omit handlers silently.
- Follow **Implementation Specification** in `ARCHITECTURE_SECURITY.md` for SQLCipher + Argon2id.
- Full interface contracts are in `CODING_DESIGN.md`.

---

## Out of Scope for Phase 1.1 / 1.2A

Deferred unless explicitly instructed:

- Planning/sprint folder structures
- New agent roles or orchestration changes
- Major Component Pattern or `IDependencyModule` redesign
- Formal deviation log system beyond build reports
- Web, cloud sync, or collaboration features

---

## Agent Checklist (End of Build)

Before considering the build complete:

- [ ] All handlers use `ExecuteAsync` with guard clauses
- [ ] All handlers from `HANDLER_INVENTORY.md` implemented or explicitly deferred with justification
- [ ] Combined report complete per `BuildDisclosure.md` (all sections, one file)
- [ ] High-severity assumptions flagged per Rule 11
- [ ] Unit tests exist for components built (per `AGENTS.md` Rule 4)

---

## Success Criteria

Phase 1.1/1.2A process compliance is achieved when:

- Build report exists with all required sections
- Deviations are explicit — not hidden in code or chat
- `ExecuteAsync` and guard clauses are used on all handlers
- Core rules (Component Pattern, `IDependencyModule`, Implementation Order) are followed or explicitly deviated with justification
- Combined build report (Part 1 + Part 2 Build Disclosure) exists and is ready for steward handoff

---

**Last Updated:** 2026-06-21 (build report spec consolidated in `BuildDisclosure.md`)