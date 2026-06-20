# BuildDisclosure.md — Post-Build Mandatory Final Step

**Authority:** `AGENTS.md` Rule 12  
**When:** Always — the **last** step of every build, after the build report  
**Output:** `REASONING-YYYY-MM-DD-XXX.md` in the project root (returned to project stewards for analysis)  
**Naming:** `XXX` = 3-digit daily sequence; must match paired `BUILD-REPORT-YYYY-MM-DD-XXX.md` (see `PHASE_1_1_IMPROVEMENTS.md` → Report Naming)

---

## Purpose

You are completing the **final mandatory step** of a Fortress build.

Do **not** write more code. Make your build-time reasoning fully visible so project stewards can analyze how the documentation performed as executable instructions.

---

## Prerequisites

- [ ] Implementation is complete (or honestly marked partial/blocked in your build report)
- [ ] Solution builds and tests have been run (note failures honestly)
- [ ] `.docs/Builds/BUILD-REPORT-YYYY-MM-DD-XXX.md` exists with all required sections

If any prerequisite is not met, state that under **Build Status** — do not pretend the build succeeded.

---

## Objective

Produce a clear, honest, structured **retrospective** of how you processed the documentation **during the build you just completed**.

Surface contradictions, ambiguities, assumptions, and places where documentation worked or failed as pseudocode. Stewards use your output to improve the documentation system.

---

## What to Review

Re-read or consult these **in light of what you actually built**:

1. `AGENTS.md` (authority hierarchy — Rule 10)
2. `BuildDisclosure.md` (this file — Rule 12)
3. Your build report (`.docs/Builds/BUILD-REPORT-*.md`)
4. Key `.docs/` files you relied on during implementation
5. Representative code you wrote (handlers, security, storage, bootstrapping)
6. Deviations and assumptions you recorded (Rule 11)

**Boundary:** Do not read or reference `Research/`.

---

## Mandatory Rules

1. **Last output of the build** — Create `REASONING-YYYY-MM-DD-XXX.md` in the project root. Use the **same** `YYYY-MM-DD-XXX` as the build report for this run. If multiple runs occur the same day, increment `XXX` (`001`, `002`, …) — do not overwrite prior sequences unless instructed.
2. **Retrospective honesty** — Base analysis on what actually happened. Quote docs, code paths, and build-report entries.
3. **Rules 10 & 11** — Document conflicts and gaps; distinguish low-risk from high-risk assumptions.
4. **Do not edit `.docs/`** — Suggest improvements in `REASONING-YYYY-MM-DD-XXX.md` only (except `.docs/Builds/` where the build report already lives).
5. **Stop when done** — Once the reasoning file is saved, the build is complete.

---

## Required Sections in `REASONING-YYYY-MM-DD-XXX.md`

Use these **exact headings**:

### Build Status

- Agent name, date, outcome: **success / partial / blocked**
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

## Self-Assessment (include in `REASONING-YYYY-MM-DD-XXX.md`)

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

If used, add the optional **Craft Reflection** section at the end of `REASONING-YYYY-MM-DD-XXX.md`. This does not replace any required section above.

---

## Completion

Write `REASONING-YYYY-MM-DD-XXX.md` to the project root (matching the build report sequence). Return it to project stewards. **Stop.**