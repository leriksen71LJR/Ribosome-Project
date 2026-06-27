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
| Steward preflight | `Preflight-Phase-2.1-2026-06-26-1300.md` |

Format: `{Topic}-{YYYY-MM-DD}-{HHmm}.md`

**Preflight reports:** See [`PROCESS.md`](../PROCESS.md) — Preflight reports. Steward saves completed runs here.

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

## Ribosome experiment layout

| Pattern | Example | Use |
|---------|---------|-----|
| `Experiments/00N/` | `006/`, `007/` | Multi-file experiment (package, guidance, reports) |
| `Experiments/Experiment-NN-*.md` | Exp03 composite note | Single standalone research document |
| Filename `-HHmm` suffix | `...-2026-06-23-0452.md` | Preserve upload/authored timestamp on drafts |

## Links in markdown (VS Code / Grok Build)

VS Code/Grok Build **only** opens markdown links whose href is **file-relative** to the current document. `c:\...`, `file:///`, and `/Fortress/...` hrefs do not open reliably in this harness.

**Workaround (two-part):**

| Part | What | Example (from `Logs/`) |
|------|------|------------------------|
| **Link** | Short display name + file-relative href | `[007/README.md](../Research/Ribosome/Experiments/007/README.md)` |
| **Full path** | Windows path in backticks for copy/paste | `` `c:\Users\lerik\source\repos\fortress-design\Fortress\...` `` |

Recompute href when moving a file. See [VS Code markdown path completions](https://code.visualstudio.com/docs/languages/markdown#_path-completions).