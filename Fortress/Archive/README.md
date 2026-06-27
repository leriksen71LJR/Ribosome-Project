# Archive — Zip Only

**Policy:** Historical material is kept as a **zip**, not an expanded tree. Read-only reference for humans — build agents never see this.

---

## Current archive

| File | Contents |
|------|----------|
| [`Fortress-Archive-2026-06-27-0253.zip`](Fortress-Archive-2026-06-27-0253.zip) | Full archive snapshot (~330 files): Experiments 006–008, Investigations, Legacy, 007 drafts, BuildDisclosure support |

**Backup copy:** `Records/Backups/Fortress-Archive-2026-06-27-0253.zip` (same file)

---

## When you need to read something

1. Extract to a **temp folder** (not into this repo tree):

   ```powershell
   Expand-Archive -Path Fortress/Archive/Fortress-Archive-2026-06-27-0253.zip -DestinationPath $env:TEMP\fortress-archive-read
   ```

2. Read the file you need.
3. Delete the temp folder when done.

Do **not** re-expand into `Fortress/Archive/` — that defeats zip-only management.

---

## When to refresh the zip

Create a **new dated zip** (`Fortress-Archive-yyyy-MM-dd-hhmm.zip`) when:

- Adding material that belongs in archive (superseded docs, closed experiments)
- A major phase closes and history should be frozen

**Process:**

1. Extract current zip to temp.
2. Add new files there.
3. Zip → new filename → replace `Fortress-Archive-*.zip` here + copy to `Records/Backups/`.
4. Update this README table.
5. Log in `Records/Logs/` if session-worthy.

---

**Last updated:** 2026-06-27-0253