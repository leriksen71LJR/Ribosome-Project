# Documentation Boundaries — Research vs Build Documentation

> **This document is for human researchers only.**  
> It defines rules about how we (the researchers) must handle documentation.  
> **Build agents must never see or reference this document.**

**Date:** June 17, 2026  
**Status:** Core Principle (Human Researchers Only)

---

## Core Principle

This project treats documentation as an emergent, evolving system. Because of this, we must maintain **strict separation** between two distinct layers:

- **Research Documentation** — The thinking space where we explore, question, refine, and develop new models and structures.
- **Build Documentation** — The curated, stable product that is given to agents to actually build software.

**Build documentation is a product of research. It is not the same as research.**

We must not allow leakage between these two layers.

---

## Why This Separation Matters

1. **Protect the Integrity of Research**  
   Research often contains half-formed ideas, comparisons, rejected approaches, and exploratory thinking. Exposing this to agents pollutes their context and can cause them to follow experimental or abandoned paths.

2. **Keep Agents Focused on Execution**  
   Build agents should operate against a clean, intentional set of workflow documents, procedures, and standards — not against the messy history of how we arrived at those decisions.

3. **Enable Clean Feedback Loops**  
   When agents audit documentation, they should only audit the build documentation. This gives us clearer signal about what actually works in practice, without noise from research documents.

4. **Preserve the Ribosome Model**  
   The Ribosome Model depends on clean separation between *process* (workflow) and *data* (spec/task). Allowing research documents to leak into the agent’s view breaks this separation at the meta level.

---

## Rules for Human Researchers

- **Research folder is human-only space.**  
  `.docs/Research/` must never be copied into agent working directories or included in agent handoff packages.

- **Build documentation is derived from research, but is a separate artifact.**  
  When we decide a research idea is ready, we promote it into the build documentation (e.g., moving a concept from `Research/` into `Workflows/`, `Procedures/`, or `Evaluation/`).

- **Agents must never see Research documents.**  
  Any instruction, prompt, or script that prepares material for agents must explicitly exclude the `Research/` folder.

- **Auditing and evaluation by agents must only be performed on build documentation.**  
  If we need an agent to analyze or critique something, we give it only the curated build documentation, never the raw research.

---

## Practical Implications

- When running builds (via `Run-PhaseX.ps1` or manual setup), the `Research/` folder must be excluded from the documents copied to the agent’s working directory.
- When creating handoff zips or shootout packages, create a clean “Build Documentation Only” subset.
- All documents inside `.docs/Research/` should carry a clear header stating they are for human researchers only.
- `AGENTS.md` and all agent-facing prompts should contain an explicit prohibition against reading or referencing anything inside a `Research/` folder.

---

*This document exists to protect the clarity and intentionality of the system we are building.*
