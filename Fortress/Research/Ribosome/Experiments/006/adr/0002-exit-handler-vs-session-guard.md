# ADR-0002: ExitHandler vs Session Guard

**Status:** Accepted (Phase 1.2A)  
**Seam:** S3 — process exception

## Context

`process/AGENTS.md` Rule 3 requires session guard clauses at the start of every `ExecuteAsync`. `components/Actions/PLUGIN.md` handler inventory marks `ExitHandler` as always visible, including when locked.

## Decision

**Inventory specificity wins.** `ExitHandler` may execute without an active session when the user chooses Exit. Other handlers must guard on `context.Session is not null`.

## Consequences

- Exit is always menu-visible (`IsVisible` → always `true`).
- Exit may run while locked to allow application termination.
- Cite this ADR in build report if implementing Exit without session guard.

**Evidence:** Era B T4 rule-collision cluster (Codex exception wave).