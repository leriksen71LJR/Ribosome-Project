# Decision 2: `REGISTRY.md` vs `COMPONENTS.md` Split

**Date:** 2026-06-23  
**Context:** Phase 2.1 Guidance – Steward Response Review  
**Status:** Research Position Prepared for Steward Review

---

## Summary of the Question

Should we introduce a `REGISTRY.md` as a distinct connector layer, or should inventory, load order, and cross-references remain inside `COMPONENTS.md`?

---

## Steward's Position

The Steward recommends a clean separation:

- **`COMPONENTS.md`** should focus on the **general recipe**:
  - Component pattern philosophy
  - Plugin contract and validation rules
  - Open/Closed Principle guidance
  - Technology stack and architectural constraints
  - Design principles that apply to *all* components

- **`REGISTRY.md`** should focus on **mapping and inventory**:
  - Component inventory
  - Load/registration order
  - Dependency relationships between components
  - Links to each component’s `PLUGIN.md`
  - Cross-references to relevant Tensions and Strategies

This is a direct application of the Recipe / Ingredients / Connector model.

---

## Research Position

**We support the Steward's proposed split**, with one refinement:

- `COMPONENTS.md` should **retain ownership** of the plugin contract, validation expectations, and core component rules. These are still part of the stable "recipe."
- `REGISTRY.md` should own the **inventory, load order, dependency map, and cross-references**.

### Rationale

| Current Problem | How the Split Helps |
|-----------------|---------------------|
| `COMPONENTS.md` mixes stable philosophy with frequently changing inventory/tables | Each document has a clearer, more stable purpose |
| Inventory and cross-references change more often than core rules | `REGISTRY.md` can evolve without touching the philosophical core |
| Agents sometimes struggle to find "where things relate" | `REGISTRY.md` becomes the single, obvious place for relationships and navigation |
| Risk of `COMPONENTS.md` becoming bloated over time | Intentional granularity is protected |

### Benefits of Supporting This Split

- Strengthens the **Connector** layer in the Recipe/Ingredients/Connector model without adding unnecessary weight.
- Makes `COMPONENTS.md` more focused and durable as the philosophical foundation.
- Gives Build Agents a clearer mental model: "Philosophy and rules live in COMPONENTS; relationships and where to look live in REGISTRY."
- Aligns with the goal of reducing invention caused by unclear navigation.

---

## Recommendation

We recommend proceeding with the split as described by the Steward, with the refinement that `COMPONENTS.md` keeps the plugin contract and validation rules.

This keeps the "recipe" layer authoritative while giving the "connector" layer a clear home.

---

## Question for the Steward

Do you agree with Research's refinement (that `COMPONENTS.md` should retain the plugin contract and core validation rules), or would you prefer those to move into `REGISTRY.md` as well?

---

*Prepared by Research for Steward review — one decision at a time.*