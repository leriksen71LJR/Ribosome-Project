# Idea: 20 Exploratory Paths for Phase 2.2 and Beyond

**Date:** 2026-06-24  
**Status:** Initial exploration  
**Type:** Strategic research idea

---

## Purpose

This document explores 20 plausible but currently unexplored directions the Fortress / Ribosome project could take after Phase 2.1 stabilizes. These paths go beyond the topics we have already discussed (multi-stage workflows, custom agents per stage, domain-specific pipelines, controlled invention, and the Specification Pipeline model).

The goal is to surface genuinely new angles rather than incremental refinements of existing ideas.

---

## 20 Unexplored Paths

| # | Path Name | One-Sentence Description |
|---|-----------|--------------------------|
| 1 | Agent Self-Reflection Loops | Agents are required to periodically review their own past decisions and surface inconsistencies or drift without human prompting. |
| 2 | Specification Mutation Testing | Intentionally introduce small mutations into documentation and measure how well agents detect and respond to the change. |
| 3 | Tension Forecasting Engine | Build mechanisms that predict which tensions are likely to emerge in the next 3–6 months based on current system evolution signals. |
| 4 | Agent Apprenticeship Model | New agents start with limited authority and must earn trust by having their proposals reviewed and accepted by more experienced agents or the Steward. |
| 5 | Specification Pipeline as a DAG | Move from a linear pipeline to a directed acyclic graph where stages can branch, merge, and run in parallel depending on context. |
| 6 | Documentation Debt as a First-Class Metric | Treat accumulated undocumented decisions and tensions as a measurable, trackable form of technical debt with its own dashboards and alerts. |
| 7 | Cross-Domain Tension Propagation | When a tension is resolved in one domain, automatically detect and propose related tension updates in other domains that may be affected. |
| 8 | Agent Reputation and Trust Scoring | Agents accumulate a "trust score" based on the quality and longevity of their proposals that get promoted into `.documents/`. |
| 9 | Multi-Modal Specification Authoring | Allow specifications to exist in multiple forms (structured text, diagrams, formal contracts, examples) that are kept in sync automatically. |
| 10 | Post-Mortem as Structured Pipeline Input | Turn every significant failure or near-miss into a structured input that automatically creates or updates tensions and strategies. |
| 11 | Dynamic Stage Activation | Workflow stages are not fixed in advance; they activate or deactivate based on real-time signals from the codebase and previous agent behavior. |
| 12 | Specification Federation | Multiple independent Specification Pipelines (across different projects or teams) can reference and inherit from each other in controlled ways. |
| 13 | Agent Memory Palaces | Give agents structured, long-term, queryable memory stores that persist across many builds and phases, organized by tension and strategy. |
| 14 | Governance by Distributed Stewards | Move from a single Steward to a small group of Stewards who must reach consensus on major structural changes. |
| 15 | Automated Drift Detection Between Code and Documentation | Continuously scan the codebase for behavior that diverges from documented tensions, strategies, or contracts and raise structured alerts. |
| 16 | Specification Pipeline for Non-Code Artifacts | Apply the same pipeline model to tests, infrastructure-as-code, runbooks, and user-facing documentation. |
| 17 | Intent Provenance Tracking | Every line of generated code carries traceable metadata back to the specific tension, strategy, or decision that justified it. |
| 18 | Agent "Why" Interviews | After a build, agents can be queried in a structured way about *why* they made certain decisions, producing richer disclosure than current reports. |
| 19 | Specification Pipeline + Formal Verification | Integrate lightweight formal methods or property-based testing directly into the pipeline so some tensions can be mechanically verified. |
| 20 | Living Architecture Decision Records | Turn tensions and strategies into living documents that evolve with the system rather than becoming frozen historical artifacts. |

---

## Top 5 Paths — Selected for Depth and Leverage

After reviewing all 20, these five stand out as having the highest combination of:
- Novelty (we have not seriously explored them yet)
- Leverage on current Phase 2.1 foundations
- Long-term strategic value
- Manageable risk of fragmentation

### 1. Agent Self-Reflection Loops

**Core Idea:**  
Build a recurring process where agents are periodically required to review their own past behavior, decisions, and inventions — without waiting for a human to ask — and surface patterns of drift, inconsistency, or recurring invention.

**Phase A – Foundation (Near-term)**
- Define what "self-reflection" means in this context (scope, frequency, output format).
- Create a lightweight mechanism for agents to query their own recent build history and disclosure reports.
- Pilot a simple monthly self-reflection report that agents must produce and store in `.codingAgent/`.

**Phase B – Maturation**
- Develop structured reflection templates that force agents to compare current behavior against documented tensions and strategies.
- Introduce the concept of "reflection debt" — when an agent skips or produces shallow reflections.
- Begin surfacing recurring self-identified issues as candidate tensions.

**Phase C – Scale & Integration**
- Make self-reflection a mandatory stage in the Specification Pipeline for certain classes of work.
- Allow high-quality self-reflections to directly propose new tensions or strategy updates (with Steward review).
- Explore whether certain agents can be granted limited authority to resolve low-risk tensions based on strong self-reflection evidence.

**Why This Path Matters:**  
It shifts agents from purely reactive participants to active participants in maintaining the integrity of the system over time.

---

### 2. Tension Forecasting Engine

**Core Idea:**  
Instead of only reacting to tensions after they cause invention or pain, build mechanisms that can *predict* which areas of the system are likely to develop significant tensions in the near future.

**Phase A – Foundation**
- Identify leading indicators that historically precede the emergence of high-impact tensions (e.g., rapid growth in a component, frequent small inventions in an area, increasing cross-component calls).
- Create a simple scoring model or set of heuristics that flags "tension-prone" areas.
- Pilot a quarterly "Tension Forecast Report" produced during a dedicated workflow stage.

**Phase B – Maturation**
- Refine the forecasting model using real data from Phase 2.1 builds.
- Introduce the concept of "preemptive tension seeding" — creating lightweight Proposed tensions in areas the model flags as high-risk.
- Begin measuring the accuracy of forecasts (how many predicted tensions actually materialized).

**Phase C – Scale & Integration**
- Make tension forecasting a continuous background process rather than a periodic report.
- Allow the forecasting system to propose new tensions directly into `.codingAgent/` for Steward review.
- Explore integration with architectural fitness functions or other observability signals.

**Why This Path Matters:**  
It moves governance from reactive to proactive, which could significantly reduce the cost of invention over time.

---

### 3. Specification Pipeline as a DAG (Non-Linear)

**Core Idea:**  
Move away from the assumption that the Specification Pipeline is strictly linear. Instead, allow stages to branch, merge, run in parallel, or be skipped based on context, risk, or previous outcomes.

**Phase A – Foundation**
- Define the minimal set of valid stage relationships (sequential, parallel, conditional, merging).
- Create a simple declarative way to describe pipeline shapes for different classes of work.
- Pilot one non-linear workflow (e.g., parallel discovery + risk assessment stages that later merge).

**Phase B – Maturation**
- Develop clear rules for how information and decisions flow across parallel or branching stages.
- Introduce the concept of "stage contracts" — explicit expectations about what each stage must produce for downstream stages.
- Begin tracking which pipeline shapes correlate with better or worse outcomes (invention volume, Steward review load, build quality).

**Phase C – Scale & Integration**
- Allow dynamic pipeline reshaping at runtime based on real-time signals (e.g., if high uncertainty is detected, automatically activate an extra validation stage).
- Support reusable pipeline fragments that can be composed into larger workflows.
- Explore whether different domains or risk profiles should have fundamentally different pipeline topologies by default.

**Why This Path Matters:**  
A linear pipeline is simple but eventually becomes a bottleneck. A DAG model is more expressive and may better match how real architectural work actually happens.

---

### 4. Agent Apprenticeship Model

**Core Idea:**  
Treat agent capability as something that develops over time rather than assuming all agents are equally trusted from the start. New or lower-trust agents operate under tighter constraints and must earn greater autonomy through demonstrated quality.

**Phase A – Foundation**
- Define a simple trust/competence tier system for agents (e.g., Apprentice → Journeyman → Master).
- Establish clear boundaries on what each tier is allowed to do without additional review (e.g., Apprentices can only propose, Masters can resolve certain classes of low-risk tensions).
- Pilot the model with one or two agents in a controlled build round.

**Phase B – Maturation**
- Develop mechanisms for agents to "level up" based on observable signals (proposal acceptance rate, quality of self-reflections, longevity of promoted decisions).
- Create structured feedback loops where the Steward or more senior agents can explicitly coach or correct junior agents.
- Begin tracking aggregate metrics on how the apprenticeship model affects overall invention volume and Steward workload.

**Phase C – Scale & Integration**
- Allow high-trust agents to take on limited curation responsibilities (e.g., triaging proposals from lower-trust agents before they reach the Steward).
- Explore whether apprenticeship can be partially automated (e.g., an agent’s "mentor" could be another specialized agent).
- Consider whether human Stewards should also have visible "apprenticeship" relationships with each other for major architectural decisions.

**Why This Path Matters:**  
It provides a more humane and realistic model of capability development while creating natural boundaries that protect governance as the number of agents grows.

---

### 5. Post-Mortem as Structured Pipeline Input

**Core Idea:**  
Treat every significant failure, near-miss, or surprising outcome not as a one-off retrospective, but as structured, first-class input that automatically feeds back into the Specification Pipeline — creating or updating tensions, strategies, and forecasts.

**Phase A – Foundation**
- Define a lightweight but structured post-mortem format that captures root causes, contributing tensions, and proposed strategy changes.
- Create a mandatory step in the workflow after any high-severity incident or near-miss.
- Pilot feeding post-mortem outputs directly into `.codingAgent/` as draft tension or strategy updates.

**Phase B – Maturation**
- Develop patterns for how different classes of incidents should map to different types of pipeline updates (new tension, strategy refinement, forecast adjustment, etc.).
- Begin measuring whether post-mortem-driven updates lead to measurable reductions in similar incidents over time.
- Introduce the concept of "post-mortem debt" — incidents that were not properly processed back into the pipeline.

**Phase C – Scale & Integration**
- Automate parts of the post-mortem ingestion process (e.g., extracting candidate tensions from incident reports).
- Allow high-quality post-mortems to trigger automatic creation of Proposed tensions (with Steward review gates).
- Explore whether recurring post-mortem patterns can feed into the Tension Forecasting Engine (Path 2).

**Why This Path Matters:**  
It closes the loop between real-world outcomes and the evolution of the specification system, making the pipeline genuinely learning-oriented rather than purely prescriptive.

---

## Promising Combinations

While the five paths above are strong on their own, several ideas from outside the top 5 have meaningful synergy when combined with them (or with each other). These combinations often produce more value together than either idea would in isolation.

### High-Potential Combinations

| Combination | Ideas Involved | Why It Works Well | Strategic Value | Difficulty |
|-------------|----------------|-------------------|------------------|------------|
| **Apprenticeship + Reputation/Trust Scoring** | Path 4 + Path 8 | Trust scoring gives the Apprenticeship model a concrete, measurable mechanism for "leveling up". Without it, apprenticeship remains conceptual and hard to govern. | Very High | Medium |
| **Self-Reflection Loops + Automated Drift Detection** | Path 1 + Path 15 | Drift detection gives self-reflection something concrete and ongoing to work on. Self-reflection gives drift detection semantic understanding instead of just mechanical alerts. | High | Medium |
| **Post-Mortem Feedback + Intent Provenance Tracking** | Path 5 + Path 17 | Makes post-mortems dramatically more powerful by allowing traceability back to the original tension, strategy, or decision that led to the outcome. | High | Medium-High |
| **Tension Forecasting + Cross-Domain Tension Propagation** | Path 2 + Path 7 | Forecasting becomes significantly more strategic when it can predict not just local tensions, but also how resolving one tension may create or surface tensions in other domains. | High | Medium |
| **Agent Memory Palaces as Foundational Layer** | Path 13 supporting Paths 1, 4, and 5 | Long-term, queryable memory makes Self-Reflection, Apprenticeship, and rich Post-Mortem feedback actually feasible over long periods and across many builds. | Medium-High | High |
| **Living ADRs + Post-Mortem Feedback** | Path 20 + Path 5 | Turns static Architecture Decision Records into evolving artifacts that are continuously updated by real outcomes (via post-mortems). Natural evolution of how we currently handle tensions. | Medium-High | Medium |

### Key Insight on Combinations

The most promising combinations tend to create **closed feedback loops**:
- Something generates signal (Drift Detection, Post-Mortems, Self-Reflection)
- Something interprets and structures that signal (Memory Palaces, Provenance Tracking)
- Something acts on it with appropriate authority (Apprenticeship tiers, Trust Scoring, Forecasting)

This suggests that the highest-leverage future work may not be in any single path, but in designing the **interaction layer** between these mechanisms.

---

## Summary Assessment

These five paths are deliberately diverse:

- **Path 1 (Self-Reflection)** focuses on agent internal process.
- **Path 2 (Tension Forecasting)** focuses on proactive governance.
- **Path 3 (Pipeline as DAG)** focuses on workflow topology.
- **Path 4 (Apprenticeship)** focuses on capability development and trust boundaries.
- **Path 5 (Post-Mortem Feedback)** focuses on closing the learning loop from real outcomes.

They are not mutually exclusive. In fact, several of them reinforce each other (e.g., Self-Reflection + Apprenticeship, Tension Forecasting + Post-Mortem Feedback, DAG Pipeline + Apprenticeship tiers).

A pragmatic approach would be to treat **Path 5 (Post-Mortem as Structured Input)** as a strong forcing function that could help surface which of the other paths are most valuable in practice.

---

*This document is intended as a living exploration of possible futures rather than a commitment to any specific direction.*

---

## Clarifying Summary

This document serves two purposes:

1. **Broad Exploration** — It surfaces 20 plausible but currently unexplored directions the project could take after Phase 2.1 stabilizes. These go beyond the topics we have already discussed in depth (multi-stage workflows, custom agents, domain-specific pipelines, controlled invention, and the Specification Pipeline model).

2. **Focused Prioritization + Combination Thinking** — It identifies a top 5 set of paths worth deeper consideration and highlights several high-value combinations between ideas (both within and outside the top 5). The combinations section is particularly important because many of these ideas are not mutually exclusive — their real power often emerges when they are deliberately connected.

The overarching theme across the strongest ideas is **closing feedback loops** between agent behavior, real-world outcomes, governance mechanisms, and the evolution of the specification itself. The most promising future work appears to lie in designing the *interaction layers* between these mechanisms rather than optimizing any single mechanism in isolation.

This is a living document. New paths and combinations can (and should) be added as the project evolves.