using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpisivanjePodatakaCSV
{
    public partial class Form1 : Form
    {
        List<Osoba> listaOsoba = new List<Osoba> ();
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

                /*
                osoba.Ime = txtIme.Text;
                osoba.Prezime = txtPrezime.Text;
                osoba.Email = txtEmail.Text;
                osoba.GodinaRodjenja = Convert.ToInt16(txtGodinaRodjenja.Text);
                */

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
                            listaOsoba.Add(osoba);
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

        private void btnSpremi_Click(object sender, EventArgs e)
        {

            /*
            //txtIspis.Text = osoba.ToString();

            txtIspis.Text = "Ime  Prezime  Email  GodinaRodjenja" + Environment.NewLine;

            foreach (Osoba osoba in listaOsoba)
            {
                txtIspis.AppendText(osoba.ToString() + Environment.NewLine);
            }
            */

            string putanjaDatoteke = "C:\\Users\\Ucenik\\Documents\\testCSV";

            try
            {
                using (StreamWriter sw = new StreamWriter(putanjaDatoteke))
                {
                    sw.WriteLine("Ime,Prezime,Email,GodinaRodjenja");

                    foreach (Osoba osoba in listaOsoba)
                    {
                        sw.WriteLine($"{osoba.Ime},{osoba.Prezime},{osoba.Email}," + $"{osoba.GodinaRodjenja}");
                    }
                }

                MessageBox.Show("Podatci su uspiješno spremljeni u CSV datoteku!", "Uspijeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do pogreške prilikom spremanja podataka: " + ex.Message,
                    "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}