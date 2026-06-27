# STORAGE-SAVE-STRATEGY.md

**Purpose:** Clarify the current storage save strategy for the MVP.

## Current Approach (MVP)
Full-table rewrite on `SaveAsync` is acceptable for the Phase 1.2A MVP.

## Future Direction
Incremental updates and data migrations are deferred to later phases.

## Notes
This decision is captured to make the current seam explicit. Any change to save semantics would require updating this file and associated decision procedures.