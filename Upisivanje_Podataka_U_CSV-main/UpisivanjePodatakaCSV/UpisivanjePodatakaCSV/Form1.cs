using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpisivanjePodatakaCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            txtGodinaRodjenja.Clear();
            txtPrezime.Clear();
            txtIme.Clear();
            txtEmail.Clear();
        }

        private void btnUpisi_Click(object sender, EventArgs e)
        {
            // Osoba osoba = new Osoba();


            try
            {
                Osoba osoba = new Osoba(txtIme.Text,
                    txtPrezime.Text, txtEmail.Text,
                    Convert.ToInt16(txtGodinaRodjenja.Text));

                txtGodinaRodjenja.Clear();
                txtPrezime.Clear();
                txtIme.Clear();
                txtEmail.Clear();
                txtIme.Focus();

                DialogResult upit = MessageBox.Show("Želite li unjeti još podataka?", "Upit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                switch (upit)
                {
                    case DialogResult.Yes:
                        {
                            break;
                        }

                    case DialogResult.No:
                        {
                            txtIme.Enabled = false;
                            txtPrezime.Enabled = false;
                            txtGodinaRodjenja.Enabled = false;
                            txtEmail.Enabled = false;
                            break;
                        }
                }
            }

            catch (Exception greska){
                MessageBox.Show(greska.Message, "Pogrešan unos!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }
    }
}