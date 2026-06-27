# SCHEMA-CONTRACT.md

**Purpose:** Clarify ownership and responsibility for database schema creation and updates.

## Current State (MVP)
Schema creation is handled inside the storage service during initialization.

## Open Question
A clearer `EnsureSchema` contract or explicit schema ownership may be needed in future phases.

## Notes
This seam was identified during the Phase 1.2A shootout. It is tracked here for future resolution.