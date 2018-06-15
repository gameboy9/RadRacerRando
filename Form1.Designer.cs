namespace ExcitebikeRando
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
            this.cmdRandomize = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblFlags = new System.Windows.Forms.Label();
            this.txtFlags = new System.Windows.Forms.TextBox();
            this.btnNewSeed = new System.Windows.Forms.Button();
            this.lblSeed = new System.Windows.Forms.Label();
            this.txtSeed = new System.Windows.Forms.TextBox();
            this.lblCompareImage = new System.Windows.Forms.Label();
            this.txtCompare = new System.Windows.Forms.TextBox();
            this.lblReqChecksum = new System.Windows.Forms.Label();
            this.lblRequired = new System.Windows.Forms.Label();
            this.lblSHAChecksum = new System.Windows.Forms.Label();
            this.lblSHA = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblRomImage = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTimerDifficulty = new System.Windows.Forms.ComboBox();
            this.cboTrackLength = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdRandomize
            // 
            this.cmdRandomize.Location = new System.Drawing.Point(437, 248);
            this.cmdRandomize.Name = "cmdRandomize";
            this.cmdRandomize.Size = new System.Drawing.Size(96, 23);
            this.cmdRandomize.TabIndex = 154;
            this.cmdRandomize.Text = "Randomize";
            this.cmdRandomize.UseVisualStyleBackColor = true;
            this.cmdRandomize.Click += new System.EventHandler(this.cmdRandomize_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 309);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 153;
            // 
            // lblFlags
            // 
            this.lblFlags.AutoSize = true;
            this.lblFlags.Location = new System.Drawing.Point(291, 113);
            this.lblFlags.Name = "lblFlags";
            this.lblFlags.Size = new System.Drawing.Size(32, 13);
            this.lblFlags.TabIndex = 148;
            this.lblFlags.Text = "Flags";
            // 
            // txtFlags
            // 
            this.txtFlags.Location = new System.Drawing.Point(329, 109);
            this.txtFlags.Name = "txtFlags";
            this.txtFlags.Size = new System.Drawing.Size(200, 20);
            this.txtFlags.TabIndex = 147;
            this.txtFlags.Leave += new System.EventHandler(this.determineChecks);
            // 
            // btnNewSeed
            // 
            this.btnNewSeed.Location = new System.Drawing.Point(186, 109);
            this.btnNewSeed.Name = "btnNewSeed";
            this.btnNewSeed.Size = new System.Drawing.Size(86, 23);
            this.btnNewSeed.TabIndex = 139;
            this.btnNewSeed.Text = "New Seed";
            this.btnNewSeed.UseVisualStyleBackColor = true;
            this.btnNewSeed.Click += new System.EventHandler(this.btnNewSeed_Click);
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Location = new System.Drawing.Point(12, 113);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(32, 13);
            this.lblSeed.TabIndex = 146;
            this.lblSeed.Text = "Seed";
            // 
            // txtSeed
            // 
            this.txtSeed.Location = new System.Drawing.Point(69, 111);
            this.txtSeed.Name = "txtSeed";
            this.txtSeed.Size = new System.Drawing.Size(100, 20);
            this.txtSeed.TabIndex = 138;
            // 
            // lblCompareImage
            // 
            this.lblCompareImage.AutoSize = true;
            this.lblCompareImage.Location = new System.Drawing.Point(12, 35);
            this.lblCompareImage.Name = "lblCompareImage";
            this.lblCompareImage.Size = new System.Drawing.Size(94, 13);
            this.lblCompareImage.TabIndex = 145;
            this.lblCompareImage.Text = "Comparison Image";
            // 
            // txtCompare
            // 
            this.txtCompare.Location = new System.Drawing.Point(138, 35);
            this.txtCompare.Name = "txtCompare";
            this.txtCompare.Size = new System.Drawing.Size(320, 20);
            this.txtCompare.TabIndex = 135;
            // 
            // lblReqChecksum
            // 
            this.lblReqChecksum.AutoSize = true;
            this.lblReqChecksum.Location = new System.Drawing.Point(135, 88);
            this.lblReqChecksum.Name = "lblReqChecksum";
            this.lblReqChecksum.Size = new System.Drawing.Size(247, 13);
            this.lblReqChecksum.TabIndex = 144;
            this.lblReqChecksum.Text = "2e9897846e54a4a9865e87de7517c6710bdec255";
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Location = new System.Drawing.Point(12, 88);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(50, 13);
            this.lblRequired.TabIndex = 143;
            this.lblRequired.Text = "Required";
            // 
            // lblSHAChecksum
            // 
            this.lblSHAChecksum.AutoSize = true;
            this.lblSHAChecksum.Location = new System.Drawing.Point(135, 64);
            this.lblSHAChecksum.Name = "lblSHAChecksum";
            this.lblSHAChecksum.Size = new System.Drawing.Size(247, 13);
            this.lblSHAChecksum.TabIndex = 142;
            this.lblSHAChecksum.Text = "????????????????????????????????????????";
            // 
            // lblSHA
            // 
            this.lblSHA.AutoSize = true;
            this.lblSHA.Location = new System.Drawing.Point(12, 64);
            this.lblSHA.Name = "lblSHA";
            this.lblSHA.Size = new System.Drawing.Size(88, 13);
            this.lblSHA.TabIndex = 141;
            this.lblSHA.Text = "SHA1 Checksum";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(464, 7);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 134;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblRomImage
            // 
            this.lblRomImage.AutoSize = true;
            this.lblRomImage.Location = new System.Drawing.Point(12, 9);
            this.lblRomImage.Name = "lblRomImage";
            this.lblRomImage.Size = new System.Drawing.Size(119, 13);
            this.lblRomImage.TabIndex = 140;
            this.lblRomImage.Text = "Rad Racer ROM Image";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(138, 9);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(320, 20);
            this.txtFileName.TabIndex = 133;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 157;
            this.label1.Text = "Timer Difficulty";
            // 
            // cboTimerDifficulty
            // 
            this.cboTimerDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimerDifficulty.FormattingEnabled = true;
            this.cboTimerDifficulty.Items.AddRange(new object[] {
            "Very Easy",
            "Easy",
            "Medium",
            "Hard",
            "Very Hard"});
            this.cboTimerDifficulty.Location = new System.Drawing.Point(104, 169);
            this.cboTimerDifficulty.Name = "cboTimerDifficulty";
            this.cboTimerDifficulty.Size = new System.Drawing.Size(121, 21);
            this.cboTimerDifficulty.TabIndex = 159;
            this.cboTimerDifficulty.SelectedIndexChanged += new System.EventHandler(this.determineFlags);
            // 
            // cboTrackLength
            // 
            this.cboTrackLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrackLength.FormattingEnabled = true;
            this.cboTrackLength.Items.AddRange(new object[] {
            "Very Short",
            "Short",
            "Moderate",
            "Long",
            "Very Long"});
            this.cboTrackLength.Location = new System.Drawing.Point(104, 144);
            this.cboTrackLength.Name = "cboTrackLength";
            this.cboTrackLength.Size = new System.Drawing.Size(121, 21);
            this.cboTrackLength.TabIndex = 163;
            this.cboTrackLength.SelectedIndexChanged += new System.EventHandler(this.determineFlags);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 161;
            this.label4.Text = "Track Length";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 345);
            this.Controls.Add(this.cboTrackLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboTimerDifficulty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdRandomize);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblFlags);
            this.Controls.Add(this.txtFlags);
            this.Controls.Add(this.btnNewSeed);
            this.Controls.Add(this.lblSeed);
            this.Controls.Add(this.txtSeed);
            this.Controls.Add(this.lblCompareImage);
            this.Controls.Add(this.txtCompare);
            this.Controls.Add(this.lblReqChecksum);
            this.Controls.Add(this.lblRequired);
            this.Controls.Add(this.lblSHAChecksum);
            this.Controls.Add(this.lblSHA);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblRomImage);
            this.Controls.Add(this.txtFileName);
            this.Name = "Form1";
            this.Text = "Rad Racer Randomizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdRandomize;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblFlags;
        private System.Windows.Forms.TextBox txtFlags;
        private System.Windows.Forms.Button btnNewSeed;
        private System.Windows.Forms.Label lblSeed;
        private System.Windows.Forms.TextBox txtSeed;
        private System.Windows.Forms.Label lblCompareImage;
        private System.Windows.Forms.TextBox txtCompare;
        private System.Windows.Forms.Label lblReqChecksum;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Label lblSHAChecksum;
        private System.Windows.Forms.Label lblSHA;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblRomImage;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTimerDifficulty;
        private System.Windows.Forms.ComboBox cboTrackLength;
        private System.Windows.Forms.Label label4;
    }
}

