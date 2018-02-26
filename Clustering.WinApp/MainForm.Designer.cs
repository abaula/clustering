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
            ((System.ComponentModel.ISupportInitialize)(this.trbClusterDivider)).BeginInit();
            this.SuspendLayout();
            // 
            // panImage
            // 
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 547);
            this.Controls.Add(this.panImage);
            this.Controls.Add(this.trbClusterDivider);
            this.Controls.Add(this.panMassLegend);
            this.Name = "MainForm";
            this.Text = "Clustering";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trbClusterDivider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panImage;
        private System.Windows.Forms.Panel panMassLegend;
        private System.Windows.Forms.TrackBar trbClusterDivider;
    }
}

