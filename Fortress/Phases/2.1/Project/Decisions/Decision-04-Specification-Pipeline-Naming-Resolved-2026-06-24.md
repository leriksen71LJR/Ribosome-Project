# Decision 04: Specification Pipeline Naming

**Date:** 2026-06-24  
**Status:** Resolved  
**Related to:** Phase 2.2 Long-term Direction  
**Reminder:** Send to Steward — Tomorrow evening at earliest

---

## Decision

We have adopted **"Specification Pipeline"** as the working name for the three-layer documentation architecture pattern (Recipe + Connector + Ingredients).

---

## Rationale

- **Evocative**: Clearly communicates flow and progressive transformation of specifications into working code.
- **Simple**: Familiar pattern language (similar to Pipeline, Factory, Strategy, Builder).
- **Accurate**: Makes it explicit that "build" is only one stage in a larger process, not the entire system.
- **Aligned with Ribosome thinking**: Supports the idea of documentation moving through stages of refinement and translation.
- **Scalable**: Naturally accommodates future stages and specialized behavior at different points in the pipeline.
- **Grounded in existing practice**: The current structure of `COMPONENTS.md` + `REGISTRY.md` + `PLUGIN.md` already functions as a working Specification Pipeline:
  - `COMPONENTS.md` = Recipe layer (general philosophy and contracts)
  - `REGISTRY.md` = Mapping / Translation layer (inventory, relationships, cross-references)
  - `PLUGIN.md` = Ingredients / Executable Detail layer (component-specific implementation guidance)

This name replaces earlier proposals such as "Connector Pattern", "Layered Translation Pattern", and "Documentation Pipeline".

---

## Implications

- We will begin using **Specification Pipeline** consistently in Phase 2.2 research and future Steward communications.
- This name should influence how we talk about stages, agent roles, and the `.codingAgent/` workspace.
- Future work on multi-stage workflows and custom agents per stage should be framed within the Specification Pipeline concept.

---

## Open Questions

- Should we eventually create a short, canonical definition of the Specification Pipeline (similar to how we might define Tensions or Strategies)?
- How does the Specification Pipeline concept interact with the idea of Custom Agents per Workflow Stage?

---

*This decision is ready to be shared with the Steward.*