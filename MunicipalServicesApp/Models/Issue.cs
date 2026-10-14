using System;

namespace MunicipalServicesApp.Models
{
    public class Issue
    {
        public string ReferenceNumber { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }
        public DateTime DateReported { get; set; }
        public int SupportCount { get; set; } = 1;

        public string Status => SupportCount >= 3
            ? Localization.Translator.T("statusUnderReview")
            : Localization.Translator.T("statusSubmitted");

        public bool HasAttachment => !string.IsNullOrWhiteSpace(AttachmentPath);

        public override string ToString()
        {
            return $"[{ReferenceNumber}] {Category} - {Location} ({DateReported:g})";
        }
    }
}
