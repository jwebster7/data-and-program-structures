namespace Ksu.Cis300.BTrees
{
    partial class NameLookup
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
            this.uxMinimumDegree = new System.Windows.Forms.NumericUpDown();
            this.uxNumberOfItems = new System.Windows.Forms.NumericUpDown();
            this.uxMakeTree = new System.Windows.Forms.Button();
            this.uxOpen = new System.Windows.Forms.Button();
            this.uxNameBox = new System.Windows.Forms.TextBox();
            this.uxGetStatistics = new System.Windows.Forms.Button();
            this.uxFrequency = new System.Windows.Forms.TextBox();
            this.uxRank = new System.Windows.Forms.TextBox();
            this.uxFrequencyLabel = new System.Windows.Forms.Label();
            this.uxRankLabel = new System.Windows.Forms.Label();
            this.uxNameLabel = new System.Windows.Forms.Label();
            this.uxDegreeLabel = new System.Windows.Forms.Label();
            this.uxItemLabel = new System.Windows.Forms.Label();
            this.uxOpenFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.uxMinimumDegree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfItems)).BeginInit();
            this.SuspendLayout();
            // 
            // uxMinimumDegree
            // 
            this.uxMinimumDegree.Location = new System.Drawing.Point(118, 12);
            this.uxMinimumDegree.Name = "uxMinimumDegree";
            this.uxMinimumDegree.Size = new System.Drawing.Size(56, 20);
            this.uxMinimumDegree.TabIndex = 0;
            this.uxMinimumDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxMinimumDegree.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // uxNumberOfItems
            // 
            this.uxNumberOfItems.Location = new System.Drawing.Point(118, 38);
            this.uxNumberOfItems.Name = "uxNumberOfItems";
            this.uxNumberOfItems.Size = new System.Drawing.Size(56, 20);
            this.uxNumberOfItems.TabIndex = 1;
            this.uxNumberOfItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uxMakeTree
            // 
            this.uxMakeTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxMakeTree.Location = new System.Drawing.Point(180, 12);
            this.uxMakeTree.Name = "uxMakeTree";
            this.uxMakeTree.Size = new System.Drawing.Size(187, 46);
            this.uxMakeTree.TabIndex = 2;
            this.uxMakeTree.Text = "Make Tree";
            this.uxMakeTree.UseVisualStyleBackColor = true;
            this.uxMakeTree.Click += new System.EventHandler(this.uxMakeTree_Click);
            // 
            // uxOpen
            // 
            this.uxOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxOpen.Location = new System.Drawing.Point(12, 64);
            this.uxOpen.Name = "uxOpen";
            this.uxOpen.Size = new System.Drawing.Size(355, 46);
            this.uxOpen.TabIndex = 3;
            this.uxOpen.Text = "Open Data File";
            this.uxOpen.UseVisualStyleBackColor = true;
            this.uxOpen.Click += new System.EventHandler(this.uxOpenDataFile_Click);
            // 
            // uxNameBox
            // 
            this.uxNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxNameBox.Location = new System.Drawing.Point(92, 116);
            this.uxNameBox.Multiline = true;
            this.uxNameBox.Name = "uxNameBox";
            this.uxNameBox.Size = new System.Drawing.Size(275, 33);
            this.uxNameBox.TabIndex = 4;
            // 
            // uxGetStatistics
            // 
            this.uxGetStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxGetStatistics.Location = new System.Drawing.Point(12, 155);
            this.uxGetStatistics.Name = "uxGetStatistics";
            this.uxGetStatistics.Size = new System.Drawing.Size(355, 46);
            this.uxGetStatistics.TabIndex = 5;
            this.uxGetStatistics.Text = "Get Statistics";
            this.uxGetStatistics.UseVisualStyleBackColor = true;
            this.uxGetStatistics.Click += new System.EventHandler(this.uxGetStatistics_Click);
            // 
            // uxFrequency
            // 
            this.uxFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxFrequency.Location = new System.Drawing.Point(133, 207);
            this.uxFrequency.Multiline = true;
            this.uxFrequency.Name = "uxFrequency";
            this.uxFrequency.ReadOnly = true;
            this.uxFrequency.Size = new System.Drawing.Size(234, 33);
            this.uxFrequency.TabIndex = 6;
            // 
            // uxRank
            // 
            this.uxRank.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxRank.Location = new System.Drawing.Point(78, 246);
            this.uxRank.Multiline = true;
            this.uxRank.Name = "uxRank";
            this.uxRank.ReadOnly = true;
            this.uxRank.Size = new System.Drawing.Size(289, 33);
            this.uxRank.TabIndex = 7;
            // 
            // uxFrequencyLabel
            // 
            this.uxFrequencyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxFrequencyLabel.Location = new System.Drawing.Point(12, 207);
            this.uxFrequencyLabel.Name = "uxFrequencyLabel";
            this.uxFrequencyLabel.Size = new System.Drawing.Size(115, 33);
            this.uxFrequencyLabel.TabIndex = 8;
            this.uxFrequencyLabel.Text = "Frequency:";
            // 
            // uxRankLabel
            // 
            this.uxRankLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxRankLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxRankLabel.Location = new System.Drawing.Point(12, 246);
            this.uxRankLabel.Name = "uxRankLabel";
            this.uxRankLabel.Size = new System.Drawing.Size(60, 33);
            this.uxRankLabel.TabIndex = 9;
            this.uxRankLabel.Text = "Rank:";
            // 
            // uxNameLabel
            // 
            this.uxNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.uxNameLabel.Location = new System.Drawing.Point(12, 116);
            this.uxNameLabel.Name = "uxNameLabel";
            this.uxNameLabel.Size = new System.Drawing.Size(74, 33);
            this.uxNameLabel.TabIndex = 10;
            this.uxNameLabel.Text = "Name:";
            // 
            // uxDegreeLabel
            // 
            this.uxDegreeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxDegreeLabel.Location = new System.Drawing.Point(12, 12);
            this.uxDegreeLabel.Name = "uxDegreeLabel";
            this.uxDegreeLabel.Size = new System.Drawing.Size(101, 20);
            this.uxDegreeLabel.TabIndex = 11;
            this.uxDegreeLabel.Text = "Minimum Degree";
            this.uxDegreeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxItemLabel
            // 
            this.uxItemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxItemLabel.Location = new System.Drawing.Point(12, 38);
            this.uxItemLabel.Name = "uxItemLabel";
            this.uxItemLabel.Size = new System.Drawing.Size(101, 20);
            this.uxItemLabel.TabIndex = 12;
            this.uxItemLabel.Text = "Number of Items";
            this.uxItemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxOpenFile
            // 
            this.uxOpenFile.FileName = "uxOpenFile";
            // 
            // NameLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 291);
            this.Controls.Add(this.uxItemLabel);
            this.Controls.Add(this.uxDegreeLabel);
            this.Controls.Add(this.uxNameLabel);
            this.Controls.Add(this.uxRankLabel);
            this.Controls.Add(this.uxFrequencyLabel);
            this.Controls.Add(this.uxRank);
            this.Controls.Add(this.uxFrequency);
            this.Controls.Add(this.uxGetStatistics);
            this.Controls.Add(this.uxNameBox);
            this.Controls.Add(this.uxOpen);
            this.Controls.Add(this.uxMakeTree);
            this.Controls.Add(this.uxNumberOfItems);
            this.Controls.Add(this.uxMinimumDegree);
            this.Name = "NameLookup";
            this.Text = "B Trees";
            ((System.ComponentModel.ISupportInitialize)(this.uxMinimumDegree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown uxMinimumDegree;
        private System.Windows.Forms.NumericUpDown uxNumberOfItems;
        private System.Windows.Forms.Button uxMakeTree;
        private System.Windows.Forms.Button uxOpen;
        private System.Windows.Forms.TextBox uxNameBox;
        private System.Windows.Forms.Button uxGetStatistics;
        private System.Windows.Forms.TextBox uxFrequency;
        private System.Windows.Forms.TextBox uxRank;
        private System.Windows.Forms.Label uxFrequencyLabel;
        private System.Windows.Forms.Label uxRankLabel;
        private System.Windows.Forms.Label uxNameLabel;
        private System.Windows.Forms.Label uxDegreeLabel;
        private System.Windows.Forms.Label uxItemLabel;
        private System.Windows.Forms.OpenFileDialog uxOpenFile;
    }
}

