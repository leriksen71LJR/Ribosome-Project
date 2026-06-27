# ADR-0006: Incomplete Contract — Acceptance Criteria

**Status:** Accepted (Phase 1.2A)  
**Seam:** S1 — cross-component contract (T3)

## Context

Era B: `IEncryptionService` had init/verify only. 3/3 agents invented per-connection keying; 2/3 disclosed; 2 interface isoforms + 1 static helper isoform.

## Decision

`IEncryptionService` **must** include on the interface:

- `bool IsInitialized { get; }`
- `Task ApplyKeyAsync(SqliteConnection connection, CancellationToken cancellationToken = default)`
- `void Clear()`

**Forbidden:** Static-only key application helper while leaving interface unchanged.

**Bridge spec:** `components/Security/PLUGIN.md` (Storage bridge section) — storage calls `ApplyKeyAsync` after every `OpenAsync`.

## Acceptance criteria (Era C regression)

| Criterion | Required |
|-----------|----------|
| Method on interface | `ApplyKeyAsync` public on `IEncryptionService` |
| Key lifetime | In-memory in `EncryptionService` until `Clear()` |
| Lock behavior | `LockAsync` calls `Clear()`; storage fails when locked |
| Isoforms | 0–1 inter-agent shapes on next shootout |

## Consequences

Full contract in `components/Security/PLUGIN.md`.

**Evidence:** Era B encryption cluster; P1 steward patch on live export; §9.5 regression target.