# Invention Disclosure Requirements

**Authority:** `process/AGENTS.md` Rules 9–11 · `process/BUILD-DISCLOSURE.md` Invention Summary

## Principle

Invention is **diagnostic information**, not agent failure. When specs are incomplete, agents implement and **disclose** — that feeds the steward loop (mRNA patch → re-shootout). Silent functional invention is a QC failure (Era B: Codex encryption).

---

## Rule

When implementation required choices not specified in documentation, **disclose** them in the build report Invention Summary table.

---

## Assumption severity (Rule 11)

| Severity | When | Report where |
|----------|------|--------------|
| **Low** | Cosmetic, naming, non-security defaults with negligible divergence risk | Open Gaps — brief note |
| **Medium** | Save strategy variant, schema bootstrap choice, test harness limitation | Invention Summary + Open Gaps |
| **High** | Encryption keying shape, cross-component contracts, security behavior, silent new-db on wrong password | Invention Summary — **must** be prominent; cite doc gap |

**High-risk examples from Era B:** per-connection `ApplyKeyAsync` shape; archive hard delete; full-table save; Exit guard exception.

Low-risk is acceptable only with: why necessary, why low risk. High-risk without disclosure → steward spot-check required.

---

## High-risk seams (always disclose if invented)

| Seam | Doc / Tension |
|------|----------------|
| Encryption ↔ storage keying | `components/Security/PLUGIN.md` (Storage bridge), [0006](../tensions/0006-incomplete-contract-acceptance.md) |
| Archive behavior | [0003](../tensions/0003-archive-semantics-mvp.md), `components/Actions/PLUGIN.md` handler inventory row |
| Save strategy | [0004](../tensions/0004-storage-save-strategy.md), `components/Infrastructure/PLUGIN.md` |
| Exit session guard | [0002](../tensions/0002-exit-handler-vs-session-guard.md) |
| Modules folder | [0001](../tensions/0001-modules-folder-exception.md) |
| UX (password prompt/masking) | `components/Security/PLUGIN.md` UX section |

---

## I-code taxonomy

| Code | Meaning |
|------|---------|
| I-A | Same implementation, same gap |
| I-B | Behavior choice at ambiguous spec |
| I-C | Process/rule exception |
| I-D | Tooling or environment workaround |
| I-E | Implementation isoform (same function, different shape) |

---

## Steward spot-check

When disclosure is silent on S1 seams, stewards inspect code for encryption keying and cross-component bridges.