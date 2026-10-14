using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MunicipalServicesApp.Data
{
    public static class IssueRepository
    {
        private static readonly List<Models.Issue> _issues = new List<Models.Issue>();
        private static int _nextReferenceNumber = 1000;

        public static IReadOnlyList<Models.Issue> Issues => _issues.AsReadOnly();
        public static int Count => _issues.Count;

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

        public static void AddSupport(Models.Issue issue)
        {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            issue.SupportCount++;
            TryAppendToLog($"SUPPORT ADDED\t{DateTime.Now:yyyy-MM-dd HH:mm:ss}\t{issue.ReferenceNumber}\tNew supporter count: {issue.SupportCount}");
        }

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

            if (a.Length > 4 && b.Contains(a)) return true;
            if (b.Length > 4 && a.Contains(b)) return true;

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
            }
        }
    }
}
