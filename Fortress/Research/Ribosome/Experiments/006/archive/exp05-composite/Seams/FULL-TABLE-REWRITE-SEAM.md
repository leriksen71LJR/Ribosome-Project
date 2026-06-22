# FULL-TABLE-REWRITE-SEAM.md

**Purpose:** Document the seam around storage save strategy (full-table rewrite vs incremental).

## Current Approach (MVP)
Full-table rewrite on `SaveAsync` is acceptable for the Phase 1.2A MVP.

## Impact
This choice affects performance and data migration strategy in future phases.

## Notes
This seam was identified during the Phase 1.2A shootout and is tracked here for future resolution. It is also referenced in `Seams/STORAGE-SAVE-STRATEGY.md`.