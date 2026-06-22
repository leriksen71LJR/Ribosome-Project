# Logs

**Purpose:** Preserve context, decisions, and progress without relying solely on chat history.

## When to log

Create a log file when:

- Significant work is completed
- Key decisions are made
- A focused session ends

## Naming

Use clear, descriptive names with **date and time in 24-hour format**:

| Pattern | Example |
|---------|---------|
| Daily work summary | `Daily-Work-Summary-2026-06-21-1251.md` |
| Decision record | `Phase2-Decisions-2026-06-21-1430.md` |
| Process note | `Process-Export-Zip-Rules-2026-06-21-0900.md` |

Format: `{Topic}-{YYYY-MM-DD}-{HHmm}.md`

## Relationship to other state files

| File | Role |
|------|------|
| **`Logs/`** (this folder) | Session-level narrative — what happened, why, what's next |
| [`STATUS.md`](../STATUS.md) | Living project snapshot — blockers, current phase |
| [`handoff-audit.md`](../../handoff-audit.md) | Detailed steward audit trail (repo root) |
| [`Handoff/MemoryCapsule/CURRENT.md`](../Handoff/MemoryCapsule/CURRENT.md) | Executive capsule for new Super Grok chats |

Logs complement — do not replace — `STATUS.md` and the memory capsule system.

## Local workspaces (not committed)

| Path | Purpose |
|------|---------|
| `_tmp/` | Zip staging, experiment extracts, one-off scripts — **gitignored**; safe to delete locally |

Canonical Ribosome experiment artifacts belong under `Fortress/Research/Ribosome/Experiments/`.