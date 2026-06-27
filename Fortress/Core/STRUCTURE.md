# Fortress — Structure & Rules

**Status:** Active canonical structure (as of 2026-06-26)

## Purpose

`Fortress/` is the **single source of truth** for documentation, process, and phase packages for the Fortress training project.

| Folder | Role |
|--------|------|
| `Archive/` | Historical content as **zip only** — read-only; extract to temp to read |
| `Core/` | Timeless essentials — charter, structure, context, memory capsules |
| `Ideas/` | Ongoing ideas, templates, operational tooling |
| `Phases/` | Phase-specific work — `Project/` (agent package), `Export/` (shootout) |
| `Records/` | Operational records — logs, backlog, handoff exports, backups, phase history |

Build agents receive a **shootout copy** of `Phases/{id}/Project/` only. They must not read `Archive/`, `Core/`, `Ideas/`, or `Records/` during implementation.

## File Naming Conventions

When saving documents with a date in the filename, use:

**`yyyy-MM-dd-hhmm`** (24-hour clock, no colon)

Examples: `Daily-Work-Summary-2026-06-21-2117.md`, `Preflight-Phase-2.1-2026-06-26-1300.md`

## Directory Layout

```
Fortress/
├── Archive/
│   ├── README.md          ← zip-only policy
│   └── Fortress-Archive-{yyyy-MM-dd-hhmm}.zip  ← historical content (extract to temp to read)
├── Core/
│   ├── CHARTER.md
│   ├── STRUCTURE.md       ← this file
│   ├── Current-Context.md
│   ├── HANDOFF.md
│   ├── Ribosome-Model.md
│   ├── DocumentationBoundaries.md
│   └── Memory/            ← memory capsules (CURRENT.md, TEMPLATE.md, Archive/)
├── Ideas/
├── Phases/
│   ├── PHASES.md
│   ├── 1.2A/              ← Project/ + Export/
│   ├── 2.1/
│   └── 2.2/
└── Records/
    ├── Logs/
    ├── Backlog/
    ├── Export/            ← analysis handoffs to local build project
    ├── Backups/
    └── Phases/            ← phase history (proposals, old rules)
```

## Phase convention

```
Phases/{id}/
├── Project/     ← all prep for the coding agent (AGENTS.md = root)
├── Export/      ← shootout mirror + Prompts/ + zip
└── *.md         ← optional steward meta (not agent read path)
```

## Rules

1. **Do not create new top-level folders** without updating this file and `PROCESS.md`.
2. **Keep content high-signal.** Prefer one strong document over many fragments.
3. **Date-stamp important artifacts.**
4. **Agent buildable files** live under `Phases/{id}/Project/` only.
5. **When in doubt**, put cross-cutting thinking in `Ideas/` first; promote later.

## Backup Procedures

**Naming:** `Fortress-Migration-yyyy-MM-dd-hhmm.zip` or `Research-Complete-yyyy-MM-dd-hhmm.zip` (legacy name OK)

**Location:** `Records/Backups/`

**When:** Before major structural changes, after significant decision points, or when requested.

**Latest full backup:** `Records/Backups/Fortress-Migration-2026-06-26-2321.zip` (pre Pass 0–3 structure migration)

## Logging

- **Steward + session logs:** `Records/Logs/`
- **Preflight reports:** `Records/Logs/Preflight-{Subject}-{date}-{HHmm}.md`
- See `Records/Logs/README.md`

## Operational moves

For cleanup or reorganization, follow `Ideas/Operational-File-Move-Pipeline.md` and `Ideas/Preflight-Process.md`: preflight, small batches, verify, log.

## Relationship to external build project

- `fortress-design/Fortress/` = documentation and phase packages
- External repo = implementation (`src/`, tests/)
- `Records/Export/` = analysis reports intended for the local build project

---

**Last updated:** 2026-06-26 — Canonical five-folder structure; `Research/` retired.  
**Next review trigger:** Major phase transition or significant process change.