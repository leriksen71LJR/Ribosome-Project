# Reduce Conceptual / Prose-Heavy Language in Core Documents

**Date:** 2026-06-20  
**Priority:** Medium-High  
**Complexity:** Medium  
**Phase:** 2.2+

## Problem

Sections in `ARCHITECTURE.md` and `CODING_DESIGN.md` use high-level conceptual language ("rich, complex object graph", "Strategy by List elsewhere where it fits", etc.) that requires significant interpretation. This increases variance between agents and moves the documentation away from a pseudo-code / executable style.

## Observed Evidence

- Claude and Codex both highlighted interpretive language as a source of potential divergence.
- Vague phrases force agents to make different architectural and implementation decisions.

## Proposed Solution

- Review `ARCHITECTURE.md` and `CODING_DESIGN.md` for high-interpretation sections.
- Where possible, replace or supplement conceptual descriptions with more concrete rules, checklists, or decision procedures.
- Consider moving purely conceptual/explanatory content to a separate "Design Rationale" document in Research (or a dedicated section) rather than mixing it with executable instructions.

## Expected Benefit

- Lowers variance on structural and design decisions.
- Moves the documentation system closer to the "Documentation as Pseudo Code" goal.
- Makes core agent-visible documents more focused and less ambiguous.
