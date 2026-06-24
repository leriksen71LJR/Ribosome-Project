# Steward Response — Experiment 07 Phase 2.1 Guidance

**Date:** 2026-06-23  
**In response to:** [007/Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-0452.md](Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-0452.md)  
**Context:** Experiment 06 DI-pattern package committed; plan-mode review (`BUILD-REPORT-2026-06-21-001-GrokBuild`, outcome `blocked`, 8/10 doc executability) received well by Research  
**Audience:** Research / Lead Researcher  
**Posture:** Thinking-partner response — positions offered, not a finished design

---

## 1. Executive Summary

**Overall direction: supported.** The guidance document correctly identifies what Experiment 06 solved (plugin-shaped T0 mRNA, collapsed process) and what remains implicit (cross-cutting seams, behavioral strategies, connector layer between recipe and ingredients).

Phase 2.1 should be treated as **infrastructure for learning how to curate** seams and strategies — not as a one-shot design pass whose correctness is proven in a single build round. Seams and strategies are **emergent**; we discover how to manage them across many phases, not in Phase 1.2C alone.

We endorse the contemplative tone, the earn-your-file threshold, the prototype cap (3 seams + 2 strategies), lifecycle status, and the Documentation Maintenance Proposals table. Three structural decisions need steward agreement before implementation: **`seams/` vs `adr/`**, **`REGISTRY.md` vs `COMPONENTS.md` split**, and **agent write boundaries** during builds.

---

## 2. Alignment with Experiment History

| Experiment | Lesson relevant to Phase 2.1 |
|------------|------------------------------|
| **05** | Cross-cutting concerns deserve names — but fine-grained Workflow/Seams trees created fragmentation and stub mRNA |
| **06** | `CORE` + `COMPONENTS` + `PLUGIN.md` + collapsed `adr/` restored executability; plan-mode audit scored 8/10 |
| **Era B** | Invention often came from missing **strategy** clarity, not missing contracts (encryption keying, save semantics, archive) |

Phase 2.1 should apply Experiment 05’s *insight* (name cross-cutting concerns) at Experiment 06’s *grain* (coarse, plugin-aligned, capped growth) — exactly what the guidance document argues.

---

## 3. Emergent Seams and Strategies (Steward Position)

We do **not** expect Phase 2.1 — or any single shootout in Phase 1.2C — to establish a complete, proven catalog of seams and strategies.

| Expectation | Rationale |
|-------------|-----------|
| Seams/strategies **emerge** from friction, divergence, and steward judgment over time | One build round is a point sample, not validation of the ontology |
| Early files start as **Proposed**, not canon | Matches the lifecycle model in §4.4 of the guidance plan |
| Phase 2.1 success = **better traceability and curation habit**, not zero invention | Invention remains diagnostic signal; the goal is routing it to gaps, ADRs, seams, or strategies |
| 1.2C has insufficient time and information to “close” the seam/strategy set | Phase 2.1 is one step in a longer Ribosome evolution |

**Revised success emphasis (additive to guidance §10):**

| Signal | Phase 2.1 “good enough” |
|--------|-------------------------|
| Traceability | High-severity inventions cite a seam, strategy, ADR, or explicit doc gap |
| Maintenance loop | Build reports include scannable Maintenance Proposals rows stewards can aggregate |
| Curation | At least one Proposed → Active or Active → Deprecated transition driven by real use |
| Weight discipline | File count grows slower than new *named* concerns (not slower than code) |

We should **not** gate Phase 2.1 on a control/treatment shootout pair. Ship the prototype when steward agrees on the three structural decisions below; learn from use.

---

## 4. Strong Agreement

### 4.1 Seams distinct from strategies

Experiment 05 conflated boundary risk (Seams) with behavioral recipes (Process-Strategies). Separating them is high leverage. Seams mark *where tension lives*; strategies mark *which approach we chose* when multiple are reasonable.

### 4.2 Earn-your-file threshold

Two-of-four criteria (cross-cutting, measured divergence, likely recur, hiding causes drift) is workable. **Steward addition:** fast-path if Era B cluster or existing `adr/` already documents the concern — promote or link rather than duplicate.

### 4.3 Prototype scope cap

Maximum 3 seam files + 2 strategy files on first pass — essential guard against Exp05-style sprawl.

### 4.4 Lifecycle status

Proposed / Active / Deprecated / Retired on seam and strategy files directly addresses zombie-artifact risk and supports emergent curation.

### 4.5 Documentation Maintenance Proposals table

Strong fit for Era C combined reports. Complements Invention Summary (what was invented) with steward-actionable maintenance signal (what doc should change). Keeps agents as **sensors**, not editors.

### 4.6 Recipe / ingredients / connector metaphor

Maps onto Exp06:

| Role | Exp06 | Phase 2.1 |
|------|-------|-----------|
| Recipe | `CORE.md`, `COMPONENTS.md` | Slim `COMPONENTS.md` to philosophy + pattern |
| Ingredients | `components/*/PLUGIN.md` | Unchanged |
| Connector | *embedded in* `COMPONENTS.md` today | `components/REGISTRY.md` (hypothesis to test) |

Apply only where it reduces invention or improves clarity — not reflexively.

---

## 5. Decisions Needed Before Implementation

### 5.1 `seams/` vs existing `adr/` (Exp06)

Experiment 06 collapsed Exp05 `Seams/` into **`adr/`** (six records + `REGISTRY.md`). Introducing **`seams/`** without a clear rule risks parallel trees — the fragmentation Phase 2.1 aims to avoid.

**Steward recommendation (Option A):**

| Layer | Purpose |
|-------|---------|
| **`seams/`** | Boundary catalog — risk points, triggers, links; status often **Proposed** or **Active** |
| **`adr/`** | Accepted decisions — resolution, consequences, acceptance criteria |
| **Flow** | Seam surfaces tension → steward/agent flags gap → ADR records decision → seam links to ADR |

Document this relationship in `CORE.md` in one short section. Do not let agents maintain two competing authorities.

**Question for Research:** Does Option A match your intent, or should `adr/` be retired in favor of `seams/` only?

### 5.2 `REGISTRY.md` vs `COMPONENTS.md`

Today `COMPONENTS.md` holds plugin load order, contract, and inventory table. `REGISTRY.md` only adds value if **inventory and cross-links move out** of `COMPONENTS.md`.

**Steward recommendation:**

- **`COMPONENTS.md`** — component pattern, plugin contract, Open/Closed rules, technology stack  
- **`REGISTRY.md`** — load order, dependency map, `PLUGIN.md` links, seam/strategy/ADR cross-refs  

Update mandatory read order once. Measure whether agents cite REGISTRY in build reports — directional signal, not pass/fail.

### 5.3 Agent write boundaries during builds

Guidance §4.2 suggests agents may append Maintenance Notes to seam/strategy files. Exp06 **`process/AGENTS.md` Rule 5** treats `.docs/` as read-only except `Builds/`.

**Steward recommendation:** Keep docs read-only during builds. Channel all agent maintenance signal through:

1. BUILD-REPORT — **Documentation Maintenance Proposals** table (required when non-empty)  
2. Optional steward queue file under `Builds/` if aggregation is needed  

No in-place edits to seam/strategy/ADR files during routine shootouts.

---

## 6. Suggested First Prototype Set (Seeds, Not Canon)

Seed from Era B / Exp06 plan-mode gaps. Status: **Proposed** until use promotes them.

| Type | Candidate | Notes |
|------|-----------|-------|
| Seam | Wrong-password / first-run UX | Plan-mode Medium gap; spread across Security plugin |
| Seam | Schema bootstrap | Two valid paths in Infrastructure plugin |
| Seam | Export-backup edges | Light spec in Actions plugin |
| Strategy | Save strategy | `adr/0004` exists — candidate to elevate as Active strategy doc |
| Strategy | Disclosure + maintenance | Era C report shape + Maintenance Proposals table |

Defer visibility, error-handling, and other strategies until a build cites recurring divergence.

---

## 7. Proposed Way Forward

| Step | Action | Owner |
|------|--------|-------|
| 1 | Research reviews this response + guidance plan | Research |
| 2 | Resolve three decisions: seams/adr, REGISTRY split, agent write boundary | Steward + Research |
| 3 | Implement Phase 2.1 prototype on **Experiment 07** branch (fork from Exp06) — not live `Fortress/Project/` | Steward |
| 4 | Add Maintenance Proposals section to `process/BUILD-DISCLOSURE.md` in prototype | Steward |
| 5 | Use build rounds as **sensor passes** — aggregate proposals over time, curate lifecycle | Ongoing |

No requirement for a single shootout to “validate” the seam/strategy set before step 3.

---

## 8. Responses to Open Questions (Guidance §8)

| Question | Steward position |
|----------|------------------|
| Line between `COMPONENTS.md`, `REGISTRY.md`, `PLUGIN.md` | Philosophy/pattern → COMPONENTS; map/links/order → REGISTRY; executable mRNA → PLUGIN |
| Minimum viable `REGISTRY.md` | One screen: load order table, dependency edges, plugin links, seam/strategy/ADR index — no duplicated rules |
| When something earns its own file | Two-of-four threshold + lifecycle Proposed; promote on repeat invention or explicit steward call |
| Avoid Exp05 fragmentation | Cap growth (3+2 prototype), single connector (REGISTRY), clear seams→adr flow, retirement status |
| Agent maintenance responsibility | Read, cite, propose in report table — do not edit seam/strategy files during builds |
| What does success look like in 1.2C? | Traceability + usable maintenance signal + curation habit — not a complete seam catalog |

---

## 9. File Locations (Repository)

| Document | Link | Full path (copy) |
|----------|------|------------------|
| Phase 2.1 guidance (Research upload) | [007/Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-0452.md](Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-0452.md) | `c:\Users\lerik\source\repos\fortress-design\Fortress\Research\Ribosome\Experiments\007\Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-0452.md` |
| This steward response | [007/Experiment-07-Steward-Response-2026-06-23.md](Experiment-07-Steward-Response-2026-06-23.md) | `c:\Users\lerik\source\repos\fortress-design\Fortress\Research\Ribosome\Experiments\007\Experiment-07-Steward-Response-2026-06-23.md` |
| Experiment 07 index | [007/README.md](README.md) | `c:\Users\lerik\source\repos\fortress-design\Fortress\Research\Ribosome\Experiments\007\README.md` |
| Experiments index | [Experiments/README.md](../README.md) | `c:\Users\lerik\source\repos\fortress-design\Fortress\Research\Ribosome\Experiments\README.md` |
| Exp06 baseline (unchanged until fork) | [006/README.md](../006/README.md) | `c:\Users\lerik\source\repos\fortress-design\Fortress\Research\Ribosome\Experiments\006\README.md` |

Research-only until Phase 2.1 prototype is approved. Do not modify live `Fortress/Project/` export without explicit steward decision.

---

## 10. Closing

The guidance plan is the right next contemplation after Experiment 06. We support moving forward with a **small, emergent, curated** Phase 2.1 prototype — not a comprehensive seam/strategy taxonomy and not shootout-gated proof.

We welcome Research’s view on the three pre-implementation decisions (§5) and on whether the revised success emphasis (§3) matches how Lead Researcher wants to evaluate Phase 2.1 in the 1.2C window.

**Update:** Research revised guidance — [007/Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-REVISED.md](Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-REVISED.md). **Decision 1 (2026-06-23):** Option A superseded by unified `tensions/` — [Research report](Decision-1-Tensions-Concept-Report-for-Steward-2026-06-23.md), [Steward accept](Experiment-07-Steward-Response-Decision-1-Tensions-2026-06-23.md).

---

*Prepared for Research handoff. Steward / build-side perspective.*