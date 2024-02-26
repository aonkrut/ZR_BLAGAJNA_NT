
namespace ZR_BLAGAJNA_NT {
    partial class dobavljaci {
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.label8 = new System.Windows.Forms.Label();
            this.cb_dobavljaci_id = new System.Windows.Forms.ComboBox();
            this.bttn_obrisi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_kontakt = new System.Windows.Forms.TextBox();
            this.tb_adresa = new System.Windows.Forms.TextBox();
            this.tb_naziv = new System.Windows.Forms.TextBox();
            this.bttn_spremi = new System.Windows.Forms.Button();
            this.listView_dobavljaci = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.naziv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.adresa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.kontakt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.izbornik1 = new ZR_BLAGAJNA_NT.izbornik();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 17);
            this.label8.TabIndex = 39;
            this.label8.Text = "Popis dobavljača";
            // 
            // cb_dobavljaci_id
            // 
            this.cb_dobavljaci_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_dobavljaci_id.FormattingEnabled = true;
            this.cb_dobavljaci_id.ItemHeight = 16;
            this.cb_dobavljaci_id.Location = new System.Drawing.Point(119, 96);
            this.cb_dobavljaci_id.Name = "cb_dobavljaci_id";
            this.cb_dobavljaci_id.Size = new System.Drawing.Size(96, 24);
            this.cb_dobavljaci_id.TabIndex = 37;
            this.cb_dobavljaci_id.SelectedIndexChanged += new System.EventHandler(this.cb_dobavljaci_id_SelectedIndexChanged);
            // 
            // bttn_obrisi
            // 
            this.bttn_obrisi.Location = new System.Drawing.Point(25, 335);
            this.bttn_obrisi.Name = "bttn_obrisi";
            this.bttn_obrisi.Size = new System.Drawing.Size(75, 30);
            this.bttn_obrisi.TabIndex = 36;
            this.bttn_obrisi.Text = "Obriši";
            this.bttn_obrisi.UseVisualStyleBackColor = true;
            this.bttn_obrisi.Click += new System.EventHandler(this.bttn_obrisi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(364, 32);
            this.label6.TabIndex = 33;
            this.label6.Text = "Administracija dobavljača";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Kontakt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "Adresa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Naziv";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Dobavljač ID:";
            // 
            // tb_kontakt
            // 
            this.tb_kontakt.Location = new System.Drawing.Point(25, 258);
            this.tb_kontakt.Name = "tb_kontakt";
            this.tb_kontakt.Size = new System.Drawing.Size(190, 22);
            this.tb_kontakt.TabIndex = 26;
            // 
            // tb_adresa
            // 
            this.tb_adresa.Location = new System.Drawing.Point(25, 204);
            this.tb_adresa.Name = "tb_adresa";
            this.tb_adresa.Size = new System.Drawing.Size(190, 22);
            this.tb_adresa.TabIndex = 25;
            // 
            // tb_naziv
            // 
            this.tb_naziv.Location = new System.Drawing.Point(25, 147);
            this.tb_naziv.Name = "tb_naziv";
            this.tb_naziv.Size = new System.Drawing.Size(190, 22);
            this.tb_naziv.TabIndex = 24;
            // 
            // bttn_spremi
            // 
            this.bttn_spremi.Location = new System.Drawing.Point(25, 299);
            this.bttn_spremi.Name = "bttn_spremi";
            this.bttn_spremi.Size = new System.Drawing.Size(190, 30);
            this.bttn_spremi.TabIndex = 23;
            this.bttn_spremi.Text = "Spremi";
            this.bttn_spremi.UseVisualStyleBackColor = true;
            this.bttn_spremi.Click += new System.EventHandler(this.bttn_spremi_Click);
            // 
            // listView_dobavljaci
            // 
            this.listView_dobavljaci.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.naziv,
            this.adresa,
            this.kontakt});
            this.listView_dobavljaci.HideSelection = false;
            this.listView_dobavljaci.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView_dobavljaci.Location = new System.Drawing.Point(257, 127);
            this.listView_dobavljaci.Name = "listView_dobavljaci";
            this.listView_dobavljaci.Size = new System.Drawing.Size(485, 238);
            this.listView_dobavljaci.TabIndex = 40;
            this.listView_dobavljaci.UseCompatibleStateImageBehavior = false;
            // 
            // id
            // 
            this.id.Text = "id";
            this.id.Width = 45;
            // 
            // naziv
            // 
            this.naziv.Text = "naziv";
            this.naziv.Width = 100;
            // 
            // adresa
            // 
            this.adresa.Text = "adresa";
            this.adresa.Width = 100;
            // 
            // kontakt
            // 
            this.kontakt.Text = "kontakt";
            this.kontakt.Width = 110;
            // 
            // izbornik1
            // 
            this.izbornik1.Location = new System.Drawing.Point(3, 0);
            this.izbornik1.Name = "izbornik1";
            this.izbornik1.Size = new System.Drawing.Size(800, 38);
            this.izbornik1.TabIndex = 41;
            // 
            // dobavljaci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.izbornik1);
            this.Controls.Add(this.listView_dobavljaci);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cb_dobavljaci_id);
            this.Controls.Add(this.bttn_obrisi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_kontakt);
            this.Controls.Add(this.tb_adresa);
            this.Controls.Add(this.tb_naziv);
            this.Controls.Add(this.bttn_spremi);
            this.Name = "dobavljaci";
            this.Text = "dobavljaci";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_dobavljaci_id;
        private System.Windows.Forms.Button bttn_obrisi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_kontakt;
        private System.Windows.Forms.TextBox tb_adresa;
        private System.Windows.Forms.TextBox tb_naziv;
        private System.Windows.Forms.Button bttn_spremi;
        private System.Windows.Forms.ListView listView_dobavljaci;
        private izbornik izbornik1;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader naziv;
        private System.Windows.Forms.ColumnHeader adresa;
        private System.Windows.Forms.ColumnHeader kontakt;
    }
}