# Export — Phase 2.1

**Status:** Ready — mirror refreshed 2026-06-26  
**Source of truth:** `Fortress/Phases/2.1/Project/` (edit there; re-copy before shootout if changed)

## Contents

| Path | Purpose |
|------|---------|
| `Project/` | Full copy of living agent package — copy to external shootout root |
| `Prompts/Build-Prompt.md` | Orchestrator prompt for Phase 2.1 builds |

## Shootout steps

1. Copy `Export/Project/` to external build root (e.g. `fortress-shootout\{Agent}/`)
2. Give agent `Prompts/Build-Prompt.md` (adjust assigned root path)
3. Optional: zip as `Fortress-Phase2.1-Shootout-YYYY-MM-DD.zip` per `PROCESS.md`

**Agent project root** = folder containing `AGENTS.md`.