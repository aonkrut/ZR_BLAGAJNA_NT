
namespace ZR_BLAGAJNA_NT {
    partial class izbornik {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bLAGAJNAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDMINISTRACIJAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaposleniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dobavljačiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proizvodiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.računiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bLAGAJNAToolStripMenuItem,
            this.aDMINISTRACIJAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(429, 28);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bLAGAJNAToolStripMenuItem
            // 
            this.bLAGAJNAToolStripMenuItem.Name = "bLAGAJNAToolStripMenuItem";
            this.bLAGAJNAToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.bLAGAJNAToolStripMenuItem.Text = "BLAGAJNA";
            this.bLAGAJNAToolStripMenuItem.Click += new System.EventHandler(this.bLAGAJNAToolStripMenuItem_Click);
            // 
            // aDMINISTRACIJAToolStripMenuItem
            // 
            this.aDMINISTRACIJAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zaposleniciToolStripMenuItem,
            this.dobavljačiToolStripMenuItem,
            this.proizvodiToolStripMenuItem,
            this.računiToolStripMenuItem});
            this.aDMINISTRACIJAToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aDMINISTRACIJAToolStripMenuItem.Name = "aDMINISTRACIJAToolStripMenuItem";
            this.aDMINISTRACIJAToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.aDMINISTRACIJAToolStripMenuItem.Text = "ADMINISTRACIJA";
            this.aDMINISTRACIJAToolStripMenuItem.Click += new System.EventHandler(this.aDMINISTRACIJAToolStripMenuItem_Click);
            // 
            // zaposleniciToolStripMenuItem
            // 
            this.zaposleniciToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.zaposleniciToolStripMenuItem.Name = "zaposleniciToolStripMenuItem";
            this.zaposleniciToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.zaposleniciToolStripMenuItem.Text = "Zaposlenici";
            this.zaposleniciToolStripMenuItem.Click += new System.EventHandler(this.zaposleniciToolStripMenuItem_Click);
            // 
            // dobavljačiToolStripMenuItem
            // 
            this.dobavljačiToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dobavljačiToolStripMenuItem.Name = "dobavljačiToolStripMenuItem";
            this.dobavljačiToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.dobavljačiToolStripMenuItem.Text = "Dobavljači";
            this.dobavljačiToolStripMenuItem.Click += new System.EventHandler(this.dobavljačiToolStripMenuItem_Click);
            // 
            // proizvodiToolStripMenuItem
            // 
            this.proizvodiToolStripMenuItem.Name = "proizvodiToolStripMenuItem";
            this.proizvodiToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.proizvodiToolStripMenuItem.Text = "Proizvodi";
            this.proizvodiToolStripMenuItem.Click += new System.EventHandler(this.proizvodiToolStripMenuItem_Click);
            // 
            // računiToolStripMenuItem
            // 
            this.računiToolStripMenuItem.Name = "računiToolStripMenuItem";
            this.računiToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.računiToolStripMenuItem.Text = "Računi";
            this.računiToolStripMenuItem.Click += new System.EventHandler(this.računiToolStripMenuItem_Click);
            // 
            // izbornik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.Name = "izbornik";
            this.Size = new System.Drawing.Size(429, 34);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bLAGAJNAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aDMINISTRACIJAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zaposleniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dobavljačiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proizvodiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem računiToolStripMenuItem;
    }
}
