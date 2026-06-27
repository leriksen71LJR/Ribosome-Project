# Super Grok Memory Capsule System

**Purpose:** Hand off the **Super Grok steward** role to a new chat without depending on transcript memory.

**Owner:** Super Grok (`fortress-design` workspace) — not build agents, not Lead Researcher.

---

## How It Works

| File | Role |
|------|------|
| [`CURRENT.md`](CURRENT.md) | **Always read this** when starting or resuming as Super Grok. Living capsule — updated in place. |
| [`TEMPLATE.md`](TEMPLATE.md) | Blank structure for creating a new capsule or archive snapshot. |
| `Archive/SuperGrok-YYYY-MM-DD.md` | Frozen snapshot when retiring a chat (optional but recommended). |

**Reading order for a new Super Grok chat:**

1. Repo root [`handoff-audit.md`](../../../handoff-audit.md) — full audit trail and session log
2. **`Fortress/Core/Memory/CURRENT.md`** — executive state (this system)
3. [`Fortress/STATUS.md`](../../STATUS.md) — project snapshot
4. User message + any Research executive summary (if provided)

---

## When to Update `CURRENT.md`

Super Grok **must** refresh `CURRENT.md` when:

- A doc fix item is completed or reprioritized
- Export package or zip is refreshed
- Steward analysis of new build artifacts finishes
- Git milestone committed
- Phase direction changes (user decision)
- **Before retiring this chat** — final pass so the next instance starts warm

`handoff-audit.md` remains the detailed log. `CURRENT.md` is the **executive summary** — dense, skimmable, decision-ready.

---

## Chat Retirement Protocol

When the user says this chat is strained or ending:

1. Update `handoff-audit.md` (session log + pending)
2. Update `CURRENT.md` (full refresh)
3. Copy `CURRENT.md` → `Archive/SuperGrok-YYYY-MM-DD.md`
4. Tell the user: *"New chat: open `fortress-design`, paste 'Resume as Super Grok — read handoff-audit.md and MemoryCapsule/CURRENT.md'"*

---

## Relationship to Lead Researcher

Lead Researcher maintains its **own** memory capsule (separate chat, separate file).

| Role | Capsule location | Focus |
|------|------------------|-------|
| **Super Grok** | `Fortress/Core/Memory/` | Doc fixes, export, steward analysis, `handoff-audit.md` |
| **Lead Researcher** | Research agent's capsule (user-provided) | Composite synthesis, Phase 2 arc, `Ideas/` / `Phases/` |

Super Grok **reads** Research's executive summary when the user sends it — for alignment, not to replace Research's judgment.

---

## Team Ethos (user, 2026-06-21)

The Research agent's long-arc work made this steward role possible. Super Grok is fast and execution-focused; Research brings depth, synthesis, and judgment the user trusts. **Complementary roles — not competing.** Honor Research's contributions; do not try to be Research.