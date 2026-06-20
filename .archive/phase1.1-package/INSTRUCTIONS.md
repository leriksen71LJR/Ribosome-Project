# Phase 1.1 Shootout Instructions

This package contains everything needed to run the Phase 1.1 build with the updated rules.

## What’s Included

- `.docs/` — Full documentation (including the new `PHASE_1_1_IMPROVEMENTS.md`)
- `AGENTS.md` — Updated root agent instructions
- `Prompts/` — Three ready-to-use prompts for Grok Build, Claude, and Codex

## How to Use This Package

1. **Unzip** this package.
2. For each agent (Grok Build, Claude, Codex), create a clean working folder.
3. Copy the following into each agent’s working folder:
   - The entire `.docs/` folder
   - The `AGENTS.md` file (root level)
4. Use the corresponding prompt from the `Prompts/` folder when starting the agent.

## Important Phase 1.1 Rules

- Agents **must** produce a structured build report at the end.
- Report filename format: `BUILD-YYYY-MM-DD-<Agent>.md` inside `.docs/Builds/`
- Agents **must** explicitly list deviations from the documentation.
- `IActionHandler` methods should be async (`ExecuteAsync`).

## Goal

Evaluate how well the documentation (especially the new Phase 1.1 requirements) guides agents to produce consistent, transparent, and high-quality output.
