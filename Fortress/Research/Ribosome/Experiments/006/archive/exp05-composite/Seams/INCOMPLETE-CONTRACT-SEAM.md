# INCOMPLETE-CONTRACT-SEAM.md

**Purpose:** Document seams caused by incomplete interface or contract definitions.

## Example from Phase 1.2A
`IEncryptionService` only defined `InitializeDatabaseAsync` and `VerifyKey`. The storage layer required `ApplyKeyAsync` for per-connection keying, which was not part of the interface.

## Impact
This led to different implementation shapes (isoforms) across agents and created a high-severity seam.

## Recommended Action
Ensure that interface bodies in `CODING_DESIGN.md` are complete or explicitly marked as deferred with a linked Decision Procedure.

## Notes
This type of seam (incomplete contracts) was one of the most expensive in the Phase 1.2A shootout. It is tracked here as a pattern to avoid in future specifications.