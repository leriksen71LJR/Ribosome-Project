# Logs

**Location:** `Fortress/Records/Logs/`  
**Purpose:** Preserve context, decisions, and progress without relying solely on chat history.

## When to log

- Significant work completed
- Key decisions made
- End of a focused session
- Steward preflight completed

## Naming

`{Topic}-{YYYY-MM-DD}-{HHmm}.md` in 24-hour format.

| Pattern | Example |
|---------|---------|
| Daily work summary | `Daily-Work-Summary-2026-06-21-1251.md` |
| Session record | `Session-002-2026-06-26.md` |
| Steward preflight | `Preflight-Phase-2.1-2026-06-26-1300.md` |
| Migration note | `Fortress-Structure-Migration-Pass0-3-2026-06-26.md` |

**Preflight reports:** See [`PROCESS.md`](../../PROCESS.md). Steward saves completed runs here.

## Relationship to other state files

| File | Role |
|------|------|
| **`Records/Logs/`** (this folder) | Session narrative — what happened, why, what's next |
| [`STATUS.md`](../../STATUS.md) | Living snapshot — blockers, current phase |
| [`Core/Current-Context.md`](../../Core/Current-Context.md) | Research/context snapshot |
| [`Core/Memory/CURRENT.md`](../../Core/Memory/CURRENT.md) | Executive memory capsule |

## Experiments (historical)

Canonical Ribosome experiment artifacts: `Fortress/Archive/Experiments/Ribosome/Experiments/`

## Markdown links (VS Code / Grok Build)

Use **file-relative** hrefs from the current document. Example from this folder:

`[PHASES.md](../../Phases/PHASES.md)`

Add full Windows paths in backticks when copy/paste helps.