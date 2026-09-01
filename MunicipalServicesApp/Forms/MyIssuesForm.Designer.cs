using MunicipalServicesApp.Controls;

namespace MunicipalServicesApp.Forms
{
    partial class MyIssuesForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new MunicipalServicesApp.Controls.BlobGradientPanel();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.listViewIssues = new System.Windows.Forms.ListView();
            this.colReference = new System.Windows.Forms.ColumnHeader();
            this.colCategory = new System.Windows.Forms.ColumnHeader();
            this.colLocation = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colSupporters = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.lblEmptyState = new System.Windows.Forms.Label();
            this.btnBackToMain = new MunicipalServicesApp.Controls.RoundedButton();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            //
            // panelHeader
            //
            this.panelHeader.Controls.Add(this.lblHeaderSubtitle);
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.GradientEnd = System.Drawing.Color.FromArgb(179, 136, 255);
            this.panelHeader.GradientStart = System.Drawing.Color.FromArgb(94, 53, 209);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(700, 90);
            this.panelHeader.TabIndex = 0;
            //
            // lblHeaderSubtitle
            //
            this.lblHeaderSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(240, 235, 255);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(25, 55);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(620, 22);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "Every issue reported this session, with its live status.";
            //
            // lblHeaderTitle
            //
            this.lblHeaderTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(22, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(620, 35);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "📄  My Reported Issues";
            //
            // listViewIssues
            //
            this.listViewIssues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colReference,
            this.colCategory,
            this.colLocation,
            this.colDate,
            this.colSupporters,
            this.colStatus});
            this.listViewIssues.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.listViewIssues.FullRowSelect = true;
            this.listViewIssues.GridLines = true;
            this.listViewIssues.HideSelection = false;
            this.listViewIssues.Location = new System.Drawing.Point(25, 110);
            this.listViewIssues.MultiSelect = false;
            this.listViewIssues.Name = "listViewIssues";
            this.listViewIssues.Size = new System.Drawing.Size(650, 340);
            this.listViewIssues.TabIndex = 1;
            this.listViewIssues.UseCompatibleStateImageBehavior = false;
            this.listViewIssues.View = System.Windows.Forms.View.Details;
            //
            // colReference
            //
            this.colReference.Text = "Reference";
            this.colReference.Width = 90;
            //
            // colCategory
            //
            this.colCategory.Text = "Category";
            this.colCategory.Width = 150;
            //
            // colLocation
            //
            this.colLocation.Text = "Location";
            this.colLocation.Width = 160;
            //
            // colDate
            //
            this.colDate.Text = "Date Reported";
            this.colDate.Width = 130;
            //
            // colSupporters
            //
            this.colSupporters.Text = "Supporters";
            this.colSupporters.Width = 75;
            //
            // colStatus
            //
            this.colStatus.Text = "Status";
            this.colStatus.Width = 95;
            //
            // lblEmptyState
            //
            this.lblEmptyState.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblEmptyState.ForeColor = System.Drawing.Color.Gray;
            this.lblEmptyState.Location = new System.Drawing.Point(25, 130);
            this.lblEmptyState.Name = "lblEmptyState";
            this.lblEmptyState.Size = new System.Drawing.Size(650, 80);
            this.lblEmptyState.TabIndex = 2;
            this.lblEmptyState.Text = "You haven\'t reported any issues yet. Once you submit a report, it will appear h" +
    "ere.";
            this.lblEmptyState.Visible = false;
            //
            // btnBackToMain
            //
            this.btnBackToMain.CornerRadius = 16;
            this.btnBackToMain.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBackToMain.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnBackToMain.GradientEnd = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnBackToMain.Location = new System.Drawing.Point(25, 465);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(220, 42);
            this.btnBackToMain.TabIndex = 3;
            this.btnBackToMain.Text = "← Back to Main Menu";
            this.btnBackToMain.UseGradient = false;
            this.btnBackToMain.UseVisualStyleBackColor = true;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            //
            // MyIssuesForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 530);
            this.Controls.Add(this.btnBackToMain);
            this.Controls.Add(this.lblEmptyState);
            this.Controls.Add(this.listViewIssues);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyIssuesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Reported Issues - Municipal Services";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private MunicipalServicesApp.Controls.BlobGradientPanel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.ListView listViewIssues;
        private System.Windows.Forms.ColumnHeader colReference;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colSupporters;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Label lblEmptyState;
        private MunicipalServicesApp.Controls.RoundedButton btnBackToMain;
    }
}
