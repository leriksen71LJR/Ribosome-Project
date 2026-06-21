# Build Disclosure — Collected Artifacts (Human Research)

**Purpose:** Archive post-build build reports returned from shootout builds (Part 1 build report + Part 2 Build Disclosure).

**Protocol (current):** Agents follow `Fortress/Project/BuildDisclosure.md` (Rule 12). One combined file: `.docs/Builds/BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md`.

**Protocol (legacy, pre-2026-06-21):** Separate `BUILD-REPORT-YYYY-MM-DD-XXX.md` + `REASONING-YYYY-MM-DD-XXX-{Agent}.md` in project root. Deprecated — retained in `Collected/` for historical builds only.

**Not the same as:** `Research/ReasoningDisclosure/Collected/` — that folder holds **legacy pre-build** disclosure exercises (`REASONING_YYYY-MM-DD.md` underscore format).

**Cross-agent analysis:** [Build-Agent-Disclosure-Responses-2026-06-21.md](Build-Agent-Disclosure-Responses-2026-06-21.md) — **self-contained** synthesis: Era A/B/C naming, evidence excerpts (Part II), steward implications (§7), and expansive Ribosome / Documentation-as-Pseudocode analysis (§9). `Collected/` remains raw archive; reading the analysis doc alone is sufficient for Research review.

---

## Inventory

| Date | Agent | Seq | Outcome | Combined report | Legacy reasoning (if any) | Shootout path | Notes |
|------|-------|-----|---------|-----------------|---------------------------|---------------|-------|
| 2026-06-20 | Claude | 001 | success | [BUILD-REPORT-2026-06-20-001.md](Collected/BUILD-REPORT-2026-06-20-001.md) | [REASONING-2026-06-20-001-Claude.md](Collected/REASONING-2026-06-20-001-Claude.md) | `fortress-shootout\Claude` | **Legacy paired format.** First full Phase 1.2A validation build. |
| 2026-06-20 | GrokBuild | 002 | success | [BUILD-REPORT-2026-06-20-002-GrokBuild.md](Collected/BUILD-REPORT-2026-06-20-002-GrokBuild.md) | [REASONING-2026-06-20-002-GrokBuild.md](Collected/REASONING-2026-06-20-002-GrokBuild.md) | `fortress-shootout\Grok` | Renamed copy in Collected (avoids Codex 002 filename clash). |
| 2026-06-20 | Codex | 002 | success (warnings) | [BUILD-REPORT-2026-06-20-002.md](Collected/BUILD-REPORT-2026-06-20-002.md) | [REASONING-2026-06-20-002-Codex.md](Collected/REASONING-2026-06-20-002-Codex.md) | `fortress-shootout\Cortex` | Rule 4 partial coverage; encryption isoform (static ApplyKey). |

---

## How to add a new entry

1. Copy from shootout folder (or unzip) into `Collected/` — keep original filename.
2. Add a row to the inventory table above.
3. Fan-out to Lead Researcher (composite) and Super Grok (doc fixes) as needed.

**Do not** place build `src/` or binaries here — build reports only.

---

*Human researchers only. Build agents must not read `Research/`.*