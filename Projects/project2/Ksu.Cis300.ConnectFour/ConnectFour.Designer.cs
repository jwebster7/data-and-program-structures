namespace Ksu.Cis300.ConnectFour
{
    partial class ConnectFour
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.uxTurnLabel = new System.Windows.Forms.Label();
            this.uxPlayerTurn = new System.Windows.Forms.Label();
            this.uxPlaceButtonC = new System.Windows.Forms.FlowLayoutPanel();
            this.uxBoardContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.uxTurnLabel);
            this.flowLayoutPanel1.Controls.Add(this.uxPlayerTurn);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(414, 28);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // uxTurnLabel
            // 
            this.uxTurnLabel.BackColor = System.Drawing.Color.White;
            this.uxTurnLabel.Location = new System.Drawing.Point(354, 0);
            this.uxTurnLabel.Name = "uxTurnLabel";
            this.uxTurnLabel.Size = new System.Drawing.Size(57, 23);
            this.uxTurnLabel.TabIndex = 1;
            this.uxTurnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxPlayerTurn
            // 
            this.uxPlayerTurn.Location = new System.Drawing.Point(261, 0);
            this.uxPlayerTurn.Name = "uxPlayerTurn";
            this.uxPlayerTurn.Size = new System.Drawing.Size(87, 23);
            this.uxPlayerTurn.TabIndex = 0;
            this.uxPlayerTurn.Text = "Player\'s Turn:";
            this.uxPlayerTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxPlaceButtonC
            // 
            this.uxPlaceButtonC.Location = new System.Drawing.Point(0, 32);
            this.uxPlaceButtonC.Name = "uxPlaceButtonC";
            this.uxPlaceButtonC.Size = new System.Drawing.Size(414, 28);
            this.uxPlaceButtonC.TabIndex = 1;
            // 
            // uxBoardContainer
            // 
            this.uxBoardContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uxBoardContainer.Location = new System.Drawing.Point(0, 66);
            this.uxBoardContainer.Name = "uxBoardContainer";
            this.uxBoardContainer.Size = new System.Drawing.Size(414, 336);
            this.uxBoardContainer.TabIndex = 0;
            // 
            // ConnectFour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 401);
            this.Controls.Add(this.uxBoardContainer);
            this.Controls.Add(this.uxPlaceButtonC);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(430, 440);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(430, 440);
            this.Name = "ConnectFour";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Connect Four ";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel uxPlaceButtonC;
        private System.Windows.Forms.FlowLayoutPanel uxBoardContainer;
        private System.Windows.Forms.Label uxPlayerTurn;
        private System.Windows.Forms.Label uxTurnLabel;
    }
}

