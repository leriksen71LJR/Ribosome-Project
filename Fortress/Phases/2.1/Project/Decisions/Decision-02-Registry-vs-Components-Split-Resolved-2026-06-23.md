# Decision 02: REGISTRY.md vs COMPONENTS.md Split

**Date Resolved:** 2026-06-23  
**Status:** Accepted by Steward  
**Related to:** Phase 2.1 Guidance – Experiment 07

---

## Decision

We will implement a clean separation between `COMPONENTS.md` and `REGISTRY.md`:

- **`COMPONENTS.md`** will focus on the **general recipe**:
  - Component pattern philosophy and design principles
  - Plugin contract rules and validation expectations
  - Open/Closed Principle guidance
  - Technology stack and architectural constraints
  - Rules that apply to *all* components

- **`REGISTRY.md`** will focus on **mapping and inventory**:
  - Component inventory (what exists)
  - Load/registration order
  - Dependency relationships between components
  - Links to each component’s `PLUGIN.md`
  - Cross-references to relevant Tensions and Strategies

---

## Rationale

This split applies the **Recipe / Ingredients / Connector** model cleanly:

- `COMPONENTS.md` becomes the stable, high-level “recipe” document.
- `REGISTRY.md` becomes the practical “connector” that agents and humans consult when they need to understand relationships, ordering, and where to find things.

The current `COMPONENTS.md` mixes both types of content, which makes it harder to maintain and less clear in purpose. This split improves clarity, reduces bloat in the core philosophy document, and strengthens the Connector layer without adding unnecessary weight.

---

## Positions

| Role       | Position |
|------------|----------|
| **Steward**    | Proposed the clean split. Wants `COMPONENTS.md` focused on philosophy/pattern and `REGISTRY.md` focused on inventory, load order, and cross-references. |
| **Research**   | Supports the split with one refinement: `COMPONENTS.md` should retain ownership of the plugin contract, validation expectations, and core component rules (these are still part of the “recipe”). |

Both parties agree this is the right direction.

---

## Follow-up Actions

- Migrate inventory-style content (load order, dependency map, plugin links) from the current `COMPONENTS.md` into the new `REGISTRY.md`.
- Update mandatory read order in `process/AGENTS.md` once `REGISTRY.md` exists.
- Monitor whether agents begin citing `REGISTRY.md` in build reports (directional signal).

---

**Recorded by:** Research  
**Approved by:** Steward