namespace Ksu.Cis300.TravelingSalesperson
{
    partial class UserInterface
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
            this.uxLoadGraph = new System.Windows.Forms.Button();
            this.uxTourLabel = new System.Windows.Forms.Label();
            this.uxTour = new System.Windows.Forms.TextBox();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // uxLoadGraph
            // 
            this.uxLoadGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.75F);
            this.uxLoadGraph.Location = new System.Drawing.Point(12, 12);
            this.uxLoadGraph.Name = "uxLoadGraph";
            this.uxLoadGraph.Size = new System.Drawing.Size(257, 40);
            this.uxLoadGraph.TabIndex = 0;
            this.uxLoadGraph.Text = "Load Graph";
            this.uxLoadGraph.UseVisualStyleBackColor = true;
            this.uxLoadGraph.Click += new System.EventHandler(this.uxLoadGraph_Click);
            // 
            // uxTourLabel
            // 
            this.uxTourLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.75F);
            this.uxTourLabel.Location = new System.Drawing.Point(12, 55);
            this.uxTourLabel.Name = "uxTourLabel";
            this.uxTourLabel.Size = new System.Drawing.Size(68, 23);
            this.uxTourLabel.TabIndex = 1;
            this.uxTourLabel.Text = "Tour:";
            this.uxTourLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uxTourLabel.Click += new System.EventHandler(this.uxTourLabel_Click);
            // 
            // uxTour
            // 
            this.uxTour.AcceptsReturn = true;
            this.uxTour.Location = new System.Drawing.Point(12, 81);
            this.uxTour.Multiline = true;
            this.uxTour.Name = "uxTour";
            this.uxTour.ReadOnly = true;
            this.uxTour.Size = new System.Drawing.Size(257, 168);
            this.uxTour.TabIndex = 2;
            this.uxTour.TextChanged += new System.EventHandler(this.uxTour_TextChanged);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 261);
            this.Controls.Add(this.uxTour);
            this.Controls.Add(this.uxTourLabel);
            this.Controls.Add(this.uxLoadGraph);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(297, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(297, 300);
            this.Name = "UserInterface";
            this.Text = "Traveling Salesperson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxLoadGraph;
        private System.Windows.Forms.Label uxTourLabel;
        private System.Windows.Forms.TextBox uxTour;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.SaveFileDialog uxSaveDialog;
    }
}

