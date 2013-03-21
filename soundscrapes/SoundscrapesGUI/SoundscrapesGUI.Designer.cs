namespace SoundscrapesGUI {
	partial class mainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.concertsDataGridView = new System.Windows.Forms.DataGridView();
			this.refreshButton = new System.Windows.Forms.Button();
			this.bandSearchTextBox = new System.Windows.Forms.TextBox();
			this.searchBandButton = new System.Windows.Forms.Button();
			this.bandSearchGroupBox = new System.Windows.Forms.GroupBox();
			this.containsRadioButton = new System.Windows.Forms.RadioButton();
			this.startsWithRadioButton = new System.Windows.Forms.RadioButton();
			this.searchTabControl = new System.Windows.Forms.TabControl();
			this.bandSearchTabPage = new System.Windows.Forms.TabPage();
			this.venueSearchTabPage = new System.Windows.Forms.TabPage();
			this.searchVenueButton = new System.Windows.Forms.Button();
			this.venueComboBox = new System.Windows.Forms.ComboBox();
			this.searchGroupBox = new System.Windows.Forms.GroupBox();
			this.resultsGroupBox = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.concertsDataGridView)).BeginInit();
			this.bandSearchGroupBox.SuspendLayout();
			this.searchTabControl.SuspendLayout();
			this.bandSearchTabPage.SuspendLayout();
			this.venueSearchTabPage.SuspendLayout();
			this.searchGroupBox.SuspendLayout();
			this.resultsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// concertsDataGridView
			// 
			this.concertsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.concertsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.concertsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.concertsDataGridView.Location = new System.Drawing.Point(7, 19);
			this.concertsDataGridView.Name = "concertsDataGridView";
			this.concertsDataGridView.ReadOnly = true;
			this.concertsDataGridView.Size = new System.Drawing.Size(588, 284);
			this.concertsDataGridView.TabIndex = 0;
			this.concertsDataGridView.MouseEnter += new System.EventHandler(this.concertsDataGridView_MouseEnter);
			// 
			// refreshButton
			// 
			this.refreshButton.Location = new System.Drawing.Point(12, 12);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(75, 23);
			this.refreshButton.TabIndex = 1;
			this.refreshButton.Text = "Refresh";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// bandSearchTextBox
			// 
			this.bandSearchTextBox.Location = new System.Drawing.Point(3, 9);
			this.bandSearchTextBox.Name = "bandSearchTextBox";
			this.bandSearchTextBox.Size = new System.Drawing.Size(337, 20);
			this.bandSearchTextBox.TabIndex = 2;
			// 
			// searchBandButton
			// 
			this.searchBandButton.Location = new System.Drawing.Point(166, 40);
			this.searchBandButton.Name = "searchBandButton";
			this.searchBandButton.Size = new System.Drawing.Size(78, 23);
			this.searchBandButton.TabIndex = 3;
			this.searchBandButton.Text = "Search Band";
			this.searchBandButton.UseVisualStyleBackColor = true;
			this.searchBandButton.Click += new System.EventHandler(this.searchBandButton_Click);
			// 
			// bandSearchGroupBox
			// 
			this.bandSearchGroupBox.Controls.Add(this.containsRadioButton);
			this.bandSearchGroupBox.Controls.Add(this.startsWithRadioButton);
			this.bandSearchGroupBox.Location = new System.Drawing.Point(3, 32);
			this.bandSearchGroupBox.Name = "bandSearchGroupBox";
			this.bandSearchGroupBox.Size = new System.Drawing.Size(157, 36);
			this.bandSearchGroupBox.TabIndex = 4;
			this.bandSearchGroupBox.TabStop = false;
			// 
			// containsRadioButton
			// 
			this.containsRadioButton.AutoSize = true;
			this.containsRadioButton.Checked = true;
			this.containsRadioButton.Location = new System.Drawing.Point(88, 11);
			this.containsRadioButton.Name = "containsRadioButton";
			this.containsRadioButton.Size = new System.Drawing.Size(66, 17);
			this.containsRadioButton.TabIndex = 1;
			this.containsRadioButton.TabStop = true;
			this.containsRadioButton.Text = "Contains";
			this.containsRadioButton.UseVisualStyleBackColor = true;
			// 
			// startsWithRadioButton
			// 
			this.startsWithRadioButton.AutoSize = true;
			this.startsWithRadioButton.Location = new System.Drawing.Point(8, 11);
			this.startsWithRadioButton.Name = "startsWithRadioButton";
			this.startsWithRadioButton.Size = new System.Drawing.Size(74, 17);
			this.startsWithRadioButton.TabIndex = 0;
			this.startsWithRadioButton.Text = "Starts with";
			this.startsWithRadioButton.UseVisualStyleBackColor = true;
			// 
			// searchTabControl
			// 
			this.searchTabControl.Controls.Add(this.bandSearchTabPage);
			this.searchTabControl.Controls.Add(this.venueSearchTabPage);
			this.searchTabControl.Location = new System.Drawing.Point(6, 19);
			this.searchTabControl.Name = "searchTabControl";
			this.searchTabControl.SelectedIndex = 0;
			this.searchTabControl.Size = new System.Drawing.Size(591, 109);
			this.searchTabControl.TabIndex = 5;
			// 
			// bandSearchTabPage
			// 
			this.bandSearchTabPage.Controls.Add(this.bandSearchTextBox);
			this.bandSearchTabPage.Controls.Add(this.bandSearchGroupBox);
			this.bandSearchTabPage.Controls.Add(this.searchBandButton);
			this.bandSearchTabPage.Location = new System.Drawing.Point(4, 22);
			this.bandSearchTabPage.Name = "bandSearchTabPage";
			this.bandSearchTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.bandSearchTabPage.Size = new System.Drawing.Size(583, 83);
			this.bandSearchTabPage.TabIndex = 0;
			this.bandSearchTabPage.Text = "Band";
			this.bandSearchTabPage.UseVisualStyleBackColor = true;
			// 
			// venueSearchTabPage
			// 
			this.venueSearchTabPage.Controls.Add(this.searchVenueButton);
			this.venueSearchTabPage.Controls.Add(this.venueComboBox);
			this.venueSearchTabPage.Location = new System.Drawing.Point(4, 22);
			this.venueSearchTabPage.Name = "venueSearchTabPage";
			this.venueSearchTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.venueSearchTabPage.Size = new System.Drawing.Size(583, 83);
			this.venueSearchTabPage.TabIndex = 1;
			this.venueSearchTabPage.Text = "Venue";
			this.venueSearchTabPage.UseVisualStyleBackColor = true;
			// 
			// searchVenueButton
			// 
			this.searchVenueButton.Location = new System.Drawing.Point(7, 34);
			this.searchVenueButton.Name = "searchVenueButton";
			this.searchVenueButton.Size = new System.Drawing.Size(85, 23);
			this.searchVenueButton.TabIndex = 1;
			this.searchVenueButton.Text = "Search Venue";
			this.searchVenueButton.UseVisualStyleBackColor = true;
			this.searchVenueButton.Click += new System.EventHandler(this.searchVenueButton_Click);
			// 
			// venueComboBox
			// 
			this.venueComboBox.FormattingEnabled = true;
			this.venueComboBox.Location = new System.Drawing.Point(7, 7);
			this.venueComboBox.Name = "venueComboBox";
			this.venueComboBox.Size = new System.Drawing.Size(224, 21);
			this.venueComboBox.TabIndex = 0;
			// 
			// searchGroupBox
			// 
			this.searchGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.searchGroupBox.Controls.Add(this.searchTabControl);
			this.searchGroupBox.Location = new System.Drawing.Point(12, 44);
			this.searchGroupBox.Name = "searchGroupBox";
			this.searchGroupBox.Size = new System.Drawing.Size(601, 139);
			this.searchGroupBox.TabIndex = 6;
			this.searchGroupBox.TabStop = false;
			this.searchGroupBox.Text = "Search by:";
			// 
			// resultsGroupBox
			// 
			this.resultsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.resultsGroupBox.Controls.Add(this.concertsDataGridView);
			this.resultsGroupBox.Location = new System.Drawing.Point(14, 189);
			this.resultsGroupBox.Name = "resultsGroupBox";
			this.resultsGroupBox.Size = new System.Drawing.Size(601, 318);
			this.resultsGroupBox.TabIndex = 7;
			this.resultsGroupBox.TabStop = false;
			this.resultsGroupBox.Text = "Results:";
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(625, 519);
			this.Controls.Add(this.resultsGroupBox);
			this.Controls.Add(this.searchGroupBox);
			this.Controls.Add(this.refreshButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "mainForm";
			this.Text = "soundscrapes";
			this.Load += new System.EventHandler(this.SoundscrapesGUI_Load);
			((System.ComponentModel.ISupportInitialize)(this.concertsDataGridView)).EndInit();
			this.bandSearchGroupBox.ResumeLayout(false);
			this.bandSearchGroupBox.PerformLayout();
			this.searchTabControl.ResumeLayout(false);
			this.bandSearchTabPage.ResumeLayout(false);
			this.bandSearchTabPage.PerformLayout();
			this.venueSearchTabPage.ResumeLayout(false);
			this.searchGroupBox.ResumeLayout(false);
			this.resultsGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView concertsDataGridView;
		private System.Windows.Forms.Button refreshButton;
		private System.Windows.Forms.TextBox bandSearchTextBox;
		private System.Windows.Forms.Button searchBandButton;
		private System.Windows.Forms.GroupBox bandSearchGroupBox;
		private System.Windows.Forms.RadioButton containsRadioButton;
		private System.Windows.Forms.RadioButton startsWithRadioButton;
		private System.Windows.Forms.TabControl searchTabControl;
		private System.Windows.Forms.TabPage bandSearchTabPage;
		private System.Windows.Forms.TabPage venueSearchTabPage;
		private System.Windows.Forms.GroupBox searchGroupBox;
		private System.Windows.Forms.GroupBox resultsGroupBox;
		private System.Windows.Forms.Button searchVenueButton;
		private System.Windows.Forms.ComboBox venueComboBox;
	}
}

