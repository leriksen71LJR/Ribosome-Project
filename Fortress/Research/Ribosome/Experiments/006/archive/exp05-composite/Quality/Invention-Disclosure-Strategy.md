# Invention-Disclosure-Strategy.md

**Type:** Quality Strategy

**Purpose:** Define how invention (implementation choices made due to specification gaps) should be made visible during and after builds.

## Core Principle
Invention should be treated as diagnostic information, not as failure. The goal is visibility and feedback into documentation quality.

## Recommended Practices
- Surface major inventions in build reports.
- Consider adding an Invention Summary table in combined disclosure formats.
- Distinguish between different types of invention (contract completion, behavior disambiguation, exception rules, etc.).

## Notes
This strategy can evolve independently from other quality and disclosure mechanisms.

*Designed to support Open/Closed — new invention tracking approaches can be added without modifying core disclosure files.*