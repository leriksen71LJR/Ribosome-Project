# Ribosome Model

**Status:** Primary Research Direction  
**Date:** June 2026

---

## Core Metaphor

We are building our own **ribosome** — the first workflow engine where documentation itself is the execution machinery.

| Biological Concept     | Fortress Equivalent                  | Role |
|------------------------|--------------------------------------|------|
| **mRNA**               | Spec / Task / Feature Request        | Pure data (what to build) |
| **Ribosome**           | Workflow Documentation               | The engine / process (how to build) |
| **tRNA + Amino Acids** | Agent + Tools + Context              | The environment that executes the ribosome |
| **Protein**            | Working code + tests + build report  | The functional output |

---

## Core Principles

1. **Spec = Data**  
   A task or feature request is pure information. It contains no process instructions.

2. **Workflow = Stateless Process**  
   The workflow document defines the *process*, not accumulated state. State lives in artifacts the agent produces (build reports, code, context files).

3. **Separation of Concerns**  
   Requirements (what) and process (how) must remain strictly separated.

4. **Explicit Registration + Parent Orchestration**  
   Workflow extensions (handlers/procedures) are **explicitly listed** by a parent workflow document. They are not auto-discovered plugins.

5. **Strong Enforcement**  
   The agent is first enticed by good structure. When structure alone is insufficient, hard rules and violation consequences ("Spanish Inquisition") are applied.

6. **There Can Be Only One**  
   At the top level, there is one primary workflow engine. Multiple specialized procedures can exist, but they are orchestrated by the parent ribosome.

---

## Why This Model

Most current approaches still treat documentation as **fuel** for an intelligent agent.

The Ribosome Model flips this:
- Documentation **is** the engine.
- The agent is the environment that runs the engine.
- Fidelity comes from structural design, not from the model being clever enough to stay on track.

This gives us a path toward more reliable, auditable, and evolvable agent behavior.

---

## Current State

This model is still **emerging research**. It is not yet fully implemented in the build-facing documentation (`Project/`). The goal of Phase 2 is to begin translating this model into concrete workflow documents, procedures, and enforcement mechanisms.

**Related Research:** [Experiment 03 — Composite Restructuring](Ribosome/Experiments/Experiment-03-Composite-Restructuring-2026-06-21.md) proposes a `.docs/` layout (Core / Workflow / Seams / Quality / Perspectives / Archive) informed by Build Disclosure shootout evidence.

---

*This document is the north star for the Ribosome Model. It lives in `Research/` and must not be given to build agents.*