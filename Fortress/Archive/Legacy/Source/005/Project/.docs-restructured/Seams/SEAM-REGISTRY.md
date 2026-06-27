# SEAM-REGISTRY.md (Optional)

**Purpose:** Provide a lightweight registry of known component seams and their associated risks or decision procedures.

This file is optional and can be used if the number of identified seams grows large enough to warrant a dedicated registry.

## Example Entries

| Seam | Type | Associated Decision Procedure | Risk Level |
|------|------|-------------------------------|------------|
| Encryption ↔ Storage keying | S1 (Cross-component contract) | — | High |
| Archive semantics | S2 (Handler behavior) | DP-03 | Medium |
| ExitHandler vs session guard | S3 (Process exception) | DP-01 | Medium |

## Notes
New seams and their associated procedures can be added without modifying core specification files. This supports Open/Closed at the seam management level.