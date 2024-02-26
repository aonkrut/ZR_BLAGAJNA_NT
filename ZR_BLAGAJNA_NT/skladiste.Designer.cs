
namespace ZR_BLAGAJNA_NT {
    partial class skladiste {
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
            this.izbornik1 = new ZR_BLAGAJNA_NT.izbornik();
            this.SuspendLayout();
            // 
            // izbornik1
            // 
            this.izbornik1.Location = new System.Drawing.Point(0, 0);
            this.izbornik1.Name = "izbornik1";
            this.izbornik1.Size = new System.Drawing.Size(801, 34);
            this.izbornik1.TabIndex = 0;
            // 
            // skladiste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.izbornik1);
            this.Name = "skladiste";
            this.Text = "skladiste";
            this.ResumeLayout(false);

        }

        #endregion

        private izbornik izbornik1;
    }
}