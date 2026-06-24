# Experiment 07 — Phase 2.1 Guidance Plan (Revised)

**Date:** 2026-06-23  
**Status:** Revised after Steward response — ready for Research confirmation on one open item  
**Tone:** Contemplative where judgment remains open; decisive where Steward and Research align  
**Supersedes:** [007/Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-0452.md](Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-0452.md) (original upload preserved)  
**Incorporates:** [007/Experiment-07-Steward-Response-2026-06-23.md](Experiment-07-Steward-Response-2026-06-23.md)

---

## 1. Purpose of This Document

This document prepares guidance for **Phase 2.1** of the Fortress documentation architecture. Its role is to help the Steward implement a small, learnable evolution of Experiment 06 — not to deliver a finished seam/strategy taxonomy.

Phase 2.1 is **infrastructure for learning how to curate** cross-cutting concerns. Seams and strategies are **emergent**; we discover how to manage them across many phases, not in a single build round.

We operate as **thinking partners who initiate**, but this revision takes clearer stands where the Steward has resolved real tensions.

---

## 2. Core Posture (Unchanged)

We treat the documentation system as **recipes, ingredients, and connectors**:

| Layer | Role | Phase 2.1 home |
|-------|------|----------------|
| **Recipe** | General rules and philosophy | `CORE.md`, slim `COMPONENTS.md` |
| **Ingredients** | Executable component detail | `components/*/PLUGIN.md` |
| **Connector** | Map, load order, cross-links | `components/REGISTRY.md` (hypothesis to test) |

Apply the pattern where it reduces invention or improves clarity — not reflexively.

---

## 3. What We Are Trying to Solve

Experiment 06 restored plugin-shaped executability. Cross-cutting **seams** (boundary tension) and **strategies** (behavioral choice) remain implicit or scattered.

Phase 2.1 makes the most important of these **visible and maintainable** without recreating Experiment 05 fragmentation. Success is **traceability + maintenance signal + curation habit** — not a complete catalog proven in one shootout.

---

## 4. Pre-Implementation Decisions (Steward-Aligned)

Three decisions must be settled before forking the Exp06 package into an Exp07 prototype. Research adopts the Steward’s recommended direction on all three, with one confirmation question noted below.

### 4.1 `seams/` and `adr/` — Both, With Clear Flow (Option A)

Experiment 06 collapsed Exp05 `Seams/` into **`adr/`** (six records + `REGISTRY.md`). Re-introducing boundaries without a rule risks parallel competing trees.

**Decision (adopted):**

| Layer | Purpose | Typical status |
|-------|---------|----------------|
| **`seams/`** | Boundary catalog — risk points, triggers, links to plugins | **Proposed** or **Active** |
| **`adr/`** | Accepted decisions — resolution, consequences, acceptance criteria | **Active** (accepted) |
| **Flow** | Seam surfaces tension → agent/steward flags gap → ADR records decision → seam links to ADR |

**Implementation rule:** One short section in `CORE.md` documents this relationship. Agents do not maintain two competing authorities.

**Fast-path (Steward addition):** If an Era B cluster or existing `adr/` already documents a concern, **promote or link** — do not duplicate as a new seam file.

**Open for Lead Researcher confirmation:** Does Option A match intent, or should `adr/` be retired in favor of `seams/` only? Research currently recommends **Option A**.

### 4.2 `REGISTRY.md` vs `COMPONENTS.md` — Clean Split

`REGISTRY.md` only earns its place if inventory and cross-links **move out** of `COMPONENTS.md`.

**Decision (adopted):**

| File | Holds |
|------|-------|
| **`COMPONENTS.md`** | Component pattern, plugin contract, Open/Closed rules, technology stack |
| **`REGISTRY.md`** | Load order, dependency map, `PLUGIN.md` links, seam/strategy/ADR cross-refs |

**Minimum viable `REGISTRY.md`:** One screen — load order table, dependency edges, plugin links, seam/strategy/ADR index. No duplicated rules from `COMPONENTS.md`.

Update mandatory read order once in `process/AGENTS.md`. Whether agents cite REGISTRY in build reports is a **directional** signal, not pass/fail.

### 4.3 Agent Write Boundaries — Read-Only `.docs/` During Builds

The original guidance (§4.2) allowed agents to append Maintenance Notes to seam/strategy files. The Steward correctly notes this conflicts with Exp06 **`process/AGENTS.md` Rule 5** (`.docs/` read-only except `Builds/`).

**Decision (adopted):**

| Agent may | Agent may not |
|-----------|---------------|
| Read, follow, and cite seams, strategies, ADRs | Edit seam, strategy, or ADR files during routine shootouts |
| Flag gaps in the **Documentation Maintenance Proposals** table | Append in-place maintenance notes to doc files |
| Propose actions in BUILD-REPORT | Treat proposals as authoritative doc changes |

**Channels for maintenance signal:**

1. BUILD-REPORT — **Documentation Maintenance Proposals** table (required when non-empty)  
2. Optional steward queue file under `Builds/` if aggregation is needed  

Agents are **sensors**, not editors. Steward curation drives Proposed → Active → Deprecated transitions.

---

## 5. Structural Recommendations

### 5.1 Seams

Introduce `seams/` under `.docs/`.

A seam earns its own file when it meets **at least two of**:

- Genuinely cross-cutting  
- Already produced measurable invention or divergence  
- Likely to recur  
- Hiding it is likely to create confusion or drift  

**Seams** mark *where tension lives*. **Strategies** mark *which approach we chose* when multiple are reasonable. Do not conflate them.

All new seam files start at lifecycle status **Proposed**.

### 5.2 Strategies

A strategy is a named, selectable approach to a recurring problem. Many Era B inventions came from missing **strategy** clarity, not missing contracts.

A strategy earns documentation when the choice has recurring cross-component impact or hiding it has already produced divergence.

**Prototype cap:** Maximum **3 seam files + 2 strategy files** on first pass. Essential guard against Exp05-style sprawl.

**Suggested seeds (Proposed, not canon):**

| Type | Candidate | Notes |
|------|-----------|-------|
| Seam | Wrong-password / first-run UX | Plan-mode Medium gap; Security plugin |
| Seam | Schema bootstrap | Two valid paths; Infrastructure plugin |
| Seam | Export-backup edges | Light spec; Actions plugin |
| Strategy | Save strategy | `adr/0004` exists — elevate as Active strategy doc |
| Strategy | Disclosure + maintenance | Era C report shape + Maintenance Proposals table |

Defer visibility, error-handling, and other strategies until a build cites recurring divergence.

### 5.3 Documentation Maintenance Proposals Table

Build reports include this table when proposals exist. It complements Invention Summary (what was invented) with steward-actionable signal (what doc should change).

```markdown
## Documentation Maintenance Proposals

| Type                  | Name                        | Description                                      | Severity | Should Block Build? | Proposed Action             |
|-----------------------|-----------------------------|--------------------------------------------------|----------|---------------------|-----------------------------|
| Missing Seam          | [Name]                      | [Brief description of risk or gap]               | High     | No                  | Create new seam file        |
| Outdated Strategy     | Visibility Strategy         | Current strategy no longer matches implementation| Medium   | No                  | Review and update           |
| Missing Strategy      | [Name]                      | Recurring decision pattern observed              | Medium   | No                  | Create new strategy file    |
| Retirement Candidate  | Old Archive Strategy        | No longer referenced in active components        | Low      | No                  | Mark as Deprecated          |
```

Add this section to `process/BUILD-DISCLOSURE.md` in the Exp07 prototype.

### 5.4 Lifecycle Status

Every seam and strategy file carries:

- **Proposed** — Newly created, not yet validated by use  
- **Active** — Currently relevant and referenced  
- **Deprecated** — No longer recommended; kept for history  
- **Retired** — Removed from active use after review  

Curation over time prevents zombie artifacts.

---

## 6. What to Carry Forward from Experiment 05

Experiment 05 correctly named cross-cutting concerns as first-class elements. Its failure was **too fine a grain**.

Apply Experiment 05’s insight at Experiment 06’s grain: coarse, plugin-aligned, capped growth. A concern earns its own file only when the cost of keeping it implicit exceeds the cost of structure — **intentional granularity**, not minimalism for its own sake.

---

## 7. Tone and Posture

This revision is more decisive on structure (three pre-implementation decisions, agent boundaries, REGISTRY split) because the Steward has done the hard arbitration work.

We remain contemplative on **which** seams and strategies will prove durable — that emerges from use, not from one design session.

---

## 8. Open Questions (Reduced)

Questions resolved by §4 are removed. What remains genuinely open:

| Question | Posture |
|----------|---------|
| Should `adr/` be retired in favor of `seams/` only? | Steward recommends Option A (both); Research seeks confirmation |
| Which strategies beyond the seed set earn files next? | Defer until builds cite recurring divergence |
| Does REGISTRY reduce invention in practice? | Test in prototype; directional evidence from build reports |
| How aggressively to retire Deprecated artifacts? | Steward judgment after curation habit forms |

---

## 9. Proposed Next Steps

| Step | Action | Owner |
|------|--------|-------|
| 1 | Lead Researcher confirms Option A (`seams/` + `adr/`) or counters | Research |
| 2 | Fork Exp06 → Exp07 prototype (not live `Fortress/Project/`) | Steward |
| 3 | Implement REGISTRY split; slim `COMPONENTS.md` | Steward |
| 4 | Add 3 seams + 2 strategies (Proposed); document seams→adr in `CORE.md` | Steward |
| 5 | Add Maintenance Proposals to `process/BUILD-DISCLOSURE.md` | Steward |
| 6 | Use build rounds as **sensor passes** — aggregate proposals, curate lifecycle | Ongoing |

**No shootout gate** before step 2. Ship when the three decisions in §4 are agreed; learn from use.

---

## 10. Success Measures for Phase 2.1

Phase 2.1 is not successful because new folders exist. **Good enough** in the 1.2C window:

| Signal | What good enough looks like |
|--------|----------------------------|
| **Traceability** | High-severity inventions cite a seam, strategy, ADR, or explicit doc gap |
| **Maintenance loop** | Build reports include scannable Maintenance Proposals rows stewards can aggregate |
| **Curation** | At least one Proposed → Active or Active → Deprecated transition driven by real use |
| **Weight discipline** | File count grows slower than new *named* concerns (not slower than code) |

**Directional signals (not pass/fail):**

| Signal | Observation |
|--------|-------------|
| Reduced undocumented invention | Fewer untraceable high-severity inventions in Invention Summary |
| Registry referenced | Agents cite `REGISTRY.md` for load order in build reports |
| Component fidelity | Handler registration and contract completeness stable or improving |

Invention remains **diagnostic signal**. The goal is routing it to gaps, ADRs, seams, or strategies — not eliminating it in one round.

---

## 11. Steward Alignment Summary

| Topic | Research position after Steward review |
|-------|----------------------------------------|
| Emergent curation | Adopted — Phase 2.1 is one step in longer Ribosome evolution |
| Seams vs strategies | Adopted — distinct categories |
| Earn-your-file + fast-path | Adopted — two-of-four + link/promote from Era B / `adr/` |
| Prototype cap | Adopted — 3 seams + 2 strategies |
| Maintenance Proposals table | Adopted — sole agent maintenance channel during builds |
| Recipe / ingredients / connector | Adopted — with REGISTRY split per §4.2 |
| Shootout gate | Rejected — ship prototype on decision agreement |

---

*End of revised document — prepared for Research confirmation and Steward prototype fork.*