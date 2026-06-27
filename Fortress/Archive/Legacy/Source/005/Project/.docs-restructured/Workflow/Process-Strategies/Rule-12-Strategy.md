# Rule-12-Strategy.md

**Type:** Process Strategy

**Purpose:** Enforce the mandatory post-build Build Disclosure requirement (Rule 12).

## Requirements
- Every build must end with a Build Disclosure after the build report is complete.
- The disclosure must be honest, retrospective, and based on actual implementation.
- The output file must follow the naming convention and be placed in the project root.
- The disclosure is the final artifact — the build is not considered complete until it exists.

## Notes
This strategy is non-negotiable. Pre-build disclosure is deprecated for standard builds. Alternative disclosure approaches can be developed as separate strategies.