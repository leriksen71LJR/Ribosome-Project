# Shared Memory — Steward Assessment

**Date:** 2026-06-27-1800  
**Type:** Idea / Steward synthesis  
**Status:** Parked — architecture agreed in principle; vault repo not created yet  
**Location:** `Fortress/Ideas/Shared-Memory-Steward-Assessment-2026-06-27-1800.md`

**Naming:** Dated filenames use `yyyy-MM-dd-hhmm` per [`Core/STRUCTURE.md`](../Core/STRUCTURE.md) (24-hour clock, no colon).

**Research sources (saved in `Ideas/`):**

- [`Idea-Shared-Memory-System-2026-06-27.md`](Idea-Shared-Memory-System-2026-06-27.md) — full narrative (supersedes 26th version)
- [`Conversation-Notes-Shared-Memory-Roles-Centralization-2026-06-27-1530.md`](Conversation-Notes-Shared-Memory-Roles-Centralization-2026-06-27-1530.md) — roles, inbox, centralization snapshot
- [`Shared-Memory-Research-Summary-2026-06-26-1410.md`](Shared-Memory-Research-Summary-2026-06-26-1410.md) — architecture comparison pass
- [`Idea-Shared-Memory-System-between-Frontier-Research-Steward-2026-06-26-1420.md`](Idea-Shared-Memory-System-between-Frontier-Research-Steward-2026-06-26-1420.md) — earlier draft (Obsidian-centric)

---

## Executive summary

**Problem:** Each new AI chat forgets everything. Re-briefing wastes your time and drifts Research vs Steward.

**Answer:** Hybrid memory — git-backed markdown, Frontier inbox, conscious promotion gate — in a **dedicated vault repo** both architects share.

**Director decisions (2026-06-27):**

| Decision | Detail |
|----------|--------|
| Both architects local | Research and Steward on the same PC — no cloud handoff |
| Both architects **thin** | Sessions are hats + bootstrap prompts, not fat project trees |
| **One merged vault** | Project content from both roles lives in **one new repo** (own git) |
| **Not** named `research` | New folder, new source control — name TBD (`fortress-vault` placeholder below) |
| **`fortress-design` becomes thin** | Export, shootout mirrors, build handoff — not the daily architect notebook |

**Not built yet.** Ideas on the shelf until you say go (likely after a real 2.1 shootout).

---

## What I think

The research is **right about the problem** and **right about the mechanisms** (inbox, layers, promotion gate, markdown + git).

What it had wrong was **where things live**. It assumed one repo (`Research/` or `fortress-design/Fortress/`). You've clarified something better:

- **Thick:** one vault repo — merged content both architects read and write
- **Thin:** `fortress-design` + each architect session (chat, rules, bootstrap line)

The **Frontier inbox** stays the strongest concrete piece — one file for raw sparks on phone. Research mines it in the **vault**. Steward stays out of raw inbox.

**Centralized core + thin layers** still holds — but the core is the **vault repo**, not `fortress-design`. Research and Steward are equally thin; neither gets a private fat tree.

---

## What I got wrong (twice)

1. **Read-only report → full install.** You asked for a report; I wired infrastructure into `Core/` and `PROCESS.md`. You stopped it. Correct call.

2. **Single-repo mental model.** I kept putting the vault inside `fortress-design` and treated Steward as the fat tree owner. You want **both architects thin**, content **merged outside** in its own git repo. `fortress-design` thins out too.

Rolled back all installs. This file + research copies = shelf stock only.

---

## Target layout — two repos

```
~/source/repos/
│
├── fortress-design/                 ← THIN (architects + build pipeline)
│   └── Fortress/
│       ├── Phases/{id}/Export/      ← shootout mirrors, zips, prompts
│       ├── README.md                ← points to vault: "work happens next door"
│       └── (minimal — no daily memory work here)
│
└── fortress-vault/                  ← THICK (name TBD — NOT "research")
    ├── STATUS.md
    ├── PROCESS.md
    ├── Core/
    │   ├── Current-Context.md       ← Research bootstrap
    │   ├── Memory/CURRENT.md        ← Steward bootstrap
    │   ├── CHARTER.md, STRUCTURE.md, …
    ├── Ideas/
    │   ├── Frontier-Inbox.md
    │   └── *.md
    ├── Phases/{id}/Project/         ← living agent package (merged work)
    ├── Records/                     ← logs, staging, backups
    └── Archive/
```

**Working name:** `fortress-vault` until you pick something else.

### What lives where

| Lives in **vault** (thick) | Lives in **fortress-design** (thin) |
|----------------------------|-------------------------------------|
| `Current-Context`, steward `CURRENT` | `Phases/{id}/Export/Project/` copy |
| `Frontier-Inbox`, refined `Ideas/` | Shootout zips, `Build-Prompt.md` |
| `Phases/{id}/Project/` source of truth | README pointer to vault |
| Decisions, PLUGINs, tensions, logs | Optional: stale mirror during transition |
| `STATUS.md`, `PROCESS.md` for architects | Build-agent boundary (agents never see vault) |

### What "thin architect" means

Neither Research nor Steward keeps a duplicate of the vault.

| Thin piece | Research | Steward |
|------------|----------|---------|
| Chat session | New chat each time — ephemeral | Same |
| Bootstrap paste-line | Points at vault paths | Points at vault paths |
| IDE rules | "You are Research; vault is …" | "You are Steward; vault is …" |
| Optional scratch | In-flight analysis only | In-flight doc-fix only |
| Fat project tree | **No** | **No** |

Both open the **same vault repo** in the editor. Same files on disk. Different read/write rules.

### Why two repos

1. **Clean git history** — architect collaboration separate from export zip churn.
2. **No split brain** — Research and Steward aren't in different folders; one vault.
3. **`fortress-design` one job** — shootout packaging, not also the living notebook.

---

## How it works — the workflow

Every session: **Open → Work → Close**. Paths below are in **vault** unless noted.

### Director (you)

| When | Read | Write |
|------|------|-------|
| "Where are we?" | `vault/STATUS.md` | — |
| Quick spark (phone) | — | `vault/Ideas/Frontier-Inbox.md` |
| Start architect chat | — | Paste bootstrap line (below) |
| Big decision | What they surfaced | Say it; they persist in vault |

### Research (thin → vault)

| When | Read | Write |
|------|------|-------|
| **Open** | `Core/Current-Context.md` → `Ideas/Frontier-Inbox.md` (unprocessed) → `STATUS.md` if needed | — |
| **Work** | `Ideas/`, `Records/` | `Ideas/{Topic}-{yyyy-MM-dd-hhmm}.md`; optional `Records/Export/{Topic}-{yyyy-MM-dd-hhmm}.md` |
| **Mine inbox** | Raw entries | Mark `→ processed`; create idea file |
| **Close** | — | `Core/Current-Context.md` |

**Must not write:** `Phases/.../Project/` (spec), `Core/Memory/CURRENT.md`, anything in `fortress-design`.

**Bootstrap paste:**
> *Research — vault repo `{vault-path}`. Read `Core/Current-Context.md` + unprocessed `Ideas/Frontier-Inbox.md`. Write to `Ideas/` and `Current-Context`. Do not edit `Phases/.../Project/`.*

### Steward (thin → vault)

| When | Read | Write |
|------|------|-------|
| **Open** | `Core/Memory/CURRENT.md` → `STATUS.md` | — |
| **Work** | Refined `Ideas/`, `Phases/.../Project/` | `.documents/`; `.codingAgent/` proposals |
| **Promote** | Research output you approved | `Project/` spec changes |
| **Inbox** | **Skip** | — |
| **Close** | — | `CURRENT.md`, `STATUS.md`, `Records/Logs/` if warranted |
| **Shootout** (on request) | `vault/Phases/{id}/Project/` | Copy → `fortress-design/Phases/{id}/Export/` |

**Bootstrap paste:**
> *Steward — vault repo `{vault-path}`. Read `Core/Memory/CURRENT.md` + `STATUS.md`. Skip inbox. Edit vault `Project/`. Export to `fortress-design` only when Director asks.*

### Write triggers

| Trigger | Who | Where (vault) |
|---------|-----|---------------|
| Raw idea | Director / Frontier | `Ideas/Frontier-Inbox.md` |
| Session state after research | Research | `Core/Current-Context.md` |
| Refined analysis | Research | `Ideas/` or `Records/Export/` |
| Inbox → keeper | Research | `Ideas/{Topic}-{yyyy-MM-dd-hhmm}.md` + mark inbox |
| Spec / promotion | Steward | `Phases/.../Project/.documents/` |
| Experiment not ready for spec | Steward | `Phases/.../Project/.codingAgent/` |
| Phase or export state | Steward | `CURRENT.md`, `STATUS.md` |

**Promotion** = Steward moves exploratory → owned (with your oversight on big calls). Research recommends; never auto-promotes to spec.

### Example week

| Day | Who | What |
|-----|-----|------|
| Mon | You (phone) | Append inbox bullet in **vault** |
| Tue | Research chat | Mine inbox → `vault/Ideas/Wrong-Password-UX-2026-06-28-0930.md` → update `Current-Context` |
| Wed | You | Skim vault (git pull). *"Steward, promote X into 2.1."* |
| Thu | Steward chat | Edit `vault/Phases/2.1/Project/` → update `CURRENT` |
| Fri | Steward | Copy `vault/Project/` → `fortress-design/Export/` → shootout |

Build agent sees **fortress-design Export only** — never vault, never inbox, never chat.

### Material flow

```
                    VAULT REPO (fortress-vault)
                    ───────────────────────────

Director spark ──► Ideas/Frontier-Inbox
                        │
                   Research (thin chat)
                        │
            ┌───────────┴───────────┐
            ▼                       ▼
      Ideas/ (refined)      Records/Export/ (optional staging)
            │                       │
            └──────────► Steward (thin chat) promotes
                              │
                    Phases/Project/.documents/
                    Core/ (timeless updates)
                    STATUS / CURRENT

                              │ shootout copy (on request)
                              ▼
                    fortress-design (THIN)
                    Phases/{id}/Export/  ──► build agents
```

---

## Migration plan (when ready)

**Gate:** Real 2.1 shootout first — learn where memory actually hurts.

**Steps:**

1. Create `fortress-vault/` (or your name), `git init`, sibling to `fortress-design`.
2. Move merged `Fortress/` tree from `fortress-design` → vault (Core, Ideas, Phases/Project, Records, Archive, STATUS, PROCESS).
3. Thin `fortress-design` — keep Export structure; add README: *vault path, shootout-only role*.
4. Add `Ideas/Frontier-Inbox.md` in vault if not migrated.
5. Two bootstrap paste-lines (this doc or vault README).
6. Optional: VS Code multi-root workspace (`fortress-vault` + `fortress-design`).

**Smallest v1 if pain is light:** vault + inbox + two bootstrap lines only — skip role folders, scratch trees, Obsidian until needed.

**Do not:** install into `fortress-design/Core/` or `PROCESS.md` before cutover — that's the mistake already made and reverted.

---

## Fit today vs target

| Artifact | Today (`fortress-design`) | Target (vault) |
|----------|-------------------------|----------------|
| `STATUS.md` | Here | Moves to vault |
| `Current-Context.md` | Here | Moves to vault |
| `Memory/CURRENT.md` | Here | Moves to vault |
| `Phases/2.1/Project/` | Here | Moves to vault |
| `Phases/2.1/Export/` | Here | Stays in `fortress-design` |
| This assessment | Here (idea shelf) | Stays until promoted or copied to vault |

---

## Open questions

- **Vault repo name** — `fortress-vault`? Something else? (Not `research`.)
- **Cutover timing** — after 2.1 shootout, or sooner?
- **`fortress-research` repo** — absorb into vault and retire, or keep separate?
- **Inbox alone** — enough for v1, or formal role docs in vault from day one?
- **Mobile** — git pull on phone enough, or Obsidian sync on vault?
- **Multi-root workspace** — one VS Code window for both repos, or vault only day-to-day?

---

## Recommendation

| Do now | Do later |
|--------|----------|
| Keep research + this assessment on the shelf | Create vault repo when you say go |
| Finish 2.1 shootout from current `fortress-design` | Migrate tree; thin `fortress-design` |
| Note where memory hurts in practice | Implement inbox + bootstrap lines in vault |

The architecture is clear enough to build. The timing isn't — **observe 2.1 handoff pain first**, then migrate to two-repo layout rather than bolting process onto today's single repo.

When you're ready: name the vault, say cutover — I'll scaffold the repo and migration plan, **small first**.

---

*Steward synthesis. Does not modify live `Core/` or `PROCESS.md` until Director approves cutover.*