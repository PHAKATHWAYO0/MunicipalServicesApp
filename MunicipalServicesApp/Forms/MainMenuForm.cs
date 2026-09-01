using System;
using System.Windows.Forms;
using MunicipalServicesApp.Controls;
using MunicipalServicesApp.Localization;

namespace MunicipalServicesApp.Forms
{
    /// <summary>
    /// The application's main menu, shown on startup. Per the Task 2 brief,
    /// only "Report Issues" is enabled in this part of the Portfolio of
    /// Evidence — "Local Events and Announcements" and "Service Request
    /// Status" are both disabled here. The "My Reported Issues" history
    /// feature is still fully implemented, but is reached via the
    /// "📄 My Reports" shortcut on the Report Issues screen instead of this
    /// menu, so the brief's "only Report Issues enabled" requirement holds.
    /// Also hosts the EN / ZU / AF language switcher used across the app.
    /// </summary>
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            ApplyTranslations();
            UpdateLanguageButtonStyles();
        }

        /// <summary>
        /// Refreshes every piece of static text on this form from the
        /// Translator. Unlike the other forms (which are re-created each
        /// time they're opened), MainMenuForm lives for the whole session,
        /// so it must actively re-apply text whenever the language changes.
        /// </summary>
        private void ApplyTranslations()
        {
            lblBrand.Text = Translator.T("brand");
            lblWelcome.Text = Translator.T("welcome");
            lblWelcomeSub.Text = Translator.T("welcomeSub");
            lblTitle.Text = Translator.T("mainMenuTitle");
            lblSubtitle.Text = Translator.T("mainMenuSubtitle");
            btnReportIssues.Text = Translator.T("btnReportIssues");
            btnLocalEvents.Text = Translator.T("btnLocalEvents");
            btnServiceStatus.Text = Translator.T("btnServiceStatus");
            lblFooter.Text = Translator.T("footer");
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            // Open the Report Issues form modally. The main menu stays alive
            // (but hidden) underneath and re-appears once the user navigates
            // back, so the app always has exactly one visible window.
            this.Hide();

            using (var reportIssuesForm = new ReportIssuesForm())
            {
                reportIssuesForm.ShowDialog();
            }

            this.Show();
        }

        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
            // This button is disabled for the current submission (see class
            // summary), so this handler never actually fires — it's kept
            // in place, ready to be re-enabled here directly in a later
            // part of the Portfolio of Evidence. In the meantime, the same
            // "My Reported Issues" screen is reachable from the Report
            // Issues form's "📄 My Reports" button.
            this.Hide();

            using (var myIssuesForm = new MyIssuesForm())
            {
                myIssuesForm.ShowDialog();
            }

            this.Show();
        }

        private void btnLangEnglish_Click(object sender, EventArgs e) => SwitchLanguage(AppLanguage.English);
        private void btnLangZulu_Click(object sender, EventArgs e) => SwitchLanguage(AppLanguage.isiZulu);
        private void btnLangAfrikaans_Click(object sender, EventArgs e) => SwitchLanguage(AppLanguage.Afrikaans);

        private void SwitchLanguage(AppLanguage language)
        {
            Translator.CurrentLanguage = language;
            ApplyTranslations();
            UpdateLanguageButtonStyles();
        }

        /// <summary>Highlights whichever language button matches the current language.</summary>
        private void UpdateLanguageButtonStyles()
        {
            SetLanguageButtonState(btnLangEnglish, Translator.CurrentLanguage == AppLanguage.English);
            SetLanguageButtonState(btnLangZulu, Translator.CurrentLanguage == AppLanguage.isiZulu);
            SetLanguageButtonState(btnLangAfrikaans, Translator.CurrentLanguage == AppLanguage.Afrikaans);
        }

        private static void SetLanguageButtonState(Controls.RoundedButton button, bool selected)
        {
            button.UseGradient = selected;
            button.ForeColor = selected ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(94, 53, 209);
            button.Invalidate();
        }
    }
}
