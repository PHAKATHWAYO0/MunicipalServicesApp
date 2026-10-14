using System;
using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Data
{
    /// <summary>
    /// Central in-memory store and search engine for the Local Events and
    /// Announcements module (Part 2 of the PoE). Deliberately uses several
    /// different data structures, each chosen for what it's actually good
    /// at, rather than one generic list for everything:
    ///
    /// - SortedDictionary&lt;DateTime, List&lt;Event&gt;&gt;: the primary store,
    ///   keeping events organised by date automatically (brief 2.1.b).
    /// - HashSet&lt;string&gt; / HashSet&lt;DateTime&gt;: unique categories and
    ///   unique event dates, for filter dropdowns with no duplicates.
    /// - Stack&lt;Event&gt;: "Recently Viewed" browsing history (LIFO).
    /// - Queue&lt;string&gt;: "Recent Searches" (FIFO, bounded).
    /// - Dictionary&lt;string, int&gt;: counts how often each category is
    ///   searched, driving the recommendation feature.
    /// - EventPriorityQueue (custom min-heap): efficiently retrieves the
    ///   soonest upcoming events without re-sorting the whole collection.
    /// </summary>
    public static class EventRepository
    {
        private static readonly SortedDictionary<DateTime, List<Event>> EventsByDate =
            new SortedDictionary<DateTime, List<Event>>();

        private static readonly HashSet<string> Categories =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private static readonly HashSet<DateTime> EventDates = new HashSet<DateTime>();

        private static readonly Stack<Event> RecentlyViewed = new Stack<Event>();
        private const int MaxRecentlyViewed = 5;

        private static readonly Queue<string> RecentSearchTerms = new Queue<string>();
        private const int MaxRecentSearches = 8;

        private static readonly Dictionary<string, int> CategorySearchFrequency =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        static EventRepository()
        {
            SeedSampleEvents();
        }

        /// <summary>
        /// Loads a realistic starter set of municipal events spread across
        /// the coming weeks, so the screen has meaningful content the first
        /// time it is opened. Dates are calculated relative to today so the
        /// demo always looks current, whenever it's run.
        /// </summary>
        private static void SeedSampleEvents()
        {
            DateTime today = DateTime.Today;

            AddEvent(new Event
            {
                Title = "Ward 12 Community Meeting",
                Category = "Community Meeting",
                Date = today.AddDays(3).AddHours(18),
                Location = "Ward 12 Community Hall",
                Description = "Monthly community meeting to discuss local service delivery, upcoming projects, and resident concerns."
            });
            AddEvent(new Event
            {
                Title = "Scheduled Water Interruption — Main Reservoir Maintenance",
                Category = "Water & Utilities",
                Date = today.AddDays(5).AddHours(8),
                Location = "Suburbs served by Main Reservoir",
                Description = "Water supply will be interrupted for routine maintenance. Residents are advised to store water in advance."
            });
            AddEvent(new Event
            {
                Title = "Electricity Substation Upgrade",
                Category = "Electricity Maintenance",
                Date = today.AddDays(7).AddHours(9),
                Location = "Substation 4, Industrial Road",
                Description = "Planned power outage while the substation transformer is upgraded to improve reliability."
            });
            AddEvent(new Event
            {
                Title = "Community Clean-Up Day",
                Category = "Waste Management",
                Date = today.AddDays(9).AddHours(7),
                Location = "Riverside Park",
                Description = "Join municipal staff and volunteers for a community clean-up drive along the riverside walkway."
            });
            AddEvent(new Event
            {
                Title = "Free Health & Wellness Clinic",
                Category = "Health & Safety",
                Date = today.AddDays(11).AddHours(9),
                Location = "Community Health Centre",
                Description = "Free blood pressure, glucose, and general health screenings offered to all residents."
            });
            AddEvent(new Event
            {
                Title = "Youth Soccer Tournament",
                Category = "Sports & Recreation",
                Date = today.AddDays(14).AddHours(10),
                Location = "Municipal Sports Grounds",
                Description = "Under-16 soccer tournament between local schools, hosted by the municipal recreation department."
            });
            AddEvent(new Event
            {
                Title = "Fire Safety Awareness Workshop",
                Category = "Health & Safety",
                Date = today.AddDays(16).AddHours(17),
                Location = "Fire Station 2 Training Room",
                Description = "Practical workshop on home fire safety, extinguisher use, and evacuation planning, run by the fire department."
            });
            AddEvent(new Event
            {
                Title = "Local Arts and Crafts Market",
                Category = "Arts & Culture",
                Date = today.AddDays(18).AddHours(9),
                Location = "Town Square",
                Description = "Monthly market showcasing local artists, crafters, and small businesses from across the municipality."
            });
            AddEvent(new Event
            {
                Title = "Youth Skills Development Programme — Info Session",
                Category = "Youth Programs",
                Date = today.AddDays(21).AddHours(14),
                Location = "Municipal Library Hall",
                Description = "Information session for the municipality's free digital-skills and job-readiness programme for youth aged 18-25."
            });
            AddEvent(new Event
            {
                Title = "Recycling and Waste Sorting Workshop",
                Category = "Waste Management",
                Date = today.AddDays(24).AddHours(10),
                Location = "Community Hall B",
                Description = "Learn how to sort household waste for the municipality's new recycling collection programme."
            });
            AddEvent(new Event
            {
                Title = "Ward 7 Community Meeting",
                Category = "Community Meeting",
                Date = today.AddDays(27).AddHours(18),
                Location = "Ward 7 Community Hall",
                Description = "Monthly community meeting for Ward 7 residents to raise concerns and hear updates from their councillor."
            });
            AddEvent(new Event
            {
                Title = "Electricity Load Management Briefing",
                Category = "Electricity Maintenance",
                Date = today.AddDays(30).AddHours(18),
                Location = "Online / Municipal Website",
                Description = "Public briefing on the municipality's electricity load management schedule for the upcoming season."
            });
            AddEvent(new Event
            {
                Title = "Heritage Day Celebration",
                Category = "Arts & Culture",
                Date = today.AddDays(33).AddHours(11),
                Location = "Civic Centre Grounds",
                Description = "Community celebration of local heritage with food stalls, live music, and cultural performances."
            });
            AddEvent(new Event
            {
                Title = "Senior Citizens' Wellness Day",
                Category = "Health & Safety",
                Date = today.AddDays(38).AddHours(9),
                Location = "Community Health Centre",
                Description = "A day of free health checks, light exercise sessions, and social activities for senior residents."
            });
        }

        public static void AddEvent(Event ev)
        {
            if (ev == null) throw new ArgumentNullException(nameof(ev));

            DateTime dayKey = ev.Date.Date;
            if (!EventsByDate.TryGetValue(dayKey, out List<Event> eventsOnDay))
            {
                eventsOnDay = new List<Event>();
                EventsByDate[dayKey] = eventsOnDay;
            }
            eventsOnDay.Add(ev);

            Categories.Add(ev.Category);
            EventDates.Add(dayKey);
        }

        /// <summary>All events, in ascending date order (courtesy of the SortedDictionary).</summary>
        public static List<Event> GetAllEventsSorted()
        {
            var result = new List<Event>();
            foreach (var dayEvents in EventsByDate.Values)
            {
                result.AddRange(dayEvents);
            }
            return result;
        }

        /// <summary>The distinct set of event categories, alphabetically sorted for display.</summary>
        public static List<string> GetCategories()
        {
            var list = new List<string>(Categories);
            list.Sort(StringComparer.OrdinalIgnoreCase);
            return list;
        }

        /// <summary>
        /// Filters events by keyword (title/description/location), category,
        /// and an optional date range. Also records the search (category
        /// frequency + recent search terms) so the recommendation engine can
        /// learn from it.
        /// </summary>
        public static List<Event> Search(string keyword, string category, DateTime? from, DateTime? to)
        {
            RecordSearch(keyword, category);

            var results = new List<Event>();
            string normalizedKeyword = (keyword ?? string.Empty).Trim().ToLowerInvariant();
            bool filterByCategory = !string.IsNullOrWhiteSpace(category) && !string.Equals(category, "All Categories", StringComparison.OrdinalIgnoreCase);

            foreach (var ev in GetAllEventsSorted())
            {
                if (filterByCategory && !string.Equals(ev.Category, category, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (from.HasValue && ev.Date.Date < from.Value.Date)
                    continue;

                if (to.HasValue && ev.Date.Date > to.Value.Date)
                    continue;

                if (normalizedKeyword.Length > 0)
                {
                    bool matchesKeyword =
                        ev.Title.ToLowerInvariant().Contains(normalizedKeyword) ||
                        ev.Description.ToLowerInvariant().Contains(normalizedKeyword) ||
                        ev.Location.ToLowerInvariant().Contains(normalizedKeyword);

                    if (!matchesKeyword) continue;
                }

                results.Add(ev);
            }

            return results;
        }

        private static void RecordSearch(string keyword, string category)
        {
            if (!string.IsNullOrWhiteSpace(category) && !string.Equals(category, "All Categories", StringComparison.OrdinalIgnoreCase))
            {
                if (CategorySearchFrequency.ContainsKey(category))
                    CategorySearchFrequency[category]++;
                else
                    CategorySearchFrequency[category] = 1;
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                RecentSearchTerms.Enqueue(keyword.Trim());
                while (RecentSearchTerms.Count > MaxRecentSearches)
                {
                    RecentSearchTerms.Dequeue();
                }
            }
        }

        /// <summary>Most recent search terms first, oldest last.</summary>
        public static string[] GetRecentSearches()
        {
            string[] arr = RecentSearchTerms.ToArray();
            Array.Reverse(arr);
            return arr;
        }

        /// <summary>
        /// Returns the next <paramref name="count"/> soonest upcoming events
        /// (from now onward), using the custom EventPriorityQueue min-heap
        /// rather than sorting the whole collection each time.
        /// </summary>
        public static List<Event> GetUpcomingEvents(int count)
        {
            var pq = new EventPriorityQueue();
            DateTime now = DateTime.Now;

            foreach (var ev in GetAllEventsSorted())
            {
                if (ev.Date >= now)
                {
                    pq.Enqueue(ev);
                }
            }

            var result = new List<Event>();
            while (result.Count < count && pq.Count > 0)
            {
                result.Add(pq.Dequeue());
            }
            return result;
        }

        /// <summary>Pushes an event onto the "recently viewed" history stack, capped at MaxRecentlyViewed.</summary>
        public static void PushRecentlyViewed(Event ev)
        {
            RecentlyViewed.Push(ev);

            if (RecentlyViewed.Count > MaxRecentlyViewed)
            {
                Event[] items = RecentlyViewed.ToArray(); // top (most recent) first
                RecentlyViewed.Clear();
                int keep = Math.Min(items.Length, MaxRecentlyViewed);
                for (int i = keep - 1; i >= 0; i--)
                {
                    RecentlyViewed.Push(items[i]);
                }
            }
        }

        /// <summary>Most recently viewed event first.</summary>
        public static Event[] GetRecentlyViewed()
        {
            return RecentlyViewed.ToArray();
        }

        /// <summary>
        /// Suggests upcoming events based on the citizen's search history:
        /// events in whichever category has been searched most often are
        /// recommended first (content-based filtering on a single feature).
        /// If there's no search history yet, falls back to the soonest
        /// upcoming events overall (cold start).
        /// </summary>
        public static List<Event> GetRecommendations(int count)
        {
            string topCategory = null;
            int topFrequency = 0;

            foreach (var pair in CategorySearchFrequency)
            {
                if (pair.Value > topFrequency)
                {
                    topFrequency = pair.Value;
                    topCategory = pair.Key;
                }
            }

            DateTime now = DateTime.Now;
            var candidates = new List<Event>();

            if (topCategory != null)
            {
                foreach (var ev in GetAllEventsSorted())
                {
                    if (ev.Date >= now && string.Equals(ev.Category, topCategory, StringComparison.OrdinalIgnoreCase))
                    {
                        candidates.Add(ev);
                    }
                }

                // Top up with other upcoming events if the favourite category doesn't have enough on its own.
                if (candidates.Count < count)
                {
                    foreach (var ev in GetAllEventsSorted())
                    {
                        if (ev.Date >= now && !candidates.Contains(ev))
                        {
                            candidates.Add(ev);
                        }
                        if (candidates.Count >= count) break;
                    }
                }
            }
            else
            {
                candidates = GetUpcomingEvents(count);
            }

            candidates.Sort((a, b) => a.Date.CompareTo(b.Date));
            return candidates.Count > count ? candidates.GetRange(0, count) : candidates;
        }
    }
}
