using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MunicipalServicesApp.Data;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Forms
{
    public partial class LocalEventsForm : Form
    {
        private List<Event> _currentResults = new List<Event>();

        public LocalEventsForm()
        {
            InitializeComponent();
            PopulateCategoryFilter();
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddMonths(2);
            PerformSearch();
        }

        private void PopulateCategoryFilter()
        {
            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("All Categories");
            foreach (var cat in EventRepository.GetCategories())
            {
                cmbCategoryFilter.Items.Add(cat);
            }
            cmbCategoryFilter.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            txtSearchKeyword.Clear();
            cmbCategoryFilter.SelectedIndex = 0;
            chkFilterByDate.Checked = false;
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today.AddMonths(2);
            PerformSearch();
        }

        private void PerformSearch()
        {
            string keyword = txtSearchKeyword.Text;
            string category = cmbCategoryFilter.SelectedItem?.ToString();
            DateTime? from = chkFilterByDate.Checked ? dtpFrom.Value : (DateTime?)null;
            DateTime? to = chkFilterByDate.Checked ? dtpTo.Value : (DateTime?)null;

            _currentResults = EventRepository.Search(keyword, category, from, to);

            listViewEvents.Items.Clear();
            foreach (var ev in _currentResults)
            {
                var item = new ListViewItem(ev.Date.ToString("dd MMM yyyy"));
                item.SubItems.Add(ev.Category);
                item.SubItems.Add(ev.Title);
                item.SubItems.Add(ev.Location);
                listViewEvents.Items.Add(item);
            }

            rtbEventDetails.Text = _currentResults.Count == 0
                ? "No events match your search. Try clearing some filters."
                : "Select an event from the list above to see its full details here.";

            RefreshSidebar();
        }

        private void listViewEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewEvents.SelectedIndices.Count == 0) return;

            int index = listViewEvents.SelectedIndices[0];
            if (index < 0 || index >= _currentResults.Count) return;

            Event selected = _currentResults[index];
            rtbEventDetails.Text =
                $"{selected.Title}\n" +
                $"Category: {selected.Category}    Date: {selected.Date:dd MMM yyyy, HH:mm}\n" +
                $"Location: {selected.Location}\n\n" +
                $"{selected.Description}";

            EventRepository.PushRecentlyViewed(selected);
            RefreshRecentlyViewed();
        }

        private void RefreshSidebar()
        {
            RefreshUpcoming();
            RefreshRecommended();
            RefreshRecentlyViewed();
            RefreshRecentSearches();
        }

        private void RefreshUpcoming()
        {
            listBoxUpcoming.Items.Clear();
            foreach (var ev in EventRepository.GetUpcomingEvents(3))
            {
                listBoxUpcoming.Items.Add($"{ev.Date:dd MMM} — {ev.Title}");
            }
            if (listBoxUpcoming.Items.Count == 0) listBoxUpcoming.Items.Add("No upcoming events.");
        }

        private void RefreshRecommended()
        {
            listBoxRecommended.Items.Clear();
            foreach (var ev in EventRepository.GetRecommendations(3))
            {
                listBoxRecommended.Items.Add($"{ev.Date:dd MMM} — {ev.Title}");
            }
            if (listBoxRecommended.Items.Count == 0) listBoxRecommended.Items.Add("Search to get personalised picks.");
        }

        private void RefreshRecentlyViewed()
        {
            listBoxRecentlyViewed.Items.Clear();
            foreach (var ev in EventRepository.GetRecentlyViewed())
            {
                listBoxRecentlyViewed.Items.Add($"{ev.Date:dd MMM} — {ev.Title}");
            }
            if (listBoxRecentlyViewed.Items.Count == 0) listBoxRecentlyViewed.Items.Add("You haven't viewed any events yet.");
        }

        private void RefreshRecentSearches()
        {
            listBoxRecentSearches.Items.Clear();
            foreach (var term in EventRepository.GetRecentSearches())
            {
                listBoxRecentSearches.Items.Add(term);
            }
            if (listBoxRecentSearches.Items.Count == 0) listBoxRecentSearches.Items.Add("No searches yet.");
        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
