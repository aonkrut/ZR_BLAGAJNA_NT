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
    public partial class dobavljaci : Form {
        public UpraviteljBazom upraviteljBazom;
        public dobavljaci()
        {
            InitializeComponent();
            upraviteljBazom = new UpraviteljBazom();
            PostaviPocetno();
            listView_dobavljaci.View = View.Details;
        }
        private void PostaviPocetno()
        {
            tb_naziv.Text = "";
            tb_adresa.Text = "";
            tb_kontakt.Text = "";
            ProvjeriPravo();
            ResetirajAutoIncrement();
            PopuniListViewDobavljaci();
            PopuniComboBoxSaIDovima();
            PrikaziSljedeciIDDobavljaci();
            
        }
        private void ProvjeriPravo()
        {
            try
            {


                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();

                    string sqlUpit = "SELECT COUNT(*) FROM pravo WHERE zaposlenik_id = @zaposlenikId AND pravo_id = 3";
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
        private void PopuniListViewDobavljaci()
        {
            listView_dobavljaci.Items.Clear(); // Pretpostavimo da listView za dobavljače se zove listView_dobavljaci
            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();
                    string sqlUpit = "SELECT id, naziv, adresa, kontakt FROM Dobavljaci";
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        using (MySqlDataReader reader = naredba.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["id"].ToString());
                                item.SubItems.Add(reader["naziv"].ToString());
                                item.SubItems.Add(reader["adresa"].ToString());
                                item.SubItems.Add(reader["kontakt"].ToString());
                                listView_dobavljaci.Items.Add(item); // Dodaje redak u listView
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

        private void bttn_spremi_Click(object sender, EventArgs e)

        {

            int id = Convert.ToInt32(cb_dobavljaci_id.SelectedItem.ToString());
            string naziv = tb_naziv.Text.ToString();
            string adresa = tb_adresa.Text.ToString();
            string kontakt = tb_kontakt.Text.ToString();
            Azuriraj_ili_Dodaj_Dobavljaca(id, naziv, adresa, kontakt);
            PostaviPocetno();
        }
        private void bttn_obrisi_Click(object sender, EventArgs e)
        {
            // Provjeri je li neki zaposlenik odabran
            if (cb_dobavljaci_id.SelectedItem == null)
            {
                MessageBox.Show("Molimo odaberite zaposlenika za brisanje.");
                return;
            }

            int idZaBrisanje = Convert.ToInt32(cb_dobavljaci_id.SelectedItem.ToString());

            
                // Otvori dijalog za potvrdu brisanja
                var odgovor = MessageBox.Show($"Jeste li sigurni da želite obrisati zaposlenika s ID = {idZaBrisanje}?", "Potvrda brisanja", MessageBoxButtons.OKCancel);

                if (odgovor == DialogResult.OK)
                {
                    try
                    {
                    cb_dobavljaci_id.Items.Clear();
                    using (MySqlConnection veza2 = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                        {
                            veza2.Open();

                            // SQL upit za brisanje zaposlenika
                            string sqlUpit = "DELETE FROM Dobavljaci WHERE id = @id";
                            using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza2))
                            {
                                naredba.Parameters.AddWithValue("@id", idZaBrisanje);

                                int brojObrisanihRedaka = naredba.ExecuteNonQuery();

                                // Provjera je li zaposlenik uspješno obrisan
                                if (brojObrisanihRedaka > 0)
                                {
                                    MessageBox.Show("Dobavljač uspješno obrisan.");
                                    PostaviPocetno();
                                }
                                else
                                {
                                    MessageBox.Show("Nije pronađen dobavljač s tim ID-om.");
                                PostaviPocetno();
                            }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Nije moguće obrisati: {ex.Message}");
                    }
                }
            }
       

        private void cb_dobavljaci_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_naziv.Text = "";
            tb_adresa.Text = "";
            tb_kontakt.Text = "";
            // Dohvaćanje odabranog ID-a iz ComboBox-a
            if (cb_dobavljaci_id.SelectedItem != null)
            {
                int odabraniId = int.Parse(cb_dobavljaci_id.SelectedItem.ToString());
                DohvatiPodatkeIzBaze(odabraniId);
            }


        }

        private void DohvatiPodatkeIzBaze(int id)
        {
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {

                string sqlUpit = "SELECT naziv, adresa, kontakt FROM Dobavljaci WHERE id = @id";

                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    naredba.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = naredba.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Dohvati podatke iz baze
                            string naziv = reader.GetString("naziv");
                            string adresa = reader.GetString("adresa");
                            string kontakt = reader.GetString("kontakt");

                            // Postavi podatke u odgovarajuće kontrole na formi
                            tb_naziv.Text = naziv;
                            tb_adresa.Text = adresa;
                            tb_kontakt.Text = kontakt;
                        }
                    }
                }
            }
        }


        // Metoda za popunjavanje ComboBox-a sa svim ID-ovima
        private void PopuniComboBoxSaIDovima()
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
                        }
                    }
                }
            }
        }

       
        // Metoda za prikaz sljedećeg ID-a zaposlenika
        private void PrikaziSljedeciIDDobavljaci()
        {
            ResetirajAutoIncrement();
            int sljedeciID = DohvatiSljedeciID_Dobavljaci() + 1;
            // Dodavanje sljedećeg ID-a dobavljaca u ComboBox
            cb_dobavljaci_id.Items.Add(sljedeciID.ToString());
            cb_dobavljaci_id.SelectedItem = sljedeciID.ToString(); // Postavljanje odabranog ID-a

        }

        // Metoda za resetiranje auto incrementa
        private void ResetirajAutoIncrement()
        {
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                int maxID = DohvatiSljedeciID_Dobavljaci() + 1;
                string sqlUpit = "ALTER TABLE Dobavljaci AUTO_INCREMENT =" + maxID;
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    naredba.ExecuteNonQuery();
                }
            }
        }

        // Metoda za dohvaćanje sljedećeg ID-a zaposlenika
        private int DohvatiSljedeciID_Dobavljaci()
        {
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                string sqlUpit = "SELECT MAX(id) FROM dobavljaci";
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
        private void Azuriraj_ili_Dodaj_Dobavljaca(int id, string naziv, string adresa, string kontakt)
        {
            // Provjera spajanja na bazu
            if (upraviteljBazom.SpojiNaBazu())
            {
                // Provjerite postoji li zaposlenik s danim ID-om u bazi
                bool postojiZaposlenik = IDPostoji(id);

                if (postojiZaposlenik)
                {
                    // Ako zaposlenik postoji, izvršite ažuriranje njegovih podataka
                    AzurirajPodatkeDobavljaca(id, naziv, adresa, kontakt);


                }
                else
                {
                    // Ako zaposlenik ne postoji, dodajte novog zaposlenika
                    DodajNovogDobavljaca(naziv, adresa, kontakt);

                }

            }
            else
            {
                MessageBox.Show("Veza s bazom nije uspostavljena.");
            }
        }

        // Metoda za provjeru postojanja zaposlenika s danim ID-om
        private bool IDPostoji(int id)
        {
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                string sqlUpit = "SELECT COUNT(*) FROM Dobavljaci WHERE id = @id";
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    naredba.Parameters.AddWithValue("@id", id);
                    int brojZaposlenika = Convert.ToInt32(naredba.ExecuteScalar());
                    return brojZaposlenika > 0;
                }
            }
        }

        private void DodajNovogDobavljaca(string naziv, string adresa, string kontakt)
        {
           

            // SQL upit za dodavanje zaposlenika
            string sqlUpit = "INSERT INTO Dobavljaci(naziv,adresa,kontakt) VALUES (@naziv, @adresa, @kontakt)";

            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        naredba.Parameters.AddWithValue("@naziv", naziv);
                        naredba.Parameters.AddWithValue("@adresa", adresa);
                        naredba.Parameters.AddWithValue("@kontakt", kontakt);

                        int affectedRows = naredba.ExecuteNonQuery();

                        // Provjera je li zaposlenik dodan
                        if (affectedRows > 0)
                        {
                            
                            MessageBox.Show("Novi dobavljač uspješno dodan.");

                            return;
                        }
                        else
                        {
                            MessageBox.Show("Dodavanje novog dobavljača nije uspjelo.");
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
        private void AzurirajPodatkeDobavljaca(int id, string naziv, string adresa, string kontakt)
        {
            string sqlUpit = "UPDATE Dobavljaci SET naziv=@naziv, adresa=@adresa, kontakt=@kontakt WHERE id = @id";
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {

                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    naredba.Parameters.AddWithValue("@id", id);
                    naredba.Parameters.AddWithValue("@naziv", naziv);
                    naredba.Parameters.AddWithValue("@adresa", adresa);
                    naredba.Parameters.AddWithValue("@kontakt", kontakt);
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

        
    }
}
