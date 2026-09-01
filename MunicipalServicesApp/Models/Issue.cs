using System;

namespace MunicipalServicesApp.Models
{
    /// <summary>
    /// Represents a single issue/service request reported by a citizen.
    /// This is the core data structure stored by the application.
    /// </summary>
    public class Issue
    {
        public string ReferenceNumber { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        /// <summary>Full path to an attached image/document, or null if none was attached.</summary>
        public string AttachmentPath { get; set; }

        public DateTime DateReported { get; set; }

        /// <summary>
        /// How many citizens (including the original reporter) have raised
        /// or supported this issue. Increases when someone submits what the
        /// app detects as a likely duplicate and chooses to "add their
        /// support" instead of creating a new report.
        /// </summary>
        public int SupportCount { get; set; } = 1;

        /// <summary>
        /// A simple, derived status for display purposes. There is no
        /// backend workflow yet (that is out of scope for this part of the
        /// PoE), so this is intentionally simple: an issue that several
        /// citizens have independently supported is shown as "Under Review"
        /// to reflect that it has been noticed more than once.
        /// </summary>
        public string Status => SupportCount >= 3
            ? Localization.Translator.T("statusUnderReview")
            : Localization.Translator.T("statusSubmitted");

        /// <summary>Convenience flag used by the UI/reporting logic.</summary>
        public bool HasAttachment => !string.IsNullOrWhiteSpace(AttachmentPath);

        public override string ToString()
        {
            return $"[{ReferenceNumber}] {Category} - {Location} ({DateReported:g})";
        }
    }
}
