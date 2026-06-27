# Preflight Report Template

**Purpose:**  
A lightweight, reusable gate to assess readiness before treating a phase, idea, decision, process change, or any other artifact as "ready" for the next stage (handoff to Steward, active pursuit, implementation, etc.).

This is **not** a final design or exhaustive audit. It is a high-signal checkpoint to force explicit reflection and surface gaps early.

**Usage Instructions:**
1. Copy this file and rename it for the specific item (e.g. `Phase-2.1-Preflight-2026-06-25.md` or `Structure-Builder-Pattern-2026-06-24.md`).
2. Fill in only the relevant sections. Delete or mark N/A for irrelevant criteria.
3. Be brutally honest about gaps.
4. End with a clear **Verdict**.
5. Save the completed report in:
   - `Records/Logs/` for steward preflights (see `PROCESS.md`).
   - `Phases/{id}/` at phase root for phase-specific research handoff notes.
   - `Ideas/` when still internal exploration.
6. Update `Current-Context.md` or the relevant Backlog item with the outcome.

---

## Metadata

**Date:** YYYY-MM-DD  
**Preflight For:** [Phase X.Y / Idea Name / Decision / Process / Other]  
**Type:** Phase | Idea | Decision | Process Change | Other  
**Author:** Research (Grok)  
**Related Artifacts:** [List key files, e.g. PHASE_2_1_PROJECTS_RESTRUCTURE_PLAN-2026-06-24.md, Decision-04-..., Memory Capsule]  
**Previous Related Preflights:** [None / Link to prior]

---

## Context & Scope

Brief description of what is being evaluated and why now.

What does "readiness" mean in this specific case?

---

## Core Readiness Criteria

Use or adapt these categories. Mark status and provide brief evidence.

### 1. Decision Lock-in & Clarity
- Core decisions are explicitly recorded and marked **Locked** (with date and approver where applicable).
- Rationale and trade-offs are captured (not just the conclusion).
- Open questions are listed and owned.

**Status:** [Ready / Partial / Not Ready]  
**Evidence / Gaps:**

### 2. Alignment with Core Principles
- Fits the **Specification Pipeline** model (Recipe + Connector + Ingredients).
- Respects **Structure Builder** pattern where relevant (COMPONENTS / REGISTRY / PLUGIN).
- Follows conservative, intentional specialization (smallest viable set, avoid Experiment 05 fragmentation).
- Clear role boundaries (Steward owns architecture; operational roles handle day-to-day).

**Status:** [Ready / Partial / Not Ready]  
**Evidence / Gaps:**

### 3. High-Signal Artifacts
- Necessary documentation exists at the right fidelity (not bloated, not underspecified).
- Tensions and Strategies (where relevant) are visible and categorized.
- Reflection / lessons from prior work have been internalized or documented.

**Status:** [Ready / Partial / Not Ready]  
**Evidence / Gaps:**

### 4. Handoff / Execution Readiness
- The item can be understood and acted on by the Steward without requiring Research to stay involved.
- Risks, dependencies, and "unknown unknowns" are surfaced.
- Next concrete actions are defined and owned.

**Status:** [Ready / Partial / Not Ready]  
**Evidence / Gaps:**

### 5. Custom Criteria (add as needed)
- [Your criterion here]

**Status:** [Ready / Partial / Not Ready]  
**Evidence / Gaps:**

---

## Assessment

What feels solid?  
What feels fragile or incomplete?  
Any emergent patterns or tensions noticed during this preflight?

---

## Open Questions & Risks

List the most important unresolved items. Prioritize.

1. 
2. 

---

## Verdict

**Overall Readiness:**  
**Ready** | **Ready with Conditions** | **Not Ready** | **Needs More Research**

**Conditions (if any):**

**Rationale (2-4 sentences):**

---

## Recommendations & Next Steps

- Immediate actions
- Who owns what
- Suggested follow-up preflight trigger (e.g. "After first real build using this phase")

---

**End of Preflight Report**

*This template should be updated as our principles evolve. Keep it high-signal.*