# BuildDisclosure-Core-Protocol.md

**Type:** Core Workflow Protocol

**Purpose:** Define the mandatory post-build disclosure requirements (Rule 12). This file focuses only on the non-negotiable protocol.

## Requirements
- Disclosure must be the final step of every build.
- Must produce a file named `REASONING-YYYY-MM-DD-XXX-{Agent}.md` in the project root.
- Must include the mandatory header block and required sections.
- Must be based on actual implementation performed during the build.
- Must be returned to project stewards.

## Notes
Specific analytical strategies, disclosure styles, and optional craft layers have been moved to strategy files under `Workflow/Disclosure-Strategies/`.

*This protocol is designed to remain relatively stable while disclosure strategies can evolve.*