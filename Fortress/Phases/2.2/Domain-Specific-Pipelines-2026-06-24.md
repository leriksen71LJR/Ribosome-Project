# Phase 2.2 Idea: Domain-Specific Specification Pipelines

**Date:** 2026-06-24  
**Status:** Initial capture  
**Related Concepts:** Specification Pipeline, Custom Agents per Workflow Stage, .codingAgent/ workspace, tensions/, strategies/

---

## The Idea

If the **Specification Pipeline** pattern proves successful at the system level, it will eventually hit a scaling limit.

A single global `COMPONENTS.md` + `REGISTRY.md` + `PLUGIN.md` structure becomes insufficient once the system grows beyond a certain size and complexity. Instead, we would need to segment components into **domain-specific Specification Pipelines**.

### Examples

- **Tasks domain** would have its own:
  - `tasks/COMPONENTS.md` (or equivalent)
  - `tasks/REGISTRY.md`
  - `tasks/.../PLUGIN.md` files

- **Payments domain** would have a completely separate pipeline.

- **Scheduling domain** would have another.

Each domain would own its own Recipe → Connector → Ingredients pipeline, tailored to the specific concerns, invariants, and workflows of that domain.

---

## Initial Thoughts

This idea feels like a natural and almost inevitable evolution if the core Specification Pipeline model delivers value.

### Why It Makes Sense

- **Cognitive load management**: A single global pipeline eventually becomes too large for any human or agent to hold in working memory. Domain-specific pipelines allow focused reasoning within bounded contexts.
- **Stronger alignment with Domain-Driven Design**: This mirrors the idea of Bounded Contexts. Each domain can evolve its own contracts, patterns, and strategies without forcing global consensus on every decision.
- **Better governance isolation**: Tensions and strategies that are highly specific to one domain (e.g., payment retry logic or task scheduling constraints) can live closer to the code they affect, rather than polluting a global namespace.
- **Enables specialized agents more naturally**: If we pursue Custom Agents per Workflow Stage, having domain-specific pipelines makes it even more powerful. You could have agents that are not just stage-specialized but also *domain-specialized* (e.g., a Payments Strategist agent vs a Tasks Strategist agent).
- **Reduces cross-domain coupling**: Changes in one domain’s pipeline have less risk of accidentally affecting unrelated areas.

### Risks and Challenges

- **Fragmentation risk (Experiment 05 echo)**: If taken too far or too quickly, we could recreate the over-fragmentation problems we saw in Experiment 05. The cure could become worse than the disease.
- **Cross-domain tensions and strategies**: Some concerns will inevitably span domains (e.g., audit logging, security policies, data consistency rules). We would need a clean way to express and govern these without creating a messy “global vs local” split.
- **Navigation and discoverability**: Humans and agents would need reliable ways to know which pipeline applies to a given problem. A top-level registry or discovery mechanism might become necessary.
- **Consistency tax**: Different domains might evolve slightly different conventions, making it harder to move between them or maintain system-wide coherence over time.
- **Governance overhead**: The Steward role would become more complex — responsible for both domain-level pipelines *and* cross-cutting concerns.

### Relationship to Other Phase 2.2 Ideas

This idea pairs very naturally with **Custom Agents per Workflow Stage**. If we have multiple Specification Pipelines, it becomes even more compelling to have agents that are specialized not just by stage (Discovery, Strategy, Build), but also by domain (e.g., a Payments Strategist vs a Tasks Strategist).

It also puts more pressure on the design of the **`.codingAgent/`** workspace. We would likely need clearer internal structure (domain-specific subfolders or namespaces) so that proposals and drafts don’t bleed across domains.

### Deeper Implications

- **Bounded Contexts for Reasoning**: This is essentially applying Domain-Driven Design’s concept of Bounded Contexts to the documentation and agent reasoning layer. Each domain gets its own coherent Specification Pipeline, reducing cognitive load and allowing domains to evolve at different rates.
- **Amplifies Controlled Invention**: Domain-specific pipelines make it easier to define where controlled invention is encouraged (e.g., in early strategy stages within Payments) versus where it should be tightly constrained (e.g., in implementation stages).
- **Governance Expansion**: The Steward role grows in complexity. They must now curate not only tensions and strategies *within* domains, but also cross-domain concerns. This is both a scaling challenge and a necessary evolution if the system grows large.
- **Timing**: This is a “when we succeed” idea, not a “do this now” idea. It only becomes relevant after the single global Specification Pipeline has proven valuable and starts showing signs of strain (e.g., `REGISTRY.md` becoming unwieldy, recurring cross-domain tensions, or agents struggling with context). We should validate the base model in Phase 2.1 first.

### Open Question

At what point does a system cross the threshold where one Specification Pipeline is no longer enough? Is it purely a function of size/complexity, or are there specific signals (recurring cross-domain tensions, cognitive overload in `REGISTRY.md`, etc.) that should trigger this segmentation?

---

## Status

This is recorded as an early strategic idea for Phase 2.2 and beyond. It should be revisited once Phase 2.1 is stood up and we have real usage data from the single-pipeline model.

*Captured from user direction on 2026-06-24.*