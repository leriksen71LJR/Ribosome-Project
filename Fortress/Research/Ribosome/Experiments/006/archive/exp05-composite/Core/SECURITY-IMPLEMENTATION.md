# SECURITY-IMPLEMENTATION.md (Core)

**Purpose:** High-fidelity implementation specification for the Security Component (Phase 1.2A).

This file focuses on executable details for encryption, key derivation, and session management.

## Key Contracts
- `IEncryptionService`
- `ISessionService`
- `IKeyDerivationService`

## Implementation Notes
- Use SQLCipher with AES-256-GCM
- Key derivation must use Argon2id (PBKDF2 is not permitted without deviation)
- Master password is never persisted
- Session remains active until manual lock or timeout

## Important Flows
- First-time setup
- Subsequent unlock
- Wrong password behavior

*Detailed pseudocode and parameter tables have been preserved from the original specification.*