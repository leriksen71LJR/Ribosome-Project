# Tension 0007 — Wrong-Password / First-Run UX

## Status

Open

## Description

Behavior when the user enters an incorrect master password on an existing vault, and first-run vs returning-user flows, are not fully specified across Security and Actions plugins.

## Why It Matters

Era B inventions clustered on password UX (silent retry, lockout, messaging). Agents need explicit guidance or must gap-report.

## Affected Areas

- `components/Security/PLUGIN.md`
- `components/Actions/PLUGIN.md`

## Current State / Workarounds

Agents gap-report or assume; steward may promote resolution from build reports.

## Related Tensions

- [0008-schema-bootstrap.md](0008-schema-bootstrap.md)