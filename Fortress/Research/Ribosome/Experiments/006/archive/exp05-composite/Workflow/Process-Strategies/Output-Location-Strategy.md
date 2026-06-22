# Output-Location-Strategy.md

**Type:** Process Strategy

**Purpose:** Enforce the rule that all generated files must be written to the assigned project root.

## Requirements
- All generated files must be written directly into the assigned project root folder.
- Writing to worktrees, temporary folders, or any location other than the designated root is forbidden.
- Before creating `src/`, `tests/`, or any code file, the absolute path to `AGENTS.md` must be stated in the build report.

## Notes
This strategy prevents accidental work in the wrong location (e.g., inside documentation repos or export mirrors). Deviations are high-severity.