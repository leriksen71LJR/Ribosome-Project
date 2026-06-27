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

At the end of every build, produce a structured report in `.docs/Builds/`.

| Rule | Detail |
|------|--------|
| **Location** | `.docs/Builds/` only (the sole `.docs/` write exception — `AGENTS.md` Rule 5) |
| **Filename** | `BUILD-REPORT-YYYY-MM-DD-XXX.md` — see **Report Naming** below |
| **Header** | Include agent name, date, and build status (success / partial / blocked) |

**Minimum sections (use these exact headings):**

1. **Summary of Work Completed**
2. **Files Created / Modified**
3. **Key Implementation Decisions** (grouped by topic: Architecture, Handlers, Security, Storage, DI, Tests)
4. **Deviations from Documentation** (see section 3 below — use `None` if applicable)
5. **Deep Documentation Audit** (format per `Evaluation/EvaluationCriteria.md`)
6. **Open Gaps and Assumptions**
7. **Recommended Next Steps**

Reports must use grouped sections — not one flat unstructured list.

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

Per `AGENTS.md` Rule 12, every build **must** end with a Build Disclosure **after** the build report.

| Rule | Detail |
|------|--------|
| **Instructions** | `BuildDisclosure.md` (project root) |
| **Output** | `REASONING-YYYY-MM-DD-XXX-{Agent}.md` in the project root — same `XXX` as the paired build report; `{Agent}` = your agent identifier |
| **Timing** | Last artifact — never before code or build report |
| **Handoff** | Returned to project stewards for documentation analysis |

The build report records **what happened**. The Build Disclosure records **how the documentation performed** during the build. Both are required.

**Optional:** `AgentGamification.md` — shared craft layer for build and disclosure (Pride Points, Cartographer framing). Does not alter mandatory sections.

---

## Report Naming (Build Report + Reasoning)

Both artifacts use **`YYYY-MM-DD-XXX`** where `XXX` is a **3-digit sequence** (`001`, `002`, `003`, …).

| Artifact | Location | Pattern |
|----------|----------|---------|
| Build report | `.docs/Builds/` | `BUILD-REPORT-YYYY-MM-DD-XXX.md` |
| Build Disclosure | project root | `REASONING-YYYY-MM-DD-XXX-{Agent}.md` |

**Agent identifier (`{Agent}`):**

- Short slug with **no spaces** — e.g. `GrokBuild`, `Claude`, `Codex`, `Composer`
- Use the name you identify as in the build report header
- Same agent on a re-run the same day uses a **new** `XXX`, not a new agent suffix on the same sequence

**Sequence rules:**

1. Use today's date in `YYYY-MM-DD`.
2. Scan existing files with the same prefix and date (e.g. `BUILD-REPORT-2026-06-20-*.md`, `REASONING-2026-06-20-*.md`).
3. Set `XXX` to the **next unused** 3-digit sequence for that date.
4. **Same build run:** the build report and reasoning file **must share the same** `YYYY-MM-DD-XXX`.
5. Do **not** overwrite an existing sequence unless explicitly instructed — create the next sequence instead.

**Examples:**
- `BUILD-REPORT-2026-06-20-001.md` + `REASONING-2026-06-20-001-GrokBuild.md`
- Second run same day → `...-002-Claude.md` (paired with `BUILD-REPORT-2026-06-20-002.md`)

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
- [ ] `BUILD-REPORT-YYYY-MM-DD-XXX.md` written to `.docs/Builds/`
- [ ] **Deviations from Documentation** section is present (even if `None`)
- [ ] **Deep Documentation Audit** section is present per `Evaluation/EvaluationCriteria.md`
- [ ] High-severity assumptions flagged per Rule 11
- [ ] Unit tests exist for components built (per `AGENTS.md` Rule 4)
- [ ] `REASONING-YYYY-MM-DD-XXX-{Agent}.md` written per Rule 12 and `BuildDisclosure.md` (final step; same `XXX` as build report; agent in filename + header)

---

## Success Criteria

Phase 1.1/1.2A process compliance is achieved when:

- Build report exists with all required sections
- Deviations are explicit — not hidden in code or chat
- `ExecuteAsync` and guard clauses are used on all handlers
- Core rules (Component Pattern, `IDependencyModule`, Implementation Order) are followed or explicitly deviated with justification
- Post-build Reasoning Disclosure exists and is ready for steward handoff

---

**Last Updated:** 2026-06-20 (post-build Reasoning Disclosure — Rule 12)