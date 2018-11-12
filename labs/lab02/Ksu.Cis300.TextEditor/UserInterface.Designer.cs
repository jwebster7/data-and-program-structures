namespace Ksu.Cis300.TextEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.uxFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.uxOpenButton = new System.Windows.Forms.ToolStripMenuItem();
            this.uxSaveAsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.uxTextEntry = new System.Windows.Forms.TextBox();
            this.uxOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxFileButton,
            this.uxOpenButton,
            this.uxSaveAsButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Name";
            // 
            // uxFileButton
            // 
            this.uxFileButton.Name = "uxFileButton";
            this.uxFileButton.Size = new System.Drawing.Size(37, 20);
            this.uxFileButton.Text = "File";
            // 
            // uxOpenButton
            // 
            this.uxOpenButton.Name = "uxOpenButton";
            this.uxOpenButton.Size = new System.Drawing.Size(48, 20);
            this.uxOpenButton.Text = "Open";
            this.uxOpenButton.Click += new System.EventHandler(this.uxOpenButton_Click);
            // 
            // uxSaveAsButton
            // 
            this.uxSaveAsButton.Name = "uxSaveAsButton";
            this.uxSaveAsButton.Size = new System.Drawing.Size(59, 20);
            this.uxSaveAsButton.Text = "Save As";
            this.uxSaveAsButton.Click += new System.EventHandler(this.uxSaveAsButton_Click);
            // 
            // uxTextEntry
            // 
            this.uxTextEntry.Location = new System.Drawing.Point(12, 27);
            this.uxTextEntry.Multiline = true;
            this.uxTextEntry.Name = "uxTextEntry";
            this.uxTextEntry.Size = new System.Drawing.Size(669, 804);
            this.uxTextEntry.TabIndex = 1;
            // 
            // uxSaveDialog
            // 
            this.uxSaveDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.uxSaveDialog_FileOk);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 843);
            this.Controls.Add(this.uxTextEntry);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserInterface";
            this.Text = "Text Editor";
            this.Load += new System.EventHandler(this.UserInterface_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uxFileButton;
        private System.Windows.Forms.ToolStripMenuItem uxOpenButton;
        private System.Windows.Forms.ToolStripMenuItem uxSaveAsButton;
        private System.Windows.Forms.TextBox uxTextEntry;
        private System.Windows.Forms.OpenFileDialog uxOpenDialog;
        private System.Windows.Forms.SaveFileDialog uxSaveDialog;
    }
}

