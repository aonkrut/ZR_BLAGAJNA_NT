using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace ZR_BLAGAJNA_NT {
    public partial class zaposlenici : Form {
        public UpraviteljBazom upraviteljBazom;

        // Konstruktor klase, inicijalizira osnovne komponente i funkcionalnosti
        // Stvaranje instance upravitelja bazom,  inicijalizacija komponenti forme
        public zaposlenici() 
        {    
            upraviteljBazom = new UpraviteljBazom();  
            InitializeComponent();  
            PostaviPocetno();
            listView_zaposlenici.View = View.Details;
        }
        private void bttn_spremi_Click(object sender, EventArgs e)
        {
            // Dohvaćanje podataka
            int id = Convert.ToInt32(cb_zaposlenici_id.SelectedItem.ToString());
            string ime = tb_ime.Text.ToString();
            string prezime = tb_prezime.Text.ToString();
            string kime = tb_kime.Text.ToString();
            
            string lozinka = HashLozinku(tb_lozinka.Text.ToString());

            // Pozivanje funkcije za dodavanje novog zaposlenika
            Azuriraj_ili_Dodaj_Zaposlenika(id, ime, prezime, kime, lozinka);
            PostaviPocetno();
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

        // Primjer korištenja prilikom dodavanja zaposlenika
        private void DodajZaposlenika(string korisnickoIme, string lozinka)
        {
            // Hashiraj lozinku prije spremanja u bazu podataka
            string hashLozinka = HashLozinku(lozinka);

            // Spremi zaposlenika u bazu podataka s hashiranom lozinkom
            // Ovdje dodajte odgovarajuće SQL naredbe za unos u bazu podataka
        }

        private void PostaviPocetno()
        {
            tb_ime.Text = "";
            tb_prezime.Text = "";
            tb_kime.Text = "";
            tb_lozinka.Text = "";
            checkedListBoxPrava.Items.Clear();
            cb_zaposlenici_id.Items.Clear();

            PopuniListViewZaposlenici();
            PopuniComboBoxSaIDovima();
            ResetirajAutoIncrement();  
            PrikaziSljedeciIDZaposlenika();  
            PopuniPravima();  

        }
        private void PopuniListViewZaposlenici()
        {
            listView_zaposlenici.Items.Clear(); 
            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();
                    string sqlUpit = "SELECT id, ime, prezime, korisnicko_ime FROM Zaposlenici";
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        using (MySqlDataReader reader = naredba.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["id"].ToString());
                                item.SubItems.Add(reader["ime"].ToString());
                                item.SubItems.Add(reader["prezime"].ToString());
                                item.SubItems.Add(reader["korisnicko_ime"].ToString());
                                listView_zaposlenici.Items.Add(item); 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške: {ex.Message}");
            }
        }

        private void UcitajIOznaciPravaZaposlenika(int id)
        {
            if (IDPostoji(id))
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    string sqlUpit = "SELECT pravo_id FROM pravo WHERE zaposlenik_id = @id";
                    veza.Open();
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        naredba.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader reader = naredba.ExecuteReader()) //ovdje javi grešku
                        {
                            while (reader.Read())
                            {
                                int pravoId = reader.GetInt32("pravo_id");
                                // Pretpostavimo da je format u checkedListBoxPrava "id-pravo"
                                for (int i = 0; i < checkedListBoxPrava.Items.Count; i++)
                                {
                                    string item = checkedListBoxPrava.Items[i].ToString();
                                    if (item.StartsWith(pravoId.ToString() + "-"))
                                    {
                                        checkedListBoxPrava.SetItemChecked(i, true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void cb_zaposlenici_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_ime.Text = "";
            tb_prezime.Text = "";
            tb_kime.Text = "";
            tb_lozinka.Text = "";
            foreach (int i in checkedListBoxPrava.CheckedIndices)
            {
                checkedListBoxPrava.SetItemChecked(i, false);
            }
            // Dohvaćanje odabranog ID-a iz ComboBox-a
            if (cb_zaposlenici_id.SelectedItem != null)
            {
                int odabraniId = int.Parse(cb_zaposlenici_id.SelectedItem.ToString());

                // Ovdje možete izvršiti SQL upit za dohvaćanje podataka iz baze
                // Na primjer, dohvatite ime, prezime, korisničko ime i lozinku za odabrani ID
                // i postavite ih u odgovarajuće kontrole na formi
                DohvatiPodatkeIzBaze(odabraniId);
            }
        }

        private void DohvatiPodatkeIzBaze(int id)
        {
            foreach (int i in checkedListBoxPrava.CheckedIndices)
            {
                checkedListBoxPrava.SetItemChecked(i, false);
            }
            UcitajIOznaciPravaZaposlenika(id);
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                
                string sqlUpit = "SELECT ime, prezime, korisnicko_ime, lozinka FROM Zaposlenici WHERE id = @id";
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    naredba.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = naredba.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Dohvati podatke iz baze
                            string ime = reader.GetString("ime");
                            string prezime = reader.GetString("prezime");
                            string korisnickoIme = reader.GetString("korisnicko_ime");
                            string lozinka = reader.GetString("lozinka");

                            // Postavi podatke u odgovarajuće kontrole na formi
                            tb_ime.Text = ime;
                            tb_prezime.Text = prezime;
                            tb_kime.Text = korisnickoIme;
                            tb_lozinka.Text = lozinka;
                        }
                    }
                }
            }
        }
      

     


        // Metoda za popunjavanje ComboBox-a sa svim ID-ovima zaposlenika
        private void PopuniComboBoxSaIDovima()
        {
            cb_zaposlenici_id.Items.Clear();
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                string sqlUpit = "SELECT id FROM Zaposlenici"; // Upit za dohvaćanje svih ID-ova
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    using (MySqlDataReader reader = naredba.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            cb_zaposlenici_id.Items.Add(id.ToString()); // Dodaj svaki ID u ComboBox
                        }
                    }
                }
            }
        }

        private void DodajPravaZaposleniku()
        {
            try
            {
                int zap_id = Convert.ToInt32(cb_zaposlenici_id.SelectedItem.ToString());
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();

                    foreach (var item in checkedListBoxPrava.CheckedItems)
                    {
                        // Pretpostavimo da je svaka stavka u formatu "id-pravo"
                        int pravoId = Convert.ToInt32(item.ToString().Split('-')[0]);

                        string sqlUpit = "INSERT INTO pravo (zaposlenik_id, pravo_id) VALUES (@zaposlenikId, @pravoId)";
                        using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                        {
                            naredba.Parameters.AddWithValue("@zaposlenikId", zap_id);
                            naredba.Parameters.AddWithValue("@pravoId", pravoId);

                            naredba.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }
        }


        // Metoda za popunjavanje prava
        private void PopuniPravima()
        {
            PrikaziPrava prikaziPrava = new PrikaziPrava(checkedListBoxPrava, upraviteljBazom);
            prikaziPrava.DohvatiPrava();
        }





        // Metoda za provjeru postojanja korisničkog imena
        private bool KorisnickoImePostoji(string korisnickoIme)
        {
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                string sqlUpit_1 = "SELECT COUNT(*) FROM Zaposlenici WHERE korisnicko_ime = @korisnickoIme";
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit_1, veza))
                {
                    naredba.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);
                    int brojPostojecih = Convert.ToInt32(naredba.ExecuteScalar());
                    return brojPostojecih > 0;
                }
            }
        }

        // Metoda za prikaz sljedećeg ID-a zaposlenika
        private void PrikaziSljedeciIDZaposlenika()
        {
            int sljedeciID = DohvatiSljedeciIDZaposlenika() + 1;
            // Dodavanje sljedećeg ID-a zaposlenika u ComboBox
            cb_zaposlenici_id.Items.Add(sljedeciID.ToString());
            cb_zaposlenici_id.SelectedItem = sljedeciID.ToString(); // Postavljanje odabranog ID-a

        }

        // Metoda za resetiranje auto incrementa
        private void ResetirajAutoIncrement()
        {
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                int maxID = DohvatiSljedeciIDZaposlenika() + 1;
                string sqlUpit = "ALTER TABLE Zaposlenici AUTO_INCREMENT =" + maxID;
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    naredba.ExecuteNonQuery();
                }
            }
        }

        // Metoda za dohvaćanje sljedećeg ID-a zaposlenika
        private int DohvatiSljedeciIDZaposlenika()
        {
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                string sqlUpit = "SELECT MAX(id) FROM Zaposlenici";
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    object rezultat = naredba.ExecuteScalar();
                    if (rezultat != DBNull.Value)
                    {
                        return Convert.ToInt32(rezultat);

                    }
                    else
                    {
                        return 0; // Ako nema zapisa u tablici
                    }
                }
            }
        }

        // Metoda za dodavanje novog zaposlenika ili ažuriranje postojećeg
        private void Azuriraj_ili_Dodaj_Zaposlenika(int id, string ime, string prezime, string korisnickoIme, string lozinka)
        {
            // Provjera spajanja na bazu
            if (upraviteljBazom.SpojiNaBazu())
            {
                // Provjerite postoji li zaposlenik s danim ID-om u bazi
                bool postojiZaposlenik = IDPostoji(id);

                if (postojiZaposlenik)
                {
                    // Ako zaposlenik postoji, izvršite ažuriranje njegovih podataka
                    AzurirajPodatkeZaposlenika(id, ime, prezime, korisnickoIme, lozinka);
                    ObrisiPostojecePravaZaposlenika(id);

                }
                else
                {
                    // Ako zaposlenik ne postoji, dodajte novog zaposlenika
                    DodajNovogZaposlenika(ime, prezime, korisnickoIme, lozinka);
                    
                }

                // Ako ste ažurirali podatke ili dodali novog zaposlenika, možete dodati prava
                DodajPravaZaposleniku();

                // Postavite formu na početno stanje
                PostaviPocetno();
            }
            else
            {
                MessageBox.Show("Veza s bazom nije uspostavljena.");
            }
        }
        private void ObrisiPostojecePravaZaposlenika(int id)
        {
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                string sqlUpit = "DELETE FROM pravo WHERE zaposlenik_id = @id";
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    naredba.Parameters.AddWithValue("@id", id);
                    naredba.ExecuteNonQuery();
                }
            }
        }
        // Metoda za provjeru postojanja zaposlenika s danim ID-om
        private bool IDPostoji(int id)
        {
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                string sqlUpit = "SELECT COUNT(*) FROM Zaposlenici WHERE id = @id";
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    naredba.Parameters.AddWithValue("@id", id);
                    int brojZaposlenika = Convert.ToInt32(naredba.ExecuteScalar());
                    return brojZaposlenika > 0;
                }
            }
        }
        private void DodajNovogZaposlenika(string ime, string prezime, string korisnickoIme, string lozinka) {
            // Provjera postoji li već korisničko ime
            if (KorisnickoImePostoji(korisnickoIme))
            {
                MessageBox.Show("Korisničko ime već postoji. Molimo odaberite drugo.");
                tb_kime.Text = "";
                return;
            }

            // SQL upit za dodavanje zaposlenika
            string sqlUpit = "INSERT INTO Zaposlenici (ime, prezime, korisnicko_ime, lozinka, prva_prijava) VALUES (@ime, @prezime, @korisnickoIme, @lozinka, 1)";

            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        naredba.Parameters.AddWithValue("@ime", ime);
                        naredba.Parameters.AddWithValue("@prezime", prezime);
                        naredba.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);
                        naredba.Parameters.AddWithValue("@lozinka", lozinka);

                        int affectedRows = naredba.ExecuteNonQuery();

                        // Provjera je li zaposlenik dodan
                        if (affectedRows > 0)
                        {
                            DodajPravaZaposleniku();
                            MessageBox.Show("Novi zaposlenik uspješno dodan.");

                            PostaviPocetno();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Dodavanje novog zaposlenika nije uspjelo.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }
        }
        // Metoda za ažuriranje podataka zaposlenika
        private void AzurirajPodatkeZaposlenika(int id, string ime, string prezime, string korisnickoIme, string lozinka)
        {
            string sqlUpit = "UPDATE Zaposlenici SET ime = @ime, prezime = @prezime, korisnicko_ime = @korisnickoIme, lozinka = @lozinka, prva_prijava=1 WHERE id = @id";
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {

                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    naredba.Parameters.AddWithValue("@id", id);
                    naredba.Parameters.AddWithValue("@ime", ime);
                    naredba.Parameters.AddWithValue("@prezime", prezime);
                    naredba.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);
                    naredba.Parameters.AddWithValue("@lozinka", lozinka);

                    int affectedRows = naredba.ExecuteNonQuery();

                    // Provjera je li zaposlenik dodan
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Ažurirano.");

                        return;
                    }
                    else
                    {
                        MessageBox.Show("Ažuriranje podataka nije uspjelo.");
                    }
                }
            }

        }

        private void bttn_obrisi_Click(object sender, EventArgs e)
        {
            // Provjeri je li neki zaposlenik odabran
            if (cb_zaposlenici_id.SelectedItem == null)
            {
                MessageBox.Show("Molimo odaberite zaposlenika za brisanje.");
                return;
            }

            int idZaBrisanje = Convert.ToInt32(cb_zaposlenici_id.SelectedItem.ToString());

            using (MySqlConnection veza1 = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                veza1.Open();

                // SQL upit za brojanje korisnika u tablici
                string sqlUpitBrojanje = "SELECT COUNT(*) FROM Zaposlenici";
                using (MySqlCommand naredbaBrojanje = new MySqlCommand(sqlUpitBrojanje, veza1))
                {
                    int brojZaposlenika = Convert.ToInt32(naredbaBrojanje.ExecuteScalar());

                    if (brojZaposlenika <= 1)
                    {
                        MessageBox.Show("Nije moguće obrisati jedinog zaposlenika u bazi.");
                        return;
                    }
                }
                // Otvori dijalog za potvrdu brisanja
                var odgovor = MessageBox.Show($"Jeste li sigurni da želite obrisati zaposlenika s ID = {idZaBrisanje}?", "Potvrda brisanja", MessageBoxButtons.OKCancel);

                if (odgovor == DialogResult.OK)
                {
                    try
                    {
                        using (MySqlConnection veza2 = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                        {
                            veza2.Open();

                            // SQL upit za brisanje zaposlenika
                            string sqlUpit = "DELETE FROM Zaposlenici WHERE id = @id";
                            using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza2))
                            {
                                naredba.Parameters.AddWithValue("@id", idZaBrisanje);

                                int brojObrisanihRedaka = naredba.ExecuteNonQuery();

                                // Provjera je li zaposlenik uspješno obrisan
                                if (brojObrisanihRedaka > 0)
                                {
                                    MessageBox.Show("Zaposlenik uspješno obrisan.");
                                    // Ovdje možete dodati kod za osvježavanje liste zaposlenika ili druge akcije
                                    PostaviPocetno();
                                }
                                else
                                {
                                    MessageBox.Show("Nije pronađen zaposlenik s tim ID-om.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Došlo je do greške: {ex.Message}");
                    }
                }
            }
        }
    }




    public class PrikaziPrava {
        private CheckedListBox checkedListBoxPrava;
        private UpraviteljBazom upraviteljBazom;

        // Konstruktor klase
        public PrikaziPrava(CheckedListBox checkedListBox, UpraviteljBazom upravitelj)
        {
            this.checkedListBoxPrava = checkedListBox;
            this.upraviteljBazom = upravitelj;
        }

        // Metoda za dohvat prava iz baze
        public void DohvatiPrava()
        {
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                string sqlUpit = "SELECT id, pravo FROM prava";
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    using (var reader = naredba.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string idPravo = reader["id"].ToString() + "-" + reader["pravo"].ToString();
                            checkedListBoxPrava.Items.Add(idPravo);
                        }
                    }
                }
            }
        }
    }

}
