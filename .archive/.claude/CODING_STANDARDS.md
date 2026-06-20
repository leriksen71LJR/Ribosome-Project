# CODING_STANDARDS.md

## Coding Standards & Guidelines

This document defines the non-negotiable rules for all code written in the Forge task manager project. All agents and developers **must** follow these standards. Violations will be caught by the Reviewer Agent and must be fixed before any merge or deployment.

### General Principles

- **Readability First**: Code should be self-documenting. Comments explain *why*, not *what*.
- **Simplicity Over Cleverness**: Prefer boring, obvious solutions that a junior developer can understand in 5 minutes.
- **Consistency**: Follow the style of existing code unless a better pattern is proposed, reviewed, and approved.
- **Test-Driven Development (Mandatory)**: New features require failing tests written *before* implementation code. "If it's not tested, it's not done."

### Technology Stack Standards

**Python (Backend - FastAPI)**
- Formatter: `black` (line-length=88)
- Linter: `ruff` (strict mode)
- Type Checker: `mypy` (strict)
- Testing: `pytest` + `pytest-cov` + `pytest-asyncio`
- Async: Use `asyncio` + `httpx` for HTTP clients
- API: Follow FastAPI best practices (Pydantic v2 models, dependency injection)

**TypeScript / React (Frontend)**
- Formatter: `prettier`
- Linter: `eslint` + `@typescript-eslint`
- Testing: `vitest` + `@testing-library/react` + Playwright for e2e
- State: Use React hooks + TanStack Query where appropriate

### Exception Handling (Mandatory)

**Core Rule**: Never swallow exceptions silently.

#### Guidelines:
1. **Catch Only What You Can Handle**
   - Catch specific exceptions, never bare `except:` or `catch (Exception e)`
   - If you catch, you must either:
     - Recover meaningfully, **or**
     - Re-raise with additional context, **or**
     - Log + re-raise

2. **Always Provide Context**
   ```python
   # Good
   try:
       result = await risky_operation(item_id)
   except SpecificDomainError as e:
       logger.error(f"Failed to process {item_id} during {phase}: {e}", exc_info=True)
       raise ProcessingError(f"Item {item_id} failed in {phase}") from e
   ```

3. **Use Custom Exceptions** for domain errors
   - Create meaningful exception hierarchies under `forge.exceptions`
   - Include relevant data in the exception object (e.g., `item_id`, `user_id`)

4. **Never Return Error Codes** (use exceptions instead)

5. **Global Exception Handler**
   - Every entry point (API, CLI, background job) must have a top-level exception handler that:
     - Logs the full stack trace
     - Returns a safe, user-friendly error response
     - Never leaks internal details, stack traces, or sensitive data to clients

### Formatting & Tooling (Enforced in CI)

- Pre-commit hooks: **Mandatory** (black, ruff, mypy, prettier, eslint)
- All code must pass `ruff check --fix` and `black --check`
- Type coverage target: 95%+ on new code (mypy strict)
- Test coverage target: **≥ 85%** overall, **≥ 90%** on new features (enforced by Tester + Reviewer)

### Documentation

- Every public function, class, and API endpoint must have a clear docstring / JSDoc
- Complex logic requires inline comments explaining the *why* and any non-obvious trade-offs
- Update relevant architecture or decision docs when behavior changes

### Security (Non-Negotiable)

- Never hardcode secrets (use environment variables + secret manager)
- Validate **all** inputs (Pydantic models + sanitization)
- Use parameterized queries / prepared statements
- Follow OWASP guidelines + principle of least privilege
- Rate limiting and authentication on all public endpoints

### Performance

- Avoid premature optimization
- Profile before optimizing (use `py-spy` or browser devtools)
- Document any algorithm worse than O(n log n)
- Keep hot paths < 50ms where possible

---

**Violations of these standards will be caught by the Reviewer Agent and must be fixed before merge. The Tester Agent will block deployment on insufficient coverage or failing tests.**

*Last Updated: 2026-05-24 | Aligned with 5-agent Forge Team*