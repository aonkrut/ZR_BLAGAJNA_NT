
namespace ZR_BLAGAJNA_NT {
    partial class proizvodi {
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
            this.cb_proizvodi_id = new System.Windows.Forms.ComboBox();
            this.bttn_obrisi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_kol_na_skl = new System.Windows.Forms.TextBox();
            this.tb_cijena = new System.Windows.Forms.TextBox();
            this.tb_naziv = new System.Windows.Forms.TextBox();
            this.tb_barcode = new System.Windows.Forms.TextBox();
            this.bttn_spremi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_min_kol = new System.Windows.Forms.TextBox();
            this.cb_dobavljaci_id = new System.Windows.Forms.ComboBox();
            this.bttn_dodaj = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // izbornik1
            // 
            this.izbornik1.Location = new System.Drawing.Point(-1, 1);
            this.izbornik1.Name = "izbornik1";
            this.izbornik1.Size = new System.Drawing.Size(802, 34);
            this.izbornik1.TabIndex = 0;
            // 
            // cb_proizvodi_id
            // 
            this.cb_proizvodi_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_proizvodi_id.FormattingEnabled = true;
            this.cb_proizvodi_id.ItemHeight = 16;
            this.cb_proizvodi_id.Location = new System.Drawing.Point(120, 75);
            this.cb_proizvodi_id.Name = "cb_proizvodi_id";
            this.cb_proizvodi_id.Size = new System.Drawing.Size(95, 24);
            this.cb_proizvodi_id.TabIndex = 31;
            this.cb_proizvodi_id.SelectedIndexChanged += new System.EventHandler(this.cb_proizvodi_id_SelectedIndexChanged);
            // 
            // bttn_obrisi
            // 
            this.bttn_obrisi.Location = new System.Drawing.Point(25, 338);
            this.bttn_obrisi.Name = "bttn_obrisi";
            this.bttn_obrisi.Size = new System.Drawing.Size(75, 30);
            this.bttn_obrisi.TabIndex = 30;
            this.bttn_obrisi.Text = "Obriši";
            this.bttn_obrisi.UseVisualStyleBackColor = true;
            this.bttn_obrisi.Click += new System.EventHandler(this.bttn_obrisi_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Kol. na skladištu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Cijena ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Barcode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Proizvod ID:";
            // 
            // tb_kol_na_skl
            // 
            this.tb_kol_na_skl.Location = new System.Drawing.Point(253, 126);
            this.tb_kol_na_skl.Name = "tb_kol_na_skl";
            this.tb_kol_na_skl.Size = new System.Drawing.Size(120, 22);
            this.tb_kol_na_skl.TabIndex = 23;
            // 
            // tb_cijena
            // 
            this.tb_cijena.Location = new System.Drawing.Point(25, 247);
            this.tb_cijena.Name = "tb_cijena";
            this.tb_cijena.Size = new System.Drawing.Size(190, 22);
            this.tb_cijena.TabIndex = 22;
            // 
            // tb_naziv
            // 
            this.tb_naziv.Location = new System.Drawing.Point(25, 183);
            this.tb_naziv.Name = "tb_naziv";
            this.tb_naziv.Size = new System.Drawing.Size(190, 22);
            this.tb_naziv.TabIndex = 21;
            // 
            // tb_barcode
            // 
            this.tb_barcode.Location = new System.Drawing.Point(25, 126);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.Size = new System.Drawing.Size(190, 22);
            this.tb_barcode.TabIndex = 20;
            // 
            // bttn_spremi
            // 
            this.bttn_spremi.Location = new System.Drawing.Point(25, 293);
            this.bttn_spremi.Name = "bttn_spremi";
            this.bttn_spremi.Size = new System.Drawing.Size(435, 30);
            this.bttn_spremi.TabIndex = 19;
            this.bttn_spremi.Text = "Spremi";
            this.bttn_spremi.UseVisualStyleBackColor = true;
            this.bttn_spremi.Click += new System.EventHandler(this.bttn_spremi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(349, 32);
            this.label6.TabIndex = 32;
            this.label6.Text = "Administracija proizvoda";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 33;
            this.label7.Text = "Min. količina";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(250, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 34;
            this.label8.Text = "Dobavljač ID:";
            // 
            // tb_min_kol
            // 
            this.tb_min_kol.Location = new System.Drawing.Point(253, 183);
            this.tb_min_kol.Name = "tb_min_kol";
            this.tb_min_kol.Size = new System.Drawing.Size(207, 22);
            this.tb_min_kol.TabIndex = 36;
            // 
            // cb_dobavljaci_id
            // 
            this.cb_dobavljaci_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_dobavljaci_id.FormattingEnabled = true;
            this.cb_dobavljaci_id.ItemHeight = 16;
            this.cb_dobavljaci_id.Location = new System.Drawing.Point(352, 213);
            this.cb_dobavljaci_id.Name = "cb_dobavljaci_id";
            this.cb_dobavljaci_id.Size = new System.Drawing.Size(108, 24);
            this.cb_dobavljaci_id.TabIndex = 38;
            // 
            // bttn_dodaj
            // 
            this.bttn_dodaj.Location = new System.Drawing.Point(379, 126);
            this.bttn_dodaj.Name = "bttn_dodaj";
            this.bttn_dodaj.Size = new System.Drawing.Size(42, 23);
            this.bttn_dodaj.TabIndex = 39;
            this.bttn_dodaj.Text = "+1";
            this.bttn_dodaj.UseVisualStyleBackColor = true;
            this.bttn_dodaj.Click += new System.EventHandler(this.bttn_dodaj_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(427, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 23);
            this.button2.TabIndex = 40;
            this.button2.Text = "-1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.bttn_smanji_Click);
            // 
            // proizvodi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bttn_dodaj);
            this.Controls.Add(this.cb_dobavljaci_id);
            this.Controls.Add(this.tb_min_kol);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cb_proizvodi_id);
            this.Controls.Add(this.bttn_obrisi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_kol_na_skl);
            this.Controls.Add(this.tb_cijena);
            this.Controls.Add(this.tb_naziv);
            this.Controls.Add(this.tb_barcode);
            this.Controls.Add(this.bttn_spremi);
            this.Controls.Add(this.izbornik1);
            this.Name = "proizvodi";
            this.Text = "proizvodi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private izbornik izbornik1;
        private System.Windows.Forms.ComboBox cb_proizvodi_id;
        private System.Windows.Forms.Button bttn_obrisi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_kol_na_skl;
        private System.Windows.Forms.TextBox tb_cijena;
        private System.Windows.Forms.TextBox tb_naziv;
        private System.Windows.Forms.TextBox tb_barcode;
        private System.Windows.Forms.Button bttn_spremi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_min_kol;
        private System.Windows.Forms.ComboBox cb_dobavljaci_id;
        private System.Windows.Forms.Button bttn_dodaj;
        private System.Windows.Forms.Button button2;
    }
}