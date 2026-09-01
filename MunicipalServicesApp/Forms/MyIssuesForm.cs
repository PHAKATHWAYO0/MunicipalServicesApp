using System;
using System.Windows.Forms;
using MunicipalServicesApp.Data;
using MunicipalServicesApp.Localization;

namespace MunicipalServicesApp.Forms
{
    /// <summary>
    /// Shows every issue reported during the current session, pulled
    /// straight from the shared <see cref="IssueRepository"/>, along with a
    /// simple derived status and how many citizens have supported each one
    /// (see the duplicate-detection feature in <see cref="ReportIssuesForm"/>).
    /// This gives citizens visibility into what they've reported instead of
    /// submissions disappearing into a void, which research on citizen
    /// reporting apps links to higher trust and repeat engagement.
    /// </summary>
    public partial class MyIssuesForm : Form
    {
        public MyIssuesForm()
        {
            InitializeComponent();
            ApplyTranslations();
            PopulateList();
        }

        private void ApplyTranslations()
        {
            lblHeaderTitle.Text = Translator.T("myIssuesTitle");
            lblHeaderSubtitle.Text = Translator.T("myIssuesSubtitle");
            colReference.Text = Translator.T("colReference");
            colCategory.Text = Translator.T("colCategory");
            colLocation.Text = Translator.T("colLocation");
            colDate.Text = Translator.T("colDate");
            colSupporters.Text = Translator.T("colSupporters");
            colStatus.Text = Translator.T("colStatus");
            lblEmptyState.Text = Translator.T("emptyState");
            btnBackToMain.Text = Translator.T("btnBackToMain");
        }

        private void PopulateList()
        {
            listViewIssues.Items.Clear();

            if (IssueRepository.Count == 0)
            {
                lblEmptyState.Visible = true;
                listViewIssues.Visible = false;
                return;
            }

            lblEmptyState.Visible = false;
            listViewIssues.Visible = true;

            foreach (var issue in IssueRepository.Issues)
            {
                var item = new ListViewItem(issue.ReferenceNumber);
                item.SubItems.Add(issue.Category);
                item.SubItems.Add(issue.Location);
                item.SubItems.Add(issue.DateReported.ToString("dd MMM yyyy, HH:mm"));
                item.SubItems.Add(issue.SupportCount.ToString());
                item.SubItems.Add(issue.Status);
                listViewIssues.Items.Add(item);
            }
        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
