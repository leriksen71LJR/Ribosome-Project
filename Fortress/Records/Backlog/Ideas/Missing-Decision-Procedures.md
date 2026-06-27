# Missing Decision Procedures for Ambiguous Rules

**Date:** 2026-06-20  
**Priority:** High  
**Complexity:** Medium  
**Phase:** 2.1 / 2.2

## Problem

When documentation contains contradictions or ambiguities (e.g. folder structure conflict between `AGENTS.md` and `ARCHITECTURE.md`, `Execute` vs `ExecuteAsync`), agents are forced to make high-impact decisions without guidance. This leads to high variance between agents and silent deviation from intent.

## Observed Evidence

- All three agents (Claude, Grok Build, Codex) independently identified multiple contradictions.
- Agents resolved conflicts differently or with varying levels of confidence.
- No document provides a clear "tie-breaker" or decision procedure when rules conflict.

## Proposed Solution

Create a short, explicit **"Conflict Resolution & Decision Procedures"** section in `AGENTS.md` (or a dedicated small document referenced by it) that defines:

- Clear precedence order between documents (e.g. User Prompt > `AGENTS.md` > `ARCHITECTURE.md` > `CODING_DESIGN.md` > Examples).
- How to handle missing referenced files (e.g. `PHASE_1_1_IMPROVEMENTS.md`).
- When to report vs. when to choose one interpretation.
- A lightweight "Decision Log" requirement in the build report when the agent had to make a non-obvious choice.

## Expected Benefit

- Significantly lower variance between agents on structural decisions.
- Makes deviations visible and auditable rather than silent.
- Strengthens the "Documentation as Pseudo Code" model by reducing the need for agent judgment on core rules.
