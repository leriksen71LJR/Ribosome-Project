# Preflight Reports

When the Director asks for a preflight report on a phase or idea, it's just for us.

The point is to double-check our own work before we hand anything to the Steward. It doesn't change anything in the actual project. It just helps us make sure the thinking is as complete and high-quality as we can make it.

How it usually goes:
Director: "hey let's get a preflight report for [phase or idea]"
Research: asks a few questions if we need more clarity
Research: "ok, I got what I need and I'll make the report"
Then Research writes up a short report.

The report is only to tell us (Director + Research) whether the work feels done or if there's important stuff still missing. We want to give the Steward the cleanest, most complete picture possible.

Things worth checking in a preflight:
- Have we actually finished the thinking on this, or are there big gaps?
- What decisions are locked vs still open?
- Is the core idea or phase clear enough that the Steward could work with it without us having to explain a bunch of missing pieces?
- Did we capture the important tensions, trade-offs, or lessons?
- Does this line up with the way we like to work (Specification Pipeline, keeping things conservative and high-signal)?
- What would the Steward still need from us to feel like they have the full story?

Keep it light. We're not trying to create bureaucracy — just making sure we don't hand over half-baked stuff.

## Operational File Move / Repo Cleanup Process

When doing larger file moves, cleanups, or repo simplification (like the current Research/ consolidation), we use a lightweight operational pipeline. This is an extension of the preflight idea, applied to file work.

**Process:**
1. **Preflight** — Quick internal check: What are we trying to achieve? Current state? Risks? Target structure? (Use the same light question style as above.)
2. **Small batches** — Break into tiny, logical groups (e.g., one type of file or folder at a time). Never one giant script.
3. **Execute + Verify** — Do the batch. Immediately check with dir/list that it worked as expected.
4. **Reflect** — After each batch: Did it do what we expected? Anything left? Update docs if needed? Lessons?
5. **Repeat** until done.
6. **Final Disclosure** — Update STRUCTURE.md (and any relevant logs) with the new state. Summarize what was done and the final layout.

**When to trigger:** Any time we're tempted to do a big one-shot move. Director can say "preflight the cleanup" or "run a file move preflight".

**Key lenses to check (adapt as needed):**
- Alignment with high-signal and conservative principles.
- Clear ownership (Steward design vs ops).
- No unnecessary fragmentation.
- All important history preserved in Archive/ or git.
- Resulting structure is simple (aim for 3-5 root folders).
- Docs (STRUCTURE.md etc.) are updated.

This keeps us consistent with the Specification Pipeline thinking even for boring operational work. Saved here so we use it going forward.