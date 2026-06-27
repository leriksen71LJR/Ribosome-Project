# Idea: Specialized Agents Across the Specification Pipeline

**Date:** 2026-06-24  
**Status:** Working idea  
**Related:** Memory Palace idea, Structure Builder pattern, Phase 2.2

## Core Concept

As the project evolves toward a multi-stage **Specification Pipeline**, the idea of using one general-purpose Build Agent becomes increasingly limiting. Different stages of the pipeline have very different cognitive and behavioral requirements.

This idea explores assigning **specialized agents** to different stages, with clearly defined roles, responsibilities, and levels of invention permission.

### Role Distinction: Steward vs Pipeline Operations

We are making a deliberate distinction between two roles:

- **Steward**: Owns the *architecture and documentation design*. This includes the overall structure of the pipeline, the design of the Memory Palace, the rules for agent behavior, and the philosophy of the system.
- **Pipeline Manager / Operator**: Would be responsible for the *day-to-day operation* of the pipeline — coordinating specialized agents, managing memory updates during builds, and handling reflection processes.

The Director (Mr. Bear) supports this separation. This keeps the Steward focused on high-level architecture and design integrity rather than operational execution.

## Pipeline Stages and Recommended Agents

| Stage | Primary Agent | Multiple Agents? | Invention Permission | Key Responsibilities | Notes |
|-------|---------------|------------------|----------------------|----------------------|-------|
| Discovery | Explorer | Yes (2–3) | Low–Medium | Surface unknown tensions and patterns | Benefits from diverse perspectives |
| Analysis & Invention | Analyst | Yes (limited) | Medium–High | Evaluate when invention is justified | Sensitive stage — needs judgment |
| Strategy & Tension Work | Strategist | Yes (primary + reviewer) | Medium | Create, validate, and manage strategies & tensions | Highest governance impact |
| Design | Architect | Usually 1 (+ reviewer) | Low–Medium | Design components and relationships | Needs consistency |
| Implementation (Build) | Builder | Usually 1 | Very Low | Write code while following existing patterns | Strong preference for single agent |
| Reflection & Memory | Reflector | Yes (2–3 with different lenses) | N/A | Distill experience into high-quality memory | Highest leverage for long-term learning |
| Validation & Disclosure | Auditor | Yes (1 worker + 1 reviewer) | Low | Review output and generate disclosures | Improves quality |

## Key Insights

### 1. The Build Stage is Different

The Implementation stage benefits **least** from multiple agents. It values consistency, style coherence, and low invention more than diversity of thought. Having multiple Builder agents tends to increase style drift and hidden invention.

**Recommendation:** Start with a single focused Builder agent. Consider adding a separate Auditor/Reviewer agent instead of multiple builders.

### 2. Reflection is Extremely High Value

The Reflection stage is one of the highest-leverage places to introduce multiple specialized agents. Different Reflector agents can focus on technical lessons, governance implications, memory quality, and long-term patterns.

### 3. Strategy Work Needs Strong Governance

The Strategist role has significant governance implications. Multiple Strategist agents can improve quality through review and challenge, but this also increases the risk of conflicting strategies. Strong governance processes are required (whether led by the Steward in a design capacity or by a separate Pipeline Manager role in day-to-day operations).

## Risks of Over-Specialization

- Increased governance complexity (especially around coordination between specialized agents)
- Potential for conflicting proposals between agents
- Higher chance of memory becoming noisy or contradictory
- Risk of recreating Experiment 05-style fragmentation
- Potential overload on the Steward if operational responsibilities are not clearly separated from architectural design responsibilities

## Recommended Starting Approach (Phase 2.2)

Start conservatively with:

- **Explorer** (Discovery)
- **Strategist** (Strategy & Tension work)
- **Builder** (Implementation) — single agent
- **Reflector** (Reflection & Memory)

Add additional agents (Analyst, Architect, Auditor) only after the core pipeline and Memory Palace are working well.

---

*This idea treats agent specialization as a gradual evolution rather than a sudden overhaul, with careful attention to where multiplicity adds value versus where it creates risk.*
