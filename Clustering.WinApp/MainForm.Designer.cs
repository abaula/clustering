namespace Clustering.WinApp
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
            this.panImage = new System.Windows.Forms.Panel();
            this.panMassLegend = new System.Windows.Forms.Panel();
            this.trbClusterDivider = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbClusterDivider)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panImage
            // 
            this.panImage.Controls.Add(this.menuStrip1);
            this.panImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panImage.Location = new System.Drawing.Point(58, 0);
            this.panImage.Name = "panImage";
            this.panImage.Size = new System.Drawing.Size(908, 502);
            this.panImage.TabIndex = 0;
            this.panImage.Paint += new System.Windows.Forms.PaintEventHandler(this.panImage_Paint);
            // 
            // panMassLegend
            // 
            this.panMassLegend.Dock = System.Windows.Forms.DockStyle.Left;
            this.panMassLegend.Location = new System.Drawing.Point(0, 0);
            this.panMassLegend.Name = "panMassLegend";
            this.panMassLegend.Size = new System.Drawing.Size(58, 547);
            this.panMassLegend.TabIndex = 1;
            this.panMassLegend.Paint += new System.Windows.Forms.PaintEventHandler(this.panMassLegend_Paint);
            this.panMassLegend.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panMassLegend_MouseClick);
            // 
            // trbClusterDivider
            // 
            this.trbClusterDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trbClusterDivider.Location = new System.Drawing.Point(58, 502);
            this.trbClusterDivider.Name = "trbClusterDivider";
            this.trbClusterDivider.Size = new System.Drawing.Size(908, 45);
            this.trbClusterDivider.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(908, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 547);
            this.Controls.Add(this.panImage);
            this.Controls.Add(this.trbClusterDivider);
            this.Controls.Add(this.panMassLegend);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Clustering";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panImage.ResumeLayout(false);
            this.panImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbClusterDivider)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panImage;
        private System.Windows.Forms.Panel panMassLegend;
        private System.Windows.Forms.TrackBar trbClusterDivider;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    }
}

