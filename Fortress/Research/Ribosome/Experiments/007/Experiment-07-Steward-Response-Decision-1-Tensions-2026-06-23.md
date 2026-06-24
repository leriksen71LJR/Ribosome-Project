# Steward Response — Decision 1: Unified `tensions/`

**Date:** 2026-06-23  
**In response to:** [007/Decision-1-Tensions-Concept-Report-for-Steward-2026-06-23.md](Decision-1-Tensions-Concept-Report-for-Steward-2026-06-23.md)  
**Context:** Closes the open item in [REVISED guidance](Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-REVISED.md) §4.1 (Option A: `seams/` + `adr/`)  
**Audience:** Research / Director (Mr. Bear)  
**Posture:** Accept with guardrails — proceed to prototype on this model

---

## 1. Executive Summary

**Yes — proceed with unified `tensions/`** as the replacement for the proposed `seams/` + `adr/` split in Phase 2.1.

Research’s synthesis addresses the Steward’s main objection to two folders (parallel trees, link drift, cognitive load) without giving up what Option A was trying to protect: **keep friction visible** (`Open`) and **record decisions with rationale** (`Resolution` when `Resolved`).

This is not a return to Experiment 05 sprawl. It is **one folder, one artifact type, capped growth** — aligned with Exp06 grain.

---

## 2. Why the Steward Accepts (Not Just “Research Prefers Simpler”)

| Steward concern (Option A) | How `tensions/` answers it |
|----------------------------|----------------------------|
| Two competing authorities | One folder; status inside the file |
| Seam→ADR link maintenance | Same file grows from Open → Resolved; history in Notes |
| Premature closure of friction | `Open` can persist across many builds |
| Decision quality when resolved | Resolution block mirrors ADR fields we already use |
| Exp05 fragmentation | Opposite pattern: fewer concepts, not more folders |

The report correctly reframes the disagreement: the Steward wanted **separation of concerns**, not **separation of folders**. Status + sections achieve that.

---

## 3. Guardrails (Required for Phase 2.1 Prototype)

Acceptance is **conditional** on these steward rules:

### 3.1 `strategies/` stays separate

`tensions/` replaces **`seams/` + `adr/`** only. **Strategies** (behavioral choice when multiple approaches are reasonable) remain a distinct category per REVISED §5.2 — not folded into Tension Records.

| Concept | Folder | Question it answers |
|---------|--------|-------------------|
| **Tension** | `tensions/` | Where is friction, and what did we decide about it? |
| **Strategy** | `strategies/` (cap 2 in prototype) | Which approach do we use for a recurring behavior? |

### 3.2 Registry and index

- Add **`tensions/REGISTRY.md`** (or a tensions table inside `components/REGISTRY.md`) — same role Exp06 `adr/REGISTRY.md` plays today.
- Mandatory read order: cite registry when a tension is triggered; agents reference **tension id/name** in build reports, not “ADR number” vocabulary.

### 3.3 Migrate Exp06 `adr/` — don’t orphan

Exp06 has six ADRs + registry rows. For the Exp07 prototype fork:

| Approach | Action |
|----------|--------|
| **Preferred** | Convert each `adr/NNNN-*.md` to a **Resolved** Tension Record (preserve decision text; add Description/Why from context where thin) |
| **Fallback** | Keep `archive/adr-exp06/` read-only reference; new work only in `tensions/` |

Do not maintain **both** live `adr/` and `tensions/` in the prototype.

### 3.4 Lifecycle vocabulary (align with REVISED)

Map prior Proposed/Active language to tension status for the prototype:

| REVISED term | Tension status |
|--------------|----------------|
| Proposed / Active (unresolved) | **Open** |
| Accepted decision | **Resolved** |
| No longer relevant | **Deprecated** |

“Retired” = delete or move to `archive/` after steward review — same as today.

### 3.5 Prototype cap unchanged

Still **max 3 Open tensions + 2 strategies** on first pass (seeds from Era B / plan-mode gaps). `tensions/` does not justify more files.

### 3.6 Maintenance Proposals table — extend types

Add row types for the build report (agents still read-only on `.docs/`):

| Type | Example |
|------|---------|
| Missing Tension | New friction with no record |
| Open Tension — insufficient guidance | Tension exists but PLUGIN/strategy doesn’t resolve it |
| Resolution Candidate | Enough divergence to move Open → Resolved (steward decides) |
| Deprecated Tension candidate | No longer referenced |

### 3.7 Minimum viable Tension Record (MVP)

For prototype, a record may be **thin** when Open:

- Status, Description, Affected Areas (plugin links), Notes

Resolution sections are **required only when Status = Resolved**. Steward promotes Open → Resolved; agents propose via table only.

---

## 4. What Changes in REVISED Guidance

| REVISED §4.1 (Option A) | After Decision 1 |
|-------------------------|------------------|
| `seams/` + `adr/` + flow in CORE | **`tensions/`** + short CORE section on Open/Resolved |
| Fast-path from existing `adr/` | Fast-path becomes **migrate or link archive**, not dual live trees |
| Open question on Option A | **Closed** — adopt `tensions/` |

Research should publish a **REVISED-2** or patch §4 when convenient — not blocking prototype if this response is cited in the fork README.

---

## 5. Remaining Open Items (Not Blockers)

| Item | Owner |
|------|-------|
| Exact Tension Record template (1-page steward doc) | Research + Steward |
| Whether `Related Tensions` uses ids (`T-0003`) or filenames only | Steward preference: **numbered files** `0001-*.md` + registry row (continuity with Exp06 ADR habit) |
| Integration row schema in Maintenance Proposals | Next decision memo |
| Director sign-off | Mr. Bear |

---

## 6. Prototype Fork — Cleared to Plan

With Decision 1 accepted, the **Exp07 prototype fork** may proceed when the Director agrees timing:

1. Copy Exp06 doc tree → Research `007/` prototype (or promote later to `Fortress/Project/2.1/` per `PROCESS.md`).
2. Replace `adr/` with `tensions/` per §3.3.
3. Add `strategies/` seeds (2), REGISTRY split, Maintenance Proposals in BUILD-DISCLOSURE.
4. Document read-order and tension citation rules in `process/AGENTS.md`.

No shootout required before the fork.

---

## 7. Closing

Research’s `tensions/` model is a **credible synthesis**, not a shortcut. The Steward accepts it for Phase 2.1 and recommends the Director do the same unless you see a conflict with training goals.

Next step from Research’s offer: **minimum viable Tension Record template** + Maintenance Proposals integration — Decision 2 when you are ready.

---

*Prepared for Research handoff. Steward / build-side perspective.*