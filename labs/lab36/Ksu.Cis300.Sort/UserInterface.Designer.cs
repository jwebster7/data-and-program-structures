namespace Ksu.Cis300.Sort
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
            this.uxSortFile = new System.Windows.Forms.Button();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // uxSortFile
            // 
            this.uxSortFile.Location = new System.Drawing.Point(12, 12);
            this.uxSortFile.Name = "uxSortFile";
            this.uxSortFile.Size = new System.Drawing.Size(168, 23);
            this.uxSortFile.TabIndex = 0;
            this.uxSortFile.Text = "Sort File";
            this.uxSortFile.UseVisualStyleBackColor = true;
            this.uxSortFile.Click += new System.EventHandler(this.uxSortFile_Click);
            // 
            // SelectionSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(192, 45);
            this.Controls.Add(this.uxSortFile);
            this.Name = "SelectionSort";
            this.Text = "Selection Sort";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxSortFile;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.SaveFileDialog uxSaveDialog;
    }
}

