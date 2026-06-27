# Implementation-Order-Strategy.md

**Type:** Process Strategy

**Purpose:** Define the mandatory bottom-up implementation order for all work.

## Required Order
1. Contracts (interfaces)
2. Models (data classes)
3. Infrastructure services
4. Security & Session services
5. Actions (handlers)
6. Bootstrapping
7. Tests

## Rules
- Never implement a handler before its required services and contracts exist.
- Never implement a service before its contracts and dependent models exist.
- The Architect Agent must reject plans that violate this order.

## Notes
This strategy enforces architectural integrity. Alternative ordering strategies are not recommended for this project.