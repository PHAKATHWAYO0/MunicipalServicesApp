using MunicipalServicesApp.Controls;

namespace MunicipalServicesApp.Forms
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHero = new MunicipalServicesApp.Controls.BlobGradientPanel();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblWelcomeSub = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.btnLangAfrikaans = new MunicipalServicesApp.Controls.RoundedButton();
            this.btnLangZulu = new MunicipalServicesApp.Controls.RoundedButton();
            this.btnLangEnglish = new MunicipalServicesApp.Controls.RoundedButton();
            this.lblFooter = new System.Windows.Forms.Label();
            this.btnServiceStatus = new MunicipalServicesApp.Controls.RoundedButton();
            this.btnLocalEvents = new MunicipalServicesApp.Controls.RoundedButton();
            this.btnReportIssues = new MunicipalServicesApp.Controls.RoundedButton();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelHero.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHero
            //
            this.panelHero.Controls.Add(this.lblWelcomeSub);
            this.panelHero.Controls.Add(this.lblWelcome);
            this.panelHero.Controls.Add(this.lblBrand);
            this.panelHero.GradientEnd = System.Drawing.Color.FromArgb(179, 136, 255);
            this.panelHero.GradientStart = System.Drawing.Color.FromArgb(94, 53, 209);
            this.panelHero.Location = new System.Drawing.Point(0, 0);
            this.panelHero.Name = "panelHero";
            this.panelHero.Size = new System.Drawing.Size(340, 520);
            this.panelHero.TabIndex = 0;
            //
            // lblBrand
            //
            this.lblBrand.AutoSize = true;
            this.lblBrand.BackColor = System.Drawing.Color.Transparent;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(40, 40);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(140, 19);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "MUNICIPAL SERVICES";
            //
            // lblWelcome
            //
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(37, 210);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(270, 100);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome!";
            //
            // lblWelcomeSub
            //
            this.lblWelcomeSub.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeSub.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblWelcomeSub.ForeColor = System.Drawing.Color.FromArgb(240, 235, 255);
            this.lblWelcomeSub.Location = new System.Drawing.Point(40, 300);
            this.lblWelcomeSub.Name = "lblWelcomeSub";
            this.lblWelcomeSub.Size = new System.Drawing.Size(260, 100);
            this.lblWelcomeSub.TabIndex = 2;
            this.lblWelcomeSub.Text = "Report issues, stay informed, and help improve services in your community.";
            //
            // panelContent
            //
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.btnLangAfrikaans);
            this.panelContent.Controls.Add(this.btnLangZulu);
            this.panelContent.Controls.Add(this.btnLangEnglish);
            this.panelContent.Controls.Add(this.lblFooter);
            this.panelContent.Controls.Add(this.btnServiceStatus);
            this.panelContent.Controls.Add(this.btnLocalEvents);
            this.panelContent.Controls.Add(this.btnReportIssues);
            this.panelContent.Controls.Add(this.lblSubtitle);
            this.panelContent.Controls.Add(this.lblTitle);
            this.panelContent.Location = new System.Drawing.Point(340, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(560, 520);
            this.panelContent.TabIndex = 1;
            //
            // btnLangAfrikaans
            //
            this.btnLangAfrikaans.CornerRadius = 8;
            this.btnLangAfrikaans.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnLangAfrikaans.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnLangAfrikaans.GradientEnd = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnLangAfrikaans.GradientStart = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnLangAfrikaans.Location = new System.Drawing.Point(490, 24);
            this.btnLangAfrikaans.Name = "btnLangAfrikaans";
            this.btnLangAfrikaans.Size = new System.Drawing.Size(46, 26);
            this.btnLangAfrikaans.TabIndex = 8;
            this.btnLangAfrikaans.Text = "AF";
            this.btnLangAfrikaans.UseGradient = false;
            this.btnLangAfrikaans.UseVisualStyleBackColor = true;
            this.btnLangAfrikaans.Click += new System.EventHandler(this.btnLangAfrikaans_Click);
            //
            // btnLangZulu
            //
            this.btnLangZulu.CornerRadius = 8;
            this.btnLangZulu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnLangZulu.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnLangZulu.GradientEnd = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnLangZulu.GradientStart = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnLangZulu.Location = new System.Drawing.Point(440, 24);
            this.btnLangZulu.Name = "btnLangZulu";
            this.btnLangZulu.Size = new System.Drawing.Size(46, 26);
            this.btnLangZulu.TabIndex = 7;
            this.btnLangZulu.Text = "ZU";
            this.btnLangZulu.UseGradient = false;
            this.btnLangZulu.UseVisualStyleBackColor = true;
            this.btnLangZulu.Click += new System.EventHandler(this.btnLangZulu_Click);
            //
            // btnLangEnglish
            //
            this.btnLangEnglish.CornerRadius = 8;
            this.btnLangEnglish.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnLangEnglish.ForeColor = System.Drawing.Color.White;
            this.btnLangEnglish.GradientEnd = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnLangEnglish.GradientStart = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnLangEnglish.Location = new System.Drawing.Point(390, 24);
            this.btnLangEnglish.Name = "btnLangEnglish";
            this.btnLangEnglish.Size = new System.Drawing.Size(46, 26);
            this.btnLangEnglish.TabIndex = 6;
            this.btnLangEnglish.Text = "EN";
            this.btnLangEnglish.UseGradient = true;
            this.btnLangEnglish.UseVisualStyleBackColor = true;
            this.btnLangEnglish.Click += new System.EventHandler(this.btnLangEnglish_Click);
            //
            // lblFooter
            //
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblFooter.ForeColor = System.Drawing.Color.Gray;
            this.lblFooter.Location = new System.Drawing.Point(48, 400);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(465, 40);
            this.lblFooter.TabIndex = 5;
            this.lblFooter.Text = "Only \"Report Issues\" and \"Local Events\" are available in this release.";
            //
            // btnServiceStatus
            //
            this.btnServiceStatus.CornerRadius = 16;
            this.btnServiceStatus.Enabled = false;
            this.btnServiceStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnServiceStatus.GradientEnd = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnServiceStatus.GradientStart = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnServiceStatus.Location = new System.Drawing.Point(48, 300);
            this.btnServiceStatus.Name = "btnServiceStatus";
            this.btnServiceStatus.Size = new System.Drawing.Size(465, 60);
            this.btnServiceStatus.TabIndex = 4;
            this.btnServiceStatus.Text = "📍  Service Request Status   (coming soon)";
            this.btnServiceStatus.UseGradient = true;
            this.btnServiceStatus.UseVisualStyleBackColor = true;
            this.btnServiceStatus.Click += new System.EventHandler(this.btnServiceStatus_Click);
            //
            // btnLocalEvents
            //
            this.btnLocalEvents.CornerRadius = 16;
            this.btnLocalEvents.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLocalEvents.GradientEnd = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnLocalEvents.GradientStart = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnLocalEvents.Location = new System.Drawing.Point(48, 225);
            this.btnLocalEvents.Name = "btnLocalEvents";
            this.btnLocalEvents.Size = new System.Drawing.Size(465, 60);
            this.btnLocalEvents.TabIndex = 3;
            this.btnLocalEvents.Text = "📅  Local Events and Announcements";
            this.btnLocalEvents.UseGradient = true;
            this.btnLocalEvents.UseVisualStyleBackColor = true;
            this.btnLocalEvents.Click += new System.EventHandler(this.btnLocalEvents_Click);
            //
            // btnReportIssues
            //
            this.btnReportIssues.CornerRadius = 16;
            this.btnReportIssues.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportIssues.GradientEnd = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnReportIssues.GradientStart = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnReportIssues.Location = new System.Drawing.Point(48, 150);
            this.btnReportIssues.Name = "btnReportIssues";
            this.btnReportIssues.Size = new System.Drawing.Size(465, 60);
            this.btnReportIssues.TabIndex = 2;
            this.btnReportIssues.Text = "🛠  Report Issues";
            this.btnReportIssues.UseGradient = true;
            this.btnReportIssues.UseVisualStyleBackColor = false;
            this.btnReportIssues.Click += new System.EventHandler(this.btnReportIssues_Click);
            //
            // lblSubtitle
            //
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(120, 110, 140);
            this.lblSubtitle.Location = new System.Drawing.Point(50, 100);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(440, 30);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "What would you like to do today?";
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(59, 31, 115);
            this.lblTitle.Location = new System.Drawing.Point(46, 55);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(440, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Main Menu";
            //
            // MainMenuForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHero);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipal Services Application";
            this.panelHero.ResumeLayout(false);
            this.panelHero.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private MunicipalServicesApp.Controls.BlobGradientPanel panelHero;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblWelcomeSub;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private MunicipalServicesApp.Controls.RoundedButton btnReportIssues;
        private MunicipalServicesApp.Controls.RoundedButton btnLocalEvents;
        private MunicipalServicesApp.Controls.RoundedButton btnServiceStatus;
        private System.Windows.Forms.Label lblFooter;
        private MunicipalServicesApp.Controls.RoundedButton btnLangEnglish;
        private MunicipalServicesApp.Controls.RoundedButton btnLangZulu;
        private MunicipalServicesApp.Controls.RoundedButton btnLangAfrikaans;
    }
}
