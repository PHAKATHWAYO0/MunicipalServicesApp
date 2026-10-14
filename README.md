# Municipal Services Application — Part 2 (Local Events and Announcements)

C# .NET Framework (4.8) Windows Forms app. Part 1 (Report Issues) plus Part 2
(Local Events and Announcements) are both implemented; Service Request
Status remains disabled until Task 3.

## How to Compile and Run
1. Requires Visual Studio 2022 with the ".NET desktop development" workload.
2. Open `MunicipalServicesApp.sln`.
3. Build: Ctrl+Shift+B.
4. Run: F5.

## How to Use
- Main Menu: Report Issues and Local Events and Announcements are both enabled.
- **Local Events and Announcements**: search events by keyword, category, and
  date range. Click an event to see full details (also pushes it onto the
  "Recently Viewed" list). The sidebar shows Next Upcoming (priority queue),
  Recommended for You (based on your search history), Recently Viewed
  (stack), and Recent Searches (queue).
- Report Issues: unchanged from Part 1 (progress feedback, duplicate
  detection, My Reports history).

## Data Structures Used (Local Events module)
- `SortedDictionary<DateTime, List<Event>>` — main event store, organised by date.
- `HashSet<string>` / `HashSet<DateTime>` — unique categories and dates.
- `Stack<Event>` — Recently Viewed history (LIFO).
- `Queue<string>` — Recent Searches (FIFO, bounded).
- `Dictionary<string,int>` — category search frequency, feeds recommendations.
- `EventPriorityQueue` (custom min-heap) — Next Upcoming Events, since
  .NET Framework 4.8 has no built-in PriorityQueue type.

## Project Structure
```
MunicipalServicesApp/
├── MunicipalServicesApp.sln
└── MunicipalServicesApp/
    ├── MunicipalServicesApp.csproj
    ├── app.config
    ├── Program.cs
    ├── Models/ (Issue.cs, Event.cs)
    ├── Data/ (IssueRepository.cs, EventRepository.cs, EventPriorityQueue.cs)
    ├── Localization/ (Translator.cs)
    ├── Controls/ (BlobGradientPanel.cs, RoundedButton.cs)
    └── Forms/ (MainMenuForm, ReportIssuesForm, MyIssuesForm, LocalEventsForm)
```
