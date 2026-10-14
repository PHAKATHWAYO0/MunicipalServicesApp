using MunicipalServicesApp.Controls;

namespace MunicipalServicesApp.Forms
{
    partial class ReportIssuesForm
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
            this.panelHeader = new MunicipalServicesApp.Controls.BlobGradientPanel();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.btnMyReports = new MunicipalServicesApp.Controls.RoundedButton();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.btnAttach = new MunicipalServicesApp.Controls.RoundedButton();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.lblEngagement = new System.Windows.Forms.Label();
            this.progressBarEngagement = new System.Windows.Forms.ProgressBar();
            this.btnSubmit = new MunicipalServicesApp.Controls.RoundedButton();
            this.btnBackToMain = new MunicipalServicesApp.Controls.RoundedButton();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.Controls.Add(this.btnMyReports);
            this.panelHeader.Controls.Add(this.lblHeaderSubtitle);
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.GradientEnd = System.Drawing.Color.FromArgb(179, 136, 255);
            this.panelHeader.GradientStart = System.Drawing.Color.FromArgb(94, 53, 209);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(580, 90);
            this.panelHeader.TabIndex = 0;
            //
            // btnMyReports
            //
            this.btnMyReports.CornerRadius = 12;
            this.btnMyReports.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnMyReports.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnMyReports.GradientEnd = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnMyReports.Location = new System.Drawing.Point(440, 20);
            this.btnMyReports.Name = "btnMyReports";
            this.btnMyReports.Size = new System.Drawing.Size(115, 30);
            this.btnMyReports.TabIndex = 2;
            this.btnMyReports.Text = "📄 My Reports";
            this.btnMyReports.UseGradient = false;
            this.btnMyReports.UseVisualStyleBackColor = true;
            this.btnMyReports.Click += new System.EventHandler(this.btnMyReports_Click);
            //
            // lblHeaderSubtitle
            //
            this.lblHeaderSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(240, 235, 255);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(25, 55);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(500, 22);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "Tell us what\'s wrong — we\'ll take it from here.";
            //
            // lblHeaderTitle
            //
            this.lblHeaderTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(22, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(500, 35);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "📋  Report an Issue";
            //
            // lblLocation
            //
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(59, 31, 115);
            this.lblLocation.Location = new System.Drawing.Point(28, 150);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(300, 20);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Location of the issue *";
            //
            // txtLocation
            //
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLocation.Location = new System.Drawing.Point(30, 172);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(520, 25);
            this.txtLocation.TabIndex = 2;
            this.txtLocation.TextChanged += new System.EventHandler(this.InputChanged);
            //
            // lblCategory
            //
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(59, 31, 115);
            this.lblCategory.Location = new System.Drawing.Point(28, 210);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(300, 20);
            this.lblCategory.TabIndex = 3;
            this.lblCategory.Text = "Category *";
            //
            // cmbCategory
            //
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(30, 232);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(300, 25);
            this.cmbCategory.TabIndex = 4;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.InputChanged);
            //
            // lblDescription
            //
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(59, 31, 115);
            this.lblDescription.Location = new System.Drawing.Point(28, 270);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(400, 20);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Describe the issue *";
            //
            // rtbDescription
            //
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rtbDescription.Location = new System.Drawing.Point(30, 292);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(520, 100);
            this.rtbDescription.TabIndex = 6;
            this.rtbDescription.TextChanged += new System.EventHandler(this.InputChanged);
            //
            // btnAttach
            //
            this.btnAttach.CornerRadius = 14;
            this.btnAttach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAttach.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnAttach.GradientEnd = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnAttach.Location = new System.Drawing.Point(30, 405);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(200, 32);
            this.btnAttach.TabIndex = 7;
            this.btnAttach.Text = "📎 Attach Image / Document";
            this.btnAttach.UseGradient = false;
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            //
            // lblAttachment
            //
            this.lblAttachment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblAttachment.ForeColor = System.Drawing.Color.DimGray;
            this.lblAttachment.Location = new System.Drawing.Point(240, 411);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(310, 20);
            this.lblAttachment.TabIndex = 8;
            this.lblAttachment.Text = "No file attached";
            //
            // lblEngagement
            //
            this.lblEngagement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEngagement.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.lblEngagement.Location = new System.Drawing.Point(30, 455);
            this.lblEngagement.Name = "lblEngagement";
            this.lblEngagement.Size = new System.Drawing.Size(520, 22);
            this.lblEngagement.TabIndex = 9;
            this.lblEngagement.Text = "Let\'s get started — fill in the details below.";
            //
            // progressBarEngagement
            //
            this.progressBarEngagement.Location = new System.Drawing.Point(30, 480);
            this.progressBarEngagement.Name = "progressBarEngagement";
            this.progressBarEngagement.Size = new System.Drawing.Size(520, 22);
            this.progressBarEngagement.TabIndex = 10;
            //
            // btnSubmit
            //
            this.btnSubmit.CornerRadius = 16;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.GradientEnd = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnSubmit.GradientStart = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnSubmit.Location = new System.Drawing.Point(30, 520);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(250, 45);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Submit Report";
            this.btnSubmit.UseGradient = true;
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            //
            // btnBackToMain
            //
            this.btnBackToMain.CornerRadius = 16;
            this.btnBackToMain.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBackToMain.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnBackToMain.GradientEnd = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnBackToMain.Location = new System.Drawing.Point(300, 520);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(250, 45);
            this.btnBackToMain.TabIndex = 12;
            this.btnBackToMain.Text = "← Back to Main Menu";
            this.btnBackToMain.UseGradient = false;
            this.btnBackToMain.UseVisualStyleBackColor = true;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            //
            // openFileDialog
            //
            this.openFileDialog.Filter = "Images and Documents (*.jpg;*.jpeg;*.png;*.bmp;*.pdf;*.docx;*.txt)|*.jpg;*.jpeg;" +
                "*.png;*.bmp;*.pdf;*.docx;*.txt|All files (*.*)|*.*";
            this.openFileDialog.Title = "Attach an image or document";
            //
            // ReportIssuesForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 590);
            this.Controls.Add(this.btnBackToMain);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.progressBarEngagement);
            this.Controls.Add(this.lblEngagement);
            this.Controls.Add(this.lblAttachment);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportIssuesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report an Issue - Municipal Services";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MunicipalServicesApp.Controls.BlobGradientPanel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private MunicipalServicesApp.Controls.RoundedButton btnMyReports;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private MunicipalServicesApp.Controls.RoundedButton btnAttach;
        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.Label lblEngagement;
        private System.Windows.Forms.ProgressBar progressBarEngagement;
        private MunicipalServicesApp.Controls.RoundedButton btnSubmit;
        private MunicipalServicesApp.Controls.RoundedButton btnBackToMain;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
