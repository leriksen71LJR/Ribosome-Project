# Plan: Disclosure Analysis Revision

**Status:** Executed 2026-06-21 — see revised `Build-Agent-Disclosure-Responses-2026-06-21.md`  
**Date:** 2026-06-21  
**Target:** [`Build-Agent-Disclosure-Responses-2026-06-21.md`](Build-Agent-Disclosure-Responses-2026-06-21.md)  
**Author:** Super Grok (Steward)

> **Note:** This file exists because the Cursor plan view did not receive the plan from `CreatePlan`. Use this document as the authoritative plan for review and execution.

---

## Goal

Transform the disclosure analysis into a **self-contained Research artifact** that:

1. Fixes evidence and comprehension gaps (multi-agent review)
2. Inlines curated source corpus (Part II appendices, ~40% per file)
3. Ends with a **substantial §9 closing essay** on practical Ribosome and Documentation-as-Pseudocode implications

---

## Document outline

```
§1   Why this document exists
§1.1 Reader Primer (NEW)
§2   Historical artifact naming (trim anomalies → Part II)
§3   Corpus + §3.1 bias callout + Era A completeness matrix
§4   What agents were asked to do
§5   Cross-agent findings (§5.1.1 isoforms, §5.5 secondary inventions)
§6   Response quality (trimmed)
§7   Implications for Fortress + extended P2 queue
§8   Ribosome mechanics (tables)
§9   EXTENDED ANALYSIS — practical implications (CAPSTONE, ~200–300 lines)
§10  Recommended next steps (brief)
---
Part II  Appendices A–D + Source Provenance
```

---

## Multi-agent review — fixes to apply

| Severity | Fix |
|----------|-----|
| **High** | §5.1: Codex did not *disclose* encryption keying in text — only implemented static `ApplyKeyAsync` |
| **High** | Era A Collected stubs misrepresented — flag Claude/Grok Collected as non-authoritative |
| **High** | Add storage-save, schema/EnsureSchema omissions to §5.5 and §7.1 |
| **Med** | Expand corpus bias: name doc improvements Era A → Era B |
| **Med** | Correct §8.1: agent ≠ ribosome (workflow docs = ribosome) |
| **Med** | Add isoform table (interface vs static encryption) |

---

## §9 — Extended Analysis (capstone)

**Target:** ~2,000–2,500 words. Prose-forward essay, not bullets-only. §8 supplies tables; §9 interprets for Research and stewards.

### §9.1 What Phase 1.2A proved about Documentation as Pseudocode

- Success = T0–T1 surface (handler inventory, security blocks, SQL)
- Failure = T2–T4 seam clusters (deferred phrases, incomplete interfaces, rule collisions)
- Process–requirements inversion: process docs rated higher — invest in contracts, not more `AGENTS.md`
- Measurability gap: principles without acceptance criteria
- Bias: 7–8/10 scores are post-fix; Era C is regression test

### §9.2 Ribosome — operational today vs still metaphor

- **Operational:** post-build QC, convergence diagnosis, process machinery, steward loop (P1 done)
- **Still metaphor:** fidelity tiers, Decision Procedures, QC metrics, single ribosome
- **Correction:** agent = environment (tRNA), not ribosome

### §9.3 Practical rules for documentation authors

1. Interface bodies = highest-leverage pseudocode
2. Deferred phrases = stop codons
3. Cross-component bridge paragraphs required
4. Decision matrices beat narrative
5. Exception rules → Decision Procedures
6. Acceptance criteria close isoform risk

### §9.4 Practical implications for stewards

- Handoff §7 = fix queue
- Disclosure QC can fail silently (Codex encryption)
- Pre-build deprecated for fix-queue authority
- One-at-a-time doc fixes validated
- Extended P2 queue

### §9.5 Phase 2 and Era C shootout

- Regression metrics table (invention clusters, isoforms, disclosure completeness)
- Decision Procedure seeds
- Invention Summary table in Era C (merge, don't fork)

### §9.6 Anti-patterns the corpus refutes

- Convergent invention ≠ agent failure
- Build success ≠ spec completeness
- Don't compensate weak requirements with process docs
- Don't trust pre-build for fix priority
- Don't assume disclosure captures all invention
- Don't pursue "smarter agents" over spec patches

### §9.7 Institutional layer

Scar-aware reporting protects QC integrity.

### §9.8 Closing synthesis

One paragraph tying pseudocode unevenness → seams → QC → patches → procedures → Era C regression.

---

## Part II appendices

| Appendix | Contents |
|----------|----------|
| **A** | Era A excerpts (Grok/Codex shootout full; Claude stub + note) |
| **B** | Era B curated blocks per agent + Codex code forensic |
| **C** | Era C spec summary (~40 lines from `BuildDisclosure.md`) |
| **D** | Operational tables: tiers, seams, invention register, divergence matrix, pseudocode-quality matrix, QC spec, procedure seeds |
| **Provenance** | Filename matrix (replaces link-only index) |

---

## Execution order

1. Copy Grok/Cortex 002 to `Collected/`
2. Revise Part I §1–§7 (evidence fixes)
3. Write §8 mechanics tables
4. **Write §9 extended analysis (largest effort)**
5. Brief §10
6. Build Part II appendices A–D
7. Update `README.md`, `handoff-audit.md`, `MemoryCapsule/CURRENT.md`

---

## §9 acceptance bar

Reader can answer without other files:

1. What doc types to invest in first
2. How post-build disclosure fits Ribosome QC in practice
3. What Era C should measure
4. Why Codex encryption changes trust in disclosure
5. What Decision Procedures to seed
6. Metaphor vs operational machinery today

---

*Approve this plan by replying "execute" or edit this file and ask steward to implement.*