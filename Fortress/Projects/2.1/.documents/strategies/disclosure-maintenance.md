# Strategy — Disclosure + Documentation Maintenance (Era C)

## Status

Active

## Description

How build agents surface documentation gaps and maintenance signal without editing authoritative docs in place.

## Decision

1. Combined build report per `.documents/process/BUILD-DISCLOSURE.md` (single file in `Builds/`).
2. **Invention Summary** table — what was invented and whether disclosed.
3. **Documentation Maintenance Proposals** table — steward-actionable doc changes (mandatory when non-empty).
4. Optional drafts in `.codingAgent/proposals/` — steward reviews and promotes into `.documents/`.

## Rationale

Agents remain sensors; steward and Director curate `.documents/`. Prevents parallel truth trees (Exp05 lesson).

## Related

- `.documents/process/BUILD-DISCLOSURE.md`
- `.documents/process/AGENTS.md` Rule 5 (two-zone boundary)