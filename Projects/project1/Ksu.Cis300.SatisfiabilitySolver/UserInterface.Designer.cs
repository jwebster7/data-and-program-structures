namespace Ksu.Cis300.SatisfiabilitySolver
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
            this.uxReadFormula = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.uxDisplaySolution = new System.Windows.Forms.TextBox();
            this.uxOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // uxReadFormula
            // 
            this.uxReadFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uxReadFormula.Location = new System.Drawing.Point(12, 12);
            this.uxReadFormula.Name = "uxReadFormula";
            this.uxReadFormula.Size = new System.Drawing.Size(303, 40);
            this.uxReadFormula.TabIndex = 0;
            this.uxReadFormula.Text = "Read Formula";
            this.uxReadFormula.UseVisualStyleBackColor = true;
            this.uxReadFormula.Click += new System.EventHandler(this.uxReadFormula_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Solution:";
            // 
            // uxDisplaySolution
            // 
            this.uxDisplaySolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.uxDisplaySolution.Location = new System.Drawing.Point(100, 61);
            this.uxDisplaySolution.Name = "uxDisplaySolution";
            this.uxDisplaySolution.ReadOnly = true;
            this.uxDisplaySolution.Size = new System.Drawing.Size(215, 30);
            this.uxDisplaySolution.TabIndex = 2;
            // 
            // uxOpenFileDialog
            // 
            this.uxOpenFileDialog.Filter = "Text files|*.txt|All files|*.*";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 107);
            this.Controls.Add(this.uxDisplaySolution);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uxReadFormula);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Satisfiable Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxReadFormula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox uxDisplaySolution;
        private System.Windows.Forms.OpenFileDialog uxOpenFileDialog;
    }
}

