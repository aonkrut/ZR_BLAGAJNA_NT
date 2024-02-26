
namespace ZR_BLAGAJNA_NT {
    partial class zaposlenici {
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
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            this.bttn_spremi = new System.Windows.Forms.Button();
            this.tb_ime = new System.Windows.Forms.TextBox();
            this.tb_prezime = new System.Windows.Forms.TextBox();
            this.tb_kime = new System.Windows.Forms.TextBox();
            this.tb_lozinka = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkedListBoxPrava = new System.Windows.Forms.CheckedListBox();
            this.bttn_obrisi = new System.Windows.Forms.Button();
            this.cb_zaposlenici_id = new System.Windows.Forms.ComboBox();
            this.listView_zaposlenici = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prezime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.korisnicko_ime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.izbornik1 = new ZR_BLAGAJNA_NT.izbornik();
            this.SuspendLayout();
            // 
            // bttn_spremi
            // 
            this.bttn_spremi.Location = new System.Drawing.Point(25, 350);
            this.bttn_spremi.Name = "bttn_spremi";
            this.bttn_spremi.Size = new System.Drawing.Size(402, 30);
            this.bttn_spremi.TabIndex = 3;
            this.bttn_spremi.Text = "Spremi";
            this.bttn_spremi.UseVisualStyleBackColor = true;
            this.bttn_spremi.Click += new System.EventHandler(this.bttn_spremi_Click);
            // 
            // tb_ime
            // 
            this.tb_ime.Location = new System.Drawing.Point(25, 130);
            this.tb_ime.Name = "tb_ime";
            this.tb_ime.Size = new System.Drawing.Size(190, 22);
            this.tb_ime.TabIndex = 4;
            // 
            // tb_prezime
            // 
            this.tb_prezime.Location = new System.Drawing.Point(25, 187);
            this.tb_prezime.Name = "tb_prezime";
            this.tb_prezime.Size = new System.Drawing.Size(190, 22);
            this.tb_prezime.TabIndex = 5;
            // 
            // tb_kime
            // 
            this.tb_kime.Location = new System.Drawing.Point(25, 251);
            this.tb_kime.Name = "tb_kime";
            this.tb_kime.Size = new System.Drawing.Size(190, 22);
            this.tb_kime.TabIndex = 6;
            // 
            // tb_lozinka
            // 
            this.tb_lozinka.Location = new System.Drawing.Point(25, 313);
            this.tb_lozinka.Name = "tb_lozinka";
            this.tb_lozinka.PasswordChar = '*';
            this.tb_lozinka.Size = new System.Drawing.Size(190, 22);
            this.tb_lozinka.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Zaposlenik ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Prezime";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Korisničko ime";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Lozinka";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(379, 32);
            this.label6.TabIndex = 14;
            this.label6.Text = "Administracija zaposlenika";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(235, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Prava";
            // 
            // checkedListBoxPrava
            // 
            this.checkedListBoxPrava.FormattingEnabled = true;
            this.checkedListBoxPrava.Location = new System.Drawing.Point(238, 110);
            this.checkedListBoxPrava.Name = "checkedListBoxPrava";
            this.checkedListBoxPrava.Size = new System.Drawing.Size(189, 225);
            this.checkedListBoxPrava.TabIndex = 16;
            // 
            // bttn_obrisi
            // 
            this.bttn_obrisi.Location = new System.Drawing.Point(25, 386);
            this.bttn_obrisi.Name = "bttn_obrisi";
            this.bttn_obrisi.Size = new System.Drawing.Size(75, 30);
            this.bttn_obrisi.TabIndex = 17;
            this.bttn_obrisi.Text = "Obriši";
            this.bttn_obrisi.UseVisualStyleBackColor = true;
            this.bttn_obrisi.Click += new System.EventHandler(this.bttn_obrisi_Click);
            // 
            // cb_zaposlenici_id
            // 
            this.cb_zaposlenici_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_zaposlenici_id.FormattingEnabled = true;
            this.cb_zaposlenici_id.ItemHeight = 16;
            this.cb_zaposlenici_id.Location = new System.Drawing.Point(120, 79);
            this.cb_zaposlenici_id.Name = "cb_zaposlenici_id";
            this.cb_zaposlenici_id.Size = new System.Drawing.Size(95, 24);
            this.cb_zaposlenici_id.TabIndex = 18;
            this.cb_zaposlenici_id.SelectedIndexChanged += new System.EventHandler(this.cb_zaposlenici_id_SelectedIndexChanged);
            // 
            // listView_zaposlenici
            // 
            this.listView_zaposlenici.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.ime,
            this.prezime,
            this.korisnicko_ime});
            this.listView_zaposlenici.HideSelection = false;
            this.listView_zaposlenici.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3});
            this.listView_zaposlenici.Location = new System.Drawing.Point(451, 79);
            this.listView_zaposlenici.Name = "listView_zaposlenici";
            this.listView_zaposlenici.Size = new System.Drawing.Size(328, 301);
            this.listView_zaposlenici.TabIndex = 20;
            this.listView_zaposlenici.UseCompatibleStateImageBehavior = false;
            // 
            // id
            // 
            this.id.Text = "id";
            this.id.Width = 20;
            // 
            // ime
            // 
            this.ime.Text = "Ime";
            // 
            // prezime
            // 
            this.prezime.Text = "Prezime";
            // 
            // korisnicko_ime
            // 
            this.korisnicko_ime.Text = "Korisničko ime";
            this.korisnicko_ime.Width = 80;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(432, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Popis zaposlenika";
            // 
            // izbornik1
            // 
            this.izbornik1.Location = new System.Drawing.Point(-2, 2);
            this.izbornik1.Name = "izbornik1";
            this.izbornik1.Size = new System.Drawing.Size(800, 35);
            this.izbornik1.TabIndex = 22;
            // 
            // zaposlenici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.izbornik1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listView_zaposlenici);
            this.Controls.Add(this.cb_zaposlenici_id);
            this.Controls.Add(this.bttn_obrisi);
            this.Controls.Add(this.checkedListBoxPrava);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_lozinka);
            this.Controls.Add(this.tb_kime);
            this.Controls.Add(this.tb_prezime);
            this.Controls.Add(this.tb_ime);
            this.Controls.Add(this.bttn_spremi);
            this.Name = "zaposlenici";
            this.Text = "zaposlenici";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bttn_spremi;
        private System.Windows.Forms.TextBox tb_ime;
        private System.Windows.Forms.TextBox tb_prezime;
        private System.Windows.Forms.TextBox tb_kime;
        private System.Windows.Forms.TextBox tb_lozinka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox checkedListBoxPrava;
        private System.Windows.Forms.Button bttn_obrisi;
        private System.Windows.Forms.ComboBox cb_zaposlenici_id;
        private System.Windows.Forms.ListView listView_zaposlenici;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader ime;
        private System.Windows.Forms.ColumnHeader prezime;
        private System.Windows.Forms.ColumnHeader korisnicko_ime;
        private izbornik izbornik1;
    }
}