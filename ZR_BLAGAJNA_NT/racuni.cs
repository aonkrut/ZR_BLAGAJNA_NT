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
    public partial class racuni : Form {
        public UpraviteljBazom upraviteljBazom;
        public racuni()
        {
            InitializeComponent();
            upraviteljBazom = new UpraviteljBazom();
            PostaviPocetno();
            listView_stavke.View = View.Details;
            listView_stavke.Columns.Add("Proizvod ID", 100, HorizontalAlignment.Left);
            listView_stavke.Columns.Add("Količina", 100, HorizontalAlignment.Left);
            listView_stavke.Columns.Add("Cijena po jedinici", 150, HorizontalAlignment.Left);
        }
        private void PostaviPocetno(){
            PopuniComboBoxSaIDovimaRacuna();
            PopuniComboBoxStanja();
        }
        private void PopuniComboBoxSaIDovimaRacuna()
        {
            cb_racuni_id.Items.Clear();
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                string sqlUpit = "SELECT id FROM Racun";
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    using (MySqlDataReader reader = naredba.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            cb_racuni_id.Items.Add(id.ToString()); 
                        }
                    }
                }
            }
        }
        private void PopuniComboBoxStanja()
        {
            cb_stanje.Items.Clear();
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                string sqlUpit = "SELECT id,status FROM Status";
                veza.Open();
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                {
                    using (MySqlDataReader reader = naredba.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string a= id.ToString()+ "-"+reader.GetString("status");
                            cb_stanje.Items.Add(a); // Dodaj svaki ID u ComboBox
                        }
                    }
                }
            }
        }
        private void PopuniListViewRacuni()
        {
        }
        private void bttn_potvrdi_Click(object sender, EventArgs e)
        {
            if (int.TryParse(cb_racuni_id.SelectedItem?.ToString(), out int odabraniIDracuna))
            {
                try
                {
                    using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                    {
                        veza.Open();

                        if (cb_stanje.SelectedItem != null)
                        {
                            // Razdvajanje ID-a i statusa iz selektiranog teksta u ComboBoxu
                            string[] id_stanje = cb_stanje.SelectedItem.ToString().Split('-');
                            if (id_stanje.Length == 2 && int.TryParse(id_stanje[0], out int pripadajuciIDstanja))
                            {
                                if (pripadajuciIDstanja==3) {
                                    VratiProizvode(odabraniIDracuna);
                                }
                                string sqlUpit = "UPDATE status_racuna SET status_id = @pripadajuciIDstanja WHERE racun_id = @odabraniID";

                                using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                                {
                                    naredba.Parameters.AddWithValue("@odabraniID", odabraniIDracuna);
                                    naredba.Parameters.AddWithValue("@pripadajuciIDstanja", pripadajuciIDstanja);

                                    naredba.ExecuteNonQuery();

                                    MessageBox.Show("Status računa uspješno ažuriran.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Neispravan format za ID statusa.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nije odabran status.");
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
                MessageBox.Show("Neispravan format za ID računa.");
            }
        }

        private void VratiProizvode(int racun_id)
        {
            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();

                    string sqlDohvatiStavke = "SELECT proizvod_id,kolicina FROM stavkaracuna WHERE racun_id = @racun_id";

                    using (MySqlCommand dohvatiStavke = new MySqlCommand(sqlDohvatiStavke, veza))
                    {
                        dohvatiStavke.Parameters.AddWithValue("@racun_id", racun_id);

                        using (MySqlDataReader reader = dohvatiStavke.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int proizvod_id = reader.GetInt32("proizvod_id");
                                int kolicina = reader.GetInt32("kolicina");
                                VratiKOlicinuUbazu(proizvod_id, kolicina);
                                MessageBox.Show("" + proizvod_id + "," + kolicina);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom dodavanja proizvoda iz računa: {ex.Message}");
            }
        }

        private void VratiKOlicinuUbazu(int proizvod_id, int kolicina)
        {
            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();
                  string sqlAzurirajKolicinu = "UPDATE proizvodi SET kol_na_sklad = kol_na_sklad + @kolicina WHERE id = @proizvod_id";

                  using (MySqlCommand azurirajKolicinu = new MySqlCommand(sqlAzurirajKolicinu, veza))
                                {
                                    azurirajKolicinu.Parameters.AddWithValue("@kolicina", kolicina);
                                    azurirajKolicinu.Parameters.AddWithValue("@proizvod_id", proizvod_id);
                                    azurirajKolicinu.ExecuteNonQuery();
                                
                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom dodavanja proizvoda u tablicu Proizvodi: {ex.Message}");
            }
        }




        private void cb_racuni_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cb_racuni_id.SelectedItem?.ToString(), out int odabraniIDracuna))
            {

                try
                {
                    using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                    {
                        veza.Open();

                        string sqlUpit = "SELECT sr.status_id, s.id, s.status " +
                                         "FROM status_racuna sr " +
                                         "INNER JOIN Status s ON sr.status_id = s.id " +
                                         "WHERE sr.racun_id = @odabraniID";

                        using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                        {
                            naredba.Parameters.AddWithValue("@odabraniID", odabraniIDracuna);

                            using (MySqlDataReader reader = naredba.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    prikaziPodatkeRacuna(odabraniIDracuna);
                                    int pripadajuciIDstanja = reader.GetInt32("status_id");
                                    int id = reader.GetInt32("id");
                                    string status = reader.GetString("status");
                                    cb_stanje.SelectedItem = $"{id}-{status}";
                                    if (pripadajuciIDstanja == 3)
                                    {
                                        bttn_potvrdi.Enabled = false;
                                        MessageBox.Show("Stanja stoniranih računa ne mogu se mijenjati.");
                                    }
                                    else
                                    {
                                        bttn_potvrdi.Enabled = true; 
                                    }
                                    
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
                MessageBox.Show("Neispravan format za ID računa.");
            }
        }
        private void prikaziPodatkeRacuna(int racun_id)
        {
            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();

                    // Dohvati id zaposlenika koji je izdao račun iz tablice racun
                    string sqlDohvatiZaposlenika = "SELECT zaposlenik_id, datum_izdavanja FROM Racun WHERE id = @racun_id";
                    using (MySqlCommand dohvatiZaposlenika = new MySqlCommand(sqlDohvatiZaposlenika, veza))
                    {
                        dohvatiZaposlenika.Parameters.AddWithValue("@racun_id", racun_id);
                        using (MySqlDataReader reader = dohvatiZaposlenika.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int zaposlenik_id = reader.GetInt32("zaposlenik_id");
                                DateTime datum_izdavanja = reader.GetDateTime("datum_izdavanja");

                                // Dohvati ime zaposlenika
                                string imeZaposlenika = DohvatiImeZaposlenika(zaposlenik_id);
                                DohvatiPodatkeZaStavke(racun_id);
                                // Postavi podatke u odgovarajuće labele
                                l_kime.Text = imeZaposlenika;
                                l_vrijeme_izdavanja.Text = datum_izdavanja.ToString();
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

        private string DohvatiImeZaposlenika(int zaposlenik_id)
        {
            string imeZaposlenika = "Nepoznato";

            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();

                    // Dohvati ime zaposlenika
                    string sqlDohvatiIme = "SELECT ime FROM Zaposlenici WHERE id = @zaposlenik_id";
                    using (MySqlCommand dohvatiIme = new MySqlCommand(sqlDohvatiIme, veza))
                    {
                        dohvatiIme.Parameters.AddWithValue("@zaposlenik_id", zaposlenik_id);
                        using (MySqlDataReader reader = dohvatiIme.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                imeZaposlenika = reader.GetString("ime");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom dohvaćanja imena zaposlenika: {ex.Message}");
            }

            return imeZaposlenika;
        }

        private void DohvatiPodatkeZaStavke(int racunId)
        {
            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();

                    // SQL upit za dohvaćanje podataka o stavkama
                    string sqlUpit = "SELECT proizvod_id, kolicina, cijena_po_jedinici FROM StavkaRacuna WHERE racun_id = @racunId";

                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        naredba.Parameters.AddWithValue("@racunId", racunId);

                        using (MySqlDataReader reader = naredba.ExecuteReader())
                        {
                            listView_stavke.Items.Clear(); // Očisti prethodne stavke

                            while (reader.Read())
                            {
                                int proizvodId = reader.GetInt32("proizvod_id");
                                int kolicina = reader.GetInt32("kolicina");
                                decimal cijenaPoJedinici = reader.GetDecimal("cijena_po_jedinici");

                                // Dodaj podatke u ListView
                                string[] podaciStavke = { proizvodId.ToString(), kolicina.ToString(), cijenaPoJedinici.ToString() };
                                ListViewItem stavka = new ListViewItem(podaciStavke);

                                // Dodaj stavku u listView_stavke koristeći SubItems
                                stavka.SubItems.Add(kolicina.ToString());
                                stavka.SubItems.Add(cijenaPoJedinici.ToString());

                                // Dodaj stavku u listView_stavke
                                listView_stavke.Items.Add(stavka);

                                // Postavi listView_stavke.View na View.Details
                                listView_stavke.View = View.Details;
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

    }
}
