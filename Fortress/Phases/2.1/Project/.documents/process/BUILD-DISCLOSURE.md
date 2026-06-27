# BUILD-DISCLOSURE — Combined Build Report (Phase 2.1)

**Authority:** `.documents/process/AGENTS.md` Rules 8 and 12  
**Output:** One file — `Builds/BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md`

Do **not** create `REASONING-*.md` or a second report file.

---

## Report Naming

| Rule | Detail |
|------|--------|
| Location | `Builds/` only |
| Pattern | `BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md` |
| Sequence | Next unused 3-digit `XXX` for the date |

---

## Required Sections

### Header

```markdown
# Build Report

| Field | Value |
|-------|-------|
| **Agent** | {slug} |
| **Date** | YYYY-MM-DD |
| **Sequence** | XXX |
| **Outcome** | success / partial / blocked |
| **Project root** | {absolute path to phase AGENTS.md directory} |
| **Phase** | 2.1 |
```

### Build report sections

1. **Summary of Work Completed**
2. **Files Created / Modified**
3. **Key Implementation Decisions** (Architecture, Handlers, Security, Storage, DI, Tests)
4. **Deviations from Documentation** — `None` or full table per AGENTS Rule 7
5. **Deep Documentation Audit** — per `.documents/quality/EvaluationCriteria.md`

### Build Disclosure sections

6. **Self-Assessment** — doc executability 1–10 for **process** vs **requirements** separately

7. **Invention Summary** (mandatory)

| # | I-code | Seam | What was invented | Disclosed? | Doc gap |
|---|--------|------|-------------------|------------|---------|
| 1 | I-A / I-E / I-B / I-C | S1/S2/S3 | ... | Yes/No | path or tension |

8. **Documentation Maintenance Proposals** (mandatory when non-empty)

| # | Type | Target | Proposal | Evidence |
|---|------|--------|----------|----------|
| 1 | Missing Tension / Open Tension / Resolution Candidate / Missing Strategy / PLUGIN patch | `.documents/...` or `.codingAgent/...` | ... | build report section |

**Row types:** Missing Tension · Open Tension (insufficient guidance) · Resolution Candidate · Deprecated Tension candidate · Missing Strategy · PLUGIN patch

9. **Open Gaps and Assumptions** — Rule 11 high-risk items
10. **Handoff Priorities** — top 3 doc fixes for stewards

---

## Audit document checklist

| Document | Key questions |
|----------|---------------|
| Phase `AGENTS.md` + `.documents/process/AGENTS.md` | Two-zone boundary and rules followable? |
| `.documents/CORE.md` + `COMPONENTS.md` + `REGISTRY.md` | Read order and split clear? |
| `.documents/components/Bootstrapping/PLUGIN.md` | DI matrix complete? |
| `.documents/tensions/` | Exceptions cited when used? |
| `.documents/quality/TEST-EXPECTATIONS.md` | Checklist honest? |

Stop when file is complete. Do not write more code after starting the report.