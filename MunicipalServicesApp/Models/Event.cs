using System;

namespace MunicipalServicesApp.Models
{
    /// <summary>
    /// Represents a single local municipal event or announcement
    /// (e.g. a community meeting, a scheduled water interruption, a
    /// sports day). This is the core data structure for the Local Events
    /// and Announcements module (Part 2 of the PoE).
    /// </summary>
    public class Event
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Date:dd MMM yyyy} - {Title} ({Category})";
        }
    }
}
