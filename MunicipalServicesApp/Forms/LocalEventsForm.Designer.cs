using MunicipalServicesApp.Controls;

namespace MunicipalServicesApp.Forms
{
    partial class LocalEventsForm
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
            this.lblSearchKeyword = new System.Windows.Forms.Label();
            this.txtSearchKeyword = new System.Windows.Forms.TextBox();
            this.lblCategoryFilter = new System.Windows.Forms.Label();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.btnSearch = new MunicipalServicesApp.Controls.RoundedButton();
            this.btnClearFilters = new MunicipalServicesApp.Controls.RoundedButton();
            this.chkFilterByDate = new System.Windows.Forms.CheckBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.listViewEvents = new System.Windows.Forms.ListView();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colCategory = new System.Windows.Forms.ColumnHeader();
            this.colTitle = new System.Windows.Forms.ColumnHeader();
            this.colLocation = new System.Windows.Forms.ColumnHeader();
            this.lblDetailsHeader = new System.Windows.Forms.Label();
            this.rtbEventDetails = new System.Windows.Forms.RichTextBox();
            this.btnBackToMain = new MunicipalServicesApp.Controls.RoundedButton();
            this.lblUpcomingHeader = new System.Windows.Forms.Label();
            this.listBoxUpcoming = new System.Windows.Forms.ListBox();
            this.lblRecommendedHeader = new System.Windows.Forms.Label();
            this.listBoxRecommended = new System.Windows.Forms.ListBox();
            this.lblRecentlyViewedHeader = new System.Windows.Forms.Label();
            this.listBoxRecentlyViewed = new System.Windows.Forms.ListBox();
            this.lblRecentSearchesHeader = new System.Windows.Forms.Label();
            this.listBoxRecentSearches = new System.Windows.Forms.ListBox();
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
            this.panelHeader.Size = new System.Drawing.Size(1000, 90);
            this.panelHeader.TabIndex = 0;
            //
            // lblHeaderSubtitle
            //
            this.lblHeaderSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(240, 235, 255);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(25, 55);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(700, 22);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "Discover what\'s happening in your community.";
            //
            // lblHeaderTitle
            //
            this.lblHeaderTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(22, 15);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(700, 35);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "📅  Local Events and Announcements";
            //
            // lblSearchKeyword
            //
            this.lblSearchKeyword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSearchKeyword.ForeColor = System.Drawing.Color.FromArgb(59, 31, 115);
            this.lblSearchKeyword.Location = new System.Drawing.Point(25, 108);
            this.lblSearchKeyword.Name = "lblSearchKeyword";
            this.lblSearchKeyword.Size = new System.Drawing.Size(60, 20);
            this.lblSearchKeyword.TabIndex = 1;
            this.lblSearchKeyword.Text = "Search:";
            //
            // txtSearchKeyword
            //
            this.txtSearchKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchKeyword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearchKeyword.Location = new System.Drawing.Point(85, 105);
            this.txtSearchKeyword.Name = "txtSearchKeyword";
            this.txtSearchKeyword.Size = new System.Drawing.Size(210, 24);
            this.txtSearchKeyword.TabIndex = 2;
            //
            // lblCategoryFilter
            //
            this.lblCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoryFilter.ForeColor = System.Drawing.Color.FromArgb(59, 31, 115);
            this.lblCategoryFilter.Location = new System.Drawing.Point(305, 108);
            this.lblCategoryFilter.Name = "lblCategoryFilter";
            this.lblCategoryFilter.Size = new System.Drawing.Size(70, 20);
            this.lblCategoryFilter.TabIndex = 3;
            this.lblCategoryFilter.Text = "Category:";
            //
            // cmbCategoryFilter
            //
            this.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategoryFilter.FormattingEnabled = true;
            this.cmbCategoryFilter.Location = new System.Drawing.Point(378, 105);
            this.cmbCategoryFilter.Name = "cmbCategoryFilter";
            this.cmbCategoryFilter.Size = new System.Drawing.Size(190, 24);
            this.cmbCategoryFilter.TabIndex = 4;
            //
            // btnSearch
            //
            this.btnSearch.CornerRadius = 10;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSearch.GradientEnd = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnSearch.GradientStart = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnSearch.Location = new System.Drawing.Point(580, 103);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 30);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseGradient = true;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // btnClearFilters
            //
            this.btnClearFilters.CornerRadius = 10;
            this.btnClearFilters.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClearFilters.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnClearFilters.GradientEnd = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnClearFilters.Location = new System.Drawing.Point(685, 103);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(90, 30);
            this.btnClearFilters.TabIndex = 6;
            this.btnClearFilters.Text = "Clear";
            this.btnClearFilters.UseGradient = false;
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            //
            // chkFilterByDate
            //
            this.chkFilterByDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkFilterByDate.ForeColor = System.Drawing.Color.FromArgb(59, 31, 115);
            this.chkFilterByDate.Location = new System.Drawing.Point(25, 146);
            this.chkFilterByDate.Name = "chkFilterByDate";
            this.chkFilterByDate.Size = new System.Drawing.Size(160, 24);
            this.chkFilterByDate.TabIndex = 7;
            this.chkFilterByDate.Text = "Filter by date range:";
            this.chkFilterByDate.UseVisualStyleBackColor = true;
            //
            // lblDateFrom
            //
            this.lblDateFrom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDateFrom.Location = new System.Drawing.Point(190, 148);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(40, 20);
            this.lblDateFrom.TabIndex = 8;
            this.lblDateFrom.Text = "From:";
            //
            // dtpFrom
            //
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(232, 145);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(120, 24);
            this.dtpFrom.TabIndex = 9;
            //
            // lblDateTo
            //
            this.lblDateTo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDateTo.Location = new System.Drawing.Point(362, 148);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(25, 20);
            this.lblDateTo.TabIndex = 10;
            this.lblDateTo.Text = "To:";
            //
            // dtpTo
            //
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(392, 145);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(120, 24);
            this.dtpTo.TabIndex = 11;
            //
            // listViewEvents
            //
            this.listViewEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colCategory,
            this.colTitle,
            this.colLocation});
            this.listViewEvents.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.listViewEvents.FullRowSelect = true;
            this.listViewEvents.GridLines = true;
            this.listViewEvents.HideSelection = false;
            this.listViewEvents.Location = new System.Drawing.Point(25, 185);
            this.listViewEvents.MultiSelect = false;
            this.listViewEvents.Name = "listViewEvents";
            this.listViewEvents.Size = new System.Drawing.Size(600, 295);
            this.listViewEvents.TabIndex = 12;
            this.listViewEvents.UseCompatibleStateImageBehavior = false;
            this.listViewEvents.View = System.Windows.Forms.View.Details;
            this.listViewEvents.SelectedIndexChanged += new System.EventHandler(this.listViewEvents_SelectedIndexChanged);
            //
            // colDate
            //
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            //
            // colCategory
            //
            this.colCategory.Text = "Category";
            this.colCategory.Width = 150;
            //
            // colTitle
            //
            this.colTitle.Text = "Title";
            this.colTitle.Width = 220;
            //
            // colLocation
            //
            this.colLocation.Text = "Location";
            this.colLocation.Width = 125;
            //
            // lblDetailsHeader
            //
            this.lblDetailsHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDetailsHeader.ForeColor = System.Drawing.Color.FromArgb(59, 31, 115);
            this.lblDetailsHeader.Location = new System.Drawing.Point(25, 488);
            this.lblDetailsHeader.Name = "lblDetailsHeader";
            this.lblDetailsHeader.Size = new System.Drawing.Size(300, 20);
            this.lblDetailsHeader.TabIndex = 13;
            this.lblDetailsHeader.Text = "Event Details:";
            //
            // rtbEventDetails
            //
            this.rtbEventDetails.BackColor = System.Drawing.Color.FromArgb(250, 249, 255);
            this.rtbEventDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbEventDetails.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rtbEventDetails.Location = new System.Drawing.Point(25, 510);
            this.rtbEventDetails.Name = "rtbEventDetails";
            this.rtbEventDetails.ReadOnly = true;
            this.rtbEventDetails.Size = new System.Drawing.Size(600, 90);
            this.rtbEventDetails.TabIndex = 14;
            this.rtbEventDetails.Text = "Select an event from the list above to see its full details here.";
            //
            // btnBackToMain
            //
            this.btnBackToMain.CornerRadius = 16;
            this.btnBackToMain.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBackToMain.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.btnBackToMain.GradientEnd = System.Drawing.Color.FromArgb(124, 77, 255);
            this.btnBackToMain.Location = new System.Drawing.Point(25, 612);
            this.btnBackToMain.Name = "btnBackToMain";
            this.btnBackToMain.Size = new System.Drawing.Size(220, 42);
            this.btnBackToMain.TabIndex = 15;
            this.btnBackToMain.Text = "← Back to Main Menu";
            this.btnBackToMain.UseGradient = false;
            this.btnBackToMain.UseVisualStyleBackColor = true;
            this.btnBackToMain.Click += new System.EventHandler(this.btnBackToMain_Click);
            //
            // lblUpcomingHeader
            //
            this.lblUpcomingHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUpcomingHeader.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.lblUpcomingHeader.Location = new System.Drawing.Point(650, 185);
            this.lblUpcomingHeader.Name = "lblUpcomingHeader";
            this.lblUpcomingHeader.Size = new System.Drawing.Size(325, 22);
            this.lblUpcomingHeader.TabIndex = 16;
            this.lblUpcomingHeader.Text = "📅  Next Upcoming";
            //
            // listBoxUpcoming
            //
            this.listBoxUpcoming.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listBoxUpcoming.FormattingEnabled = true;
            this.listBoxUpcoming.ItemHeight = 15;
            this.listBoxUpcoming.Location = new System.Drawing.Point(650, 210);
            this.listBoxUpcoming.Name = "listBoxUpcoming";
            this.listBoxUpcoming.Size = new System.Drawing.Size(325, 64);
            this.listBoxUpcoming.TabIndex = 17;
            //
            // lblRecommendedHeader
            //
            this.lblRecommendedHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRecommendedHeader.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.lblRecommendedHeader.Location = new System.Drawing.Point(650, 288);
            this.lblRecommendedHeader.Name = "lblRecommendedHeader";
            this.lblRecommendedHeader.Size = new System.Drawing.Size(325, 22);
            this.lblRecommendedHeader.TabIndex = 18;
            this.lblRecommendedHeader.Text = "✨  Recommended for You";
            //
            // listBoxRecommended
            //
            this.listBoxRecommended.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listBoxRecommended.FormattingEnabled = true;
            this.listBoxRecommended.ItemHeight = 15;
            this.listBoxRecommended.Location = new System.Drawing.Point(650, 313);
            this.listBoxRecommended.Name = "listBoxRecommended";
            this.listBoxRecommended.Size = new System.Drawing.Size(325, 64);
            this.listBoxRecommended.TabIndex = 19;
            //
            // lblRecentlyViewedHeader
            //
            this.lblRecentlyViewedHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRecentlyViewedHeader.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.lblRecentlyViewedHeader.Location = new System.Drawing.Point(650, 391);
            this.lblRecentlyViewedHeader.Name = "lblRecentlyViewedHeader";
            this.lblRecentlyViewedHeader.Size = new System.Drawing.Size(325, 22);
            this.lblRecentlyViewedHeader.TabIndex = 20;
            this.lblRecentlyViewedHeader.Text = "🕒  Recently Viewed";
            //
            // listBoxRecentlyViewed
            //
            this.listBoxRecentlyViewed.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listBoxRecentlyViewed.FormattingEnabled = true;
            this.listBoxRecentlyViewed.ItemHeight = 15;
            this.listBoxRecentlyViewed.Location = new System.Drawing.Point(650, 416);
            this.listBoxRecentlyViewed.Name = "listBoxRecentlyViewed";
            this.listBoxRecentlyViewed.Size = new System.Drawing.Size(325, 64);
            this.listBoxRecentlyViewed.TabIndex = 21;
            //
            // lblRecentSearchesHeader
            //
            this.lblRecentSearchesHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRecentSearchesHeader.ForeColor = System.Drawing.Color.FromArgb(94, 53, 209);
            this.lblRecentSearchesHeader.Location = new System.Drawing.Point(650, 494);
            this.lblRecentSearchesHeader.Name = "lblRecentSearchesHeader";
            this.lblRecentSearchesHeader.Size = new System.Drawing.Size(325, 22);
            this.lblRecentSearchesHeader.TabIndex = 22;
            this.lblRecentSearchesHeader.Text = "🔍  Recent Searches";
            //
            // listBoxRecentSearches
            //
            this.listBoxRecentSearches.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.listBoxRecentSearches.FormattingEnabled = true;
            this.listBoxRecentSearches.ItemHeight = 15;
            this.listBoxRecentSearches.Location = new System.Drawing.Point(650, 519);
            this.listBoxRecentSearches.Name = "listBoxRecentSearches";
            this.listBoxRecentSearches.Size = new System.Drawing.Size(325, 64);
            this.listBoxRecentSearches.TabIndex = 23;
            //
            // LocalEventsForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 670);
            this.Controls.Add(this.listBoxRecentSearches);
            this.Controls.Add(this.lblRecentSearchesHeader);
            this.Controls.Add(this.listBoxRecentlyViewed);
            this.Controls.Add(this.lblRecentlyViewedHeader);
            this.Controls.Add(this.listBoxRecommended);
            this.Controls.Add(this.lblRecommendedHeader);
            this.Controls.Add(this.listBoxUpcoming);
            this.Controls.Add(this.lblUpcomingHeader);
            this.Controls.Add(this.btnBackToMain);
            this.Controls.Add(this.rtbEventDetails);
            this.Controls.Add(this.lblDetailsHeader);
            this.Controls.Add(this.listViewEvents);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.chkFilterByDate);
            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbCategoryFilter);
            this.Controls.Add(this.lblCategoryFilter);
            this.Controls.Add(this.txtSearchKeyword);
            this.Controls.Add(this.lblSearchKeyword);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocalEventsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Events and Announcements - Municipal Services";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MunicipalServicesApp.Controls.BlobGradientPanel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblSearchKeyword;
        private System.Windows.Forms.TextBox txtSearchKeyword;
        private System.Windows.Forms.Label lblCategoryFilter;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private MunicipalServicesApp.Controls.RoundedButton btnSearch;
        private MunicipalServicesApp.Controls.RoundedButton btnClearFilters;
        private System.Windows.Forms.CheckBox chkFilterByDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.ListView listViewEvents;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colCategory;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.Label lblDetailsHeader;
        private System.Windows.Forms.RichTextBox rtbEventDetails;
        private MunicipalServicesApp.Controls.RoundedButton btnBackToMain;
        private System.Windows.Forms.Label lblUpcomingHeader;
        private System.Windows.Forms.ListBox listBoxUpcoming;
        private System.Windows.Forms.Label lblRecommendedHeader;
        private System.Windows.Forms.ListBox listBoxRecommended;
        private System.Windows.Forms.Label lblRecentlyViewedHeader;
        private System.Windows.Forms.ListBox listBoxRecentlyViewed;
        private System.Windows.Forms.Label lblRecentSearchesHeader;
        private System.Windows.Forms.ListBox listBoxRecentSearches;
    }
}
