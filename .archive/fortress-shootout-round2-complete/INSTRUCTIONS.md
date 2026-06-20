# Fortress Shootout Round 2 - Instructions

## What's in this package

This zip contains everything you need for **Phase 1.1 / Round 2** of the Fortress agent shootout:

- Full `.docs/` folder (including new `Phases/PHASE_1_1_IMPROVEMENTS.md`)
- Updated `AGENTS.md` (root)
- Three ready-to-use prompts in the `Prompts/` folder
- This instructions file

## How to use

1. Unzip this package into a clean folder (e.g. `fortress-shootout-round2`).
2. Inside that folder you will have:
   - `.docs/` 
   - `AGENTS.md`
   - `Prompts/`
3. For each agent, create a separate working folder and copy `.docs/` + `AGENTS.md` into it.
4. Use the corresponding prompt from the `Prompts/` folder when starting the agent.

## Key Phase 1.1 Rules (New)

All agents **must** now:
- Create a build report in `.docs/Builds/BUILD-YYYY-MM-DD-<Agent>.md`
- Explicitly list any deviations from the documented rules
- Use `ExecuteAsync` instead of `Execute` on `IActionHandler`

These rules are defined in `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md`.

## Recommended Order

1. Start with **Grok Build** using `Prompts/GROK_BUILD_PROMPT_PHASE_1_1.md`
2. Then run **Claude** and **Codex** with their respective prompts.
3. After all three finish, send me the results (especially the new `BUILD-*.md` reports).

Good luck with Round 2.
