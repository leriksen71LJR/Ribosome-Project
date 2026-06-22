# Visibility-Strategy.md

**Type:** Process Strategy

**Purpose:** Define how handler visibility in the menu should be managed.

## Recommended Approach
Each `IActionHandler` should implement `bool IsVisible(ActionContext context)` to decide dynamically whether it should appear in the current menu.

## Benefits
- Eliminates manual menu renumbering.
- Allows handlers to control their own visibility based on context (e.g., only show "Archive Completed Tasks" when completed tasks exist).
- Keeps the menu clean while still using the Strategy by List<T> pattern.

## Notes
This strategy is part of the core `IActionHandler` contract and supports a better user experience. Alternative visibility strategies can be developed if needed.