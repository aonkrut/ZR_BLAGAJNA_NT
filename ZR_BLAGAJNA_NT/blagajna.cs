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
    public partial class blagajna : Form {
        public UpraviteljBazom upraviteljBazom;
        public blagajna()
        {
            InitializeComponent();
            upraviteljBazom = new UpraviteljBazom();
            listView_popis_proizvoda.View = View.Details;
            listView_stavke.View = View.Details;
            listView_stavke.Columns.Add("Proizvod ID", 100, HorizontalAlignment.Left);
            listView_stavke.Columns.Add("Količina", 100, HorizontalAlignment.Left);
            listView_stavke.Columns.Add("Cijena po jedinici", 150, HorizontalAlignment.Left);
            prijavljenzaposlenik.Text = prijava.PrijavljeniZaposlenik;
            
            PostaviPocetno();
        }

        private void DohvatiProizvode()
        {
            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    string sqlUpit1 = "SELECT id FROM Proizvodi";

                    veza.Open();
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit1, veza))
                    {
                        using (MySqlDataReader reader = naredba.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string sqlUpit2 = "SELECT barcode, naziv, cijena, kol_na_sklad, min_kol, dobavljac_id FROM Proizvodi WHERE id = @id";

                                
                                using (MySqlConnection veza2 = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                                {
                                    veza2.Open();
                                    using (MySqlCommand naredba2 = new MySqlCommand(sqlUpit2, veza2))
                                    {
                                        naredba2.Parameters.AddWithValue("@id", id);
                                        using (MySqlDataReader reader2 = naredba2.ExecuteReader())
                                        {
                                            if (reader2.Read())  
                                            {
                                                string naziv = reader2.GetString("naziv");
                                                string barcode = reader2.GetString("barcode");
                                                decimal cijena = reader2.GetDecimal("cijena");

                                                
                                                List<string> podaciProizvoda = new List<string>
                                        {
                                            id.ToString(),  
                                            naziv,          
                                            barcode         
                                        };

                                                // Dodajte podatke o proizvodu u ListView
                                                PopuniListViewProizvoda(podaciProizvoda);

                                                
                                            }
                                        }
                                    }
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
        private void PopuniListViewProizvoda(List<string> podaciProizvoda)
        {

            listView_popis_proizvoda.Columns.Clear();
            listView_popis_proizvoda.Columns.Add("ID", 30, HorizontalAlignment.Left);
            listView_popis_proizvoda.Columns.Add("Naziv", 80, HorizontalAlignment.Left);
            listView_popis_proizvoda.Columns.Add("Barkod", 110, HorizontalAlignment.Left);

            ListViewItem item = new ListViewItem(podaciProizvoda.ToArray());
            listView_popis_proizvoda.Items.Add(item);
        }


         private void PostaviPocetno()
         {
            
            listView_popis_proizvoda.Items.Clear();
            listView_stavke.Items.Clear();
            DohvatiProizvode();
            ResetirajAutoIncrement();
            int sljedeciID = DohvatiSlijedeciIDRacuna();
            l_racun_id.Text = sljedeciID.ToString();
        
            PopuniComboBoxSaIDovimaProizvoda();
             tb_naziv.Text = "";
             tb_barcode.Text = "";
             tb_kol.Text = "1";
             l_cijena.Text = "0";
             cb_proizvodi_id.SelectedItem = "0";
             l_iznos_racuna.Text = "0";
            KreiranjeRacuna();
          

        }
        private void ResetirajAutoIncrement()
        {
            using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                int maxID = DohvatiIdZaposlenika();
                string sqlUpit = "ALTER TABLE Racun AUTO_INCREMENT =" + maxID;
                  veza.Open();
                  using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                  {
                      naredba.ExecuteNonQuery();
                  }
            }
        }

        private int DohvatiSlijedeciIDRacuna()
        {
            int slijedeciID = 1;  

            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    string sqlUpit = "SELECT MAX(id) + 1 AS slijedeciID FROM Racun";
                    veza.Open();

                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        using (MySqlDataReader reader = naredba.ExecuteReader())
                        {
                            if (reader.Read() && !reader.IsDBNull(0))
                            {
                                slijedeciID = reader.GetInt32("slijedeciID");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }

            return slijedeciID;
        }


        private void listView_popis_proizvoda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Provjeravamo je li odabrana barem jedna stavka
                if (listView_popis_proizvoda.SelectedItems.Count > 0)
                {
                    // Dobavljamo odabrani element
                    ListViewItem odabraniItem = listView_popis_proizvoda.SelectedItems[0];

                    // Dohvaćamo vrijednost odabranog elementa iz prvog stupca (pretpostavljamo da je ID u prvom stupcu)
                    if (int.TryParse(odabraniItem.SubItems[0].Text, out int odabraniId))
                    {
                        // Provjeravamo je li odabrani ID 0, ako je, izlazimo iz metode
                        if (odabraniId == 0)
                            return;

                        // Postavljamo tekstualne kutije na prazno
                        tb_naziv.Text = "";
                        tb_barcode.Text = "";
                        l_cijena.Text = "0";

                        // Pozivamo metodu za dohvat podataka proizvoda
                        DohvatiPodatkeProizvoda(odabraniId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }
        }

        private void KreiranjeRacuna()
        {
            try
            {
                int zaposlenik_id = DohvatiIdZaposlenika();
                int racun_id;

                if (!int.TryParse(l_racun_id.Text, out racun_id))
                {
                    MessageBox.Show("Neispravan format za broj računa.");
                    return;
                }

                DateTime datum_izdavanja = DateTime.Now;
                string formatiraniDatum = datum_izdavanja.ToString("yyyy-MM-dd HH:mm:ss");

                using(MySqlConnection veza1 = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza1.Open();

                    string sqlUpit1 = "INSERT INTO Racun (zaposlenik_id, datum_izdavanja) VALUES (@zaposlenik_id, STR_TO_DATE(@datum_izdavanja, '%Y-%m-%d %H:%i:%s')); SELECT LAST_INSERT_ID();";
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit1, veza1))
                    {
                        naredba.Parameters.AddWithValue("@zaposlenik_id", zaposlenik_id);
                        naredba.Parameters.AddWithValue("@datum_izdavanja", formatiraniDatum);

                        racun_id = Convert.ToInt32(naredba.ExecuteScalar());
                    }
                }


                using (MySqlConnection veza2 = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza2.Open();

                    string sqlUpit2 = "INSERT INTO Status_racuna (racun_id, status_id) VALUES (@racun_id, @status_id)";
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit2, veza2))
                    {
                        naredba.Parameters.AddWithValue("@racun_id", racun_id);
                        naredba.Parameters.AddWithValue("@status_id", 4);
                        naredba.ExecuteNonQuery();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }
        }

   

        private int DohvatiIdZaposlenika()
        {
            int zaposlenikId = 1; 

            try
            {
                using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza.Open();

                    
                    string sqlUpit = "SELECT id FROM Zaposlenici WHERE korisnicko_ime = @korisnickoIme";

                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                    {
                        naredba.Parameters.AddWithValue("@korisnickoIme", prijavljenzaposlenik.Text);

                        using (MySqlDataReader reader = naredba.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                zaposlenikId = reader.GetInt32("id");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
            }

            return zaposlenikId;
        }


        private void cb_proizvodi_id_SelectedIndexChanged(object sender, EventArgs e)
         {

            try
            {
                tb_naziv.Text = "";
                tb_barcode.Text = "";
                l_cijena.Text = "0";
                if (cb_proizvodi_id.SelectedItem != null)
                {

                    int odabraniId = int.Parse(cb_proizvodi_id.SelectedItem.ToString());
                    if (odabraniId == 0) { return; }
                    DohvatiPodatkeProizvoda(odabraniId);
                }
                
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
                cb_proizvodi_id.Items.Add("0");
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
                                 cb_proizvodi_id.Items.Add(id.ToString());
                                 cb_proizvodi_id.SelectedItem = id.ToString();
                                 DohvatiPodatkeProizvoda(id);
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
         private void DohvatiPodatkeProizvoda(int id)
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

                                 tb_naziv.Text = naziv;
                                 tb_barcode.Text = barcode;
                                l_cijena.Text = cijena.ToString();
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

        private void DodajStavkuRacuna()
        {
            try
            {
                int proizvodId = int.Parse(cb_proizvodi_id.SelectedItem.ToString());
                int kolicina = int.Parse(tb_kol.Text);
                decimal cijenaPoJedinici = decimal.Parse(l_cijena.Text);
                int racunId = int.Parse(l_racun_id.Text);
                
                
                if (cb_proizvodi_id.SelectedItem.ToString() == "0")
                {
                    return;
                }
                else
                {
                    using (MySqlConnection veza2 = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                    {
                        veza2.Open();

                        string sqlUpit2 = "UPDATE Status_racuna SET status_id = 1 WHERE racun_id = @racun_id";
                        using (MySqlCommand naredba = new MySqlCommand(sqlUpit2, veza2))
                        {
                            naredba.Parameters.AddWithValue("@racun_id", racunId);
                            naredba.ExecuteNonQuery();
                        }
                    }
                    using (MySqlConnection veza = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                    {
                        veza.Open();

                        // SQL upit za unos stavke
                        string sqlUpit = "INSERT INTO StavkaRacuna (proizvod_id, kolicina, cijena_po_jedinici, racun_id) VALUES (@proizvodId, @kolicina, @cijenaPoJedinici, @racunId)";

                        using (MySqlCommand naredba = new MySqlCommand(sqlUpit, veza))
                        {
                            // Postavljanje parametara
                            naredba.Parameters.AddWithValue("@proizvodId", proizvodId);
                            naredba.Parameters.AddWithValue("@kolicina", kolicina);
                            naredba.Parameters.AddWithValue("@cijenaPoJedinici", cijenaPoJedinici);
                            naredba.Parameters.AddWithValue("@racunId", racunId);

                            // Izvršavanje SQL naredbe
                            naredba.ExecuteNonQuery();

                            // Ažuriranje tablice Proizvodi oduzimanjem količine
                            string sqlAzurirajProizvod = "UPDATE Proizvodi SET kol_na_sklad = kol_na_sklad - @kolicina WHERE id = @proizvodId";
                            using (MySqlCommand naredbaAzurirajProizvod = new MySqlCommand(sqlAzurirajProizvod, veza))
                            {
                                naredbaAzurirajProizvod.Parameters.AddWithValue("@kolicina", kolicina);
                                naredbaAzurirajProizvod.Parameters.AddWithValue("@proizvodId", proizvodId);
                                naredbaAzurirajProizvod.ExecuteNonQuery();
                            }

                            // Ažuriranje listView_stavke
                            string[] podaciStavke = { proizvodId.ToString(), kolicina.ToString(), cijenaPoJedinici.ToString() };
                            ListViewItem stavka = new ListViewItem(podaciStavke);

                            // Dodavanje stavke u listView_stavke koristeći SubItems
                            stavka.SubItems.Add(kolicina.ToString());
                            stavka.SubItems.Add(cijenaPoJedinici.ToString());

                            // Dodavanje stavke u listView_stavke
                            listView_stavke.Items.Add(stavka);

                            // Postavljanje listView_stavke.View na View.Details
                            listView_stavke.View = View.Details;

                            IzracunIznosaRacuna();
                            cb_proizvodi_id.SelectedItem = "0";
                        }
                    }
                    NaruciProizvod(proizvodId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška: {ex.Message}");
                return;
            }
        }


        private void IzracunIznosaRacuna()
        {
            // Računanje iznosa stavke (količina * cijena po jedinici)
            int kolicina = Convert.ToInt32(tb_kol.Text);
            decimal cijenaPoJedinici = Convert.ToDecimal(l_cijena.Text);
            decimal iznosStavke = kolicina * cijenaPoJedinici;

            // Zbrajanje iznosa stavke s trenutnim iznosom računa
            decimal trenutniIznosRacuna = Convert.ToDecimal(l_iznos_racuna.Text);
            decimal noviIznosRacuna = trenutniIznosRacuna + iznosStavke;

            // Ažuriranje labela
           l_iznos_racuna.Text = noviIznosRacuna.ToString();
        }
        
        private void bttn_dodajstavku_Click(object sender, EventArgs e)
        {
            DodajStavkuRacuna();
        }

        private void ocisti_Click(object sender, EventArgs e)
        {
            int racun_id2;
            if (!int.TryParse(l_racun_id.Text, out racun_id2))
            {
                MessageBox.Show("Neispravan format za broj računa.");
                return;
            }
            using (MySqlConnection veza2 = new MySqlConnection(upraviteljBazom.VezaNaBazu))
            {
                veza2.Open();

                string sqlUpit2 = "UPDATE Status_racuna SET status_id = 4 WHERE racun_id = @racun_id";
                using (MySqlCommand naredba = new MySqlCommand(sqlUpit2, veza2))
                {
                    naredba.Parameters.AddWithValue("@racun_id", racun_id2);
                    naredba.ExecuteNonQuery();
                }
            }
            PostaviPocetno();
        }

        private void izdaj_racun_Click(object sender, EventArgs e)
        {
            IzdavanjeRacuna();
            PostaviPocetno();
        }
        private void IzdavanjeRacuna()
        {
            try
            {
                int zaposlenik_id = DohvatiIdZaposlenika();
                int racun_id;

                if (!int.TryParse(l_racun_id.Text, out racun_id))
                {
                    MessageBox.Show("Neispravan format za broj računa.");
                    return;
                }

                DateTime datum_izdavanja = DateTime.Now;
                string formatiraniDatum = datum_izdavanja.ToString("yyyy-MM-dd HH:mm:ss");

                using (MySqlConnection veza1 = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza1.Open();

                    string sqlUpit1 = "UPDATE Racun SET zaposlenik_id = @zaposlenik_id, datum_izdavanja = STR_TO_DATE(@datum_izdavanja, '%Y-%m-%d %H:%i:%s') WHERE id = @racun_id";
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit1, veza1))
                    {
                        naredba.Parameters.AddWithValue("@zaposlenik_id", zaposlenik_id);
                        naredba.Parameters.AddWithValue("@datum_izdavanja", formatiraniDatum);
                        naredba.Parameters.AddWithValue("@racun_id", racun_id);
                        naredba.ExecuteNonQuery();
                    }
                }

                using (MySqlConnection veza2 = new MySqlConnection(upraviteljBazom.VezaNaBazu))
                {
                    veza2.Open();

                    string sqlUpit2 = "UPDATE Status_racuna SET status_id = 2 WHERE racun_id = @racun_id";
                    using (MySqlCommand naredba = new MySqlCommand(sqlUpit2, veza2))
                    {
                        naredba.Parameters.AddWithValue("@racun_id", racun_id);
                        naredba.ExecuteNonQuery();
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
