# Fortress Phase 1.1 — Instructions

This package contains everything needed to run **Phase 1.1** of the Fortress documentation-driven shootout.

## What's Included

- `.docs/` — Full documentation (including new `Phases/PHASE_1_1_IMPROVEMENTS.md`)
- `AGENTS.md` — Updated root agent instructions
- `Prompts/` — Three ready-to-use prompts for Grok Build, Claude, and Codex
- This `INSTRUCTIONS.md` file

## How to Use This Package

### Step 1: Prepare Clean Folders
Create three separate clean folders, one for each agent:

```
fortress-shootout/
├── Claude/
├── Grok/
└── Codex/
```

### Step 2: Copy Documentation
Copy the following into **each** of the three agent folders:

- The entire `.docs/` folder
- `AGENTS.md`

### Step 3: Run the Agents
Use the prompts from the `Prompts/` folder:

- `GROK_BUILD_PROMPT_PHASE_1_1.md` → for Grok Build
- `CLAUDE_PROMPT_PHASE_1_1.md` → for Claude
- `CODEX_PROMPT_PHASE_1_1.md` → for Codex

### Step 4: After Each Build
Each agent should automatically create:
`.docs/Builds/BUILD-YYYY-MM-DD-<AgentName>.md`

This report is **mandatory** in Phase 1.1.

## Important Phase 1.1 Rules

1. Agents **must** produce a build report in `.docs/Builds/`
2. Agents **must** explicitly document any deviations from the rules in a section called **"Deviations from Documentation"**
3. `IActionHandler` methods must be async (`ExecuteAsync`)

## Goal of Phase 1.1

Test whether adding mandatory self-documentation and explicit deviation reporting improves agent behavior and transparency compared to Phase 1.

---

Run clean. Compare results honestly.