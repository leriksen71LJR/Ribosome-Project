# BuildDisclosure.md — Combined Build Report

**Authority:** `process/AGENTS.md` Rules 8 and 12  
**Output:** One file — `006/Builds/BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md`

Do **not** create `REASONING-*.md` or a second report file.

---

## Report Naming

| Rule | Detail |
|------|--------|
| Location | `006/Builds/` only |
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
| **Project root** | {absolute path to AGENTS.md directory} |
| **Doc root** | 006 (Experiment 06) |
```

### Build report sections

1. **Summary of Work Completed**
2. **Files Created / Modified**
3. **Key Implementation Decisions** (Architecture, Handlers, Security, Storage, DI, Tests)
4. **Deviations from Documentation** — `None` or full table per AGENTS Rule 7
5. **Deep Documentation Audit** — per `quality/EvaluationCriteria.md`; cite paths under `006/`

### Build Disclosure sections

6. **Self-Assessment** — doc executability 1–10 for **process** vs **requirements** separately

**Optional craft (does not replace mandatory rows above):**

- **What went well** — specific doc paths that translated cleanly to code
- **Critical gap** — single highest-leverage mRNA hole with evidence (quote + what you built instead)
- **Red team** — one sentence: “If I were steward, I’d patch X first because…”
- **Rule 10/11 check** — any conflict or gap you flagged vs any you filled silently

7. **Invention Summary** (mandatory — Era C instrument)

| # | I-code | Seam | What was invented | Disclosed? | Doc gap |
|---|--------|------|-------------------|------------|---------|
| 1 | I-A / I-E / I-B / I-C | S1/S2/S3 | ... | Yes/No | path or ADR |

I-codes: I-A same impl · I-B behavior choice · I-C rule exception · I-D tooling · I-E isoform

8. **Open Gaps and Assumptions** — Rule 11 high-risk items
9. **Handoff Priorities** — top 3 doc fixes for stewards

---

## Audit document checklist (DI layout)

| Document | Key questions |
|----------|---------------|
| `process/AGENTS.md` | Rules followable? |
| `CORE.md` + `COMPONENTS.md` | Read order and plugin contract clear? |
| `components/Bootstrapping/PLUGIN.md` | DI matrix and composition root complete? |
| `components/Actions/PLUGIN.md` | Handlers + IsVisible sufficient? |
| `components/Security/PLUGIN.md` | SQLCipher + Argon2id + storage bridge executable? |
| `components/Infrastructure/PLUGIN.md` | Schema + save clear? |
| `components/Logging/PLUGIN.md` | Log4Net policy (adr/0005) followed? |
| `adr/REGISTRY.md` | Exceptions cited when used? |
| `quality/TEST-EXPECTATIONS.md` | Checklist honest? SQLCipher round-trip or deviation? |

Stop when file is complete. Do not write more code after starting the report.