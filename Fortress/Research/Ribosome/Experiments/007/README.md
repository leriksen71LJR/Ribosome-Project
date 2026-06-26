# Experiment 07 — Phase 2.1 Documentation Architecture

**Status:** **Closed** — Director final call on Decisions 1–3; prototype forked to `Fortress/Projects/2.1/` (2026-06-26)  
**Date:** 2026-06-23  
**Builds on:** [006/README.md](../006/README.md) (DI-pattern plugins)

---

## Purpose

Explore how to evolve Experiment 06 with explicit **seams**, **strategies**, and a **connector** layer (`REGISTRY.md`) — without recreating Experiment 05 fragmentation.

Phase 2.1 treats seams and strategies as **emergent**; curation learns over many phases, not one shootout.

---

## Artifacts

| Document | Path | Role |
|----------|------|------|
| **Research guidance (revised)** | [007/Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-REVISED.md](Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-REVISED.md) | Post-Steward guidance — **current**; adopts three pre-implementation decisions |
| **Research guidance (original upload)** | [007/Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-0452.md](Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-0452.md) | Lead Researcher draft — preserved; superseded by REVISED |
| **Steward response** | [007/Experiment-07-Steward-Response-2026-06-23.md](Experiment-07-Steward-Response-2026-06-23.md) | Build/steward review incorporated into REVISED |
| **Decision 1 — Tensions report (Research)** | [007/Decision-1-Tensions-Concept-Report-for-Steward-2026-06-23.md](Decision-1-Tensions-Concept-Report-for-Steward-2026-06-23.md) | Unified `tensions/` replaces `seams/` + `adr/` |
| **Decision 1 — Steward response** | [007/Experiment-07-Steward-Response-Decision-1-Tensions-2026-06-23.md](Experiment-07-Steward-Response-Decision-1-Tensions-2026-06-23.md) | **Accept** with guardrails; prototype fork cleared to plan |
| **Decision 2 — Registry split (Research)** | [007/Decision-2-Registry-vs-Components-Split-Report-for-Steward-2026-06-23.md](Decision-2-Registry-vs-Components-Split-Report-for-Steward-2026-06-23.md) | Supports steward split; contract stays in COMPONENTS |
| **Decision 2 — Steward response** | [007/Experiment-07-Steward-Response-Decision-2-Registry-2026-06-23.md](Experiment-07-Steward-Response-Decision-2-Registry-2026-06-23.md) | **Agree** — no iteration needed |
| **Decision 3 — Agent write boundaries (Research)** | [007/Decision-3-Agent-Write-Boundaries-Report-for-Steward-2026-06-23.md](Decision-3-Agent-Write-Boundaries-Report-for-Steward-2026-06-23.md) | `.documents/` + `.codingAgent/` structural split |
| **Decision 3 — Steward response** | [007/Experiment-07-Steward-Response-Decision-3-Agent-Write-2026-06-23.md](Experiment-07-Steward-Response-Decision-3-Agent-Write-2026-06-23.md) | **Accept** — `.documents/` + `.codingAgent/` per Director |
| **Director final call (1–3)** | [007/Experiment-07-Director-Final-Call-Decisions-1-2-3-2026-06-23.md](Experiment-07-Director-Final-Call-Decisions-1-2-3-2026-06-23.md) | **Closed** — Research handoff authority |

---

## Related

| Item | Path |
|------|------|
| Exp06 baseline | [006/README.md](../006/README.md) |
| Exp06 plan-mode report | [006/Builds/BUILD-REPORT-2026-06-21-001-GrokBuild.md](../006/Builds/BUILD-REPORT-2026-06-21-001-GrokBuild.md) |
| Experiments index | [Experiments/README.md](../README.md) |

---

**Not in this folder yet:** shootout zip, `.docs/` tree — added when Phase 2.1 prototype is approved.