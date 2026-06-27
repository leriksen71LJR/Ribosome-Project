# ADR-0003: Archive Semantics (MVP)

**Status:** Accepted (Phase 1.2A)  
**Seam:** S2 — handler behavior

## Context

Original inventory used deferred phrase "archive/delete per storage design." Era B: 3/3 agents chose hard delete.

## Decision

For Phase 1.2A MVP, **archive = hard delete** from active storage. `ArchiveCompletedHandler` removes completed `TaskItem` rows on save. No `IsArchived` column in MVP schema.

## Consequences

- Inventory row updated in `components/Actions/PLUGIN.md` handler inventory.
- Soft-delete is Phase 2+ — requires schema migration ADR.

**Evidence:** Era B convergent invention cluster I-B (archive hard delete).