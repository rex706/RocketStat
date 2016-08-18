namespace RocketStat
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ShotsOnGoalLabel = new System.Windows.Forms.Label();
            this.NumShotsOnGoalLabel = new System.Windows.Forms.Label();
            this.PointsLabel = new System.Windows.Forms.Label();
            this.NumPointsLabel = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.GoalsLabel = new System.Windows.Forms.Label();
            this.NumGoalsLabel = new System.Windows.Forms.Label();
            this.ScanButton = new System.Windows.Forms.Button();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NumAssistsLabel = new System.Windows.Forms.Label();
            this.NumSavesLabel = new System.Windows.Forms.Label();
            this.TotalPointsLabel = new System.Windows.Forms.Label();
            this.TotalGoalsLabel = new System.Windows.Forms.Label();
            this.TotalAssistsLabel = new System.Windows.Forms.Label();
            this.TotalSavesLabel = new System.Windows.Forms.Label();
            this.TotalShotsLabel = new System.Windows.Forms.Label();
            this.CurrentGameLabel = new System.Windows.Forms.Label();
            this.TotalStatsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ShotsOnGoalLabel
            // 
            this.ShotsOnGoalLabel.AutoSize = true;
            this.ShotsOnGoalLabel.BackColor = System.Drawing.Color.Transparent;
            this.ShotsOnGoalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShotsOnGoalLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ShotsOnGoalLabel.Location = new System.Drawing.Point(491, 90);
            this.ShotsOnGoalLabel.Name = "ShotsOnGoalLabel";
            this.ShotsOnGoalLabel.Size = new System.Drawing.Size(51, 20);
            this.ShotsOnGoalLabel.TabIndex = 0;
            this.ShotsOnGoalLabel.Text = "Shots";
            // 
            // NumShotsOnGoalLabel
            // 
            this.NumShotsOnGoalLabel.BackColor = System.Drawing.Color.Transparent;
            this.NumShotsOnGoalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumShotsOnGoalLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NumShotsOnGoalLabel.Location = new System.Drawing.Point(490, 144);
            this.NumShotsOnGoalLabel.Name = "NumShotsOnGoalLabel";
            this.NumShotsOnGoalLabel.Size = new System.Drawing.Size(57, 20);
            this.NumShotsOnGoalLabel.TabIndex = 1;
            this.NumShotsOnGoalLabel.Text = "0";
            this.NumShotsOnGoalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PointsLabel
            // 
            this.PointsLabel.AutoSize = true;
            this.PointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.PointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PointsLabel.Location = new System.Drawing.Point(168, 90);
            this.PointsLabel.Name = "PointsLabel";
            this.PointsLabel.Size = new System.Drawing.Size(51, 20);
            this.PointsLabel.TabIndex = 4;
            this.PointsLabel.Text = "Score";
            // 
            // NumPointsLabel
            // 
            this.NumPointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.NumPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumPointsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NumPointsLabel.Location = new System.Drawing.Point(167, 144);
            this.NumPointsLabel.Name = "NumPointsLabel";
            this.NumPointsLabel.Size = new System.Drawing.Size(57, 20);
            this.NumPointsLabel.TabIndex = 5;
            this.NumPointsLabel.Text = "0";
            this.NumPointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(352, 302);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(170, 40);
            this.RefreshButton.TabIndex = 6;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // GoalsLabel
            // 
            this.GoalsLabel.AutoSize = true;
            this.GoalsLabel.BackColor = System.Drawing.Color.Transparent;
            this.GoalsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoalsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GoalsLabel.Location = new System.Drawing.Point(247, 90);
            this.GoalsLabel.Name = "GoalsLabel";
            this.GoalsLabel.Size = new System.Drawing.Size(51, 20);
            this.GoalsLabel.TabIndex = 7;
            this.GoalsLabel.Text = "Goals";
            // 
            // NumGoalsLabel
            // 
            this.NumGoalsLabel.BackColor = System.Drawing.Color.Transparent;
            this.NumGoalsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumGoalsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NumGoalsLabel.Location = new System.Drawing.Point(245, 144);
            this.NumGoalsLabel.Name = "NumGoalsLabel";
            this.NumGoalsLabel.Size = new System.Drawing.Size(57, 20);
            this.NumGoalsLabel.TabIndex = 8;
            this.NumGoalsLabel.Text = "0";
            this.NumGoalsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScanButton
            // 
            this.ScanButton.Location = new System.Drawing.Point(111, 302);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(170, 40);
            this.ScanButton.TabIndex = 9;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // InfoLabel
            // 
            this.InfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.ForeColor = System.Drawing.Color.Green;
            this.InfoLabel.Location = new System.Drawing.Point(243, 7);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(150, 20);
            this.InfoLabel.TabIndex = 10;
            this.InfoLabel.Text = "Ready";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(328, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Assists";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(413, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Saves";
            // 
            // NumAssistsLabel
            // 
            this.NumAssistsLabel.BackColor = System.Drawing.Color.Transparent;
            this.NumAssistsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumAssistsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NumAssistsLabel.Location = new System.Drawing.Point(329, 144);
            this.NumAssistsLabel.Name = "NumAssistsLabel";
            this.NumAssistsLabel.Size = new System.Drawing.Size(57, 20);
            this.NumAssistsLabel.TabIndex = 13;
            this.NumAssistsLabel.Text = "0";
            this.NumAssistsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumSavesLabel
            // 
            this.NumSavesLabel.BackColor = System.Drawing.Color.Transparent;
            this.NumSavesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumSavesLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NumSavesLabel.Location = new System.Drawing.Point(414, 144);
            this.NumSavesLabel.Name = "NumSavesLabel";
            this.NumSavesLabel.Size = new System.Drawing.Size(57, 20);
            this.NumSavesLabel.TabIndex = 14;
            this.NumSavesLabel.Text = "0";
            this.NumSavesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalPointsLabel
            // 
            this.TotalPointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.TotalPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalPointsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalPointsLabel.Location = new System.Drawing.Point(167, 216);
            this.TotalPointsLabel.Name = "TotalPointsLabel";
            this.TotalPointsLabel.Size = new System.Drawing.Size(57, 20);
            this.TotalPointsLabel.TabIndex = 16;
            this.TotalPointsLabel.Text = "0";
            this.TotalPointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalGoalsLabel
            // 
            this.TotalGoalsLabel.BackColor = System.Drawing.Color.Transparent;
            this.TotalGoalsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalGoalsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalGoalsLabel.Location = new System.Drawing.Point(245, 216);
            this.TotalGoalsLabel.Name = "TotalGoalsLabel";
            this.TotalGoalsLabel.Size = new System.Drawing.Size(57, 20);
            this.TotalGoalsLabel.TabIndex = 17;
            this.TotalGoalsLabel.Text = "0";
            this.TotalGoalsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalAssistsLabel
            // 
            this.TotalAssistsLabel.BackColor = System.Drawing.Color.Transparent;
            this.TotalAssistsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalAssistsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalAssistsLabel.Location = new System.Drawing.Point(329, 216);
            this.TotalAssistsLabel.Name = "TotalAssistsLabel";
            this.TotalAssistsLabel.Size = new System.Drawing.Size(57, 20);
            this.TotalAssistsLabel.TabIndex = 18;
            this.TotalAssistsLabel.Text = "0";
            this.TotalAssistsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalSavesLabel
            // 
            this.TotalSavesLabel.BackColor = System.Drawing.Color.Transparent;
            this.TotalSavesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalSavesLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalSavesLabel.Location = new System.Drawing.Point(414, 216);
            this.TotalSavesLabel.Name = "TotalSavesLabel";
            this.TotalSavesLabel.Size = new System.Drawing.Size(57, 20);
            this.TotalSavesLabel.TabIndex = 19;
            this.TotalSavesLabel.Text = "0";
            this.TotalSavesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalShotsLabel
            // 
            this.TotalShotsLabel.BackColor = System.Drawing.Color.Transparent;
            this.TotalShotsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalShotsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalShotsLabel.Location = new System.Drawing.Point(490, 216);
            this.TotalShotsLabel.Name = "TotalShotsLabel";
            this.TotalShotsLabel.Size = new System.Drawing.Size(57, 20);
            this.TotalShotsLabel.TabIndex = 20;
            this.TotalShotsLabel.Text = "0";
            this.TotalShotsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentGameLabel
            // 
            this.CurrentGameLabel.AutoSize = true;
            this.CurrentGameLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrentGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentGameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CurrentGameLabel.Location = new System.Drawing.Point(95, 144);
            this.CurrentGameLabel.Name = "CurrentGameLabel";
            this.CurrentGameLabel.Size = new System.Drawing.Size(62, 20);
            this.CurrentGameLabel.TabIndex = 21;
            this.CurrentGameLabel.Text = "Current";
            // 
            // TotalStatsLabel
            // 
            this.TotalStatsLabel.AutoSize = true;
            this.TotalStatsLabel.BackColor = System.Drawing.Color.Transparent;
            this.TotalStatsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalStatsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalStatsLabel.Location = new System.Drawing.Point(95, 216);
            this.TotalStatsLabel.Name = "TotalStatsLabel";
            this.TotalStatsLabel.Size = new System.Drawing.Size(44, 20);
            this.TotalStatsLabel.TabIndex = 22;
            this.TotalStatsLabel.Text = "Total";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RocketStat.Properties.Resources.RocketStatBackImg3;
            this.ClientSize = new System.Drawing.Size(629, 354);
            this.Controls.Add(this.TotalStatsLabel);
            this.Controls.Add(this.CurrentGameLabel);
            this.Controls.Add(this.TotalShotsLabel);
            this.Controls.Add(this.TotalSavesLabel);
            this.Controls.Add(this.TotalAssistsLabel);
            this.Controls.Add(this.TotalGoalsLabel);
            this.Controls.Add(this.TotalPointsLabel);
            this.Controls.Add(this.NumSavesLabel);
            this.Controls.Add(this.NumAssistsLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.NumGoalsLabel);
            this.Controls.Add(this.GoalsLabel);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.NumPointsLabel);
            this.Controls.Add(this.PointsLabel);
            this.Controls.Add(this.NumShotsOnGoalLabel);
            this.Controls.Add(this.ShotsOnGoalLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RocketStat";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ShotsOnGoalLabel;
        private System.Windows.Forms.Label NumShotsOnGoalLabel;
        private System.Windows.Forms.Label PointsLabel;
        private System.Windows.Forms.Label NumPointsLabel;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Label GoalsLabel;
        private System.Windows.Forms.Label NumGoalsLabel;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NumAssistsLabel;
        private System.Windows.Forms.Label NumSavesLabel;
        private System.Windows.Forms.Label TotalPointsLabel;
        private System.Windows.Forms.Label TotalGoalsLabel;
        private System.Windows.Forms.Label TotalAssistsLabel;
        private System.Windows.Forms.Label TotalSavesLabel;
        private System.Windows.Forms.Label TotalShotsLabel;
        private System.Windows.Forms.Label CurrentGameLabel;
        private System.Windows.Forms.Label TotalStatsLabel;
    }
}

