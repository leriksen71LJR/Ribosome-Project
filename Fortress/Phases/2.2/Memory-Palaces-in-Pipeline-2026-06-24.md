# Idea: Agent Memory Palaces and Guided Reflection in the Specification Pipeline

**Date:** 2026-06-24  
**Status:** Working idea  
**Related:** Specification Pipeline, Structure Builder pattern, Phase 2.2 direction

## Core Concept

As we move toward a multi-stage Specification Pipeline (where "build" is only one stage), agents will need persistent, structured memory that survives across stages and builds. The current approach of relying solely on context windows or simple `.codingAgent/` notes is insufficient for long-term coherence and learning.

This idea proposes a **Memory Palace** — a structured, governable memory system — combined with deliberate **Reflection Phases** as first-class stages in the pipeline.

### Role Distinction: Steward vs Pipeline Operations

We are making a deliberate distinction between two roles:

- **Steward**: Owns the *architecture and documentation design*. This includes the design of the Memory Palace structure, the rules for how memory should be used, and the overall philosophy of the system.
- **Pipeline Manager / Operator**: Would be responsible for the *day-to-day operation* of the pipeline, including coordinating memory updates during builds and managing reflection processes.

The Director (Mr. Bear) supports this separation. This keeps the Steward focused on architectural design rather than operational curation of memory.

## Key Components

### 1. Memory Palace Structure

```
.codingAgent/memory/
├── shared/                    # Accessible to all agents
│   ├── tensions/
│   ├── strategies/
│   ├── patterns/
│   ├── lessons-learned/
│   └── system-insights/
│
├── explorer/                  # Role-specific memory (optional)
├── strategist/
├── builder/
└── reflector/
```

### 2. Guided Reflection Phases

Instead of agents passively writing notes, we introduce structured **Reflection Phases** at key points in the pipeline:

- End of Discovery
- End of Strategy & Tension work
- End of Implementation (Build)
- After major discoveries or failures

During these phases, agents follow a structured prompt to distill experience into high-quality memory entries rather than dumping raw thoughts.

### 3. Governance Principles

- All memory remains in readable markdown.
- The Steward has full visibility and override authority over the *design* of the Memory Palace.
- Day-to-day curation and quality control of memory entries would primarily be handled through automated rules and structured reflection processes, with periodic human oversight (potentially by a Pipeline Manager role rather than the Steward).
- Important entries can be promoted into `.documents/`.
- Agents should not have unrestricted ability to delete or overwrite memory.

## Benefits

- Reduces context loss across stages and builds
- Enables meaningful long-term learning
- Supports specialized agents by giving them role-appropriate memory
- Keeps memory transparent and governable (avoids black-box problems)

## Risks & Considerations

- Risk of memory becoming noisy or contradictory if not curated
- Potential operational overhead if day-to-day memory curation is not clearly assigned (e.g., to a Pipeline Manager role rather than the Steward)
- Need for strong reflection prompts to maintain quality
- Risk of the Steward becoming overloaded if operational responsibilities are not separated from architectural design responsibilities

## Open Questions

- Should memory be mostly shared, or should specialized agents have significant private memory?
- How frequently should memory be reviewed and cleaned, and by whom (the Steward in a design/oversight capacity, or a separate Pipeline Manager role)?
- What is the right balance between agent autonomy in writing memory versus structured human oversight?

---

*This idea treats memory not as a passive store, but as an active, structured layer within the Specification Pipeline.*
