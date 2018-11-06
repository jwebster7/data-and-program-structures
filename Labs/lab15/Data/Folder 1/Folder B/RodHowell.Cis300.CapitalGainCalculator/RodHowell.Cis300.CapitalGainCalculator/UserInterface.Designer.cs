namespace RodHowell.Cis300.CapitalGainCalculator
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
            this.uxNumberLabel = new System.Windows.Forms.Label();
            this.uxNumber = new System.Windows.Forms.NumericUpDown();
            this.uxCostLabel = new System.Windows.Forms.Label();
            this.uxCost = new System.Windows.Forms.NumericUpDown();
            this.uxBuy = new System.Windows.Forms.Button();
            this.uxSell = new System.Windows.Forms.Button();
            this.uxOwnedLabel = new System.Windows.Forms.Label();
            this.uxOwned = new System.Windows.Forms.TextBox();
            this.uxGainLabel = new System.Windows.Forms.Label();
            this.uxGain = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxCost)).BeginInit();
            this.SuspendLayout();
            // 
            // uxNumberLabel
            // 
            this.uxNumberLabel.AutoSize = true;
            this.uxNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNumberLabel.Location = new System.Drawing.Point(12, 14);
            this.uxNumberLabel.Name = "uxNumberLabel";
            this.uxNumberLabel.Size = new System.Drawing.Size(280, 24);
            this.uxNumberLabel.TabIndex = 0;
            this.uxNumberLabel.Text = "Number of shares in transaction:";
            // 
            // uxNumber
            // 
            this.uxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxNumber.Location = new System.Drawing.Point(298, 12);
            this.uxNumber.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.uxNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uxNumber.Name = "uxNumber";
            this.uxNumber.Size = new System.Drawing.Size(76, 29);
            this.uxNumber.TabIndex = 1;
            this.uxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // uxCostLabel
            // 
            this.uxCostLabel.AutoSize = true;
            this.uxCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCostLabel.Location = new System.Drawing.Point(12, 51);
            this.uxCostLabel.Name = "uxCostLabel";
            this.uxCostLabel.Size = new System.Drawing.Size(171, 24);
            this.uxCostLabel.TabIndex = 2;
            this.uxCostLabel.Text = "Cost of each share:";
            // 
            // uxCost
            // 
            this.uxCost.DecimalPlaces = 2;
            this.uxCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCost.Location = new System.Drawing.Point(189, 47);
            this.uxCost.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.uxCost.Name = "uxCost";
            this.uxCost.Size = new System.Drawing.Size(185, 29);
            this.uxCost.TabIndex = 3;
            this.uxCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxBuy
            // 
            this.uxBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxBuy.Location = new System.Drawing.Point(16, 82);
            this.uxBuy.Name = "uxBuy";
            this.uxBuy.Size = new System.Drawing.Size(176, 42);
            this.uxBuy.TabIndex = 4;
            this.uxBuy.Text = "Buy";
            this.uxBuy.UseVisualStyleBackColor = true;
            // 
            // uxSell
            // 
            this.uxSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSell.Location = new System.Drawing.Point(198, 82);
            this.uxSell.Name = "uxSell";
            this.uxSell.Size = new System.Drawing.Size(176, 42);
            this.uxSell.TabIndex = 5;
            this.uxSell.Text = "Sell";
            this.uxSell.UseVisualStyleBackColor = true;
            // 
            // uxOwnedLabel
            // 
            this.uxOwnedLabel.AutoSize = true;
            this.uxOwnedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxOwnedLabel.Location = new System.Drawing.Point(12, 133);
            this.uxOwnedLabel.Name = "uxOwnedLabel";
            this.uxOwnedLabel.Size = new System.Drawing.Size(228, 24);
            this.uxOwnedLabel.TabIndex = 6;
            this.uxOwnedLabel.Text = "Number of shares owned:";
            // 
            // uxOwned
            // 
            this.uxOwned.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxOwned.Location = new System.Drawing.Point(246, 130);
            this.uxOwned.Name = "uxOwned";
            this.uxOwned.ReadOnly = true;
            this.uxOwned.Size = new System.Drawing.Size(128, 29);
            this.uxOwned.TabIndex = 7;
            this.uxOwned.Text = "0";
            this.uxOwned.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxGainLabel
            // 
            this.uxGainLabel.AutoSize = true;
            this.uxGainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxGainLabel.Location = new System.Drawing.Point(12, 168);
            this.uxGainLabel.Name = "uxGainLabel";
            this.uxGainLabel.Size = new System.Drawing.Size(143, 24);
            this.uxGainLabel.TabIndex = 8;
            this.uxGainLabel.Text = "Net capital gain:";
            // 
            // uxGain
            // 
            this.uxGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxGain.Location = new System.Drawing.Point(161, 165);
            this.uxGain.Name = "uxGain";
            this.uxGain.ReadOnly = true;
            this.uxGain.Size = new System.Drawing.Size(213, 29);
            this.uxGain.TabIndex = 9;
            this.uxGain.Text = "0.00";
            this.uxGain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 208);
            this.Controls.Add(this.uxGain);
            this.Controls.Add(this.uxGainLabel);
            this.Controls.Add(this.uxOwned);
            this.Controls.Add(this.uxOwnedLabel);
            this.Controls.Add(this.uxSell);
            this.Controls.Add(this.uxBuy);
            this.Controls.Add(this.uxCost);
            this.Controls.Add(this.uxCostLabel);
            this.Controls.Add(this.uxNumber);
            this.Controls.Add(this.uxNumberLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Capital Gain Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.uxNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label uxNumberLabel;
        private System.Windows.Forms.NumericUpDown uxNumber;
        private System.Windows.Forms.Label uxCostLabel;
        private System.Windows.Forms.NumericUpDown uxCost;
        private System.Windows.Forms.Button uxBuy;
        private System.Windows.Forms.Button uxSell;
        private System.Windows.Forms.Label uxOwnedLabel;
        private System.Windows.Forms.TextBox uxOwned;
        private System.Windows.Forms.Label uxGainLabel;
        private System.Windows.Forms.TextBox uxGain;
    }
}

