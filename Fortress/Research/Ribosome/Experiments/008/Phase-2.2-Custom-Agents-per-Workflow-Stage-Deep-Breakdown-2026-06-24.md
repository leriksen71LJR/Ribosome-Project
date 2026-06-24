# Phase 2.2: Custom Agents per Workflow Stage — Deep Breakdown

**Date:** 2026-06-24  
**Status:** Initial Exploration — steward reviewed 2026-06-24  
**Related Concepts:** Specification Pipeline, Ribosome Model, .documents vs .codingAgent, Controlled Invention, Tensions, Strategies

---

## Beyond the Obvious

At first glance, "Custom Agents per Workflow Stage" sounds like a straightforward specialization strategy: one agent optimized for discovery, another for analysis, another for building, etc.

However, when we connect this idea to our established patterns and philosophy, it becomes significantly more interesting — and more consequential.

---

## 1. Relationship to the Specification Pipeline

If we adopt **Specification Pipeline** as the core metaphor, then each stage is not just a phase of work — it is a **distinct translation step** with its own inputs, outputs, invariants, and failure modes.

This has deeper implications:

- Each stage may require **different reasoning styles**, context management strategies, and tolerance for ambiguity.
- A single general-purpose agent forced to context-switch across all stages may be fundamentally inefficient or lossy (similar to how a ribosome doesn't also perform transcription).
- Specialized agents could maintain **stage-specific contracts** — clearer expectations about what "good output" looks like at that point in the pipeline.

This moves us from "one smart agent that does everything" toward **a system of cooperating translators**, each optimized for its position in the Specification Pipeline.

---

## 2. Interaction with .documents vs .codingAgent

This idea has strong implications for our newly decided folder structure:

- **.documents/** remains the authoritative source of truth (contracts, tensions, strategies, component definitions).
- **.codingAgent/** becomes the **persistent working memory and proposal space** for the entire pipeline.

If we have specialized agents per stage, then `.codingAgent/` may need internal structure:
- Stage-specific subfolders or namespaces (`discovery/`, `analysis/`, `strategy/`, `build/`, etc.)
- Clear handoff protocols between agents
- Versioned proposals that survive across stages

Without this, we risk losing the traceability that the Specification Pipeline is meant to provide.

---

## 3. Connection to Controlled Invention

One of the most important non-obvious benefits:

Specialized agents may make **controlled invention** more tractable.

- A general agent often invents when it shouldn't (because it's unsure which rules apply).
- A stage-specialized agent could have much clearer boundaries: "In the Strategy stage, I am allowed/expected to propose new strategies when existing ones are insufficient."

This creates natural **invention gates** aligned with the pipeline stages rather than relying on a single agent to self-regulate its invention behavior.

---

## 4. Governance and Steward Implications

If we move toward custom agents per stage, the Steward's role evolves:

- The Steward is no longer just curating documentation.
- The Steward may also need to curate **agent role definitions** and **stage contracts**.
- This increases the surface area of what needs governance, but potentially decreases the Steward's need to intervene in low-level invention decisions (because the agents have clearer scopes).

This aligns with the "Steward as documentation architect + process curator" role we've been developing.

---

## 5. Risk: Echoes of Experiment 05 Fragmentation

We must be careful here.

Experiment 05 showed us that excessive granularity (too many small files, too many specialized structures) creates navigation overhead and maintenance burden.

Custom agents per stage could fall into the same trap if we over-specialize too early:
- Too many agent types
- Complex handoff logic between agents
- Difficulty maintaining consistency across the pipeline

The lesson from Experiment 05 suggests we should start with **very few, high-value specializations** rather than one agent per micro-stage.

A more conservative starting point might be:
- **Explorer Agent** (Discovery + Analysis)
- **Strategist Agent** (Strategy creation/refinement + Tension surfacing)
- **Builder Agent** (Implementation + Validation)

With clear contracts between them.

---

## 6. Relationship to Tensions and Strategies

Specialized agents could change how Tensions and Strategies are created and maintained:

- A Strategist Agent might be explicitly responsible for proposing new strategies when it detects recurring invention or friction.
- A Risk Analyst Agent (or the Risk stage) could be responsible for surfacing new Tensions.
- This creates a more **active, role-based model** for how the documentation system evolves, rather than relying solely on human-initiated or build-report-driven proposals.

This is a significant shift in the **agency of the system itself**.

---

## Initial Assessment

| Dimension                    | Assessment                                                                 | Risk Level |
|-----------------------------|-----------------------------------------------------------------------------|------------|
| Alignment with Specification Pipeline | Very High — strengthens the pipeline metaphor                             | Low        |
| Governance implications      | Medium — increases Steward scope but may improve clarity                    | Medium     |
| Risk of over-fragmentation   | Medium-High if we create too many agent types too quickly                   | Medium     |
| Support for Controlled Invention | High — clearer boundaries make intentional invention more feasible       | Low        |
| Traceability & .codingAgent/ | Requires internal structure in .codingAgent/ to maintain handoffs           | Medium     |
| Long-term maintainability    | Depends heavily on how disciplined we are about agent role definitions      | Medium     |

---

## Open Questions Worth Holding

1. What is the **minimum viable set** of specialized agents to start with in Phase 2.2?
2. Should agent specialization be **explicitly declared** in documentation (similar to how components declare their PLUGIN.md), or should it emerge more organically?
3. How do we prevent specialized agents from developing **incompatible mental models** of the system over time?
4. Does the Steward need new tooling or processes to curate agent role definitions alongside tensions and strategies?

---

This idea is more powerful — and more dangerous — than it first appears. It has the potential to significantly improve both **intentionality** and **governance**, but only if we resist the temptation to over-specialize too early.

---

*Initial deep exploration. Steward review: [Experiment-08-Steward-Response-Phase-2.2-2026-06-24.md](Experiment-08-Steward-Response-Phase-2.2-2026-06-24.md).*