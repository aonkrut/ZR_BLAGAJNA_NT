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

namespace ZR_BLAGAJNA_NT {
    public partial class proizvodi : Form {
        public UpraviteljBazom upraviteljBazom;
        public proizvodi()
        {
            InitializeComponent();
            upraviteljBazom = new UpraviteljBazom();
            

            PopuniComboBoxSaIDovimaProizvoda();
            PrikaziSljedeciIDProizvoda();
            PopuniComboBoxSaIDovimaDobavljaca();
        }
        private void ResetirajAutoIncrement()
        {
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                int maxID = DohvatiSljedeciID_Proizvodi() + 1;
                string sqlUpit = "ALTER TABLE Proizvodi AUTO_INCREMENT =" + maxID;
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    naredba.ExecuteNonQuery();
                }
            }
        }

        private void bttn_dodaj_Click(object sender, EventArgs e)
        {
            AzurirajKolicinuNaSkladistu(1);
        }

        private void bttn_smanji_Click(object sender, EventArgs e)
        {
            AzurirajKolicinuNaSkladistu(-1);
        }
        private void AzurirajKolicinuNaSkladistu(int trenutnaKolicina)
        {
            try
            {
                int iznos = string.IsNullOrEmpty(tb_kol_na_skl.Text) ? 0 : Convert.ToInt32(tb_kol_na_skl.Text);

                // Ažuriraj količinu
                int novaKolicina = trenutnaKolicina + iznos;


                // Provjeri da količina ne postane negativna
                if (novaKolicina < 0)
                {
                    MessageBox.Show("Količina na skladištu ne može biti negativna.");
                    return;
                }

                tb_kol_na_skl.Text = novaKolicina.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }
        }



        private void PopuniComboBoxSaIDovimaProizvoda()
        {
            try
            {
                cb_proizvodi_id.Items.Clear();
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    string sqlUpit = "SELECT id FROM Proizvodi"; // Upit za dohvaćanje svih ID-ova
                    veza.Open();
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        using (MySqlDataReader reader = naredba.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                cb_proizvodi_id.Items.Add(id.ToString()); // Dodaj svaki ID u ComboBox
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

        private void PopuniComboBoxSaIDovimaDobavljaca()
        {
            try
            {
                cb_dobavljaci_id.Items.Clear();
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    string sqlUpit = "SELECT id FROM Dobavljaci"; // Upit za dohvaćanje svih ID-ova
                    veza.Open();
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        using (MySqlDataReader reader = naredba.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                cb_dobavljaci_id.Items.Add(id.ToString()); // Dodaj svaki ID u ComboBox
                                cb_dobavljaci_id.SelectedItem = id.ToString();
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

        private void PrikaziSljedeciIDProizvoda()
        {
            ResetirajAutoIncrement();
            try
            {
                int sljedeciID = DohvatiSljedeciID_Proizvodi() + 1;
                // Dodavanje sljedećeg ID-a proizvoda u ComboBox
                cb_proizvodi_id.Items.Add(sljedeciID.ToString());
                cb_proizvodi_id.SelectedItem = sljedeciID.ToString(); // Postavljanje odabranog ID-a
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }
        }

        private int DohvatiSljedeciID_Proizvodi()
        {
            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    string sqlUpit = "SELECT MAX(id) FROM Proizvodi";
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
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
                return 0;
            }
        }

        private void cb_proizvodi_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tb_naziv.Text = "";
                tb_barcode.Text = "";
                tb_cijena.Text = "";
                tb_kol_na_skl.Text = "";
                tb_min_kol.Text = "";
                if (cb_proizvodi_id.SelectedItem != null)
                {
                    int odabraniId = int.Parse(cb_proizvodi_id.SelectedItem.ToString());
                    DohvatiPodatkeProizvodaIzBaze(odabraniId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }
        }

        private void DohvatiPodatkeProizvodaIzBaze(int id)
        {
            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    string sqlUpit = "SELECT barcode, naziv, cijena, kol_na_sklad, min_kol, dobavljac_id FROM Proizvodi WHERE id = @id";
                    veza.Open();
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        naredba.Parameters.AddWithValue("@id", id);
                        using (MySqlDataReader reader = naredba.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string naziv = reader.GetString("naziv");
                                string barcode = reader.GetString("barcode");
                                decimal cijena = reader.GetDecimal("cijena");
                                int kol_na_sklad = reader.GetInt32("kol_na_sklad");
                                int min_kol = reader.GetInt32("min_kol");
                                int dobavljacId = reader.GetInt32("dobavljac_id");

                                tb_naziv.Text = naziv;
                                tb_barcode.Text = barcode;
                                tb_cijena.Text = cijena.ToString();
                                tb_kol_na_skl.Text = kol_na_sklad.ToString();
                                tb_min_kol.Text = min_kol.ToString();

                                // Postavljanje odabranog dobavljača u ComboBox
                                cb_dobavljaci_id.SelectedItem = dobavljacId.ToString();
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
        private void PostaviPocetno()
        {
            tb_naziv.Text = "";
            tb_barcode.Text = "";
            tb_cijena.Text = "";
            tb_kol_na_skl.Text = "";
            tb_min_kol.Text = "";
            cb_proizvodi_id.Items.Clear();
            ProvjeriPravo();
            PopuniComboBoxSaIDovimaProizvoda();
            PrikaziSljedeciIDProizvoda();
            
        }
        private void ProvjeriPravo()
        {
            try
            {


                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();

                    string sqlUpit = "SELECT COUNT(*) FROM pravo WHERE zaposlenik_id = @zaposlenikId AND pravo_id = 4";
                    int zaposlenikId = prijava.zap_id;
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        naredba.Parameters.AddWithValue("@zaposlenikId", zaposlenikId);

                        int brojPrava = Convert.ToInt32(naredba.ExecuteScalar());

                        if (brojPrava > 0)
                        {
                        }
                        else
                        {
                            MessageBox.Show("Prijavljeni zaposlenik nema pravo ove radnje.");
                            OnemoguciTipke();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom provjere prava: {ex.Message}");
            }
        }

        private void OnemoguciTipke()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button)
                {
                    Button button = (Button)ctrl;
                    button.Enabled = false;
                }
            }
        }
        private bool IDPostoji(int id)
        {
            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    string sqlUpit = "SELECT COUNT(*) FROM Proizvodi WHERE id = @id";
                    veza.Open();
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        naredba.Parameters.AddWithValue("@id", id);
                        long count = (long)naredba.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
                return false;
            }
        }

        private void bttn_spremi_Click(object sender, EventArgs e)
        {

            if (cb_proizvodi_id.SelectedItem == null)
            {
                MessageBox.Show("Molimo odaberite proizvod za ažuriranje ili odaberite sljedeći ID za dodavanje novog proizvoda.");
                return;
            }

            int id = Convert.ToInt32(cb_proizvodi_id.SelectedItem.ToString());
            string naziv = tb_naziv.Text;
            string barcode = tb_barcode.Text;
            decimal cijena;

            // Provjeri ispravnost unosa za cijenu
            if (!decimal.TryParse(tb_cijena.Text, out cijena))
            {
                MessageBox.Show("Neispravan unos za cijenu.");
                return;
            }

            int kol_na_sklad;
            int min_kol;

            // Provjeri ispravnost unosa za količinu na skladištu
            if (!int.TryParse(tb_kol_na_skl.Text, out kol_na_sklad))
            {
                MessageBox.Show("Neispravan unos za količinu na skladištu.");
                return;
            }

            // Provjeri ispravnost unosa za minimalnu količinu
            if (!int.TryParse(tb_min_kol.Text, out min_kol))
            {
                MessageBox.Show("Neispravan unos za minimalnu količinu.");
                return;
            }

            int dobavljacId = Convert.ToInt32(cb_dobavljaci_id.SelectedItem.ToString());

            Azuriraj_ili_Dodaj_Proizvod(id, naziv, barcode, cijena, kol_na_sklad, min_kol, dobavljacId);
            PostaviPocetno();
            NaruciProizvod(id);
        }

        private void AzurirajPodatkeProizvoda(int id, string naziv, string barcode, decimal cijena, int kol_na_sklad, int min_kol, int dobavljacId)
        {
          
            string sqlUpit = "UPDATE Proizvodi SET naziv = @naziv, barcode = @barcode, cijena = @cijena, kol_na_sklad = @kol_na_sklad, min_kol = @min_kol, dobavljac_id = @dobavljacId WHERE id = @id";
            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        naredba.Parameters.AddWithValue("@id", id);
                        naredba.Parameters.AddWithValue("@naziv", naziv);
                        naredba.Parameters.AddWithValue("@barcode", barcode);
                        naredba.Parameters.AddWithValue("@cijena", cijena);
                        naredba.Parameters.AddWithValue("@kol_na_sklad", kol_na_sklad);
                        naredba.Parameters.AddWithValue("@min_kol", min_kol);
                        naredba.Parameters.AddWithValue("@dobavljacId", dobavljacId);
                        int affectedRows = naredba.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Podaci o proizvodu ažurirani.");
                        }
                        else
                        {
                            MessageBox.Show("Ažuriranje podataka nije uspjelo.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }
        }

        private void Azuriraj_ili_Dodaj_Proizvod(int id, string naziv, string barcode, decimal cijena, int kol_na_skl, int min_kol, int dobavljacId)
        {
            int iznos_za_provjeru = string.IsNullOrEmpty(tb_kol_na_skl.Text) ? 0 : Convert.ToInt32(tb_kol_na_skl.Text);

            if (iznos_za_provjeru < 0)
            {
                MessageBox.Show("Količina na skladištu ne može biti negativna.");
                return;
            }
            // Provjera spajanja na bazu
            if (upraviteljBazom.SpojiNaBazu())
            {
                // Provjerite postoji li proizvod s danim ID-om u bazi
                bool postojiProizvod = IDPostoji(id);

                if (postojiProizvod)
                {
                    // Ako proizvod postoji, izvršite ažuriranje njegovih podataka
                    AzurirajPodatkeProizvoda(id, naziv, barcode, cijena, kol_na_skl, min_kol, dobavljacId);
                }
                else
                {
                    // Ako proizvod ne postoji, dodajte novi proizvod
                    DodajNoviProizvod(naziv, barcode, cijena, kol_na_skl, min_kol, dobavljacId);
                }
            }
            else
            {
                MessageBox.Show("Veza s bazom nije uspostavljena.");
            }
        }

        private void DodajNoviProizvod(string naziv, string barcode, decimal cijena, int kol_na_skl, int min_kol, int dobavljacId)
        {
            // SQL upit za dodavanje proizvoda
            string sqlUpit = "INSERT INTO Proizvodi(naziv,barcode,cijena,kol_na_sklad,min_kol,dobavljac_id) VALUES (@naziv, @barcode, @cijena, @kol_na_skl, @min_kol, @dobavljacId)";

            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        naredba.Parameters.AddWithValue("@naziv", naziv);
                        naredba.Parameters.AddWithValue("@barcode", barcode);
                        naredba.Parameters.AddWithValue("@cijena", cijena);
                        naredba.Parameters.AddWithValue("@kol_na_skl", kol_na_skl);
                        naredba.Parameters.AddWithValue("@min_kol", min_kol);
                        naredba.Parameters.AddWithValue("@dobavljacId", dobavljacId);

                        int affectedRows = naredba.ExecuteNonQuery();

                        // Provjera je li proizvod dodan
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Novi proizvod uspješno dodan.");
                            PostaviPocetno();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Dodavanje novog proizvoda nije uspjelo.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }
        }

        private void bttn_obrisi_Click(object sender, EventArgs e)
        {
            if (cb_proizvodi_id.SelectedItem == null)
            {
                MessageBox.Show("Molimo odaberite proizvod za brisanje.");
                return;
            }

            int id = Convert.ToInt32(cb_proizvodi_id.SelectedItem.ToString());

            // Prikaži MessageBox s pitanjem
            DialogResult result = MessageBox.Show("Jeste li sigurni da želite obrisati odabrani proizvod?", "Potvrda brisanja", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                // Korisnik je odabrao OK, obriši proizvod
                ObrisiProizvod(id);
                PostaviPocetno();
            }
            else
            {
                // Korisnik je odabrao Cancel, nema akcije
            }
        }

        private void ObrisiProizvod(int id)
        {
            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    string sqlUpit = "DELETE FROM Proizvodi WHERE id = @id";
                    veza.Open();
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        naredba.Parameters.AddWithValue("@id", id);
                        int affectedRows = naredba.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Proizvod uspješno obrisan.");
                        }
                        else
                        {
                            MessageBox.Show("Brisanje proizvoda nije uspjelo.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }
        }
        private void NaruciProizvod(int proizvodId)
        {
            try
            {
                int razlika = 0;
                int novoStanje = 0;

                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();

                    string sqlDohvatiKolicine = "SELECT kol_na_sklad, min_kol FROM Proizvodi WHERE id = @proizvodId";
                    using (MySqlCommand dohvatiKolicine = new MySqlCommand(sqlDohvatiKolicine, veza))
                    {
                        dohvatiKolicine.Parameters.AddWithValue("@proizvodId", proizvodId);
                        using (MySqlDataReader reader = dohvatiKolicine.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int trenutnaKolicina = reader.GetInt32("kol_na_sklad");
                                int minKolicina = reader.GetInt32("min_kol");

                                if (trenutnaKolicina < minKolicina)
                                {
                                    razlika = (int)(2 * minKolicina) - trenutnaKolicina;
                                    novoStanje = trenutnaKolicina + razlika;
                                }
                            }
                        }
                    }

                    if (razlika > 0)
                    {
                        MessageBox.Show($"Automatski naručeno {razlika} komada proizvoda id: {proizvodId}");

                        
                        string sqlAzurirajSkladiste = "UPDATE Proizvodi SET kol_na_sklad = @novoStanje WHERE id = @proizvodId";
                        using (MySqlCommand azurirajSkladiste = new MySqlCommand(sqlAzurirajSkladiste, veza))
                        {
                            azurirajSkladiste.Parameters.AddWithValue("@novoStanje", novoStanje);
                            azurirajSkladiste.Parameters.AddWithValue("@proizvodId", proizvodId);
                            azurirajSkladiste.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom automatskog naručivanja proizvoda: {ex.Message}");
            }
        }
    }
}
