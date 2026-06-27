# Stale Examples Override Current Rules

**Date:** 2026-06-20  
**Priority:** High  
**Complexity:** Low-Medium  
**Phase:** 2.1

## Problem

Concrete code examples in `CODING_DESIGN.md` (synchronous `Execute`, hardcoded menu numbers, etc.) are being followed by agents even when they contradict newer rules in `AGENTS.md` (e.g. `ExecuteAsync`, dynamic menu numbering). Examples appear to carry more weight than abstract rules for some models.

## Observed Evidence

- Multiple agents noted the conflict between `Execute` examples and the `ExecuteAsync` requirement.
- Some agents appeared to mentally "update" the examples, while others flagged it as a deviation.
- Hardcoded numbers in handler `Name` properties conflict with dynamic menu logic described in `ARCHITECTURE.md`.

## Proposed Solution

- Update all code examples in `CODING_DESIGN.md` to match current rules (`ExecuteAsync`, no hardcoded numbers in `Name`).
- Add a prominent note at the top of `CODING_DESIGN.md`: "Examples may be illustrative. When they conflict with `AGENTS.md`, follow `AGENTS.md`."
- Consider marking older examples more clearly (e.g. "Pre-Phase 1.1 example").

## Expected Benefit

- Reduces one of the highest sources of implementation variance.
- Makes the "current truth" more obvious to agents.
