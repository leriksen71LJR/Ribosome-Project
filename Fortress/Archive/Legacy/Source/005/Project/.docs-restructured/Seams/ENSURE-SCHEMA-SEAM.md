# ENSURE-SCHEMA-SEAM.md

**Purpose:** Document the known seam around schema ownership and `EnsureSchema` responsibility.

## Current Observation
During the Phase 1.2A shootout, there was ambiguity around whether schema creation/ensuring was the responsibility of the storage service or a separate concern.

## Current Resolution (MVP)
Schema handling lives inside the storage service initialization for the MVP.

## Future Consideration
A clearer contract (e.g., `IEnsureSchema` or explicit schema ownership) may be needed in later phases.

## Notes
This seam was surfaced during build disclosure and is tracked here for future resolution.