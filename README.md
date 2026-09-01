# Municipal Services Application — Part 2 (Report Issues)

A C# .NET Framework (4.8) Windows Forms application that lets citizens report
municipal issues (potholes, water leaks, sanitation problems, etc.). This is
the first module of a larger Municipal Services App; the "Local Events" and
"Service Request Status" menu options are visible but disabled, as required
by the brief — they will be implemented in a later part of the Portfolio of
Evidence.

## 1. Requirements

- Windows 10/11
- Visual Studio 2022 (Community edition is fine) with the **.NET desktop
  development** workload installed
- .NET Framework 4.8 Developer/Targeting Pack (installed automatically by
  the workload above if it isn't already on your machine)

## 2. How to Compile and Run

1. Unzip the project folder if you received it as a `.zip`.
2. Open **`MunicipalServicesApp.sln`** by double-clicking it (this opens
   Visual Studio) — or from within Visual Studio: **File → Open → Project/
   Solution…** and select the `.sln` file.
3. Let Visual Studio finish loading/restoring the project (first load may
   take a few seconds).
4. Press **F5** (or click the green ▶ **Start** button) to build and run the
   application. You can also build only, with **Build → Build Solution**
   (Ctrl+Shift+B).
5. The compiled executable will appear at:
   `MunicipalServicesApp\bin\Debug\net48\MunicipalServicesApp.exe`

> **No internet connection or NuGet packages are required** — the project
> only uses the built-in `System.Windows.Forms` libraries that ship with
> .NET Framework.

## 3. How to Use the Application

1. On startup, the **Main Menu** appears with three options:
   - **Report Issues** — enabled, fully functional.
   - **Local Events and Announcements** — disabled (out of scope for this part).
   - **Service Request Status** — disabled, per the Task 2 brief (only
     "Report Issues" is required to be enabled in this part of the PoE).
     The underlying "My Reported Issues" feature is still fully built —
     see step 7 below for how to reach it.
2. In the top-right corner of the Main Menu, use the **EN / ZU / AF**
   buttons to switch the app's language between English, isiZulu, and
   Afrikaans. The selected language applies immediately and carries over to
   every screen you open afterwards.
3. Click **Report Issues** to open the reporting form.
4. Fill in the details of the issue:
   - **Location** — free-text field for where the issue is.
   - **Category** — choose from the dropdown (translated into the selected
     language).
   - **Description** — describe the issue in the text box.
   - **Attach Image/Document** *(optional)* — click the button to open a
     file dialog and attach a supporting photo or document.
5. As you fill in each field, watch the **progress bar and message** near
   the bottom of the form update — this is the app's user engagement
   feature (see the accompanying research document, Task 1).
6. Click **Submit Report**.
   - If any required field is missing, a message box tells you what's
     missing.
   - If the app detects a **similar issue already reported** in the same
     category with a matching location (see "Duplicate detection" below),
     it asks whether you'd like to add your support to that existing report
     instead of filing a new one.
   - Otherwise, a confirmation message box shows your unique reference
     number (e.g. `MSA-1001`) and the form clears, ready for the next report.
7. Click **📄 My Reports** (top-right of the Report Issues screen) to see
   every issue reported this session, its category/location, how many
   citizens support it, and a live status. This is the only entry point to
   that screen in the current build, since the Main Menu's "Service Request
   Status" button is intentionally disabled (see point 1).
8. Click **← Back to Main Menu** at any time to return to the main menu.

Every submitted report is also written to an `IssueLog.txt` file created
next to the `.exe`, so you have a simple audit trail of everything reported
during a session (in addition to being kept in memory for the running
application).

### My Reported Issues (history view)

A dedicated screen (`MyIssuesForm`) lists every issue in the shared
`IssueRepository`, with columns for reference number, category, location,
date, supporter count, and status. If nothing has been reported yet, a
friendly empty-state message is shown instead of a blank table. Status is
derived automatically: an issue supported by 3 or more citizens is shown as
"Under Review" rather than "Submitted", reflecting that it's been noticed
more than once — there is no backend workflow yet, so this is a simple,
transparent stand-in rather than a real ticketing system.

Per the Task 2 brief, the Main Menu's "Service Request Status" button stays
**disabled** in this submission (only "Report Issues" is required to be
enabled). The history screen is instead reached via the **📄 My Reports**
button on the Report Issues form. The `btnServiceStatus_Click` handler that
opens the same screen is already written and wired up in `MainMenuForm` —
re-enabling that button in a later part of the PoE is a one-line change
(`btnServiceStatus.Enabled = true;`).

### Duplicate / similar-issue detection

Before creating a new report, `IssueRepository.FindSimilarIssues` checks
whether an issue in the same category with a closely matching location has
already been submitted (exact match, one location description containing
the other, or ≥50% word overlap — e.g. "Corner of Main Rd and 5th Ave" vs
"5th Ave and Main Road"). If a match is found, the user is asked whether to
add their support to the existing report instead of creating a duplicate.
This is a simple in-memory heuristic, not true geolocation, since the app
has no map/GPS data available — but it's enough to meaningfully reduce
duplicate tickets for the same real-world issue.

### Multilingual UI (English / isiZulu / Afrikaans)

All static UI text (labels, buttons, headers, and the category dropdown) is
routed through `Localization/Translator.cs`, a small dictionary-based
translation helper with no external dependencies. Switching language on the
Main Menu updates its own text immediately and is picked up by every screen
opened afterwards. **Note:** the isiZulu and Afrikaans strings are a
best-effort, common-usage translation and have not been reviewed by a
fluent speaker — for a real deployment, these should be checked before
going live. Dynamic message-box text (validation errors, the duplicate-issue
prompt, submission confirmations) is intentionally left in English for this
version to keep the scope manageable.

## 4. Project Structure

```
MunicipalServicesApp/
├── MunicipalServicesApp.sln
└── MunicipalServicesApp/
    ├── MunicipalServicesApp.csproj
    ├── app.config
    ├── Program.cs                        # Application entry point
    ├── Models/
    │   └── Issue.cs                       # Data model for a reported issue
    ├── Data/
    │   └── IssueRepository.cs             # In-memory List<Issue> store, duplicate detection, file log
    ├── Localization/
    │   └── Translator.cs                  # EN / isiZulu / Afrikaans UI text
    ├── Controls/
    │   ├── BlobGradientPanel.cs           # Purple gradient "hero" panel with soft blob shapes
    │   └── RoundedButton.cs               # Rounded, optionally gradient-filled button
    └── Forms/
        ├── MainMenuForm.cs / .Designer.cs      # Main menu (3 options) + language switcher
        ├── ReportIssuesForm.cs / .Designer.cs  # Report Issues form, engagement + duplicate detection
        └── MyIssuesForm.cs / .Designer.cs      # "My Reported Issues" history view
```

### Purple theme

The UI uses a purple colour palette inspired by modern gradient "hero panel"
login screens: a `BlobGradientPanel` custom control paints a diagonal purple
gradient (`#5E35D1` → `#B388FF`) with a few soft, semi-transparent blob
shapes layered on top, and a `RoundedButton` custom control gives buttons
rounded corners with either a purple gradient fill (primary actions) or an
outlined style (secondary actions). Both controls live in `Controls/` and are
plain GDI+ drawing code with no external dependencies, so they compile with
nothing beyond the standard `System.Windows.Forms` / `System.Drawing`
references already in the project.

## 5. Design Notes (mapped to the brief)

- **Data structure:** reported issues are stored in a `List<Issue>`
  (`IssueRepository`), which is well suited to an unbounded, append-only
  collection of records.
- **Media attachment:** implemented with `OpenFileDialog`, restricted to
  common image/document types but allowing "All files" too.
- **Engagement feature:** a `ProgressBar` + `Label` combination that updates
  live via the `InputChanged` event handler wired to every input control.
  This is the gamified "progress feedback" strategy selected and justified
  in the Task 1 research document.
- **User feedback:** `MessageBox` dialogs are used for both validation
  errors and submission confirmation.
- **Navigation:** `ReportIssuesForm` is opened modally
  (`ShowDialog()`) from `MainMenuForm`, so there is always exactly one
  visible window, and "Back to Main Menu" simply closes the dialog.
- **Consistency:** both forms share the same colour palette (green
  `#005A3C` / `#007850` accents on white) and font (Segoe UI) for a
  consistent look and feel.

## 6. Known Limitations (by design, for this part of the PoE)

- Data is **not** persisted between application runs (only within a single
  session, plus the append-only `IssueLog.txt` audit trail) — a database or
  file-based data store can be added in a later part.
- "Local Events and Announcements" and "Service Request Status" are
  intentionally disabled, per the Task 2 brief.
