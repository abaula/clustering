using System.Windows.Forms;

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
            this.trbClusterDivider = new System.Windows.Forms.TrackBar();
            this.panTop = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trbClusterDivider)).BeginInit();
            this.panTop.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panImage
            // 
            this.panImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panImage.Location = new System.Drawing.Point(0, 26);
            this.panImage.Name = "panImage";
            this.panImage.Size = new System.Drawing.Size(966, 476);
            this.panImage.TabIndex = 0;
            this.panImage.Paint += new System.Windows.Forms.PaintEventHandler(this.panImage_Paint);
            // 
            // trbClusterDivider
            // 
            this.trbClusterDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trbClusterDivider.Location = new System.Drawing.Point(0, 502);
            this.trbClusterDivider.Maximum = 2000;
            this.trbClusterDivider.Name = "trbClusterDivider";
            this.trbClusterDivider.Size = new System.Drawing.Size(966, 45);
            this.trbClusterDivider.TabIndex = 2;
            this.trbClusterDivider.Scroll += new System.EventHandler(this.trbClusterDivider_Scroll);
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.menuStrip1);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(966, 26);
            this.panTop.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.splitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 24);
            this.menuStrip1.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // splitToolStripMenuItem
            // 
            this.splitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem});
            this.splitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.splitToolStripMenuItem.Name = "splitToolStripMenuItem";
            this.splitToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.splitToolStripMenuItem.Text = "Split";
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.autoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autoToolStripMenuItem.Text = "Auto";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(966, 547);
            this.Controls.Add(this.panImage);
            this.Controls.Add(this.trbClusterDivider);
            this.Controls.Add(this.panTop);
            this.Name = "MainForm";
            this.Text = "Clustering";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trbClusterDivider)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panImage;
        private System.Windows.Forms.TrackBar trbClusterDivider;
        private Panel panTop;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem splitToolStripMenuItem;
        private ToolStripMenuItem autoToolStripMenuItem;
    }
}

