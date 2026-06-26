# Phase 2.1 + Projects Restructure — Discussion on Exp06 Content

**Date:** 2026-06-24 ~14:30  
**Context:** Refining the PHASE_2_1_PROJECTS_RESTRUCTURE_PLAN.md after initial draft. Focus: whether to actively bring forward important content from Experiment 06 when building the new structure.

## What we discussed

The question was basically: should we push through and prepare the new `Fortress/Projects/2.1/` layout (the `.documents/`, `tensions/`, `strategies/`, REGISTRY connector, `.codingAgent/` split) using the real, valuable documentation content that already exists in Exp06, or keep it lighter / more skeletal at first?

Key points that landed:

- Exp06 is the strongest recent baseline we have. It has the DI plugin shape (`CORE.md`, `COMPONENTS.md`, the six actual `components/*/PLUGIN.md` files), cleaned-up process rules, and the ADRs that captured earlier decisions. This is the stuff that got the 8/10 plan-mode score.

- Phase 2.1 was designed as the direct next step on top of that work (per the guidance documents and Director final call). It makes sense to use Exp06 as the source when we fork the new structure, rather than starting nearly empty.

- However, we have to stay true to the Phase 2.1 principles that were locked:
  - Prototype cap: max 3 Open tensions + 2 strategies on the first pass.
  - Emergent curation over time — the point is learning to surface and steward these things across builds, not doing a complete ontology in one shot.
  - Agents stay sensors; steward does the promotion.

## Agreed lean

Yes to pushing the important Exp06 content into the new structure, but surgically:

- Use Exp06 as the fork source.
- Move the executable mRNA (the PLUGINs, CORE, the process/AGENTS + BUILD-DISCLOSURE) into the `.documents/` layout.
- Perform the COMPONENTS vs REGISTRY split as defined in the earlier decisions.
- Convert the 6 existing ADRs into `tensions/` records (Resolved status).
- Seed only the small number of new Open tensions and strategies we already named.
- Do not rewrite the detailed content inside the plugins or try to reclassify everything during the structural move.
- Leave old perspectives/, archive material, etc. behind.

This gives the new `Projects/2.1/` real weight from the best recent fortress work while respecting the "don't overbuild upfront" guardrails.

## Related artifacts

Full detailed notes captured in the plan:
`Fortress/Research/Phases/PHASE_2_1_PROJECTS_RESTRUCTURE_PLAN.md` (new "2026-06-24 Discussion Notes" section).

This log is the session-level capture.

## Next feel

Once the rename work and basic structure fork are clearer, we can decide the exact order: prototype under 007/ first, or build straight into Projects/ after the rename lands. Also still need to settle how much of the old adr/REGISTRY we surface during the conversion.

Recorded per the note to keep discussion conversational in chat but capture the technical substance properly.

---

**Follow-up direction (2026-06-24):**
- Leave 1.2A alone, no internal update.
- Follow 06 as canonical; using only the agreed subset from 005.
- Added final expected .documents/ tree post-Exp06 import.
- Added workflow diagrams (mermaid) for key areas.
- Research reasoning added to relevant sections of the plan.

User also shared Phase 2.2 deep breakdown (Phase-2.2-Custom-Agents-per-Workflow-Stage-Deep-Breakdown-2026-06-24.md). Noted connections to .codingAgent/ structure and controlled invention. User will review 2.2 with final adjustments after sleep/work.

All recorded in the main plan document.

*End of log.*