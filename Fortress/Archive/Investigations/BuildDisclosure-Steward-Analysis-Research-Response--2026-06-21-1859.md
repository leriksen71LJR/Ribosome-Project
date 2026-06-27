# BuildDisclosure Analysis — Research Response

**Date:** 2026-06-21  
**Source:** Build Agent Responses to Build Disclosure — Analysis (from Steward)  
**Mode:** Research (not design)  
**Purpose:** Extract perspectives, patterns, and approaches supported by the BuildDisclosure analysis to inform how we approach the design phase.

---

## Executive Summary

The BuildDisclosure analysis provides strong empirical evidence from a three-agent shootout on how well documentation performed as executable specification.

**Core finding:**  
Documentation-as-Pseudocode worked well on high-fidelity sections (handler tables, security implementation blocks, embedded SQL) but failed predictably at seams — incomplete contracts, deferred phrases, and rule collisions. Invention clustered at those seams.

Post-build disclosure (Rule 12) functioned effectively as a **translation quality control** mechanism, surfacing where the specification was underspecified.

---

## Key Perspectives Supported by the Document

| Perspective | Strength of Support | Key Evidence | Implications for Design Phase |
|-------------|---------------------|--------------|-------------------------------|
| **Making Invention Visible** | Very High | All three agents invented on the same gaps. Codex did not disclose one major invention. | Invention visibility should be treated as a core QC concern. |
| **Seam-Focused Specification** | Very High | Friction concentrated at T2–T4 seams. High-fidelity sections translated cleanly. | Prioritize completeness at component boundaries. |
| **Lightweight vs Heavy Process** | High | Process documentation scored 9/10. Over-formalization risk repeatedly flagged. | New mechanisms should stay deliberately lightweight. |
| **Integration over New Artifacts** | High | Preference for folding signals into existing reports rather than new channels. | Avoid creating parallel artifacts when existing ones can absorb requirements. |
| **Post-Build Disclosure as QC Instrument** | Very High | Pre-build disclosure missed runtime seams that post-build caught. | Post-build disclosure should remain central. |
| **Measurability Gap** | High | Rule 4 and coding standards lack verifiable thresholds. | Treat measurability as a core authoring standard. |
| **Convergent Invention = mRNA Gap** | Very High | When all three agents invented the same behavior, root cause was almost always underspecified documentation. | Use inter-agent convergence as a diagnostic signal. |
| **Process vs Requirements Inversion** | High | Process docs consistently scored higher than requirements docs. | Prioritize contract completeness over additional process rules. |
| **Acceptance Criteria Close Isoforms** | Medium-High | Different interface shapes emerged for the same functional need. | Specifications should include acceptance criteria on shape. |

---

## Major Approaches / Patterns Supported

1. **Seam Taxonomy as Diagnostic Lens**  
   Classifying invention into clear categories (S1–S5) is a powerful way to triage documentation debt.

2. **Fidelity Tiers (T0–T4)**  
   High-fidelity sections (T0–T1) translated reliably. Lower-fidelity sections produced clustered invention. This tier model is useful for authoring and review.

3. **Decision Procedure as Exception Handling**  
   When general rules collided with specific requirements, agents invented exception rules. Supports creating a lightweight Decision Procedure layer.

4. **Integration-First Mindset**  
   Multiple sections emphasize folding new requirements into existing artifacts rather than creating new ones.

5. **Post-Build Disclosure as Feedback Loop**  
   Disclosure functions as ribosomal proofreading that feeds back into specification quality.

6. **Honesty and Measurability as QC Dimensions**  
   Disclosure honesty (e.g., Codex admitting partial coverage) is treated as a quality signal.

---

## Implications for Approaching the Design Phase

Based on the document, the following high-level stances are well-supported:

- Prioritize **seam completeness** over uniform documentation polish.
- Treat **invention visibility** as a core quality attribute of the build process.
- Favor **lightweight, integrated mechanisms** over new standalone processes or artifacts.
- Keep **post-build disclosure** as the primary diagnostic instrument.
- **Seed Decision Procedures** from real, observed ambiguities rather than theoretical ones.
- Build **measurability** into specifications from the start.
- Avoid over-expanding process documentation to compensate for weak requirements.

---

## Open Questions / Hypotheses Worth Exploring

- How much of the observed invention would have been prevented by a lightweight Decision Procedure Registry seeded from these exact seams?
- Would adding an explicit **Invention Summary** table to `BuildDisclosure.md` have caught silent inventions?
- What is the right balance between automation (drift detection, consistency scanning) and human judgment in the Documentation Audit step?
- How do we design observability that surfaces reasoning quality without triggering Goodhart-style distortion?

---

**End of Research Analysis**