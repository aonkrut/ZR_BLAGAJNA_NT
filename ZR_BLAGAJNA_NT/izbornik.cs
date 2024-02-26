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

namespace ZR_BLAGAJNA_NT {
    public partial class izbornik : UserControl {
        public izbornik()
        {
            InitializeComponent();
            InitializeComponent();
        }

        private void bLAGAJNAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormAndCloseCurrent(new blagajna());
        }

        private void sKLADIŠTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormAndCloseCurrent(new skladiste());
        }

        private void zaposleniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormAndCloseCurrent(new zaposlenici());
        }

        private void dobavljačiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormAndCloseCurrent(new dobavljaci());
        }

        private void proizvodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormAndCloseCurrent(new proizvodi());
        }

        private void računiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormAndCloseCurrent(new racuni());
        }

        // Ova metoda otvara novu formu i skriva trenutnu
        private void OpenFormAndCloseCurrent(Form newForm)
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

        private void aDMINISTRACIJAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
