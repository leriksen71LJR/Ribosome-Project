# CROSS-COMPONENT-INTEGRATION-GUIDANCE.md

**Purpose:** Provide guidance on how different components should interact, especially at known seams.

This file focuses on integration patterns and known cross-component responsibilities.

## Example: Encryption and Storage Integration

When unlocking the vault, the derived encryption key must be applied to `SqliteConnection` objects before any data operations. Storage services should not open connections without proper keying.

## Notes
- Specific decision procedures for seam conflicts are maintained in `Seams/DECISION-PROCEDURES.md`.
- This file is intended to evolve as new integration patterns and seams are identified.

*Designed to be extended through addition of new integration guidance.*