# Decision 3: Agent Write Boundaries – Structural Proposal

**Date:** 2026-06-23  
**For:** Steward  
**Context:** Phase 2.1 Governance – How Build Agents interact with documentation structures

---

## Summary of the Question

As we introduce `tensions/`, `strategies/`, and `REGISTRY.md` (now proposed to live under `.documents/`), a critical governance question arises:

> Should Build Agents be allowed to directly write into the authoritative documentation folders during builds, or should there be a hard structural boundary?

This decision affects long-term maintainability, signal quality, role clarity, and the risk of uncontrolled structural growth.

---

## Steward’s Position

The Steward has been clear that `.docs/` (now proposed as `.documents/`) should remain **read-only** for Build Agents during normal builds. All maintenance signals should be routed through a structured **Documentation Maintenance Proposals** table in the build report.

This reflects a deliberate philosophy: Build Agents act as **sensors**, not co-authors of the documentation architecture.

---

## Research’s Position

We agree with the Steward’s core intent. However, we believe a **pure policy rule** (“agents may not edit during builds”) is fragile over time. A stronger approach is to create a **physical and structural separation** between authoritative documentation and agent input.

### Proposed Model

| Folder            | Purpose                                      | Write Access      | Owner                  |
|-------------------|----------------------------------------------|-------------------|------------------------|
| **`.documents`**  | Authoritative documentation (source of truth)   | Steward only     | Steward                |
| **`.codingAgent`** | Agent workspace for proposals, tensions, feedback, and strategies | Build Agents     | Build Agents (reviewed by Steward) |

### Key Rules

- Build Agents are **strictly prohibited** from writing directly into `.documents/`.
- All proposals, new tension suggestions, strategy ideas, build feedback, and maintenance notes **must** be written into `.codingAgent/`.
- The Steward periodically reviews `.codingAgent/` and promotes accepted content into `.documents/` (e.g., moving a proposed Tension into `tensions/` or formalizing a Strategy).
- This creates a clear, enforceable boundary rather than relying solely on policy or convention.

---

## Rationale

This structural approach offers several advantages:

| Benefit                        | Explanation |
|--------------------------------|-------------|
| **Clear physical boundary**    | Separation is enforced by folder structure, not just rules. |
| **Protects governance**        | The authoritative layer (`.documents/`) remains clean and under Steward control. |
| **Reduces friction for agents**| Agents have a legitimate, low-friction space to think and propose without waiting for approval on every small item. |
| **Improves signal quality**    | Proposals can be reviewed in batch. The Steward sees patterns across multiple builds before making changes. |
| **Supports intentional growth**| Prevents the authoritative documentation from accumulating noise or low-value artifacts. |
| **Aligns with roles**          | Reinforces that Build Agents are excellent at **detecting** problems and **proposing** solutions, while the Steward owns **curation** and final decisions. |

This model also creates a natural, healthy workflow:
1. Agent works in `.codingAgent/` → surfaces a Tension or proposes a Strategy.
2. Steward reviews the workspace on a regular cadence.
3. Steward decides what gets promoted into `.documents/`.

---

## Recommendation

We recommend adopting the two-folder model:

- **`.documents/`** — Authoritative documentation (read-only for Build Agents)
- **`.codingAgent/`** — Dedicated agent workspace

This replaces the simpler “read-only during builds” rule with a more robust, structural solution that scales better as Phase 2.1 evolves.

We are happy to adjust the exact names if the Steward prefers different terminology, but the **separation of concerns** is the important principle.

---

## Open Question for the Steward

Does the proposed two-folder model (`.documents/` + `.codingAgent/`) align with how you want to manage agent input and governance in Phase 2.1?

If yes, we can proceed to implementation planning. If you prefer a different boundary or naming, we are ready to refine.

---

*Prepared by Research as a thinking partner contribution.*