
namespace ZR_BLAGAJNA_NT {
    partial class blagajna {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(blagajna));
            this.ocisti = new System.Windows.Forms.Button();
            this.bttn_dodajstavku = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.l_iznos_racuna = new System.Windows.Forms.Label();
            this.izdaj_racun = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listView_popis_proizvoda = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Naziv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Barcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_proizvodi_id = new System.Windows.Forms.ComboBox();
            this.tb_barcode = new System.Windows.Forms.TextBox();
            this.tb_naziv = new System.Windows.Forms.TextBox();
            this.tb_kol = new System.Windows.Forms.TextBox();
            this.listView_stavke = new System.Windows.Forms.ListView();
            this.prijavljenzaposlenik = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.izbornik2 = new ZR_BLAGAJNA_NT.izbornik();
            this.izbornik1 = new ZR_BLAGAJNA_NT.izbornik();
            this.l_racun_id = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.l_cijena = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ocisti
            // 
            this.ocisti.Location = new System.Drawing.Point(15, 387);
            this.ocisti.Name = "ocisti";
            this.ocisti.Size = new System.Drawing.Size(80, 40);
            this.ocisti.TabIndex = 35;
            this.ocisti.Text = "Očisti sve";
            this.ocisti.UseVisualStyleBackColor = true;
            this.ocisti.Click += new System.EventHandler(this.ocisti_Click);
            // 
            // bttn_dodajstavku
            // 
            this.bttn_dodajstavku.Location = new System.Drawing.Point(180, 82);
            this.bttn_dodajstavku.Name = "bttn_dodajstavku";
            this.bttn_dodajstavku.Size = new System.Drawing.Size(307, 23);
            this.bttn_dodajstavku.TabIndex = 33;
            this.bttn_dodajstavku.Text = "DODAJ";
            this.bttn_dodajstavku.UseVisualStyleBackColor = true;
            this.bttn_dodajstavku.Click += new System.EventHandler(this.bttn_dodajstavku_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(316, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Kol";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(176, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Naziv proizvoda";
            // 
            // l_iznos_racuna
            // 
            this.l_iznos_racuna.AutoSize = true;
            this.l_iznos_racuna.BackColor = System.Drawing.SystemColors.ControlLight;
            this.l_iznos_racuna.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_iznos_racuna.ForeColor = System.Drawing.SystemColors.WindowText;
            this.l_iznos_racuna.Location = new System.Drawing.Point(24, 327);
            this.l_iznos_racuna.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_iznos_racuna.Name = "l_iznos_racuna";
            this.l_iznos_racuna.Size = new System.Drawing.Size(42, 44);
            this.l_iznos_racuna.TabIndex = 25;
            this.l_iznos_racuna.Text = "0";
            this.l_iznos_racuna.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // izdaj_racun
            // 
            this.izdaj_racun.Location = new System.Drawing.Point(100, 387);
            this.izdaj_racun.Margin = new System.Windows.Forms.Padding(4);
            this.izdaj_racun.Name = "izdaj_racun";
            this.izdaj_racun.Size = new System.Drawing.Size(387, 40);
            this.izdaj_racun.TabIndex = 24;
            this.izdaj_racun.Text = "IZDAJ RAČUN";
            this.izdaj_racun.UseVisualStyleBackColor = true;
            this.izdaj_racun.Click += new System.EventHandler(this.izdaj_racun_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "Barcode";
            // 
            // listView_popis_proizvoda
            // 
            this.listView_popis_proizvoda.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Naziv,
            this.Barcode});
            this.listView_popis_proizvoda.HideSelection = false;
            this.listView_popis_proizvoda.Location = new System.Drawing.Point(507, 37);
            this.listView_popis_proizvoda.Name = "listView_popis_proizvoda";
            this.listView_popis_proizvoda.Size = new System.Drawing.Size(281, 400);
            this.listView_popis_proizvoda.TabIndex = 37;
            this.listView_popis_proizvoda.UseCompatibleStateImageBehavior = false;
            this.listView_popis_proizvoda.SelectedIndexChanged += new System.EventHandler(this.listView_popis_proizvoda_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = " ";
            this.ID.Width = 30;
            // 
            // Naziv
            // 
            this.Naziv.Text = " ";
            this.Naziv.Width = 80;
            // 
            // Barcode
            // 
            this.Barcode.Text = " ";
            this.Barcode.Width = 90;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 17);
            this.label4.TabIndex = 38;
            this.label4.Text = "Id";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(12, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 19);
            this.label6.TabIndex = 40;
            this.label6.Text = "Broj računa:";
            // 
            // cb_proizvodi_id
            // 
            this.cb_proizvodi_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_proizvodi_id.FormattingEnabled = true;
            this.cb_proizvodi_id.ItemHeight = 16;
            this.cb_proizvodi_id.Location = new System.Drawing.Point(12, 54);
            this.cb_proizvodi_id.Name = "cb_proizvodi_id";
            this.cb_proizvodi_id.Size = new System.Drawing.Size(45, 24);
            this.cb_proizvodi_id.TabIndex = 42;
            this.cb_proizvodi_id.SelectedIndexChanged += new System.EventHandler(this.cb_proizvodi_id_SelectedIndexChanged);
            // 
            // tb_barcode
            // 
            this.tb_barcode.Location = new System.Drawing.Point(63, 55);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.Size = new System.Drawing.Size(111, 22);
            this.tb_barcode.TabIndex = 43;
            // 
            // tb_naziv
            // 
            this.tb_naziv.Location = new System.Drawing.Point(180, 56);
            this.tb_naziv.Name = "tb_naziv";
            this.tb_naziv.Size = new System.Drawing.Size(134, 22);
            this.tb_naziv.TabIndex = 44;
            // 
            // tb_kol
            // 
            this.tb_kol.Location = new System.Drawing.Point(320, 55);
            this.tb_kol.Name = "tb_kol";
            this.tb_kol.Size = new System.Drawing.Size(38, 22);
            this.tb_kol.TabIndex = 31;
            this.tb_kol.Text = "1";
            // 
            // listView_stavke
            // 
            this.listView_stavke.HideSelection = false;
            this.listView_stavke.Location = new System.Drawing.Point(15, 111);
            this.listView_stavke.Name = "listView_stavke";
            this.listView_stavke.Size = new System.Drawing.Size(472, 269);
            this.listView_stavke.TabIndex = 45;
            this.listView_stavke.UseCompatibleStateImageBehavior = false;
            // 
            // prijavljenzaposlenik
            // 
            this.prijavljenzaposlenik.AutoSize = true;
            this.prijavljenzaposlenik.Location = new System.Drawing.Point(97, 429);
            this.prijavljenzaposlenik.Name = "prijavljenzaposlenik";
            this.prijavljenzaposlenik.Size = new System.Drawing.Size(77, 17);
            this.prijavljenzaposlenik.TabIndex = 47;
            this.prijavljenzaposlenik.Text = "Zaposlenik";
            this.prijavljenzaposlenik.Click += new System.EventHandler(this.prijavljenzaposlenik_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 429);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 48;
            this.label7.Text = "Prijavljen/a:";
            // 
            // izbornik2
            // 
            this.izbornik2.Location = new System.Drawing.Point(1, -5);
            this.izbornik2.Name = "izbornik2";
            this.izbornik2.Size = new System.Drawing.Size(802, 34);
            this.izbornik2.TabIndex = 41;
            // 
            // izbornik1
            // 
            this.izbornik1.Location = new System.Drawing.Point(-3, -3);
            this.izbornik1.Name = "izbornik1";
            this.izbornik1.Size = new System.Drawing.Size(810, 34);
            this.izbornik1.TabIndex = 41;
            // 
            // l_racun_id
            // 
            this.l_racun_id.AutoSize = true;
            this.l_racun_id.Location = new System.Drawing.Point(106, 88);
            this.l_racun_id.Name = "l_racun_id";
            this.l_racun_id.Size = new System.Drawing.Size(16, 17);
            this.l_racun_id.TabIndex = 49;
            this.l_racun_id.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(360, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 20);
            this.label8.TabIndex = 51;
            this.label8.Text = "Cijena po jedinici";
            // 
            // l_cijena
            // 
            this.l_cijena.AutoSize = true;
            this.l_cijena.Location = new System.Drawing.Point(365, 59);
            this.l_cijena.Name = "l_cijena";
            this.l_cijena.Size = new System.Drawing.Size(16, 17);
            this.l_cijena.TabIndex = 52;
            this.l_cijena.Text = "0";
            // 
            // blagajna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.l_cijena);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.l_racun_id);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.prijavljenzaposlenik);
            this.Controls.Add(this.tb_naziv);
            this.Controls.Add(this.tb_barcode);
            this.Controls.Add(this.cb_proizvodi_id);
            this.Controls.Add(this.izbornik2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listView_popis_proizvoda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ocisti);
            this.Controls.Add(this.bttn_dodajstavku);
            this.Controls.Add(this.tb_kol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.l_iznos_racuna);
            this.Controls.Add(this.izdaj_racun);
            this.Controls.Add(this.listView_stavke);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "blagajna";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ocisti;
        private System.Windows.Forms.Button bttn_dodajstavku;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label l_iznos_racuna;
        private System.Windows.Forms.Button izdaj_racun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView_popis_proizvoda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private izbornik izbornik1;
        private izbornik izbornik2;
        private System.Windows.Forms.ComboBox cb_proizvodi_id;
        private System.Windows.Forms.TextBox tb_barcode;
        private System.Windows.Forms.TextBox tb_naziv;
        private System.Windows.Forms.TextBox tb_kol;
        private System.Windows.Forms.ListView listView_stavke;
        private System.Windows.Forms.Label prijavljenzaposlenik;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Naziv;
        private System.Windows.Forms.ColumnHeader Barcode;
        private System.Windows.Forms.Label l_racun_id;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label l_cijena;
    }
}

