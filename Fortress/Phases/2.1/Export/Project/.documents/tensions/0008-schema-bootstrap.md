# Tension 0008 — Schema Bootstrap Paths

## Status

Open

## Description

Whether schema creation runs inside `SqliteStorageService` on first open vs an explicit ensure step elsewhere is acceptable but must be chosen once and reported.

## Why It Matters

Linked to [0004-storage-save-strategy.md](0004-storage-save-strategy.md) — bootstrap timing affects save and first-run behavior.

## Affected Areas

- `components/Infrastructure/PLUGIN.md`
- `components/Security/PLUGIN.md`

## Current State / Workarounds

Either path acceptable if disclosed once in build report (per resolved 0004).

## Related Tensions

- [0004-storage-save-strategy.md](0004-storage-save-strategy.md)