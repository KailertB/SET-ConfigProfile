﻿namespace SET_ConfigProfile
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSource = new System.Windows.Forms.Label();
            this.lblConfig = new System.Windows.Forms.Label();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.btnBrowseSourceFolder = new System.Windows.Forms.Button();
            this.txtConfigPath = new System.Windows.Forms.TextBox();
            this.btnBrowseConfigFolder = new System.Windows.Forms.Button();
            this.ddlProfile = new System.Windows.Forms.ComboBox();
            this.lblProfile = new System.Windows.Forms.Label();
            this.copyDataGridView = new System.Windows.Forms.DataGridView();
            this.isCheckCopy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.copyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(12, 15);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(73, 13);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source Folder";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConfig
            // 
            this.lblConfig.AutoSize = true;
            this.lblConfig.Location = new System.Drawing.Point(16, 41);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(69, 13);
            this.lblConfig.TabIndex = 1;
            this.lblConfig.Text = "Config Folder";
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(91, 12);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(224, 20);
            this.txtSourcePath.TabIndex = 2;
            // 
            // btnBrowseSourceFolder
            // 
            this.btnBrowseSourceFolder.Location = new System.Drawing.Point(321, 10);
            this.btnBrowseSourceFolder.Name = "btnBrowseSourceFolder";
            this.btnBrowseSourceFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSourceFolder.TabIndex = 3;
            this.btnBrowseSourceFolder.Text = "Browse";
            this.btnBrowseSourceFolder.UseVisualStyleBackColor = true;
            this.btnBrowseSourceFolder.Click += new System.EventHandler(this.btnBrowseSourceFolder_Click);
            // 
            // txtConfigPath
            // 
            this.txtConfigPath.Location = new System.Drawing.Point(91, 38);
            this.txtConfigPath.Name = "txtConfigPath";
            this.txtConfigPath.Size = new System.Drawing.Size(224, 20);
            this.txtConfigPath.TabIndex = 4;
            // 
            // btnBrowseConfigFolder
            // 
            this.btnBrowseConfigFolder.Location = new System.Drawing.Point(321, 36);
            this.btnBrowseConfigFolder.Name = "btnBrowseConfigFolder";
            this.btnBrowseConfigFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseConfigFolder.TabIndex = 5;
            this.btnBrowseConfigFolder.Text = "Browse";
            this.btnBrowseConfigFolder.UseVisualStyleBackColor = true;
            this.btnBrowseConfigFolder.Click += new System.EventHandler(this.btnBrowseConfigFolder_Click);
            // 
            // ddlProfile
            // 
            this.ddlProfile.FormattingEnabled = true;
            this.ddlProfile.Location = new System.Drawing.Point(91, 64);
            this.ddlProfile.Name = "ddlProfile";
            this.ddlProfile.Size = new System.Drawing.Size(224, 21);
            this.ddlProfile.TabIndex = 7;
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(49, 67);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(36, 13);
            this.lblProfile.TabIndex = 8;
            this.lblProfile.Text = "Profile";
            // 
            // copyDataGridView
            // 
            this.copyDataGridView.AllowUserToDeleteRows = false;
            this.copyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.copyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isCheckCopy});
            this.copyDataGridView.Location = new System.Drawing.Point(12, 91);
            this.copyDataGridView.Name = "copyDataGridView";
            this.copyDataGridView.Size = new System.Drawing.Size(384, 198);
            this.copyDataGridView.TabIndex = 9;
            // 
            // isCheckCopy
            // 
            this.isCheckCopy.HeaderText = "";
            this.isCheckCopy.Name = "isCheckCopy";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 301);
            this.Controls.Add(this.copyDataGridView);
            this.Controls.Add(this.lblProfile);
            this.Controls.Add(this.ddlProfile);
            this.Controls.Add(this.btnBrowseConfigFolder);
            this.Controls.Add(this.txtConfigPath);
            this.Controls.Add(this.btnBrowseSourceFolder);
            this.Controls.Add(this.txtSourcePath);
            this.Controls.Add(this.lblConfig);
            this.Controls.Add(this.lblSource);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.copyDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Button btnBrowseSourceFolder;
        private System.Windows.Forms.TextBox txtConfigPath;
        private System.Windows.Forms.Button btnBrowseConfigFolder;
        private System.Windows.Forms.ComboBox ddlProfile;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.DataGridView copyDataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckCopy;
    }
}

