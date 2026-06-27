# Documentation-Boundary-Strategy.md

**Type:** Process Strategy

**Purpose:** Enforce the rule that agents must not read or reference anything under `Research/`.

## Requirements
- `Research/` is human-only thinking space.
- All content agents are allowed to use lives under `.docs/` or the current project root as defined by the active prompt.

## Notes
This strategy protects the boundary between research/experimental work and operational documentation that agents are expected to follow. Violations are considered serious.