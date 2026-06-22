# DOUBLE-PASSWORD-PROMPT.md

**Purpose:** Document the known UX seam around double password prompting during unlock.

## Observation
Some implementations prompted for the master password twice during unlock flow, which may be unnecessary or confusing for users.

## Current Status
This is tracked as a low-severity UX seam. Future improvements may include first-run detection to avoid redundant prompts.

## Notes
This seam was surfaced during build disclosure and is recorded here for future resolution.