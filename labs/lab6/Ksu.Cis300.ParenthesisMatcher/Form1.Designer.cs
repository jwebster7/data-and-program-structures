namespace Ksu.Cis300.ParenthesisMatcher
{
    partial class uxMatcher
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
            this.uxLabel = new System.Windows.Forms.Label();
            this.uxTextBox = new System.Windows.Forms.TextBox();
            this.uxCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxLabel
            // 
            this.uxLabel.AutoSize = true;
            this.uxLabel.Location = new System.Drawing.Point(12, 47);
            this.uxLabel.Name = "uxLabel";
            this.uxLabel.Size = new System.Drawing.Size(65, 13);
            this.uxLabel.TabIndex = 0;
            this.uxLabel.Text = "Enter String:";
            // 
            // uxTextBox
            // 
            this.uxTextBox.Location = new System.Drawing.Point(83, 44);
            this.uxTextBox.Name = "uxTextBox";
            this.uxTextBox.Size = new System.Drawing.Size(190, 20);
            this.uxTextBox.TabIndex = 1;
            // 
            // uxCheck
            // 
            this.uxCheck.Location = new System.Drawing.Point(83, 79);
            this.uxCheck.Name = "uxCheck";
            this.uxCheck.Size = new System.Drawing.Size(75, 23);
            this.uxCheck.TabIndex = 2;
            this.uxCheck.Text = "Check";
            this.uxCheck.UseVisualStyleBackColor = true;
            // 
            // uxMatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 137);
            this.Controls.Add(this.uxCheck);
            this.Controls.Add(this.uxTextBox);
            this.Controls.Add(this.uxLabel);
            this.Name = "uxMatcher";
            this.Text = "Parenthesis Matcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxLabel;
        private System.Windows.Forms.TextBox uxTextBox;
        private System.Windows.Forms.Button uxCheck;
    }
}

