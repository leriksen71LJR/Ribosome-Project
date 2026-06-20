# ARCHITECTURE_SECURITY.md

## Overview
This document defines the security architecture for **Fortress**. It explains how data is protected both at rest and during use, following the Component Pattern (Contracts → Implementations → Model).

---

## Security Goals

- **Confidentiality at Rest**: All user data remains encrypted and unreadable without the master password when Fortress is not running.
- **Integrity**: Protect data from unauthorized modification using authenticated encryption.
- **Transparent Encryption**: Encryption is handled transparently via SQLCipher — the application does not need to manually encrypt/decrypt data.
- **Usability**: Strong security without forcing users to wait for decryption.

---

## Security Component

The Security Component follows the standard Component structure:

### Contracts

```csharp
/// <summary>
/// Derives an encryption key from the master password and stored salt/parameters.
/// </summary>
public interface IKeyDerivationService
{
    /// <summary>
    /// Derives the key used for SQLCipher.
    /// </summary>
    byte[] DeriveKey(string password, string salt, KeyDerivationParameters parameters);
}
```

- `IEncryptionService`
- `ISessionService`
- `IKeyDerivationService`

### Implementations
- `EncryptionService` (wraps SQLCipher operations)
- `SessionManager`
- `Argon2KeyDerivationService`

### Model
- `UserSession`
- Encryption key material (never persisted)
- Master password (never persisted)

---

## Master Password & Key Management

### Initial Setup (One-Time Process)
- On first launch, the user creates a strong master password.
- This password is used **only once** during setup to:
  - Generate a random salt
  - Derive the encryption key using **Argon2id**
  - Initialize the encrypted SQLite database (SQLCipher)
- After setup, the raw master password is immediately discarded from memory.

### Subsequent Use
- Only the salt and key derivation parameters are stored on disk.
- Every future launch, the user enters their master password.
- Fortress uses the stored salt + parameters to re-derive the **exact same encryption key**.
- The raw password is **never** stored at any point.

---

## Encryption at Rest (SQLCipher)

### Technology
- **SQLCipher** (encrypted SQLite)
- AES-256-GCM encryption
- Transparent encryption — all SQL operations work normally

### What Gets Encrypted
- All tables and data (tasks, notes, credentials, goals)
- The entire database file is encrypted at rest

### Key Derivation
- Argon2id (recommended) or PBKDF2
- High iteration count and memory cost to resist brute-force attacks

---

## Session Management

- Once the correct master password is entered, a `UserSession` is created.
- The session remains active until the user manually locks or the app is closed.
- Optional auto-lock after a configurable period of inactivity.

---

## Threat Model

**These security constraints are MANDATORY.**

### What We Protect Against
- Unauthorized access to the database file when Fortress is closed
- Offline brute-force attacks on the encrypted database
- Data exposure through file theft or sharing

### What We Do NOT Fully Protect Against
- Malware running while Fortress is unlocked
- Physical access while the app is unlocked
- Weak master passwords chosen by the user

---

## Data Backup & Recovery

- Users can create encrypted backups of the entire Fortress database.
- Recovery requires the master password.
- Clear warnings will be shown that the master password cannot be recovered.

---

## Summary
Fortress uses **SQLCipher** for transparent encryption at rest. The Security Component follows the standard Component Pattern and is responsible for master password handling, key derivation, and session management.

---

*This document should be read together with `ARCHITECTURE.md` and `PROJECT_OVERVIEW.md`. All implementation must strictly follow the rules defined here.*