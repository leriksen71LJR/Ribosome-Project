# ARCHITECTURE_DECISIONS.md

## Architecture Decision Records (ADRs) for Fortress

This document records important architectural and design decisions made during the development of Fortress.

---

### ADR-001: SQLCipher for Data Storage
**Date:** May 2026  
**Decision:** Use **SQLCipher** (encrypted SQLite) instead of JSON files for persistent storage.  
**Rationale:** Provides transparent encryption, better performance on queries, industry-standard security, and avoids the complexity of manually encrypting/decrypting data at the application level.  
**Status:** Accepted

---

### ADR-002: Log4Net for Logging
**Date:** May 2026  
**Decision:** Use **Log4Net** as the logging library.  
**Rationale:** Mature, reliable, widely used in enterprise .NET systems, and provides excellent configuration flexibility.  
**Status:** Accepted

---

### ADR-004: SQLCipher for Data Storage
**Date:** May 2026  
**Decision:** Use **SQLCipher** (encrypted SQLite) instead of JSON files for persistent storage.  
**Rationale:** Provides transparent encryption, better performance on queries, industry-standard security, and avoids the complexity of manually encrypting/decrypting data at the application level.  
**Status:** Accepted

---

### ADR-005: Serilog for Logging
**Date:** May 2026  
**Decision:** Use **Serilog** as the logging library.  
**Rationale:** Modern, high-performance, excellent structured logging support, and widely used in the .NET ecosystem.  
**Status:** Accepted

---

### ADR-006: Error Handling via ActionContext
**Date:** May 2026  
**Decision:** Use two separate collections in `ActionContext` for error reporting:  
- `List<Exception> ExceptionErrors`  
- `List<string> ValidationErrors`  

Handlers should capture their own exceptions and report errors via these collections instead of letting exceptions propagate.  
**Rationale:** Provides clean separation between validation errors (user-facing) and unexpected exceptions. Keeps the main loop stable and user experience smooth.  
**Status:** Accepted

---

### ADR-007: Numbered Menu with Dynamic Visibility
**Date:** May 2026  
**Decision:** Use a persistent numbered menu system where each `IActionHandler` determines its own visibility based on the current context.  
**Rationale:** Simple for users, avoids showing irrelevant options, and keeps the main loop clean.  
**Status:** Accepted

---

*Keep this document updated as new important decisions are made.*