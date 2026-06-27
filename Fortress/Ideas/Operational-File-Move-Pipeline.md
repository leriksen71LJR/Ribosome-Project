# Operational File Move / Repo Cleanup Pipeline

**Purpose:** A lightweight, repeatable process for doing larger or messy file moves and repo cleanups (e.g. the current Research/ simplification). 

This is an operational tool for Research + Director to use so we don't do ad-hoc big scripts that fail silently. It applies the same principles we use for phases and ideas: preflight, small batches, explicit reflection, and high-signal handoff.

**When to use:** 
- Any significant folder restructuring
- Bulk moves of experiments, archives, or old material
- Cleaning up after a phase (like post-Phase 2.1)
- Anytime the "just run this big command" temptation appears

## The Process

1. **Preflight**  
   Quick check before touching anything.  
   - What exactly are we trying to achieve?  
   - What's the target structure?  
   - Current state snapshot (what's still at the root)?  
   - Risks or gotchas (empty folders, references in docs, git)?  
   - Do we have a clear "done" definition?

2. **Break into small, intentional batches**  
   Never one giant script. Group logically (e.g. "move meta files", "move old experiments", "move support folders").  
   One batch at a time.

3. **Execute + Immediate Verify**  
   Run the small move(s).  
   Immediately list the affected folders and spot-check.  
   Confirm the expected files are gone from the old place and present in the new place.

4. **Reflection (required, not optional)**  
   After each batch ask:  
   - Did that do what we expected?  
   - Anything left behind or unexpected?  
   - Any docs (STRUCTURE.md, etc.) that now need updating?  
   - Lessons for the next batch?

5. **Repeat until done**

6. **Final Disclosure / Handoff**  
   - Update STRUCTURE.md (and Current-Context if relevant) so the new layout is the official record.  
   - Produce a short summary of what was moved and the final state.  
   - Note any open questions or follow-up cleanups needed.

## Why This Exists
Big one-shot PowerShell blocks are fragile (we've seen them do nothing).  
This process forces us to stay in "thinking partner" mode even on boring operational work.  
It matches the broader principles: small viable steps, explicit reflection, conservative changes, and giving the Steward clean, high-quality results.

**Use this every time** a larger move or cleanup comes up. No exceptions.

---
*Saved for future use. This is now part of our operational toolkit.*