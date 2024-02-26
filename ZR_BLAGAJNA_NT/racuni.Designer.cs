
namespace ZR_BLAGAJNA_NT {
    partial class racuni {
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
            this.label6 = new System.Windows.Forms.Label();
            this.cb_racuni_id = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_stanje = new System.Windows.Forms.ComboBox();
            this.bttn_potvrdi = new System.Windows.Forms.Button();
            this.izbornik1 = new ZR_BLAGAJNA_NT.izbornik();
            this.Podaci = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.l_kime = new System.Windows.Forms.Label();
            this.l_vrijeme_izdavanja = new System.Windows.Forms.Label();
            this.listView_stavke = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(309, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "Administracija računa";
            // 
            // cb_racuni_id
            // 
            this.cb_racuni_id.FormattingEnabled = true;
            this.cb_racuni_id.Location = new System.Drawing.Point(44, 114);
            this.cb_racuni_id.Name = "cb_racuni_id";
            this.cb_racuni_id.Size = new System.Drawing.Size(121, 24);
            this.cb_racuni_id.TabIndex = 16;
            this.cb_racuni_id.SelectedIndexChanged += new System.EventHandler(this.cb_racuni_id_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Odaberite id računa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Odaberite željeno stanje računa";
            // 
            // cb_stanje
            // 
            this.cb_stanje.FormattingEnabled = true;
            this.cb_stanje.Location = new System.Drawing.Point(208, 114);
            this.cb_stanje.Name = "cb_stanje";
            this.cb_stanje.Size = new System.Drawing.Size(207, 24);
            this.cb_stanje.TabIndex = 19;
            // 
            // bttn_potvrdi
            // 
            this.bttn_potvrdi.Location = new System.Drawing.Point(459, 87);
            this.bttn_potvrdi.Name = "bttn_potvrdi";
            this.bttn_potvrdi.Size = new System.Drawing.Size(258, 51);
            this.bttn_potvrdi.TabIndex = 20;
            this.bttn_potvrdi.Text = "POTVDRI";
            this.bttn_potvrdi.UseVisualStyleBackColor = true;
            this.bttn_potvrdi.Click += new System.EventHandler(this.bttn_potvrdi_Click);
            // 
            // izbornik1
            // 
            this.izbornik1.Location = new System.Drawing.Point(-2, -1);
            this.izbornik1.Name = "izbornik1";
            this.izbornik1.Size = new System.Drawing.Size(802, 34);
            this.izbornik1.TabIndex = 0;
            // 
            // Podaci
            // 
            this.Podaci.AutoSize = true;
            this.Podaci.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Podaci.Location = new System.Drawing.Point(31, 169);
            this.Podaci.Name = "Podaci";
            this.Podaci.Size = new System.Drawing.Size(112, 17);
            this.Podaci.TabIndex = 22;
            this.Podaci.Text = "Podaci računa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Račun izdao/la:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Vrijeme izdavanja:";
            // 
            // l_kime
            // 
            this.l_kime.AutoSize = true;
            this.l_kime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_kime.Location = new System.Drawing.Point(70, 235);
            this.l_kime.Name = "l_kime";
            this.l_kime.Size = new System.Drawing.Size(99, 19);
            this.l_kime.TabIndex = 25;
            this.l_kime.Text = "korisničko ime";
            // 
            // l_vrijeme_izdavanja
            // 
            this.l_vrijeme_izdavanja.AutoSize = true;
            this.l_vrijeme_izdavanja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.l_vrijeme_izdavanja.Location = new System.Drawing.Point(69, 311);
            this.l_vrijeme_izdavanja.Name = "l_vrijeme_izdavanja";
            this.l_vrijeme_izdavanja.Size = new System.Drawing.Size(144, 19);
            this.l_vrijeme_izdavanja.TabIndex = 26;
            this.l_vrijeme_izdavanja.Text = "YYYY MM DD hh ii ss";
            // 
            // listView_stavke
            // 
            this.listView_stavke.HideSelection = false;
            this.listView_stavke.Location = new System.Drawing.Point(248, 189);
            this.listView_stavke.Name = "listView_stavke";
            this.listView_stavke.Size = new System.Drawing.Size(469, 183);
            this.listView_stavke.TabIndex = 46;
            this.listView_stavke.UseCompatibleStateImageBehavior = false;
            // 
            // racuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView_stavke);
            this.Controls.Add(this.l_vrijeme_izdavanja);
            this.Controls.Add(this.l_kime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Podaci);
            this.Controls.Add(this.bttn_potvrdi);
            this.Controls.Add(this.cb_stanje);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_racuni_id);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.izbornik1);
            this.Name = "racuni";
            this.Text = "racuni";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private izbornik izbornik1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_racuni_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_stanje;
        private System.Windows.Forms.Button bttn_potvrdi;
        private System.Windows.Forms.Label Podaci;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label l_kime;
        private System.Windows.Forms.Label l_vrijeme_izdavanja;
        private System.Windows.Forms.ListView listView_stavke;
    }
}