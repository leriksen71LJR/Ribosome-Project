# Fortress Research Backlog

**Purpose**  
This backlog captures ideas, improvements, open questions, and potential directions for the Fortress documentation system and Ribosome Model.  
It lives in `Research/` because this is human thinking space — not yet ready for agents.

## How to Use This Backlog

1. Add new ideas as individual files in the `Ideas/` folder (one idea per file is preferred for easier ranking and discussion).
2. Update the master list below with Priority, Complexity, and suggested Phase.
3. Before moving an idea into active Phase 2 work, promote the relevant thinking into `Project/` documentation.

## Master Backlog Summary

| ID | Idea / Topic | Priority | Complexity | Suggested Phase | Status | Notes |
|----|--------------|----------|------------|------------------|--------|-------|
| 001 | Ribosome Model formalization & first Workflow Handler implementation | High | Medium | 2.1 | Proposed | Core direction |
| 002 | Documentation Audit as mandatory workflow step | High | Low | 2.1 | In Progress | Already partially implemented |
| 003 | Explicit Workflow Handler registration pattern | High | Medium | 2.1 | Proposed | Extensibility mechanism |
| 004 | Reasoning Disclosure / observability tooling | Medium | Low | 2.1 or 2.2 | Tooling ready | Detailed description in `Ideas/Reasoning-Disclosure-Tool.md`. Forces agents to produce structured reasoning artifacts before coding. |
| 005 | Stronger enforcement language ("Spanish Inquisition") patterns | Medium | Medium | 2.2 | Research | Needs examples |
| 006 | Backlog + ranking process itself | Low | Low | Meta | Active | This document |
| 007 | Add explicit Decision Procedures for ambiguous rule situations | High | Medium | 2.1 | Proposed | From Claude Reasoning Disclosure run. Major source of agent variance. |
| 008 | Reconcile contradictory folder structure between AGENTS.md and ARCHITECTURE.md | High | Low | 2.1 | Proposed | Direct contradiction that forces agents to adjudicate. |
| 009 | Resolve Execute vs ExecuteAsync inconsistency across documents | High | Low | 2.1 | Proposed | Core interface signature conflict. |
| 010 | Reduce conceptual/prose-heavy language in ARCHITECTURE.md and CODING_DESIGN.md | Medium | Medium | 2.2 | Proposed | Increases interpretation load and variance. |
| 011 | Restore or inline missing PHASE_1_1_IMPROVEMENTS.md content | Medium | Low | 2.1 | Proposed | Critical requirements only exist as summaries. |
| ... | (Add more as discovered) | - | - | - | - | - |

## Legend

- **Priority**: High / Medium / Low
- **Complexity**: Low / Medium / High
- **Status**: Proposed / Researching / Ready for Phase X / Done

_Last updated: 2026-06-26 (Session 002)_

## New Items from Reasoning Disclosure Analysis (2026-06-20)

| ID | Title | Priority | Complexity | Phase | Status |
|----|-------|----------|------------|-------|--------|
| 012 | Missing Decision Procedures for Ambiguous Rules | High | Medium | 2.1 / 2.2 | New |
| 013 | Stale Examples Override Current Rules | High | Low-Medium | 2.1 | New |
| 014 | Missing PHASE_1_1_IMPROVEMENTS.md Specification | High | Low | 2.1 | New |
| 015 | Reduce Conceptual/Prose-Heavy Language in Core Documents | Medium-High | Medium | 2.2+ | New |

---

## Phase 2.1 Closure (Session 002, 2026-06-26)

Phase 2.1 research work is considered complete from the Research layer perspective (see `Phases/2.1/Phase-2.1-Preflight-2026-06-25.md`).

**Locked Decisions (1-4):**
- Tensions/ as unified model
- COMPONENTS = Recipe+Contract, REGISTRY = Connector (Structure Builder)
- `.documents/` + `.codingAgent/` two-zone model
- "Specification Pipeline" as the name for the 3-layer pattern

**Status:** Ready with Conditions (formal Steward review / Decision-04 handoff pending).

**Next Research Focus:** Phase 2.2 ideas (Memory Palaces, specialized agents across the Specification Pipeline, 5 strategic paths, domain-specific pipelines).

Many original backlog items 001-015 have been addressed via Experiment 07 outcomes and the PHASE_2_1_PROJECTS_RESTRUCTURE_PLAN. New Phase 2.2 items should be captured as individual Idea files rather than extending this table.
