using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MunicipalServicesApp.Data
{
    /// <summary>
    /// Central in-memory store for reported issues, backed by a List&lt;Issue&gt;.
    /// A List is used (rather than an array) because the number of issues
    /// reported in a session is unknown ahead of time and issues are only
    /// ever appended, never inserted at an arbitrary index, which List&lt;T&gt;
    /// handles efficiently (O(1) amortised Add).
    ///
    /// This class is static so that every form in the application shares the
    /// same collection for the lifetime of the process. Each submitted issue
    /// is also appended to a local log file so there is a persistent audit
    /// trail on disk (IssueLog.txt, created next to the executable).
    /// </summary>
    public static class IssueRepository
    {
        private static readonly List<Models.Issue> _issues = new List<Models.Issue>();
        private static int _nextReferenceNumber = 1000;

        public static IReadOnlyList<Models.Issue> Issues => _issues.AsReadOnly();

        public static int Count => _issues.Count;

        /// <summary>
        /// Generates a simple, human-readable reference number for a newly
        /// reported issue, e.g. "MSA-1001".
        /// </summary>
        public static string GenerateReferenceNumber()
        {
            _nextReferenceNumber++;
            return $"MSA-{_nextReferenceNumber}";
        }

        public static void Add(Models.Issue issue)
        {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            _issues.Add(issue);
            TryAppendToLog($"NEW REPORT\t{issue.DateReported:yyyy-MM-dd HH:mm:ss}\t{issue.ReferenceNumber}\t{issue.Category}\t" +
                            $"{issue.Location}\tAttachment: {(issue.HasAttachment ? issue.AttachmentPath : "None")}\tDescription: {issue.Description}");
        }

        /// <summary>
        /// Records that another citizen has raised essentially the same
        /// issue, instead of creating a brand-new duplicate entry.
        /// </summary>
        public static void AddSupport(Models.Issue issue)
        {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            issue.SupportCount++;
            TryAppendToLog($"SUPPORT ADDED\t{DateTime.Now:yyyy-MM-dd HH:mm:ss}\t{issue.ReferenceNumber}\tNew supporter count: {issue.SupportCount}");
        }

        /// <summary>
        /// Looks for already-reported issues in the same category whose
        /// location text is a close match to <paramref name="location"/>,
        /// so the UI can prompt the user to support an existing report
        /// instead of filing a duplicate. This is a lightweight, in-memory
        /// heuristic (exact match, substring containment, or &gt;=50% word
        /// overlap) rather than true geolocation, since the app does not
        /// have map/GPS data available.
        /// </summary>
        public static List<Models.Issue> FindSimilarIssues(string category, string location)
        {
            var matches = new List<Models.Issue>();
            string normLocation = Normalize(location);

            foreach (var issue in _issues)
            {
                if (!string.Equals(issue.Category, category, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (IsSimilarLocation(normLocation, Normalize(issue.Location)))
                {
                    matches.Add(issue);
                }
            }

            return matches;
        }

        private static string Normalize(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return string.Empty;
            var cleaned = new string(text.ToLowerInvariant()
                .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
            return cleaned.Trim();
        }

        private static bool IsSimilarLocation(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b)) return false;
            if (a == b) return true;

            // One location description contains the other (e.g. "Main Road"
            // vs "Main Road near the clinic").
            if (a.Length > 4 && b.Contains(a)) return true;
            if (b.Length > 4 && a.Contains(b)) return true;

            // Fall back to word-overlap (Jaccard similarity) so reordered or
            // slightly different phrasing of the same place still matches,
            // e.g. "Corner of Main Rd and 5th Ave" vs "5th Ave and Main Road".
            var wordsA = new HashSet<string>(a.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            var wordsB = new HashSet<string>(b.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            if (wordsA.Count == 0 || wordsB.Count == 0) return false;

            int intersection = wordsA.Intersect(wordsB).Count();
            int union = wordsA.Union(wordsB).Count();
            double similarity = (double)intersection / union;
            return similarity >= 0.5;
        }

        private static void TryAppendToLog(string line)
        {
            try
            {
                string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IssueLog.txt");
                File.AppendAllText(logPath, line + Environment.NewLine);
            }
            catch
            {
                // Logging to disk is a best-effort convenience feature; the
                // application must not crash if the file cannot be written
                // (e.g. read-only folder), so any failure is swallowed here.
            }
        }
    }
}
