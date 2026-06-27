# Idea: Structure Builder Pattern

**Date:** 2026-06-24  
**Status:** Working Name Locked

## Summary

We have chosen **Structure Builder** as the working name for the reusable three-layer architectural pattern currently represented by:

- `COMPONENTS.md` (Recipe / High-level rules)
- `REGISTRY.md` (Connector / Mediation layer)
- `PLUGIN.md` files (Ingredients / Executable detail)

## Rationale

- The pattern actively **builds real, usable structure** from higher-level intent.
- "Structure" was preferred over "Architecture" because it feels more concrete and closer to what the pattern produces (components, agents, memory systems, strategies, etc.).
- "Builder" clearly communicates that the pattern has a **making / producing** quality.
- The name stays practical and avoids sounding overly metaphorical or forced.

## How It Works

This pattern takes raw, high-level intent and progressively transforms it into concrete, structured, buildable output through three distinct layers. The middle layer (`REGISTRY.md`) plays the critical role of mediating and organizing the relationship between the abstract recipe and the concrete implementation.

## Future Use

This pattern is intended to be reusable. It can potentially be applied beyond components to other areas such as:
- Agent roles and memory structures
- Domain-specific pipelines (Tasks, Payments, Scheduling, etc.)
- Other architectural concerns as the system evolves

## Status

- **Working name:** Structure Builder
- This name is now the default when referring to the C + R + P pattern in documentation and discussion.
- We can revisit the name later if a stronger alternative emerges.

---

*Saved as a formal idea for future reference.*