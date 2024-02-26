using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using MySqlConnector;

namespace ZR_BLAGAJNA_NT {
    public class UpraviteljBazom {
        private static UpraviteljBazom instanca;
        private string server;
        private string baza;
        private string korisnik;
        private string lozinka;

        public string VezaNaBazu { get; }

        public UpraviteljBazom()
        {
            // Konstruktor klase - postavlja podatke za vezu prema bazi iz konfiguracijske datoteke
            server = ConfigurationManager.AppSettings["Server"];
            baza = ConfigurationManager.AppSettings["Baza"];
            korisnik = ConfigurationManager.AppSettings["Korisnik"];
            lozinka = ConfigurationManager.AppSettings["Lozinka"];
            VezaNaBazu = $"Server={server};Database={baza};User ID={korisnik};Password={lozinka}";
        }

        // Metoda koja vraća instancu klase (SINGLETON obrazac)
        public static UpraviteljBazom DohvatiInstancu()
        {
            if (instanca == null)
            {
                instanca = new UpraviteljBazom();
            }
            return instanca;
        }

        // Metoda za povezivanje s bazom podataka
        public bool SpojiNaBazu()
        {
            try
            {
                using (MySqlConnection veza = new MySqlConnection(VezaNaBazu))
                {
                    veza.Open();
                    return true; // Veza uspješno uspostavljena
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri spajanju na bazu: {ex.Message}");
                return false; // Veza nije uspješno uspostavljena
            }
        }
    }
}
