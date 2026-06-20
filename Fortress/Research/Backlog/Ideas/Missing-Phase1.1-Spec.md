# Missing PHASE_1_1_IMPROVEMENTS.md Specification

**Date:** 2026-06-20  
**Priority:** High  
**Complexity:** Low  
**Phase:** 2.1

## Problem

`AGENTS.md` references `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md` as containing mandatory requirements (structured build reports, explicit deviation reporting, `ExecuteAsync`, etc.). This file is missing from the current documentation set. Agents are forced to operate from a one-line summary in `AGENTS.md` instead of the full specification.

## Observed Evidence

- All three agents flagged the absence of this file.
- The `ExecuteAsync` requirement, build report format, and deviation reporting details are only partially documented.
- The empty `.docs/Phases/` folder creates uncertainty about whether Phase 1.1 rules are fully in force.

## Proposed Solution

Either:
- Restore `PHASE_1_1_IMPROVEMENTS.md` with the full specification, **or**
- Inline the critical Phase 1.1 requirements directly into `AGENTS.md` so they are self-contained and not dependent on a missing file.

## Expected Benefit

- Eliminates a major source of incomplete process understanding.
- Makes Phase 1.1/1.2 requirements explicit and verifiable without requiring agents to hunt for missing files.
