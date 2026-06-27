# ADR-0004: Storage Save Strategy (MVP)

**Status:** Accepted (Phase 1.2A)  
**Seam:** S2 — storage behavior

## Context

`SaveAsync` strategy was unspecified in Era A/B exports. Agents diverged on per-handler saves vs full-table rewrite vs clear-and-insert.

## Decision

**MVP:** `SaveAsync` performs **full-table rewrite** — for each table, delete all rows, re-insert from in-memory `IItem` collection.

**Schema bootstrap:** Implementation may ensure schema on first open inside `SqliteStorageService` or via explicit ensure step — either is acceptable if reported once in build report.

## Consequences

- Documented in `components/Infrastructure/PLUGIN.md`.
- Incremental updates and migrations deferred to Phase 2+.

**Evidence:** Appendix D.1 save semantics divergence (Claude/Grok/Codex).