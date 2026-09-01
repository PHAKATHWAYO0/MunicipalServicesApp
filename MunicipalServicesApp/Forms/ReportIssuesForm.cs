using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MunicipalServicesApp.Data;
using MunicipalServicesApp.Localization;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp.Forms
{
    /// <summary>
    /// Lets a citizen report a municipal issue: location, category,
    /// description and an optional attachment. Implements the "dynamic
    /// engagement feature" requirement via a ProgressBar + label combo that
    /// updates live as the user fills in the form (see Task 1 research:
    /// gamified progress feedback). Also detects likely duplicate reports
    /// and offers a shortcut to the "My Reported Issues" history screen.
    /// </summary>
    public partial class ReportIssuesForm : Form
    {
        private string _attachedFilePath;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        private const int PBM_SETBARCOLOR = 0x409;
        private const int PBM_SETBKCOLOR = 0x2001;

        public ReportIssuesForm()
        {
            InitializeComponent();
            ApplyTranslations();
            PopulateCategories();
            TryTintProgressBarPurple();
            UpdateEngagementFeedback();
        }

        /// <summary>
        /// Applies the current UI language (see Translator) to every
        /// static piece of text on this form. Called once at startup —
        /// this form is recreated each time it is opened, so it always
        /// picks up whatever language was last selected on the Main Menu.
        /// </summary>
        private void ApplyTranslations()
        {
            lblHeaderTitle.Text = Translator.T("reportHeaderTitle");
            lblHeaderSubtitle.Text = Translator.T("reportHeaderSubtitle");
            btnMyReports.Text = Translator.T("btnMyReports");
            lblLocation.Text = Translator.T("lblLocation");
            lblCategory.Text = Translator.T("lblCategory");
            lblDescription.Text = Translator.T("lblDescription");
            btnAttach.Text = Translator.T("btnAttach");
            lblAttachment.Text = Translator.T("noFileAttached");
            btnSubmit.Text = Translator.T("btnSubmit");
            btnBackToMain.Text = Translator.T("btnBackToMain");
        }

        /// <summary>
        /// Attempts to tint the ProgressBar purple to match the app theme.
        /// Windows themes the ProgressBar natively, so this may have no
        /// visible effect on every Windows version/theme combination — it
        /// is a best-effort visual touch, not required functionality, so
        /// any failure here is safely ignored.
        /// </summary>
        private void TryTintProgressBarPurple()
        {
            try
            {
                SendMessage(progressBarEngagement.Handle, PBM_SETBKCOLOR, 0, ColorTranslator.ToWin32(Color.FromArgb(237, 233, 250)));
                SendMessage(progressBarEngagement.Handle, PBM_SETBARCOLOR, 0, ColorTranslator.ToWin32(Color.FromArgb(124, 77, 255)));
            }
            catch
            {
                // Purely cosmetic — ignore if unsupported on this OS/theme.
            }
        }

        private void PopulateCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(Translator.GetCategories());
        }

        /// <summary>
        /// Single handler wired to every input control (TextChanged /
        /// SelectedIndexChanged) so the engagement feedback is recalculated
        /// the moment the user changes anything on the form.
        /// </summary>
        private void InputChanged(object sender, EventArgs e)
        {
            UpdateEngagementFeedback();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _attachedFilePath = openFileDialog.FileName;
                lblAttachment.Text = "Attached: " + Path.GetFileName(_attachedFilePath);
                lblAttachment.ForeColor = Color.FromArgb(0, 120, 80);
            }
            UpdateEngagementFeedback();
        }

        /// <summary>
        /// Drives the gamified engagement strategy chosen in Task 1: the
        /// ProgressBar fills up and the label's message becomes more
        /// encouraging as the user completes each of the four form fields
        /// (location, category, description, attachment).
        /// </summary>
        private void UpdateEngagementFeedback()
        {
            int progress = 0;

            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) progress += 25;
            if (cmbCategory.SelectedIndex >= 0) progress += 25;
            if (!string.IsNullOrWhiteSpace(rtbDescription.Text)) progress += 25;
            if (!string.IsNullOrEmpty(_attachedFilePath)) progress += 25;

            progressBarEngagement.Value = progress;
            lblEngagement.Text = Translator.T("engagement" + progress);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            string category = cmbCategory.SelectedItem.ToString();
            string location = txtLocation.Text.Trim();

            // Duplicate/similar-issue detection: before creating a brand
            // new record, check whether someone has already reported what
            // looks like the same problem in the same category and a
            // matching location, and offer to add support to that report
            // instead — this avoids the municipality receiving many
            // separate tickets for one real-world issue.
            var similarIssues = IssueRepository.FindSimilarIssues(category, location);
            if (similarIssues.Count > 0)
            {
                var existing = similarIssues[0];
                var choice = MessageBox.Show(
                    $"It looks like {similarIssues.Count} other citizen(s) already reported a similar \"{category}\" " +
                    $"issue near \"{existing.Location}\" (Ref: {existing.ReferenceNumber}).\n\n" +
                    "Would you like to add your support to that existing report instead of creating a new, separate one?\n\n" +
                    "Yes = Add my support to the existing report\nNo = Submit this as a new report anyway",
                    "Similar Issue Already Reported",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (choice == DialogResult.Yes)
                {
                    IssueRepository.AddSupport(existing);
                    MessageBox.Show(
                        $"Thanks for confirming! Your support has been added to report {existing.ReferenceNumber}.\n" +
                        $"Total supporters for this issue: {existing.SupportCount}",
                        "Support Added",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ResetForm();
                    return;
                }
                // If "No", fall through and submit as a brand new report.
            }

            var issue = new Issue
            {
                ReferenceNumber = IssueRepository.GenerateReferenceNumber(),
                Location = location,
                Category = category,
                Description = rtbDescription.Text.Trim(),
                AttachmentPath = _attachedFilePath,
                DateReported = DateTime.Now
            };

            IssueRepository.Add(issue);

            MessageBox.Show(
                $"Thank you! Your issue has been reported.\n\nReference number: {issue.ReferenceNumber}\n" +
                $"Category: {issue.Category}\nLocation: {issue.Location}\n\n" +
                $"Total issues reported this session: {IssueRepository.Count}",
                "Report Submitted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ResetForm();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location of the issue.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return false;
            }

            if (cmbCategory.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a category for the issue.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please describe the issue.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return false;
            }

            return true;
        }

        private void ResetForm()
        {
            txtLocation.Clear();
            cmbCategory.SelectedIndex = -1;
            rtbDescription.Clear();
            _attachedFilePath = null;
            lblAttachment.Text = Translator.T("noFileAttached");
            lblAttachment.ForeColor = Color.DimGray;
            UpdateEngagementFeedback();
            txtLocation.Focus();
        }

        private void btnMyReports_Click(object sender, EventArgs e)
        {
            using (var myIssuesForm = new MyIssuesForm())
            {
                myIssuesForm.ShowDialog();
            }
        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
