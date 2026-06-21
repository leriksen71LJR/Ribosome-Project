# BuildDisclosure.md — Combined Build Report (Mandatory)

**Authority:** `AGENTS.md` Rules 8 and 12  
**When:** End of every build — after implementation and tests  
**Output:** **One file only** — `.docs/Builds/BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md`  
**Do not** create `REASONING-*.md` or any second report file.

This file is the **single specification** for the combined build report: build-record sections (what happened) plus Build Disclosure sections (how documentation performed). All required content lives in one artifact.

---

## Purpose

At the end of every build, produce one structured report in `.docs/Builds/` and return it to project stewards.

- **Build-report sections** record what you built, decided, and deviated.
- **Build Disclosure sections** record how the documentation performed as executable instructions.

Do **not** write more code once you begin the report. Complete all sections honestly, then **stop**.

---

## Report Naming

One artifact per build run.

| Rule | Detail |
|------|--------|
| **Location** | `.docs/Builds/` only (sole `.docs/` write exception — `AGENTS.md` Rule 5) |
| **Pattern** | `BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md` |
| **Date** | `YYYY-MM-DD` — today's date |
| **Sequence** | `XXX` — 3-digit daily sequence (`001`, `002`, `003`, …) |
| **Agent** | `{Agent}` — short slug, no spaces (e.g. `GrokBuild`, `Claude`, `Codex`) |

**Sequence rules:**

1. Scan existing files with the same date prefix (e.g. `BUILD-REPORT-2026-06-20-*.md`).
2. Set `XXX` to the **next unused** 3-digit sequence for that date.
3. Do **not** overwrite an existing sequence unless explicitly instructed.
4. Same agent re-running the same day uses a **new** `XXX`, not a new agent suffix on the same sequence.

**Examples:**

- `BUILD-REPORT-2026-06-20-001-GrokBuild.md`
- Second run same day → `BUILD-REPORT-2026-06-20-002-Claude.md`

---

## Prerequisites

- [ ] Implementation is complete (or honestly marked partial/blocked in the report header)
- [ ] Solution builds and tests have been run (note failures honestly)
- [ ] Absolute path to `AGENTS.md` recorded in header — must match assigned shootout root (`AGENTS.md` Rule 13)

If any prerequisite is not met, state that under **Build Status** — do not pretend the build succeeded.

---

## Mandatory Rules

1. **One file** — All sections below go in `.docs/Builds/BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md`. Agent name required in filename and header.
2. **Honesty** — Base every section on what actually happened. Quote docs, code paths, and your own decisions.
3. **Rules 10 & 11** — Document conflicts and gaps; distinguish low-risk from high-risk assumptions.
4. **Do not edit `.docs/`** — Suggest improvements in the report only (except `.docs/Builds/` where the report lives).
5. **Grouped sections** — Use the exact headings below; not one flat unstructured list.
6. **Stop when done** — Once the file is saved with all required sections, the build is complete.

---

## What to Review (before writing)

Re-read or consult these **in light of what you actually built**:

1. `AGENTS.md` (authority hierarchy — Rule 10)
2. `BuildDisclosure.md` (this file)
3. Key `.docs/` files you relied on during implementation
4. Representative code you wrote (handlers, security, storage, bootstrapping)
5. Deviations and assumptions you made during the build (Rule 11)

**Boundary:** Do not read or reference `Research/`.

---

## Required Sections — Build Report

### Report header (mandatory — top of file)

```markdown
# Build Report

| Field | Value |
|-------|-------|
| **Agent** | {your agent name — must match filename slug} |
| **Date** | YYYY-MM-DD |
| **Sequence** | XXX |
| **Outcome** | success / partial / blocked |
| **Project root** | {absolute path to directory containing AGENTS.md} |
```

### 1. Summary of Work Completed

What was delivered vs. what was not. One focused overview paragraph plus bullets if helpful.

### 2. Files Created / Modified

List significant files and folders created or changed during the build.

### 3. Key Implementation Decisions

Grouped by topic — use subheadings:

- Architecture
- Handlers
- Security
- Storage
- DI
- Tests

State what you chose and why when documentation allowed judgment.

### 4. Deviations from Documentation

Use `None` if every rule was followed. Otherwise report **every** deviation, including:

- Component Pattern violations (wrong folder layout, missing `Contracts/` / `Implementations/` / `Model/`)
- Services registered outside `IDependencyModule`
- Implementation Order violations
- Missing or non-async `ExecuteAsync` on handlers
- Weak or missing guard clauses
- Substituting plain SQLite for SQLCipher, or PBKDF2 for Argon2id
- Silent assumptions on high-risk gaps (violates Rule 11)
- Writing files outside the project root or outside allowed `.docs/Builds/`

**For each deviation, state:**

| Field | Required |
|-------|----------|
| Rule not followed | Quote or reference the specific rule |
| What was done instead | Concrete description |
| Why | Intentional, ambiguity, tooling limitation, or time constraint |
| Impact | Effect on correctness, security, or maintainability |

**Example:**

> - Used synchronous `IStorageService.Save()` instead of `SaveAsync()`.
>   - Reason: Interface was implemented before async contract was finalized.
>   - Impact: Low for MVP console app; violates async convention; should be fixed in next pass.

**Do not** silently work around documented rules.

### 5. Deep Documentation Audit

Re-read documents you actually used (not from memory). Cite **specific documents** and **sections** for every issue. Apply Rules 10 and 11.

**Per-document checklist** (evaluate each document you used):

| Document | Key questions |
|----------|---------------|
| `AGENTS.md` | Were all rules followable? Any internal conflicts? |
| `ARCHITECTURE.md` | Was folder structure unambiguous? Implementation order clear? |
| `CODING_DESIGN.md` | Were interface contracts sufficient without inventing signatures? |
| `ARCHITECTURE_SECURITY.md` | Could SQLCipher + Argon2id be implemented from the spec alone? |
| `HANDLER_INVENTORY.md` | Was the handler list complete? Were `IsVisible` rules sufficient? |
| `CODING_STANDARDS.md` | Were coding rules measurable enough to verify compliance? |
| `BuildDisclosure.md` | Was this report structure clear? |

Skip documents you did not read. Note skipped required docs under **Significant Issues**.

**Minimum evidence bar** — each Significant Issue must include document, section/topic, problem, what you did, and severity (High / Medium / Low). Vague entries fail the audit.

Every **High** severity assumption must appear here or under **Open Gaps and Assumptions**.

Copy this structure:

```markdown
## Deep Documentation Audit

### Mental Model Formed
[2–4 sentences: component layout, DI, handlers, security, storage]

### Strengths
- [Bullet: specific doc + what worked as executable instruction]
- [At least 2 strengths with document references]

### Significant Issues
| # | Document | Issue | Severity | Resolution / Impact |
|---|----------|-------|----------|---------------------|
| 1 | ... | ... | High/Med/Low | ... |

[If none: state "No significant issues found" and explain what you verified.]

### Assumptions Made (Rule 11)
| # | Assumption | Why necessary | Severity | Validated? |
|---|------------|---------------|----------|----------|

### Recommendations
- [Actionable doc improvement — not generic "add more detail"]
- [At least 1 recommendation tied to a specific issue above]

### Overall Assessment
**Rating:** X/10

**One-sentence justification:**

**Would another agent produce the same structure from these docs alone?** Yes / Partially / No — explain.
```

**Audit quality rubric:** 9–10 = all issues cited with doc references; 1–4 = generic prose without references — **audit must be redone**.

See also `Evaluation/EvaluationCriteria.md` for extended guidance.

### 6. Open Gaps and Assumptions

Apply Rules 10 and 11:

- **Rule 10:** List document contradictions encountered and which document you followed.
- **Rule 11:** List assumptions made due to missing or ambiguous documentation, with severity (High / Medium / Low).

High-severity assumptions must be prominent — not buried.

### 7. Recommended Next Steps

Actionable follow-ups for the next build or steward doc fixes. Tie to specific gaps or issues above.

---

## Required Sections — Build Disclosure

After the build-report sections above, add:

```markdown
## Build Disclosure
```

Then use these **exact section headings**:

### Build Status

- Repeat agent name, date, and outcome (must match header block)
- One paragraph: what was delivered vs. what was not

### 1. Document Processing (Build Retrospective)

For each major document you used during the build:

- **What I Understood**
- **What Was Clear vs Unclear** — during implementation
- **Inferences, Assumptions, and Decisions** — cite the source document; apply Rules 10 & 11
- **Impact on Implementation**

### 2. Build Retrospective

- Documentation that functioned as **executable pseudocode**
- Sections requiring significant judgment or invention
- Documentation-driven vs. tooling/time-driven deviations
- Changes that would make a repeat build more reliable

### 3. Workflow Understanding

- How the build workflow behaved in practice
- Process vs. requirements documents
- Whether Rule 12 and this file were clear and sufficient

### 4. Risks and Assumptions

- Remaining risks and assumptions after the build
- Severity (**High / Medium / Low**) for each
- Validation or doc change needed to resolve each

### 5. Missing or Broken References

- Referenced documents that were missing, empty, or contradictory
- Impact on this build

### 6. Documentation as Pseudocode

- Strongest executable sections (with examples)
- Weakest interpretive sections (with examples)
- Instruction vs. explanation balance
- Top 3 documentation changes for the next build

### 7. Handoff to Stewards

- **Single most important finding** for documentation improvement
- **Recommended priority:** High / Medium / Low
- Patterns across multiple documents

---

## Self-Assessment (include in the report)

Apply the **Documentation as Pseudocode** lens to **`BuildDisclosure.md`**:

1. **Executable Quality Rating** — Rate this file 1–10 with one-sentence justification.
2. **What You Did Well** — One or two moments of precise diagnostic craft.
3. **The Critical Gap (with Evidence)** — Biggest gap between this file's intent and your behavior. Quote specific text.
4. **Red Team** — Why your gap analysis might be incomplete.
5. **Rule 10 & Rule 11 Enforcement Test** — One concrete example from this build for each.
6. **One High-Leverage Improvement** — One change to improve future disclosures.

---

## Optional Craft Layer

For light gamification (Documentation Cartographer framing, Pride Points, achievements), see [AgentGamification.md](AgentGamification.md).

If used, add the optional **Craft Reflection** section at the **end** of the report. This does not replace any required section above.

---

## Completion Checklist

Before considering the build complete:

- [ ] `BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md` in `.docs/Builds/` (date + sequence + agent in filename)
- [ ] All 7 build-report sections present (including **Deviations from Documentation**, even if `None`)
- [ ] **Deep Documentation Audit** meets minimum evidence bar
- [ ] All Build Disclosure sections present (under `## Build Disclosure`)
- [ ] Self-Assessment included
- [ ] No separate `REASONING-*.md` file created
- [ ] File returned to project stewards — **stop**

---

## Legacy

Builds before 2026-06-21 used two files: `BUILD-REPORT-YYYY-MM-DD-XXX.md` + `REASONING-YYYY-MM-DD-XXX-{Agent}.md` in the project root. That format is **deprecated**.