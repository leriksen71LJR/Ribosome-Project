# Item 1: IEncryptionService Design Spec

**Date:** 2026-06-21  
**Status:** Proposed direction from Research  
**Priority:** Highest leverage documentation gap from Phase 1.2A build

---

## Problem

`IEncryptionService` in `CODING_DESIGN.md` only defines two methods:

```csharp
Task InitializeDatabaseAsync(string databasePath, byte[] key, CancellationToken cancellationToken = default);
bool VerifyKey(string databasePath, byte[] key);
```

This is insufficient for how `SqliteStorageService` actually works.

`SqliteStorageService` opens a **new connection** on every `LoadAsync` / `SaveAsync` call. Without a way to apply the encryption key to each new connection, the storage layer cannot function after the initial unlock.

Claude correctly identified this during the build and extended the interface with `ApplyKeyAsync`, `IsInitialized`, and `Clear()`. This was reported as a deviation.

Without a canonical definition, different agents will extend the interface differently (or work around it in incompatible ways).

---

## Impact

This is the single highest-leverage documentation gap surfaced in the Phase 1.2A build.

- It forces invention during implementation.
- It creates divergence between agents.
- It affects every subsequent database operation after unlock.
- It touches both security correctness and storage reliability.

---

## Recommended Direction

Adopt and formalize the pattern Claude used:

Extend `IEncryptionService` with the following responsibilities:

- `ApplyKeyAsync(SqliteConnection connection, CancellationToken cancellationToken = default)`  
  Applies the derived key to an already-opened connection (via `PRAGMA key`).

- `bool IsInitialized { get; }`  
  Indicates whether a key has been successfully derived and applied.

- `void Clear()`  
  Clears the in-memory key material (called on lock).

`SqliteStorageService` should be documented to call `ApplyKeyAsync` after every `OpenAsync` on a connection.

`SessionManager.LockAsync` should call `Clear()` on the encryption service.

---

## Rationale (Why This Matters)

At the implementation level, SQLCipher requires the key to be applied to **each connection** individually. The current spec only covers the one-time initialization path.

This gap is not obvious from reading `ARCHITECTURE_SECURITY.md` or `CODING_DESIGN.md` in isolation. It only becomes visible when actually implementing storage operations that happen after the initial unlock.

Different agents will solve this differently unless the contract is made explicit. This is the primary source of non-determinism in how agents implement the security + storage boundary.

---

## Scope for This Change

**In scope:**
- Defining the three additional members on `IEncryptionService`
- Documenting the expected usage pattern in `SqliteStorageService`
- Updating the security initialization and lock flows in `ARCHITECTURE_SECURITY.md`

**Out of scope for this pass:**
- Refactoring to a connection factory or pooled connections
- Changing any existing method signatures
- Implementing the changes in code (this is a documentation specification only)

---

## Files to Update

- `CODING_DESIGN.md` — Security Component contracts section
- `ARCHITECTURE_SECURITY.md` — Implementation Specification section

No other files require changes for this item.

---

**End of specification.**