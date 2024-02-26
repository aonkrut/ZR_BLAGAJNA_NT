
namespace ZR_BLAGAJNA_NT {
    partial class prijava {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(prijava));
            this.tb_lozinka = new System.Windows.Forms.TextBox();
            this.cb_zaposlenici = new System.Windows.Forms.ComboBox();
            this.bttn_prijava = new System.Windows.Forms.Button();
            this.ikona = new System.Windows.Forms.PictureBox();
            this.naziv_aplikacije = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ikona)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_lozinka
            // 
            this.tb_lozinka.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_lozinka.Location = new System.Drawing.Point(260, 290);
            this.tb_lozinka.Name = "tb_lozinka";
            this.tb_lozinka.PasswordChar = '*';
            this.tb_lozinka.Size = new System.Drawing.Size(296, 34);
            this.tb_lozinka.TabIndex = 0;
            // 
            // cb_zaposlenici
            // 
            this.cb_zaposlenici.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_zaposlenici.FormattingEnabled = true;
            this.cb_zaposlenici.ItemHeight = 25;
            this.cb_zaposlenici.Location = new System.Drawing.Point(260, 240);
            this.cb_zaposlenici.Name = "cb_zaposlenici";
            this.cb_zaposlenici.Size = new System.Drawing.Size(296, 33);
            this.cb_zaposlenici.TabIndex = 1;
            // 
            // bttn_prijava
            // 
            this.bttn_prijava.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bttn_prijava.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttn_prijava.Location = new System.Drawing.Point(260, 345);
            this.bttn_prijava.Name = "bttn_prijava";
            this.bttn_prijava.Size = new System.Drawing.Size(296, 54);
            this.bttn_prijava.TabIndex = 2;
            this.bttn_prijava.Text = "Prijavi se";
            this.bttn_prijava.UseVisualStyleBackColor = false;
            this.bttn_prijava.Click += new System.EventHandler(this.bttn_prijava_Click);
            // 
            // ikona
            // 
            this.ikona.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ikona.Image = ((System.Drawing.Image)(resources.GetObject("ikona.Image")));
            this.ikona.InitialImage = ((System.Drawing.Image)(resources.GetObject("ikona.InitialImage")));
            this.ikona.Location = new System.Drawing.Point(335, 37);
            this.ikona.Name = "ikona";
            this.ikona.Size = new System.Drawing.Size(151, 129);
            this.ikona.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ikona.TabIndex = 3;
            this.ikona.TabStop = false;
            // 
            // naziv_aplikacije
            // 
            this.naziv_aplikacije.AutoSize = true;
            this.naziv_aplikacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.naziv_aplikacije.Location = new System.Drawing.Point(305, 182);
            this.naziv_aplikacije.Name = "naziv_aplikacije";
            this.naziv_aplikacije.Size = new System.Drawing.Size(218, 32);
            this.naziv_aplikacije.TabIndex = 4;
            this.naziv_aplikacije.Text = "ZR BLAGAJNA";
            // 
            // prijava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.naziv_aplikacije);
            this.Controls.Add(this.ikona);
            this.Controls.Add(this.bttn_prijava);
            this.Controls.Add(this.cb_zaposlenici);
            this.Controls.Add(this.tb_lozinka);
            this.Name = "prijava";
            this.Text = "prijava";
            ((System.ComponentModel.ISupportInitialize)(this.ikona)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_lozinka;
        private System.Windows.Forms.ComboBox cb_zaposlenici;
        private System.Windows.Forms.Button bttn_prijava;
        private System.Windows.Forms.PictureBox ikona;
        private System.Windows.Forms.Label naziv_aplikacije;
    }
}