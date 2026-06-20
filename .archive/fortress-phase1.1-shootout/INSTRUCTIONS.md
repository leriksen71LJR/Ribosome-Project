# Fortress Phase 1.1 Shootout - Instructions

## How to Use This Package

1. Unzip this package.
2. For each agent (Claude, Grok Build, Codex), create a clean working folder.
3. Copy the following into **each** agent's working folder:
   - The entire `.docs/` folder
   - The `AGENTS.md` file (root level)
4. Use the corresponding prompt from the `Prompts/` folder when starting the agent.
5. After the build finishes, the agent should have created a report in `.docs/Builds/`.

## Prompts

- `Prompts/GROK_BUILD_PROMPT_PHASE_1_1.md` → For Grok Build
- `Prompts/CLAUDE_PROMPT_PHASE_1_1.md` → For Claude
- `Prompts/CODEX_PROMPT_PHASE_1_1.md` → For Codex

All prompts are aligned with `PHASE_1_1_IMPROVEMENTS.md`.

## Key Phase 1.1 Rules

- Agents must produce a structured build report: `BUILD-YYYY-MM-DD-<Agent>.md`
- Agents must explicitly document deviations from the rules
- `ExecuteAsync` is required on `IActionHandler`

Good luck with the builds.