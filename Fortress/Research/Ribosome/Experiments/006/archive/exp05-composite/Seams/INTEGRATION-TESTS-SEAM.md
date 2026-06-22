# INTEGRATION-TESTS-SEAM.md

**Purpose:** Document the known gap around SQLCipher round-trip integration testing.

## Observation
The Phase 1.2A shootout revealed that integration tests for encryption + storage round-trips were either missing or not clearly required.

## Impact
This creates a seam where functional correctness of encryption + persistence could drift without detection.

## Recommended Action
Add explicit guidance or requirements for SQLCipher integration testing in future phases or in `AGENTS.md` Rule 4.

## Notes
This seam was surfaced during build disclosure and is tracked here for future resolution.