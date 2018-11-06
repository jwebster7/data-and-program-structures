namespace Ksu.Cis300.MapViewer
{
    partial class uxUserInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uxUserInterface));
            this.uxToolStrip = new System.Windows.Forms.ToolStrip();
            this.uxOpenMap = new System.Windows.Forms.ToolStripButton();
            this.uxZoomIn = new System.Windows.Forms.ToolStripButton();
            this.uxZoomOut = new System.Windows.Forms.ToolStripButton();
            this.uxPanel = new System.Windows.Forms.Panel();
            this.uxOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxToolStrip
            // 
            this.uxToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxOpenMap,
            this.uxZoomIn,
            this.uxZoomOut});
            this.uxToolStrip.Location = new System.Drawing.Point(0, 0);
            this.uxToolStrip.Name = "uxToolStrip";
            this.uxToolStrip.Size = new System.Drawing.Size(481, 25);
            this.uxToolStrip.TabIndex = 0;
            this.uxToolStrip.Text = "toolStrip1";
            // 
            // uxOpenMap
            // 
            this.uxOpenMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxOpenMap.Image = ((System.Drawing.Image)(resources.GetObject("uxOpenMap.Image")));
            this.uxOpenMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxOpenMap.Name = "uxOpenMap";
            this.uxOpenMap.Size = new System.Drawing.Size(67, 22);
            this.uxOpenMap.Text = "Open Map";
            this.uxOpenMap.Click += new System.EventHandler(this.uxOpenMap_Click);
            // 
            // uxZoomIn
            // 
            this.uxZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxZoomIn.Enabled = false;
            this.uxZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("uxZoomIn.Image")));
            this.uxZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxZoomIn.Name = "uxZoomIn";
            this.uxZoomIn.Size = new System.Drawing.Size(56, 22);
            this.uxZoomIn.Text = "Zoom In";
            this.uxZoomIn.Click += new System.EventHandler(this.uxZoomIn_Click);
            // 
            // uxZoomOut
            // 
            this.uxZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxZoomOut.Enabled = false;
            this.uxZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("uxZoomOut.Image")));
            this.uxZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxZoomOut.Name = "uxZoomOut";
            this.uxZoomOut.Size = new System.Drawing.Size(66, 22);
            this.uxZoomOut.Text = "Zoom Out";
            this.uxZoomOut.Click += new System.EventHandler(this.uxZoomOut_Click);
            // 
            // uxPanel
            // 
            this.uxPanel.AutoScroll = true;
            this.uxPanel.AutoSize = true;
            this.uxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxPanel.Location = new System.Drawing.Point(0, 25);
            this.uxPanel.Name = "uxPanel";
            this.uxPanel.Size = new System.Drawing.Size(481, 399);
            this.uxPanel.TabIndex = 1;
            // 
            // uxOpenFileDialog
            // 
            this.uxOpenFileDialog.FileName = "openFileDialog1";
            // 
            // uxUserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 424);
            this.Controls.Add(this.uxPanel);
            this.Controls.Add(this.uxToolStrip);
            this.MinimumSize = new System.Drawing.Size(219, 77);
            this.Name = "uxUserInterface";
            this.Text = "Map Viewer";
            this.uxToolStrip.ResumeLayout(false);
            this.uxToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip uxToolStrip;
        private System.Windows.Forms.ToolStripButton uxOpenMap;
        private System.Windows.Forms.ToolStripButton uxZoomIn;
        private System.Windows.Forms.ToolStripButton uxZoomOut;
        private System.Windows.Forms.Panel uxPanel;
        private System.Windows.Forms.OpenFileDialog uxOpenFileDialog;
    }
}

