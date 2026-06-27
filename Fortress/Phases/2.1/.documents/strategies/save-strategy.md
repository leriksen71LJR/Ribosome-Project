# Strategy — Storage Save (MVP)

## Status

Active

## Description

How `SaveAsync` persists in-memory items to SQLCipher storage during Phase 1.2A / 2.1 MVP builds.

## Decision

**MVP:** `SaveAsync` performs **full-table rewrite** — for each table, delete all rows, re-insert from in-memory `IItem` collection.

## Rationale

Era B shootouts diverged on per-handler saves vs full rewrite. Full rewrite is simplest to specify and test for MVP.

## Related

- Resolved tension: [0004-storage-save-strategy.md](../tensions/0004-storage-save-strategy.md)
- Implementation: `components/Infrastructure/PLUGIN.md`

## Consequences

Incremental updates and migrations deferred to Phase 2+.