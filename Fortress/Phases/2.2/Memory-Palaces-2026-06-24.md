# Idea: Agent Memory Palaces + Guided Reflection Phases

**Date:** 2026-06-24  
**Status:** Working idea  
**Related Concepts:** Specification Pipeline, `.codingAgent/`, Controlled Invention, Self-Reflection

---

## Core Concept

Give agents a structured, persistent, and human-readable long-term memory system (Memory Palaces) combined with deliberate **reflection phases** that turn raw experience into clean, high-quality knowledge.

This is **not** a black-box external memory service. It is built using the coding agent itself + structured markdown files inside `.codingAgent/`.

---

## Key Design Principles

- **Transparent & Governable**: Everything must be easily readable and reviewable by the Steward. No opaque systems.
- **Robust to Current Agent Capabilities**: Must work well even if agents do not become dramatically smarter in the next 6–12 months. Relies on structure and process more than advanced intelligence.
- **Integrated into the Specification Pipeline**: Memory and reflection are treated as deliberate stages/steps within the overall multi-stage workflow, not as separate features.
- **Hybrid Memory Model**: Support both shared memory (across agents) and per-agent memory as needed.

---

## Proposed Structure

### 1. Memory Palace Location

`.codingAgent/memory/`

Recommended top-level folders to start:

- `core-tensions/`
- `strategies/`
- `patterns/`
- `lessons-learned/`
- `domain-knowledge/`
- `self-profile.md` (for the agent’s understanding of its own role and limitations)

### 2. File Structure Best Practice (Newest on Top + Summary)

For individual memory files, use this structure:

```markdown
# Tension: Wrong Password UX

## Current Status (as of 2026-06-24)
**Status:** Open  
**Last Updated By:** Explorer Agent  
**Key Insight:** The current flow causes agents to invent inconsistent error handling behaviors.

---

## History

### 2026-06-20
...

### 2026-06-24
...
```

**Why this works:**
- Agents see the most important current state immediately.
- The Steward can quickly review recent changes.
- History is preserved without forcing the agent to read everything every time.
- Scales better than pure “newest on top” as files grow.

### 3. Guided Reflection Phase

After significant work (end of a build, end of a major stage, or after discovering something important), the agent goes through a structured reflection step.

The agent is given a clear prompt that forces it to:
- Analyze what happened
- Extract real insights (not just restate events)
- Distill those insights into clean, structured entries
- Update the appropriate Memory Palace files

This acts as the “dreaming / consolidation” phase.

---

## Integration with the Specification Pipeline

Reflection and memory updates should be treated as **explicit stages** in the workflow, not optional side activities. For example:

1. Discovery
2. Analysis
3. Strategy / Tension Work
4. Implementation (Build)
5. **Reflection & Memory Consolidation**
6. Disclosure

This keeps memory work intentional and visible rather than ad-hoc.

---

## Governance & Backup Plan

- All memory content is **readable** by the Steward.
- The Steward can promote high-value memories into the authoritative `.documents/` layer (especially new tensions or strategies).
- The system is designed to remain useful even without major advances in agent intelligence. It relies on clear structure, consistent templates, and human oversight.

---

## Open Questions

- Should we start with one shared memory palace or per-role memory palaces?
- How aggressively should we prune or archive old memory entries?
- What is the right cadence for reflection (after every build, after every stage, or only when something significant happens)?

---

*This idea is designed to be practical, governable, and aligned with the Specification Pipeline philosophy. It prioritizes clarity and human oversight over relying on future agent capabilities.*
