# Decision 1 Report: Unified Tension Records

**For:** Steward  
**From:** Research  
**Date:** 2026-06-23  
**Context:** Response to Steward feedback on Experiment 07 Phase 2.1 Guidance  
**Focus:** Resolving the `seams/` vs `adr/` structural decision

---

## Summary

Research proposes replacing the two-folder model (`seams/` + `adr/`) with a **single unified structure** called `tensions/`.

This is a deliberate synthesis that honors the Steward's core concerns while significantly reducing structural overhead and long-term maintenance burden.

---

## The Problem with Maintaining Two Folders

Keeping both `seams/` and `adr/` creates several issues:

- **Fragmentation risk**: Two parallel trees increase the chance of information living in the wrong place or becoming inconsistent over time.
- **Link maintenance overhead**: Every resolved seam would need to be linked to its corresponding ADR (and potentially vice versa). This is manual work that must be kept accurate.
- **Cognitive load**: Agents and humans must understand and navigate two different concepts and folder structures.
- **Historical fragmentation**: This pattern contributed to the problems we saw in Experiment 05.

The Steward correctly identified the risk of parallel systems. Research agrees that we should not accept that overhead.

---

## Proposed Solution: Unified `tensions/` Folder

Instead of two folders, we recommend a single folder called `tensions/`.

Each file is a **Tension Record** that can represent both:

- An **open point of friction, risk, or ambiguity**, and
- The **eventual resolution** of that tension.

### Tension Record Structure (Proposed)

```markdown
# Tension: [Clear, Descriptive Name]

## Status
Open | Resolved | Deprecated

## Description
What is the point of friction, ambiguity, risk, or recurring difficulty?

## Why It Matters
Why does this tension deserve explicit attention and tracking?

## Affected Areas
Which components, workflows, or processes are impacted?

## Current State / Workarounds
How is this currently being handled (if at all)? What workarounds exist?

## Resolution (only present when Status = Resolved)
- **Decision**: What was decided?
- **Rationale**: Why was this approach chosen over alternatives?
- **Consequences**: Positive and negative outcomes of the decision.
- **Acceptance Criteria**: How will we know the decision is working as intended?

## Related Tensions
Links to other tensions that interact with or depend on this one.

## Notes / History
```

### Status Lifecycle

| Status      | Meaning                                                                 | Typical Use |
|-------------|--------------------------------------------------------------------------|-------------|
| **Open**    | Tension has been identified and is being tracked                        | New or ongoing friction points |
| **Resolved**| A deliberate decision has been made and documented                      | After analysis and Steward decision |
| **Deprecated** | The tension is no longer relevant                                    | Retired cleanly when obsolete |

---

## How This Creates Synergy

| Steward's Core Concern                          | Research's Core Concern                     | How `tensions/` Addresses Both |
|------------------------------------------------|---------------------------------------------|--------------------------------|
| Wanted clear separation between surfacing ongoing tension and recording decisions | Wanted to avoid maintaining two parallel folder structures and link overhead | Separation lives **inside** the file via `Status`, not across two folders. No links to maintain. |
| Worried about fragmentation and competing systems | Wanted lower long-term maintenance burden   | One folder. One artifact type. Reduces total concepts from 2 → 1. |
| Wanted to keep problems visible for a long time without forcing premature decisions | Wanted a clean, sustainable structure       | `Open` status allows tensions to remain visible and alive as long as needed. |
| Valued recording deliberate decisions with rationale | Wanted to reduce structural overhead        | The `Resolution` section captures decision-making power without needing a second file or folder. |

This is a true synthesis. It preserves the diagnostic value the Steward wants while delivering the simplicity and maintainability Research is advocating for.

---

## Benefits of the Unified `tensions/` Approach

- **Reduced complexity**: One folder instead of two. No cross-linking required.
- **Better historical integrity**: The full story of a tension (identification → resolution) lives in a single artifact.
- **Lower maintenance burden**: The Steward only curates one structure.
- **Cleaner governance**: Clear status model makes it obvious what stage each tension is in.
- **Avoids Experiment 05 mistakes**: Prevents the creation of parallel, competing documentation trees.
- **Supports emergent curation**: Tensions can stay `Open` across many build rounds until a high-quality decision is ready.

---

## Recommendation

Research recommends adopting the unified `tensions/` model with `Open` / `Resolved` / `Deprecated` status as the replacement for both `seams/` and `adr/`.

This decision should be made before implementing the Phase 2.1 prototype, as it affects folder structure, agent expectations, and long-term curation practices.

---

## Open Question for the Steward

Would you like to proceed with the unified `tensions/` model as described?

If yes, we can move to documenting the exact minimum viable content for a Tension Record and how it integrates with the Documentation Maintenance Proposals table.

If you have concerns or a different synthesis in mind, we are ready to iterate.

---

**End of Decision 1 Report**