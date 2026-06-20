# Phase 1.2 Prompt - Claude

**Single Source of Truth:** `.docs/` is the only authoritative source.

**Critical Rules (Non-Negotiable):**

**Output Location Rule (Mandatory):**  
All generated files and code **must** be written directly into the assigned project root folder you were given.  
Writing to any git worktree, `.claude/worktrees/`, or temporary harness folder is **strictly forbidden**. This is a process violation.

**Documentation Audit (Mandatory):**  
At the end of the build, include a section titled **"Deep Documentation Audit"** in your build report. Use the criteria in `.docs/Evaluation/EvaluationCriteria.md`. Go deep on your reasoning.

**Violation Reporting:**  
If you cannot follow a rule, document it clearly under **"Violations and Deviations"** with explanation.

Read the following in order before starting:
1. `.docs/AGENTS.md`
2. `.docs/CODING_STANDARDS.md`
3. `.docs/Prompts/Phase-1.2/Claude.md` (this file)
4. `.docs/Phases/PHASE_1_2_IMPROVEMENTS.md`

Then begin the build.