# EvaluationCriteria.md

**Purpose:** Guide agents performing the mandatory **Deep Documentation Audit** in the build report (`AGENTS.md` Rule 8, `PHASE_1_1_IMPROVEMENTS.md`).

**Relationship to Build Disclosure:** The Deep Documentation Audit is a **section inside the build report**. The post-build **Build Disclosure** (`BuildDisclosure.md`, `AGENTS.md` Rule 12) produces `REASONING-YYYY-MM-DD-XXX-{Agent}.md` — the separate **final artifact** returned to stewards (agent name in filename and header). Both share the same `XXX` sequence for a given build run. Both are required; they are not interchangeable.

**Restriction:** Report findings only. Do **not** edit documentation files during the audit or disclosure.

---

## When This Applies

- **Every build** must include a **Deep Documentation Audit** section in `BUILD-REPORT-YYYY-MM-DD-XXX.md`.
- A build report **without** this section is **incomplete**.
- Shallow one-line summaries fail the audit. Minimum evidence requirements below apply.

---

## How to Perform the Audit

1. Re-read the documents you actually used during the build (not from memory).
2. For each document in the checklist below, record: what was clear, what was ambiguous, what you assumed.
3. Cite **specific documents** and **specific sections** for every issue raised.
4. Apply `AGENTS.md` Rules 10 and 11 — conflicts and assumptions must be explicit.
5. Rate overall documentation effectiveness 1–10 with justification.

---

## Per-Document Checklist (evaluate each used)

| Document | Key questions |
|----------|---------------|
| `AGENTS.md` | Were all 11 rules followable? Any internal conflicts? |
| `ARCHITECTURE.md` | Was folder structure unambiguous? Implementation order clear? |
| `CODING_DESIGN.md` | Were interface contracts sufficient to implement without inventing signatures? |
| `ARCHITECTURE_SECURITY.md` | Could SQLCipher + Argon2id be implemented from the spec alone? |
| `HANDLER_INVENTORY.md` | Was the handler list complete? Were `IsVisible` rules sufficient? |
| `CODING_STANDARDS.md` | Were coding rules measurable enough to verify compliance? |
| `PHASE_1_1_IMPROVEMENTS.md` | Was the build report structure clear? |
| `EvaluationCriteria.md` | (this file) |

Skip documents you did not read. Note skipped docs under **Significant Issues** if they were required for your build.

---

## Minimum Evidence Bar

Each **Significant Issue** entry must include:

| Required field | Example |
|----------------|---------|
| Document | `ARCHITECTURE.md` |
| Section or topic | Solution Layout diagram |
| Problem | States X but `AGENTS.md` requires Y |
| What you did | Followed `AGENTS.md` per Rule 10 |
| Severity | High / Medium / Low |

**Vague entries fail the audit.** ❌ "Documentation was sometimes unclear."  
**Acceptable:** "`CODING_DESIGN.md` §4 names `AppSettingsService` while `ARCHITECTURE.md` lists `ConfigurationService` — resolved via latest `CODING_DESIGN.md` (Low, fixed in docs)."

Every **High** severity assumption made during the build must appear in **Significant Issues** or **Open Gaps** in the build report.

---

## Evaluation Areas (think through each)

### 1. Mental Model Formation
- What overall mental model did you form about Fortress?
- How did the documentation help or hinder that model?
- Where did you fill gaps yourself?

### 2. Clarity and Ambiguity
- Which parts were executable without interpretation?
- Which parts required judgment calls?
- Where did you choose between competing understandings?

### 3. Completeness and Gaps
- What guidance was still missing after this build?
- What edge cases were unaddressed?
- What would have prevented your largest assumption?

### 4. Consistency
- List every contradiction found (document A vs document B).
- State resolution per Rule 10.

### 5. Practical Effectiveness
- How well did docs support actual implementation?
- What friction cost the most time?
- Did docs encourage gap-reporting or silent inference?

---

## Required Output Format

Copy this structure into the build report under the heading **Deep Documentation Audit**:

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

---

## Audit Quality Rubric

| Score | Meaning |
|-------|---------|
| 9–10 | All issues cited with doc references; assumptions listed; recommendations actionable |
| 7–8 | Solid audit; minor vagueness in 1–2 entries |
| 5–6 | Some issues named but missing citations or severities |
| 1–4 | Generic prose; no document references — **audit must be redone** |

---

## Enforcement

- Build is **incomplete** without **Deep Documentation Audit** meeting the minimum evidence bar.
- Audits that only praise documentation without naming specific issues when issues existed violate `AGENTS.md` Rule 11.
- Audits that hide contradictions violate Rule 10.

---

**Last Updated:** 2026-06-20 (expanded for Phase 1.2A)