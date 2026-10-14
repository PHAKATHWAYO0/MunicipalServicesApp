using System;
using System.Windows.Forms;
using MunicipalServicesApp.Controls;
using MunicipalServicesApp.Localization;

namespace MunicipalServicesApp.Forms
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            ApplyTranslations();
            UpdateLanguageButtonStyles();
        }

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
            this.Hide();
            using (var reportIssuesForm = new ReportIssuesForm())
            {
                reportIssuesForm.ShowDialog();
            }
            this.Show();
        }

        private void btnLocalEvents_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var localEventsForm = new LocalEventsForm())
            {
                localEventsForm.ShowDialog();
            }
            this.Show();
        }

        private void btnServiceStatus_Click(object sender, EventArgs e)
        {
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

        private void UpdateLanguageButtonStyles()
        {
            SetLanguageButtonState(btnLangEnglish, Translator.CurrentLanguage == AppLanguage.English);
            SetLanguageButtonState(btnLangZulu, Translator.CurrentLanguage == AppLanguage.isiZulu);
            SetLanguageButtonState(btnLangAfrikaans, Translator.CurrentLanguage == AppLanguage.Afrikaans);
        }

        private static void SetLanguageButtonState(RoundedButton button, bool selected)
        {
            button.UseGradient = selected;
            button.ForeColor = selected ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(94, 53, 209);
            button.Invalidate();
        }
    }
}
