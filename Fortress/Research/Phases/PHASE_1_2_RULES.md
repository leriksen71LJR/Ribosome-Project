# PHASE_1_2_RULES.md

**Phase:** 1.2  
**Focus:** Documentation Discipline, Output Control, and Auditability

This document defines the **mandatory rules** that must be followed during Phase 1.2 builds.

---

## Core Rules

### 1. Output Location Rule (Mandatory)
- All generated files **must** be written directly into the assigned project root folder.
- Writing to `.claude/worktrees/`, temporary harness folders, or any location other than the designated project root is **strictly forbidden**.
- This rule takes precedence over any default behavior of the agent or harness.

### 2. Violation / Deviation Reporting (Mandatory)
- If you cannot follow any rule in this document or in `AGENTS.md` / `CODING_STANDARDS.md`, you **must** explicitly report it.
- Every build report must contain a clear **Violations** section.
- Do not silently work around rules. Report the violation, explain why it occurred, and what impact it had.

### 3. Deep Documentation Audit (Mandatory)
- At the end of every build, you **must** perform a Deep Documentation Audit.
- Use the guidance in `Evaluation/EvaluationCriteria.md`.
- The audit must be included in the build report under a section titled **"Deep Documentation Audit"**.
- The audit should focus on:
  - How you interpreted the documentation
  - What was clear vs ambiguous
  - What assumptions you had to make
  - Recommendations for improvement

### 4. Documentation Boundary Rule (Mandatory)
- You are **strictly forbidden** from reading or referencing any documents inside a `Research/` folder.
- `Research/` is human-only thinking space.
- All content you are allowed to use lives under `Project/`.

### 5. Workflow Adherence
- Follow the workflows and procedures defined in `Workflows/` and `Procedures/`.
- If a workflow or procedure is unclear, report it as a violation rather than guessing.

### 6. Reasoning Disclosure (When Requested)
- When instructed to use Reasoning Disclosure mode, you must produce the four reasoning artifacts (`REASONING_01_*` through `REASONING_04_*`) **before** writing any production code.
- This mode exists to make your document processing and decision-making visible and auditable.

---

## Summary

These rules exist to make the documentation system itself testable and improvable.  
Following them is not optional during Phase 1.2.

If any rule creates a genuine blocker, **report the violation clearly** rather than bypassing it.
