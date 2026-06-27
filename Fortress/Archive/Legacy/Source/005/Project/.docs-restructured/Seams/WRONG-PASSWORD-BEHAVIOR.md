# WRONG-PASSWORD-BEHAVIOR.md

**Purpose:** Define the required behavior when an incorrect master password is provided.

## Requirements
- Show error message: "Incorrect master password."
- Remain locked.
- Do **not** silently create a new database.
- Do not overwrite existing files.

## Notes
This behavior is critical for security and user trust. It is part of the Security Component specification and should not be deviated from without explicit reporting.