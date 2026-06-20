# PROJECT_OVERVIEW.md

## Project Name
**Fortress**

**Tagline**: Your secure personal command center.

---

## Vision
Fortress is a powerful, secure, console-based personal operating system designed for individuals who want complete control over their tasks, notes, goals, and sensitive information in one encrypted environment.

The goal is to create a "digital fortress" — a reliable, private, and highly organized space that protects what matters most while remaining fast and efficient to use from the terminal.

---

## Why Fortress?
In an age of fragmented apps and constant digital noise, Fortress offers a single, secure, keyboard-first sanctuary where users can manage their entire personal and professional life without compromise.

---

## Core Purpose
- Provide a secure, encrypted environment for personal productivity and sensitive data
- Combine task management, note-taking, goal tracking, and credential storage in one application
- Deliver a professional-grade console experience that feels both powerful and simple
- Serve as a long-term personal knowledge and productivity system

---

## Target User
- Power users and professionals who live in the terminal
- People who value privacy and security
- Users who want a single, reliable tool instead of many disconnected apps
- Anyone who prefers keyboard-driven workflows over GUI applications

---

## Key Principles
- **Security First**: All sensitive data is encrypted at rest using strong encryption
- **Console Native**: Built for speed and efficiency in the terminal
- **Simplicity + Power**: Easy to use for basic needs, deeply customizable for advanced users
- **Data Ownership**: Full control over your data with easy export and backup
- **Long-term Reliability**: Designed to be used for years, not months

---

## Launch Scope (MVP Features)

The following 7 features will be included in the initial release:

1. **Task Management** — Create, edit, complete, and organize tasks with priority, due dates, and tags
2. **Secure Notes** — Encrypted note-taking with search and organization
3. **Credential Vault** — Secure storage for passwords and sensitive information (protected by master password)
4. **Goal Tracking** — Set personal goals with milestones and progress tracking
5. **Unified Search** — Fast, powerful search across tasks, notes, and credential titles
6. **Tagging & Filtering** — Flexible tagging system with powerful filtering capabilities
7. **Export & Backup** — Export data and create encrypted backups

---

## Technology Stack (High-Level)
Built with C# (.NET 8+) using a Strategy by List<T> architecture and Microsoft Dependency Injection. Full technical details are available in `ARCHITECTURE.md`.

---

## Success Criteria
- The application is fully functional and secure
- All 7 core features work reliably
- The agent team can build the entire project using only the documentation
- The codebase follows professional standards and is easy to maintain
- Users can comfortably use Fortress as their primary personal command center

---

## Non-Goals (Out of Scope for Launch)
- Web or mobile interface
- Cloud synchronization
- Team/collaboration features
- Advanced analytics or reporting
- Integration with third-party services

## Future Vision (Post-Launch)
**Phase 2:** Recurring tasks, habit tracking, and improved search capabilities.  
**Phase 3:** Optional web companion and selective cloud sync.

---

## Configuration Management

### Purpose
Fortress supports a small set of configurable settings that control security and user experience.

### Key Configuration Items
- **Master Password Policy** — Minimum length, required character types
- **Auto-Lock Timeout** — Minutes of inactivity before automatic lock (default: 15)
- **Default Export Format** — JSON or CSV
- **Verbose Mode** — Enable detailed output for debugging (default: off)
- **Storage Location** — Path for encrypted data files (default: application folder)

### Storage
Configuration is stored in a small unencrypted `config.json` file (or `appsettings.json`). Sensitive values (like the master password) are **never** stored in configuration.

### Loading
Configuration is loaded early during the bootstrapping process and made available through the `ActionContext` or a dedicated `IConfigurationService`.

---

*This document serves as the high-level foundation. All other documentation in the `.docs/` folder will align with this vision.*