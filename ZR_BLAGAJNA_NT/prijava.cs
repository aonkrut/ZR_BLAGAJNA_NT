using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySqlConnector;

namespace ZR_BLAGAJNA_NT {
    public partial class prijava : Form {

        private UpraviteljBazom upraviteljBazom;
        public static string PrijavljeniZaposlenik = "";
        public static int zap_id;
        public prijava()
        {
            InitializeComponent();
            upraviteljBazom = new UpraviteljBazom();
            PopunaComboBoxa_KI popunaComboBoxa_KI = new PopunaComboBoxa_KI(upraviteljBazom);
            popunaComboBoxa_KI.PopuniComboBox(cb_zaposlenici);
        } 

        public class PopunaComboBoxa_KI {

            private UpraviteljBazom upraviteljBazom;

            public PopunaComboBoxa_KI(UpraviteljBazom upravitelj)
            {
                upraviteljBazom = upravitelj;
            }

            public void PopuniComboBox(ComboBox comboBox)
            {
                
                if (upraviteljBazom.SpojiNaBazu())
                {
                    string sqlUpit_1 = "SELECT korisnicko_ime FROM Zaposlenici";

                    try
                    {
                        using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                        {
                            
                            veza.Open();
                            using (MySqlCommand naredba = new MySqlCommand(sqlUpit_1, veza))
                            {
                                // Izvršavanje SQL upita 
                                using (MySqlDataReader reader = naredba.ExecuteReader())
                                {
                                    
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            comboBox.Items.Add(reader["korisnicko_ime"].ToString());
                                        }
                                        comboBox.SelectedIndex = 0;
                                    }
                                    else
                                    {
                                        // Ako nema podataka u rezultatu upita
                                        MessageBox.Show("Nema dostupnih podataka.");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Greška: {ex.Message}");
                    }
                }
                else
                {
                    // Veza s bazom nije uspostavljena
                    MessageBox.Show("Veza s bazom nije uspostavljena.");
                }
            }
        }
        private string HashLozinku(string lozinka)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] lozinkaBytes = Encoding.UTF8.GetBytes(lozinka);
                byte[] hashBytes = sha256.ComputeHash(lozinkaBytes);

                // Pretvori byte array u string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        private void bttn_prijava_Click(object sender, EventArgs e)
        {
            string korisnickoIme = cb_zaposlenici.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(korisnickoIme))
            {
                MessageBox.Show("Odaberite korisničko ime.");
                return;
            }

            string lozinka = HashLozinku(tb_lozinka.Text.ToString());


            // Provjerimo lozinku u bazi
            if (upraviteljBazom.SpojiNaBazu())
            {
                string sqlUpit = "SELECT lozinka, prva_prijava FROM Zaposlenici WHERE korisnicko_ime = @korisnickoIme";

                try
                {
                    using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                    {
                        veza.Open();
                        using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                        {
                            naredba.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);

                            using (MySqlDataReader citac = naredba.ExecuteReader())
                            {
                                if (citac.Read())
                                {
                                    string pohranjenaLozinka = citac["lozinka"].ToString();
                                    bool prvaPrijava = Convert.ToBoolean(citac["prva_prijava"]);

                                    if (pohranjenaLozinka == lozinka)
                                    {
                                        if (prvaPrijava)
                                        {
                                            // Ako je prva prijava, pitamo korisnika za novu lozinku
                                            string novaLozinka = Unos_Nove_Lozinke();

                                            // Ažuriramo bazu s novom lozinkom i postavljamo prva_prijava na false
                                            if (!string.IsNullOrEmpty(novaLozinka))
                                            {
                                                AzurirajLozinkuUBazi(korisnickoIme, novaLozinka);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Morate unijeti novu lozinku.");
                                            }
                                        }
                                        else
                                        {
                                            // Postavljanje globalne varijable zap_id na ID korisničkog imena koje se uspješno prijavilo
                                            string sqlIdUpit = "SELECT id FROM Zaposlenici WHERE korisnicko_ime = @korisnickoIme";
                                            using (MySqlConnection vezaId = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                                            {
                                                vezaId.Open();
                                                using (MySqlCommand idNaredba = new MySqlCommand(sqlIdUpit, vezaId))
                                                {
                                                    idNaredba.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);
                                                    object idObjekt = idNaredba.ExecuteScalar();
                                                    if (idObjekt != null)
                                                    {
                                                        zap_id = Convert.ToInt32(idObjekt);
                                                    }
                                                    else
                                                    {
                                                        zap_id = 0;
                                                        return;
                                                    }
                                                }
                                            }

                                            PrijavljeniZaposlenik = korisnickoIme;
                                            // Prikazi formu blagajna
                                            PrikaziFormuBlagajna(new blagajna());

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Pogrešna lozinka.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Korisničko ime nije pronađeno.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Greška: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Veza s bazom nije uspostavljena.");
            }
        }

        private void PrikaziFormuBlagajna(Form newForm)
        {
            // Pronalazi glavnu formu u kojoj se nalazi ova korisnička kontrola
            Form parentForm = this.FindForm();

            if (parentForm != null)
            {
                // Postavlja lokaciju nove forme na lokaciju trenutne forme
                newForm.Location = parentForm.Location;
                newForm.StartPosition = FormStartPosition.Manual;

                // Kada se nova forma zatvori, trenutna forma se ponovno prikazuje
                newForm.FormClosed += (s, args) => parentForm.Close();

                // Prikazuje novu formu i skriva trenutnu
                newForm.Show();
                parentForm.Hide();
            }
        }

        private string Unos_Nove_Lozinke()
        {
            // Prikazivanje InputBoxa za unos nove lozinke
            // Za korištenje InputBoxa potrebno je dodati referencu VisualBasic
            string novaLozinka = Microsoft.VisualBasic.Interaction.InputBox("Unesite novu lozinku:", "Unos nove lozinke", "");
            string novaLozinkaa = HashLozinku(novaLozinka);
            return novaLozinkaa;
        }





        private void AzurirajLozinkuUBazi(string korisnickoIme, string novaLozinka)
        {
            // Ažuriranje baze s novom lozinkom i postavljanje prva_prijava na false
            string sqlAzuriranje = "UPDATE Zaposlenici SET lozinka = @novaLozinka, prva_prijava = 0 WHERE korisnicko_ime = @korisnickoIme";
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlAzuriranje, veza))
                {
                    naredba.Parameters.AddWithValue("@novaLozinka", novaLozinka);
                    naredba.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);
                    naredba.ExecuteNonQuery();
                }
            }
        }
    }
}
   
