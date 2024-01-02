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
using System.Runtime.Serialization.Formatters.Binary;

namespace HotelPelicula
{
    public partial class AdminForma : Form
    {
        List<Control> controlsP;
        List<Control> controlsG;
        List<Control> controlsS;
        List<Control> controlsR;
        List<Control> controlsK;
        string putanja;
        public AdminForma()
        {
            InitializeComponent();
            controlsP = new List<Control>();
            controlsG = new List<Control>();
            controlsS = new List<Control>();
            controlsR = new List<Control>();
            controlsK = new List<Control>();
        }

        private void AdminForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void AdminForma_Load(object sender, EventArgs e)
        {
            PictureBox logo = new PictureBox();
            Button gost = new Button();
            Button soba = new Button();
            Button rezervacija = new Button();
            Button korisnik = new Button();

            logo.Name = "imgLogo";
            gost.Name = "btnGost";
            soba.Name = "btnSoba";
            rezervacija.Name = "btnRezervacija";
            korisnik.Name = "brnKorisnik";
            gost.Text = "Dodaj/uredi gosta";
            soba.Text = "Dodaj/uredi sobu";
            rezervacija.Text = "Dodaj/uredi rezervaciju";
            korisnik.Text = "Dodaj/uredi korisnika";
            logo.Image = Properties.Resources.logo;
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.Height = 145;
            logo.Width = 104;
            logo.Top = 60;
            logo.Left = ClientSize.Width / 2 - logo.Width / 2;
            gost.Width = soba.Width = rezervacija.Width = korisnik.Width = 150;
            gost.Height = soba.Height = rezervacija.Height = korisnik.Height = 50;
            gost.BackColor = soba.BackColor = rezervacija.BackColor = korisnik.BackColor = Color.Black;
            gost.ForeColor = soba.ForeColor = rezervacija.ForeColor = korisnik.ForeColor = Color.White;
            gost.Font = soba.Font = rezervacija.Font = korisnik.Font = new Font("Serif", 12);
            gost.Left = rezervacija.Left = ClientSize.Width / 2 - gost.Width - 5;
            soba.Left = korisnik.Left = ClientSize.Width / 2 + 5;
            gost.Top = soba.Top = logo.Bottom + 20;
            rezervacija.Top = korisnik.Top = gost.Bottom + 10;
            gost.Click += Gost_Click;
            soba.Click += Soba_Click;
            rezervacija.Click += Rezervacija_Click;
            korisnik.Click += Korisnik_Click;

            controlsP.Add(logo);
            controlsP.Add(gost);
            controlsP.Add(soba);
            controlsP.Add(rezervacija);
            controlsP.Add(korisnik);

            foreach (Control control in controlsP)
            {
                Controls.Add(control);
            }
        }

        private void Korisnik_Click(object sender, EventArgs e)
        {
            putanja = "korisnici.bin";

            if (controlsK.Count == 0)
            {
                ListBox lbKorisnici = new ListBox();
                Button dodaj = new Button();
                Button uredi = new Button();
                Button cancel = new Button();
                Button ukloni = new Button();
                TextBox ime = new TextBox();
                TextBox prezime = new TextBox();

                TextBox password = new TextBox();
                ComboBox tipKorisnika = new ComboBox();

                lbKorisnici.Left = 100;
                lbKorisnici.Top = 60;
                lbKorisnici.Width = 450;
                lbKorisnici.Height = 320;
                lbKorisnici.BackColor = Color.Black;
                lbKorisnici.ForeColor = Color.White;
                lbKorisnici.Name = "lbKorisnici";
                lbKorisnici.ScrollAlwaysVisible = true;
                lbKorisnici.Font = new Font("Serif", 8);
                dodaj.Name = "btnDodaj";
                dodaj.Left = lbKorisnici.Right + 10;
                dodaj.Top = lbKorisnici.Top;
                dodaj.BackColor = Color.Black;
                dodaj.ForeColor = Color.White;
                dodaj.Text = "Dodaj";
                dodaj.Font = new Font("Serif", 12);
                dodaj.Width = 80;
                dodaj.Height = 30;
                uredi.Name = "btnUredi";
                uredi.Left = dodaj.Left;
                uredi.Top = dodaj.Bottom + 10; ;
                uredi.BackColor = Color.Black;
                uredi.ForeColor = Color.White;
                uredi.Text = "Uredi";
                uredi.Font = new Font("Serif", 12);
                uredi.Width = 80;
                uredi.Height = 30;
                cancel.Name = "btnCancel";
                cancel.Left = dodaj.Left;
                cancel.Top = uredi.Bottom + 10; ;
                cancel.BackColor = Color.Black;
                cancel.ForeColor = Color.White;
                cancel.Text = "Otkazi";
                cancel.Font = new Font("Serif", 12);
                cancel.Width = 80;
                cancel.Height = 30;
                ukloni.Name = "btnUkloni";
                ukloni.Left = dodaj.Left;
                ukloni.Top = cancel.Bottom + 10; ;
                ukloni.BackColor = Color.Black;
                ukloni.ForeColor = Color.White;
                ukloni.Text = "Ukloni";
                ukloni.Font = new Font("Serif", 12);
                ukloni.Width = 80;
                ukloni.Height = 30;
                ime.Name = "tbIme";
                ime.Left = ukloni.Left;
                ime.Top = ukloni.Bottom + 10;
                ime.Width = 150;
                ime.Height = 25;
                ime.Font = new Font("Serif", 12);
                ime.Text = "Ime";
                ime.BackColor = Color.Black;
                ime.ForeColor = Color.White;
                ime.GotFocus += ImeKorisnik_GotFocus;
                ime.LostFocus += ImeKorisnik_LostFocus;
                prezime.Name = "tbPrezime";
                prezime.Left = ukloni.Left;
                prezime.Top = ime.Bottom + 10;
                prezime.Width = 150;
                prezime.Height = 25;
                prezime.Font = new Font("Serif", 12);
                prezime.Text = "Prezime";
                prezime.BackColor = Color.Black;
                prezime.ForeColor = Color.White;
                prezime.GotFocus += PrezimeKorisnik_GotFocus;
                prezime.LostFocus += PrezimeKorisnik_LostFocus;
                password.Width = prezime.Width;
                password.Left = ime.Left;
                password.Top = prezime.Bottom + 10;
                password.BackColor = Color.Black;
                password.ForeColor = Color.White;
                password.Font = new Font("Serif", 12);
                password.Width = prezime.Width;
                password.Text = "Sifra";
                password.Name = "tbSifra";
                password.GotFocus += PasswordKorisnik_GotFocus;
                password.LostFocus += PasswordKorisnik_LostFocus;
                tipKorisnika.Left = ime.Left;
                tipKorisnika.Top = password.Bottom + 10;
                tipKorisnika.BackColor = Color.Black;
                tipKorisnika.ForeColor = Color.White;
                tipKorisnika.Name = "cbTip";
                tipKorisnika.Items.Add("Administrator");
                tipKorisnika.Items.Add("Recepcioner");
                cancel.Click += Cancel_Click;
                dodaj.Click += Dodaj_Click;
                uredi.Click += Uredi_Click;
                ukloni.Click += Ukloni_Click;
                controlsK.Add(lbKorisnici);
                controlsK.Add(dodaj);
                controlsK.Add(uredi);
                controlsK.Add(cancel);
                controlsK.Add(ukloni);
                controlsK.Add(ime);
                controlsK.Add(prezime);
                controlsK.Add(password);
                controlsK.Add(tipKorisnika);
                foreach (Control control1 in Controls)
                {
                    control1.Hide();
                }
                foreach (Control control in controlsK)
                {
                    Controls.Add(control);
                }
            }
            else
            {
                foreach (Control control1 in Controls)
                {
                    control1.Hide();
                }
                foreach (Control control in controlsK)
                {
                    control.Show();
                }
            }

            ListBox lb = new ListBox();
            foreach (Control control1 in Controls)
            {
                if (control1.Name == "lbKorisnici")
                {
                    lb = control1 as ListBox;
                }
            }
            Stream fs = File.OpenRead(putanja);
            BinaryFormatter bf = new BinaryFormatter();
            List<Korisnik> korisnici = new List<Korisnik>();
            korisnici = bf.Deserialize(fs) as List<Korisnik>;
            fs.Close();

            foreach (Korisnik korisnik in korisnici)
            {
                lb.Items.Add(korisnik);
            }


        }

        private void PasswordKorisnik_LostFocus(object sender, EventArgs e)
        {
            TextBox password = sender as TextBox;
            if (password.Text == "" || password.Text == "Sifra")
            {
                password.Text = "Sifra";
            }
        }

        private void PasswordKorisnik_GotFocus(object sender, EventArgs e)
        {
            
            TextBox password = sender as TextBox;
            
                password.Text = "";
            
        }

        private void PrezimeKorisnik_LostFocus(object sender, EventArgs e)
        {
            TextBox prezime = sender as TextBox;
            if (prezime.Text == "" || prezime.Text == "Sifra")
            {
                prezime.Text = "Prezime";
            }
            
        }

        private void PrezimeKorisnik_GotFocus(object sender, EventArgs e)
        {
            TextBox prezime = sender as TextBox;
            prezime.Text = "";
        }

        private void ImeKorisnik_LostFocus(object sender, EventArgs e)
        {
            TextBox ime = sender as TextBox;
            if (ime.Text == "" || ime.Text == "Ime")
            {
                ime.Text = "Ime";
            }
        }

        private void ImeKorisnik_GotFocus(object sender, EventArgs e)
        {
            TextBox ime = sender as TextBox;
            ime.Text = "";
        }

        private void Ukloni_Click(object sender, EventArgs e)
        {
            ListBox lb = new ListBox();
            foreach (Control control1 in Controls)
            {
                if (control1.Name == "lbKorisnici")
                {
                    lb = control1 as ListBox;
                }
            }
            BinaryFormatter bf = new BinaryFormatter();
            List<Korisnik> korisnici = new List<Korisnik>();
            Stream fs1 = File.OpenRead(putanja);
            BinaryFormatter bf1 = new BinaryFormatter();
            korisnici.Clear();
            korisnici = bf1.Deserialize(fs1) as List<Korisnik>;
            Korisnik item = lb.SelectedItem as Korisnik;
            fs1.Close();
            int index = 0;
            if (item != null)
            {
                foreach (Korisnik korisnik in korisnici)
                {
                    if (korisnik.Ime == item.Ime && korisnik.Prezime == item.Prezime && korisnik.Korisnickoime == item.Korisnickoime && korisnik.Sifra == item.Sifra && korisnik.Vrsta == item.Vrsta)
                    {
                        break;
                    }
                    else
                    {
                        index++;
                    }
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali korisnika!");
            }

            korisnici.RemoveAt(index);
            Stream fs = File.OpenWrite(putanja);
            bf.Serialize(fs, korisnici);
            fs.Close();
            fs = File.OpenRead(putanja);
            korisnici = bf.Deserialize(fs) as List<Korisnik>;
            lb.DataSource = korisnici;
            fs.Close();
            MessageBox.Show("Uspesno ste uklonili korisnika!");
        }

        private void Uredi_Click(object sender, EventArgs e)
        {
            ListBox lb = new ListBox();
            foreach (Control control1 in Controls)
            {
                if (control1.Name == "lbKorisnici")
                {
                    lb = control1 as ListBox;
                }
            }

            TextBox ime = new TextBox();
            TextBox prezime = new TextBox();
            TextBox password = new TextBox();

            foreach (Control control in Controls)
            {
                if (control.Name == "tbIme")
                {
                    ime = control as TextBox;
                }
                if (control.Name == "tbPrezime")
                {
                    prezime = control as TextBox;
                }
                if (control.Name == "tbSifra")
                {
                    password = control as TextBox;
                }

            }

            BinaryFormatter bf = new BinaryFormatter();
            List<Korisnik> korisnici = new List<Korisnik>();
            Stream fs1 = File.OpenRead(putanja);
            BinaryFormatter bf1 = new BinaryFormatter();
            korisnici.Clear();
            korisnici = bf1.Deserialize(fs1) as List<Korisnik>;
            Korisnik item = lb.SelectedItem as Korisnik;
            fs1.Close();
            int index = 0;
            if (item != null)
            {
                foreach (Korisnik korisnik in korisnici)
                {
                    if (korisnik.Ime == item.Ime && korisnik.Prezime == item.Prezime && korisnik.Korisnickoime == item.Korisnickoime && korisnik.Sifra == item.Sifra && korisnik.Vrsta == item.Vrsta)
                    {
                        break;
                    }
                    else
                    {
                        index++;
                    }
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali korisnika!");
            }


            if (ime.Text == "" || ime.Text.ToLower() == "ime")
            {
                ime.Text = korisnici[index].Ime;
            }
            if (prezime.Text == "" || prezime.Text.ToLower() == "prezime")
            {
                prezime.Text = korisnici[index].Prezime;
            }
            if (password.Text == "" || password.Text.ToLower() == "sifra")
            {
                password.Text = korisnici[index].Sifra;
            }
            korisnici[index].Ime = ime.Text;
            korisnici[index].Prezime = prezime.Text;
            korisnici[index].Sifra = password.Text;
            Stream fs = File.OpenWrite(putanja);
            bf.Serialize(fs, korisnici);
            fs.Close();
            fs = File.OpenRead(putanja);
            korisnici = bf.Deserialize(fs) as List<Korisnik>;
            lb.DataSource = korisnici;
            fs.Close();
            MessageBox.Show("Uspesno ste uredili korisnika!");
        }

        private void Dodaj_Click(object sender, EventArgs e)
        {

            List<Korisnik> korisnik = new List<Korisnik>();
            TextBox ime = new TextBox();
            TextBox prezime = new TextBox();
            TextBox password = new TextBox();
            ComboBox tipKorisnika = new ComboBox();
            foreach (Control control in Controls)
            {
                if (control.Name == "tbIme")
                {
                    ime = control as TextBox;
                }
                if (control.Name == "tbPrezime")
                {
                    prezime = control as TextBox;
                }
                if (control.Name == "tbSifra")
                {
                    password = control as TextBox;
                }
                if (control.Name == "cbTip")
                {
                    tipKorisnika = control as ComboBox;
                }
            }
            Stream fs = File.OpenRead(putanja);
            BinaryFormatter bf = new BinaryFormatter();
            List<Korisnik> korisnici = new List<Korisnik>();
            korisnici = bf.Deserialize(fs) as List<Korisnik>;
            fs.Close();
            if ((ime.Text != "" && ime.Text.ToLower() != "ime") && (prezime.Text != "" && prezime.Text.ToLower() != "prezime") && (password.Text != "" && password.Text.ToLower() != "sifra") && tipKorisnika.SelectedItem != null)
            {
                Korisnik korisnik1 = new Korisnik(korisnici[korisnici.Count - 1].Id + 1, ime.Text, prezime.Text, password.Text, tipKorisnika.SelectedItem.ToString());
                korisnici.Add(korisnik1);
                fs = File.OpenWrite(putanja);
                bf.Serialize(fs, korisnici);
                fs.Close();

                ListBox lb = new ListBox();
                foreach (Control control1 in Controls)
                {
                    if (control1.Name == "lbKorisnici")
                    {
                        lb = control1 as ListBox;
                    }
                }
                lb.DataSource = korisnici;
                MessageBox.Show("Uspesno ste dodali korisnika!");
            }
            else
            {
                MessageBox.Show("Niste uneli sve podatke!");
            }
        }
        Label ukupnaCena = new Label();
        private void Rezervacija_Click(object sender, EventArgs e)
        {
            putanja = "rezervacije.bin";
            
            if (controlsR.Count == 0)
            {
                ListBox lbRezervacije = new ListBox();
                ListBox lbGosti = new ListBox();
                ListBox lbSobe = new ListBox();
                Button dodaj = new Button();
                Button uredi = new Button();
                Button cancel = new Button();
                Button ukloni = new Button();
                DateTimePicker datumOd = new DateTimePicker();
                DateTimePicker datumDo = new DateTimePicker();
                ComboBox tipRezervacije = new ComboBox();
                
                this.Width = 1900;
                this.Height = 900;
                lbGosti.Left = 100;
                lbGosti.Top = 100;
                lbGosti.Width = 300;
                lbGosti.Height = 500;
                lbGosti.BackColor = Color.Black;
                lbGosti.ForeColor = Color.White;
                lbGosti.Name = "lbGosti";
                lbGosti.ScrollAlwaysVisible = true;
                lbGosti.Font = new Font("Serif", 8);
                lbSobe.Left = lbGosti.Right + 10;
                lbSobe.Top = 100;
                lbSobe.Width = 300;
                lbSobe.Height = 500;
                lbSobe.BackColor = Color.Black;
                lbSobe.ForeColor = Color.White;
                lbSobe.Name = "lbSobe";
                lbSobe.ScrollAlwaysVisible = true;
                lbSobe.Font = new Font("Serif", 8);
                lbRezervacije.Left = lbSobe.Right + 10;
                lbRezervacije.Top = 100;
                lbRezervacije.Width = 300;
                lbRezervacije.Height = 500;
                lbRezervacije.BackColor = Color.Black;
                lbRezervacije.ForeColor = Color.White;
                lbRezervacije.Name = "lbRezervacije";
                lbRezervacije.ScrollAlwaysVisible = true;
                lbRezervacije.HorizontalScrollbar = true;
                lbRezervacije.Font = new Font("Serif", 8);
                dodaj.Name = "btnDodaj";
                dodaj.Left = lbRezervacije.Right + 10;
                dodaj.Top = lbRezervacije.Top;
                dodaj.BackColor = Color.Black;
                dodaj.ForeColor = Color.White;
                dodaj.Text = "Dodaj";
                dodaj.Font = new Font("Serif", 12);
                dodaj.Width = 80;
                dodaj.Height = 30;
                uredi.Name = "btnUredi";
                uredi.Left = dodaj.Left;
                uredi.Top = dodaj.Bottom + 10; ;
                uredi.BackColor = Color.Black;
                uredi.ForeColor = Color.White;
                uredi.Text = "Uredi";
                uredi.Font = new Font("Serif", 12);
                uredi.Width = 80;
                uredi.Height = 30;
                cancel.Name = "btnCancel";
                cancel.Left = dodaj.Left;
                cancel.Top = uredi.Bottom + 10; ;
                cancel.BackColor = Color.Black;
                cancel.ForeColor = Color.White;
                cancel.Text = "Otkazi";
                cancel.Font = new Font("Serif", 12);
                cancel.Width = 80;
                cancel.Height = 30;
                ukloni.Name = "btnUkloni";
                ukloni.Left = dodaj.Left;
                ukloni.Top = cancel.Bottom + 10;
                ukloni.BackColor = Color.Black;
                ukloni.ForeColor = Color.White;
                ukloni.Text = "Ukloni";
                ukloni.Font = new Font("Serif", 12);
                ukloni.Width = 80;
                ukloni.Height = 30;
                datumOd.Left = ukloni.Left;
                datumOd.Top = ukloni.Bottom + 10;
                datumOd.Name = "dpDatumOd";
                datumDo.Left = ukloni.Left;
                datumDo.Top = datumOd.Bottom + 10;
                datumDo.Name = "dpDatumDo";
                tipRezervacije.Left = ukloni.Left;
                tipRezervacije.Top = datumDo.Bottom + 10;
                tipRezervacije.Width = datumDo.Width;
                tipRezervacije.BackColor = Color.Black;
                tipRezervacije.ForeColor = Color.White;
                tipRezervacije.Items.Add("Samo nocenje");
                tipRezervacije.Items.Add("Dorucak");
                tipRezervacije.Items.Add("Polu pansion");
                tipRezervacije.Items.Add("Ceo pansion");
                tipRezervacije.Name = "cbTip";
                ukupnaCena.Left = ukloni.Left;
                ukupnaCena.Top = tipRezervacije.Bottom + 10;
                ukupnaCena.Text = "Ukupna cena: ";
                ukupnaCena.BackColor = Color.White;
                ukupnaCena.Width = datumDo.Width;
                ukupnaCena.Font = new Font("Serif", 12);
                ukupnaCena.Name = "lbCena";
                dodaj.Click += DodajRezervaciju_Click1;
                ukloni.Click += UkloniRezervaciju_Click1;
                cancel.Click += Cancel_Click;
                uredi.Click += UrediRezervaciju_Click1; 
                controlsR.Add(lbGosti);
                controlsR.Add(lbSobe);
                controlsR.Add(lbRezervacije);
                controlsR.Add(dodaj);
                controlsR.Add(uredi);
                controlsR.Add(cancel);
                controlsR.Add(ukloni);
                controlsR.Add(datumOd);
                controlsR.Add(datumDo);
                controlsR.Add(tipRezervacije);
                controlsR.Add(ukupnaCena);
                foreach (Control control1 in Controls)
                {
                    control1.Hide();
                }
                foreach (Control control in controlsR)
                {
                    Controls.Add(control);
                }
            }
            else
            {
                foreach (Control control1 in Controls)
                {
                    control1.Hide();
                }
                foreach (Control control in controlsR)
                {
                    control.Show();
                    this.Width = 1000;
                    this.Height = 500;
                }
            }
            List<Gost> gosti = new List<Gost>();
            List<Soba> sobe = new List<Soba>();
            gosti.Clear();
            sobe.Clear();
            List<Rezervacija> rezervacije = new List<Rezervacija>();
            ListBox lbGosti1 = new ListBox();
            ListBox lbSobe1 = new ListBox();
            ListBox lbRezervacije1 = new ListBox();
            Stream fs = File.OpenRead("gosti.bin");
            BinaryFormatter bf = new BinaryFormatter();
            gosti = bf.Deserialize(fs) as List<Gost>;
            fs.Close();
            fs = File.OpenRead("sobe.bin");
            sobe = bf.Deserialize(fs) as List<Soba>;
            fs.Close();
            foreach (Control control2 in Controls)
            {
                if(control2.Name == "lbGosti")
                {
                    lbGosti1 = control2 as ListBox;
                }
                if (control2.Name == "lbSobe")
                {
                    lbSobe1 = control2 as ListBox;
                }
                if (control2.Name == "lbRezervacije")
                {
                    lbRezervacije1 = control2 as ListBox;
                }
            }
            lbGosti1.DataSource = gosti;
            foreach (Soba soba in sobe)
            {
                if (soba.proveriDostupnost())
                {
                    lbSobe1.Items.Add(soba);
                }
            }
            if (File.Exists(putanja))
            {
                fs = File.OpenRead(putanja);
                rezervacije = bf.Deserialize(fs) as List<Rezervacija>;
                fs.Close();
                lbRezervacije1.DataSource = rezervacije;
            }
        }

        private void UrediRezervaciju_Click1(object sender, EventArgs e)
        {
            List<Rezervacija> rezervacije = new List<Rezervacija>();
            ComboBox tipRezervacije = new ComboBox();
            ListBox lbRezervacije1 = new ListBox();

            foreach (Control control2 in Controls)
            {
                if (control2.Name == "lbRezervacije")
                {
                    lbRezervacije1 = control2 as ListBox;
                }
                if(control2.Name == "cbTip")
                {
                    tipRezervacije = control2 as ComboBox;
                }
            }
            Rezervacija item = lbRezervacije1.SelectedItem as Rezervacija;
            if (item != null)
            {
                int index = 0;
                Stream fs = File.OpenRead(putanja);
                BinaryFormatter bf = new BinaryFormatter();
                rezervacije = bf.Deserialize(fs) as List<Rezervacija>;
                fs.Close();
                foreach (Rezervacija rezervacija in rezervacije)
                {
                    if (item.Id == rezervacija.Id)
                    {
                        break;
                    }
                    else
                    {
                        index++;
                    }
                }
                
                rezervacije[index].Tip = tipRezervacije.SelectedItem.ToString();
                fs = File.OpenWrite(putanja);
                bf.Serialize(fs, rezervacije);
                fs.Close();
                lbRezervacije1.DataSource = rezervacije;
                MessageBox.Show("Uspesno ste uredili rezervaciju!");
            }
            else
            {
                MessageBox.Show("Izaberite rezervaciju koju zelite da uredite!");
            }
        }

        private void UkloniRezervaciju_Click1(object sender, EventArgs e)
        {

            List<Soba> sobe = new List<Soba>();
            List<Rezervacija> rezervacije = new List<Rezervacija>();
            
            ListBox lbSobe1 = new ListBox();
            ListBox lbRezervacije1 = new ListBox();
            
            foreach (Control control2 in Controls)
            {
                
                if (control2.Name == "lbSobe")
                {
                    lbSobe1 = control2 as ListBox;
                }
                if (control2.Name == "lbRezervacije")
                {
                    lbRezervacije1 = control2 as ListBox;
                }
                
                
            }
            Rezervacija item = lbRezervacije1.SelectedItem as Rezervacija;
            if (item != null)
            {
                int index = 0;
                Stream fs = File.OpenRead(putanja);
                BinaryFormatter bf = new BinaryFormatter();
                rezervacije = bf.Deserialize(fs) as List<Rezervacija>;
                fs.Close();
                fs = File.OpenRead("sobe.bin");
                sobe = bf.Deserialize(fs) as List<Soba>;
                fs.Close();
                foreach (Rezervacija rezervacija in rezervacije)
                {
                    if(item.Id == rezervacija.Id)
                    {
                        break;
                    }
                    else
                    {
                        index++;
                    }
                }
                rezervacije.RemoveAt(index);
                foreach (Soba soba in sobe)
                {
                    if(item.Idsobe == soba.Id)
                    {
                        soba.dostupna();
                        break;
                    }
                }
                fs = File.OpenWrite(putanja);
                bf.Serialize(fs, rezervacije);
                fs.Close();
                fs = File.OpenWrite("sobe.bin");
                bf.Serialize(fs, sobe);
                fs.Close();
                lbRezervacije1.DataSource = rezervacije;
                lbSobe1.Items.Clear();
                foreach (Soba soba1 in sobe)
                {
                    if (soba1.proveriDostupnost())
                    {
                        lbSobe1.Items.Add(soba1);
                    }
                }
            }
            else
            {
                MessageBox.Show("Izaberite rezervaciju koju zelite da uklonite!");
            }
        }
            

        private void DodajRezervaciju_Click1(object sender, EventArgs e)
        {
            List<Gost> gosti = new List<Gost>();
            List<Soba> sobe = new List<Soba>();
            List<Rezervacija> rezervacije = new List<Rezervacija>();
            ListBox lbGosti1 = new ListBox();
            ListBox lbSobe1 = new ListBox();
            ListBox lbRezervacije1 = new ListBox();
            DateTimePicker datumOd = new DateTimePicker();
            DateTimePicker datumDo = new DateTimePicker();
            ComboBox tipRezervacije = new ComboBox();
            Label cena = new Label();
            foreach (Control control2 in Controls)
            {
                if (control2.Name == "lbGosti")
                {
                    lbGosti1 = control2 as ListBox;
                }
                if (control2.Name == "lbSobe")
                {
                    lbSobe1 = control2 as ListBox;
                }
                if (control2.Name == "lbRezervacije")
                {
                    lbRezervacije1 = control2 as ListBox;
                }
                if (control2.Name == "dpDatumOd")
                {
                    datumOd = control2 as DateTimePicker;
                }
                if (control2.Name == "dpDatumDo")
                {
                    datumDo = control2 as DateTimePicker;
                }
                if (control2.Name == "cbTip")
                {
                    tipRezervacije = control2 as ComboBox;
                }
                if (control2.Name == "lbCena")
                {
                    cena = control2 as Label;
                }
            }
            Stream fs = File.OpenRead("gosti.bin");
            BinaryFormatter bf = new BinaryFormatter();
            gosti = bf.Deserialize(fs) as List<Gost>;
            fs.Close();
            fs = File.OpenRead("sobe.bin");
            sobe = bf.Deserialize(fs) as List<Soba>;
            fs.Close();
            Gost item = null;
            Soba item1 = null;
            if (!File.Exists(putanja))
            { 
                item = lbGosti1.SelectedItem as Gost;
                item1 = lbSobe1.SelectedItem as Soba;
                if(item != null && item1 != null)
                {
                    FileStream fs1 = new FileStream(putanja, FileMode.Create);
                    double ukcena = item1.Cena + 500;
                    Rezervacija rezervacija = new Rezervacija(1, item1.Id, item.Id, datumOd.Value.Date, datumDo.Value.Date, ukcena, tipRezervacije.SelectedItem.ToString());
                    rezervacije.Add(rezervacija);
                    bf.Serialize(fs1, rezervacije);
                    lbRezervacije1.DataSource = rezervacije;
                    fs1.Close();
                    foreach (Soba soba1 in sobe)
                    {
                        if(soba1.Id == item1.Id)
                        {
                            soba1.nedstupna();
                        }
                    }
                    Stream fs2 = File.OpenWrite("sobe.bin");
                    bf.Serialize(fs2, sobe);
                    fs2.Close();
                    fs2 = File.OpenRead("sobe.bin");
                    sobe = bf.Deserialize(fs2) as List<Soba>;
                    fs2.Close();
                    lbSobe1.Items.Clear();
                    foreach (Soba soba in sobe)
                    {
                        if (soba.proveriDostupnost())
                        {
                            lbSobe1.Items.Add(soba);
                        }
                    }
                    MessageBox.Show("Uspesno ste uklonili rezervaciju!");
                    
                }
                else
                {
                    MessageBox.Show("Niste izbrali sobu i gosta!");
                }
                
            }
            else
            {
                item = lbGosti1.SelectedItem as Gost;
                item1 = lbSobe1.SelectedItem as Soba;
                if (item != null && item1 != null)
                {
                    Stream fs1 = File.OpenRead(putanja);
                    rezervacije = bf.Deserialize(fs1) as List<Rezervacija>;
                    fs1.Close();
                    double ukcena = item1.Cena + 500;
                    Rezervacija rezervacija = new Rezervacija(rezervacije[rezervacije.Count - 1].Id + 1, item1.Id, item.Id, datumOd.Value.Date, datumDo.Value.Date, ukcena, tipRezervacije.SelectedItem.ToString());
                    rezervacije.Add(rezervacija);
                    fs1 = File.OpenWrite(putanja);
                    bf.Serialize(fs1, rezervacije);
                    lbRezervacije1.DataSource = rezervacije;
                    fs1.Close();
                    foreach (Soba soba1 in sobe)
                    {
                        if (soba1.Id == item1.Id)
                        {
                            soba1.nedstupna();
                        }
                    }
                    Stream fs2 = File.OpenWrite("sobe.bin");
                    bf.Serialize(fs2, sobe);
                    fs2.Close();
                    fs2 = File.OpenRead("sobe.bin");
                    sobe = bf.Deserialize(fs2) as List<Soba>;
                    fs2.Close();
                    lbSobe1.Items.Clear();
                    foreach (Soba soba in sobe)
                    {
                        if (soba.proveriDostupnost())
                        {
                            lbSobe1.Items.Add(soba);
                        }
                    }
                    MessageBox.Show("Uspesno ste dodali rezervaciju!");
                }
                else
                {
                    MessageBox.Show("Niste izbrali sobu i gosta!");
                }
            }
        }

        private void Soba_Click(object sender, EventArgs e)
        {
            putanja = "sobe.bin";
            if (controlsS.Count == 0)
            {
                ListBox lbSobe = new ListBox();
                Button dodaj = new Button();
                Button uredi = new Button();
                Button cancel = new Button();
                Button ukloni = new Button();

                ComboBox brojKreveta = new ComboBox();
                ComboBox tipSobe = new ComboBox();
                TextBox cena = new TextBox();
                TextBox popust = new TextBox();
                TextBox minimalnoDana = new TextBox();

                lbSobe.Left = 100;
                lbSobe.Top = 60;
                lbSobe.Width = 450;
                lbSobe.Height = 320;
                lbSobe.BackColor = Color.Black;
                lbSobe.ForeColor = Color.White;
                lbSobe.Name = "lbSobe";
                lbSobe.ScrollAlwaysVisible = true;
                lbSobe.Font = new Font("Serif", 8);
                dodaj.Name = "btnDodaj";
                dodaj.Left = lbSobe.Right + 10;
                dodaj.Top = lbSobe.Top;
                dodaj.BackColor = Color.Black;
                dodaj.ForeColor = Color.White;
                dodaj.Text = "Dodaj";
                dodaj.Font = new Font("Serif", 12);
                dodaj.Width = 80;
                dodaj.Height = 30;
                dodaj.Click += DodajSobu_Click1;
                uredi.Name = "btnUredi";
                uredi.Left = dodaj.Left;
                uredi.Top = dodaj.Bottom + 10; ;
                uredi.BackColor = Color.Black;
                uredi.ForeColor = Color.White;
                uredi.Text = "Uredi";
                uredi.Font = new Font("Serif", 12);
                uredi.Width = 80;
                uredi.Height = 30;
                uredi.Click += UrediSoba_Click1;
                cancel.Name = "btnCancel";
                cancel.Left = dodaj.Left;
                cancel.Top = uredi.Bottom + 10; ;
                cancel.BackColor = Color.Black;
                cancel.ForeColor = Color.White;
                cancel.Text = "Otkazi";
                cancel.Font = new Font("Serif", 12);
                cancel.Width = 80;
                cancel.Height = 30;
                ukloni.Name = "btnUkloni";
                ukloni.Left = dodaj.Left;
                ukloni.Top = cancel.Bottom + 10; ;
                ukloni.BackColor = Color.Black;
                ukloni.ForeColor = Color.White;
                ukloni.Text = "Ukloni";
                ukloni.Font = new Font("Serif", 12);
                ukloni.Width = 80;
                ukloni.Height = 30;
                ukloni.Click += UkloniSobu_Click1;
                brojKreveta.Name = "cbBrojKreveta";
                brojKreveta.Left = ukloni.Left;
                brojKreveta.Top = ukloni.Bottom + 10;
                brojKreveta.BackColor = Color.Black;
                brojKreveta.ForeColor = Color.White;
                brojKreveta.Items.Add(1);
                brojKreveta.Items.Add(2);
                brojKreveta.Items.Add(3);
                brojKreveta.Items.Add(4);
                tipSobe.Name = "cbTipSobe";
                tipSobe.Left = brojKreveta.Left;
                tipSobe.Top = brojKreveta.Bottom + 10;
                tipSobe.BackColor = Color.Black;
                tipSobe.ForeColor = Color.White;
                tipSobe.Items.Add("standard");
                tipSobe.Items.Add("lux");
                cena.Name = "tbCena";
                cena.Left = ukloni.Left;
                cena.Top = tipSobe.Bottom + 10;
                cena.Width = tipSobe.Width;
                cena.Height = 20;
                cena.Font = new Font("Serif", 12);
                cena.Text = "Cena";
                cena.BackColor = Color.Black;
                cena.ForeColor = Color.White;
                cena.GotFocus += CenaSobe_GotFocus;
                cena.LostFocus += CenaSobe_LostFocus;
                popust.Name = "tbPopust";
                popust.Left = ukloni.Left;
                popust.Top = cena.Bottom + 10;
                popust.Width = cena.Width;
                popust.Height = 20;
                popust.Font = new Font("Serif", 12);
                popust.Text = "Popust";
                popust.BackColor = Color.Black;
                popust.ForeColor = Color.White;
                popust.GotFocus += PopustSoba_GotFocus;
                popust.LostFocus += PopustSoba_LostFocus;
                minimalnoDana.Name = "tbDani";
                minimalnoDana.Left = ukloni.Left;
                minimalnoDana.Top = popust.Bottom + 10;
                minimalnoDana.Width = tipSobe.Width;
                minimalnoDana.Height = 20;
                minimalnoDana.Font = new Font("Serif", 12);
                minimalnoDana.Text = "Minimalno dana";
                minimalnoDana.BackColor = Color.Black;
                minimalnoDana.ForeColor = Color.White;
                minimalnoDana.GotFocus += MinimalnoDanaSoba_GotFocus;
                minimalnoDana.LostFocus += MinimalnoDanaSoba_LostFocus;
                cancel.Click += Cancel_Click;

                controlsS.Add(lbSobe);
                controlsS.Add(dodaj);
                controlsS.Add(uredi);
                controlsS.Add(cancel);
                controlsS.Add(ukloni);
                controlsS.Add(brojKreveta);
                controlsS.Add(tipSobe);
                controlsS.Add(cena);
                controlsS.Add(popust);
                controlsS.Add(minimalnoDana);
                foreach (Control control1 in Controls)
                {
                    control1.Hide();
                }
                foreach (Control control in controlsS)
                {
                    Controls.Add(control);
                }
            }
            else
            {
                foreach (Control control1 in Controls)
                {
                    control1.Hide();
                }
                foreach (Control control in controlsS)
                {
                    control.Show();
                }
            }
            if (File.Exists(putanja))
            {
                Stream fs = File.OpenRead(putanja);
                BinaryFormatter bf = new BinaryFormatter();
                List<Soba> sobe = new List<Soba>();
                ListBox lbSobe = new ListBox();
                sobe = bf.Deserialize(fs) as List<Soba>;
                fs.Close();
                foreach (Control control in Controls)
                {
                    if(control.Name == "lbSobe")
                    {
                        lbSobe = control as ListBox;
                    }
                }
                lbSobe.DataSource = sobe;
            }
        }

        private void UrediSoba_Click1(object sender, EventArgs e)
        {
            List<Soba> sobe = new List<Soba>();
            ListBox lbSobe = new ListBox();
            ComboBox brojKreveta = new ComboBox();
            ComboBox tipSobe = new ComboBox();
            TextBox cena = new TextBox();
            TextBox popust = new TextBox();
            TextBox minDana = new TextBox();
            foreach (Control control in Controls)
            {
                if (control.Name == "cbBrojKreveta")
                {
                    brojKreveta = control as ComboBox;
                }
                if (control.Name == "cbTipSobe")
                {
                    tipSobe = control as ComboBox;
                }
                if (control.Name == "tbCena")
                {
                    cena = control as TextBox;
                }
                if (control.Name == "tbPopust")
                {
                    popust = control as TextBox;
                }
                if (control.Name == "tbDani")
                {
                    minDana = control as TextBox;
                }
                if (control.Name == "lbSobe")
                {
                    lbSobe = control as ListBox;
                }
            }
            if (lbSobe.Items.Count > 0)
            {
                Stream fs = File.OpenRead(putanja);
                BinaryFormatter bf = new BinaryFormatter();
                sobe.Clear();
                sobe = bf.Deserialize(fs) as List<Soba>;
                Soba item = lbSobe.SelectedItem as Soba;
                fs.Close();

                for (int i = 0; i < sobe.Count; i++)
                {
                    if (sobe[i].Id == item.Id)
                    {
                        if (brojKreveta.SelectedItem != null || tipSobe.SelectedItem != null || double.TryParse(cena.Text, out double cena1) || int.TryParse(popust.Text, out int popust1) || int.TryParse(minDana.Text, out int dani))
                        {
                            if(brojKreveta.SelectedItem != null)
                            {
                                sobe[i].Brojkreveta = int.Parse(brojKreveta.SelectedItem.ToString());
                            }
                            if(tipSobe.SelectedItem != null)
                            {
                                sobe[i].Tipsobe = tipSobe.SelectedItem.ToString();
                            }
                            double.TryParse(cena.Text, out double cena2);
                            if (sobe[i].Cena != cena2)
                            {
                                sobe[i].Cena = cena2;
                            }
                            int.TryParse(popust.Text, out int popust2);
                            if (sobe[i].Popust != popust2)
                            {
                                sobe[i].Popust = popust2;
                            }
                            int.TryParse(minDana.Text, out int minDana2);
                            if (sobe[i].Minbrdana != minDana2)
                            {
                                sobe[i].Minbrdana = minDana2;
                            }
                            fs = File.OpenWrite(putanja);
                            bf.Serialize(fs, sobe);
                            fs.Close();
                            lbSobe.DataSource = sobe;
                            MessageBox.Show("Uredili ste sobu");
                            break; 
                        }
                        else
                        {
                            MessageBox.Show("Niste uneli podatke za azuriranje!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lista soba je prazna!");
            }
        }

        private void UkloniSobu_Click1(object sender, EventArgs e)
        {
            List<Soba> sobe = new List<Soba>();
            ListBox lbSobe = new ListBox();
            foreach (Control control in Controls)
            {
                if (control.Name == "lbSobe")
                {
                    lbSobe = control as ListBox;
                }
            }
            if (lbSobe.Items.Count > 0)
            {
                Stream fs = File.OpenRead(putanja);
                BinaryFormatter bf = new BinaryFormatter();
                sobe.Clear();
                sobe = bf.Deserialize(fs) as List<Soba>;
                Soba item = lbSobe.SelectedItem as Soba;
                fs.Close();
                
                for (int i = 0; i < sobe.Count; i++)
                {
                    if (sobe[i].Id == item.Id)
                    {
                        sobe.RemoveAt(i);
                        fs = File.OpenWrite(putanja);
                        bf.Serialize(fs, sobe);
                        lbSobe.DataSource = sobe;
                        fs.Close();
                        MessageBox.Show("Uklonili ste sobu");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Lista soba je prazna!");
            }
        }

        private void DodajSobu_Click1(object sender, EventArgs e)
        {
            List<Soba> sobe = new List<Soba>();
            ComboBox brojKreveta = new ComboBox();
            ComboBox tipSobe = new ComboBox();
            TextBox cena = new TextBox();
            TextBox popust = new TextBox();
            TextBox minDana = new TextBox();
            ListBox lbSobe = new ListBox();
            foreach (Control control in Controls)
            {
                if(control.Name == "cbBrojKreveta")
                {
                    brojKreveta = control as ComboBox;
                }
                if(control.Name == "cbTipSobe")
                {
                    tipSobe = control as ComboBox;
                }
                if(control.Name == "tbCena")
                {
                    cena = control as TextBox;
                }
                if(control.Name == "tbPopust")
                {
                    popust = control as TextBox;
                }
                if(control.Name == "tbDani")
                {
                    minDana = control as TextBox;
                }
                if(control.Name == "lbSobe")
                {
                    lbSobe = control as ListBox;
                }
            }
            if (!File.Exists(putanja))
            {
                FileStream fs = new FileStream(putanja, FileMode.Create);
                fs.Close();
                Stream fs1 = File.OpenWrite(putanja);
                BinaryFormatter bf = new BinaryFormatter();
                double cena1 = double.Parse(cena.Text) * int.Parse(minDana.Text) * (1 - double.Parse(popust.Text) / 100);
                Soba soba = new Soba(1, int.Parse(brojKreveta.SelectedItem.ToString()), tipSobe.SelectedItem.ToString(), cena1, int.Parse(popust.Text), int.Parse(minDana.Text));
                sobe.Add(soba);
                bf.Serialize(fs1, sobe);
                lbSobe.DataSource = sobe;
                fs1.Close();
                MessageBox.Show("Uspesno ste dodali sobu!");
            }
            else
            {
                Stream fs1 = File.OpenRead(putanja);
                BinaryFormatter bf = new BinaryFormatter();
                sobe.Clear();
                sobe = bf.Deserialize(fs1) as List<Soba>;
                lbSobe.DataSource = sobe;
                fs1.Close();


                double cena1 = double.Parse(cena.Text) * int.Parse(minDana.Text) * (1 - double.Parse(popust.Text) / 100);
                Soba soba = new Soba(sobe[sobe.Count - 1].Brojsobe + 1, int.Parse(brojKreveta.SelectedItem.ToString()), tipSobe.SelectedItem.ToString(), cena1, int.Parse(popust.Text), int.Parse(minDana.Text));
                    sobe.Add(soba);
                    fs1 = File.OpenWrite(putanja);
                    bf.Serialize(fs1, sobe);
                    fs1.Close();
                    fs1 = File.OpenRead(putanja);
                    sobe.Clear();
                    sobe = bf.Deserialize(fs1) as List<Soba>;
                    lbSobe.DataSource = sobe;
                    fs1.Close();
                    MessageBox.Show("Uspesno ste dodali sobu!");
                
                }
        }

        private void MinimalnoDanaSoba_LostFocus(object sender, EventArgs e)
        {
            TextBox minDana = sender as TextBox;
            if (minDana.Text == "" || minDana.Text == "Minimalno dana")
            {
                minDana.Text = "Minimalno dana";
            }
        }

        private void MinimalnoDanaSoba_GotFocus(object sender, EventArgs e)
        {
            TextBox minDana = sender as TextBox;
            minDana.Text = "";
        }

        private void PopustSoba_LostFocus(object sender, EventArgs e)
        {
            TextBox popust = sender as TextBox;
            if (popust.Text == "" || popust.Text == "Popust")
            {
                popust.Text = "Popust";
            }
        }

        private void PopustSoba_GotFocus(object sender, EventArgs e)
        {
            TextBox popust = sender as TextBox;
            popust.Text = "";
        }

        private void CenaSobe_LostFocus(object sender, EventArgs e)
        {
            TextBox cena = sender as TextBox;
            if (cena.Text == "" || cena.Text == "Cena")
            {
                cena.Text = "Cena";
            }
        }

        private void CenaSobe_GotFocus(object sender, EventArgs e)
        {
            TextBox cena = sender as TextBox;
            cena.Text = "";
        }

        private void Gost_Click(object sender, EventArgs e)
        {
            putanja = "gosti.bin";
            if (controlsG.Count == 0)
            {
                ListBox lbGosti = new ListBox();
                Button dodaj = new Button();
                Button uredi = new Button();
                Button cancel = new Button();
                Button ukloni = new Button();
                TextBox ime = new TextBox();
                TextBox prezime = new TextBox();
                DateTimePicker datum = new DateTimePicker();
                TextBox broj = new TextBox();

                lbGosti.Left = 100;
                lbGosti.Top = 60;
                lbGosti.Width = 450;
                lbGosti.Height = 320;
                lbGosti.BackColor = Color.Black;
                lbGosti.ForeColor = Color.White;
                lbGosti.Name = "lbGosti";
                lbGosti.ScrollAlwaysVisible = true;
                lbGosti.Font = new Font("Serif", 8);
                dodaj.Name = "btnDodaj";
                dodaj.Left = lbGosti.Right + 30;
                dodaj.Top = lbGosti.Top;
                dodaj.BackColor = Color.Black;
                dodaj.ForeColor = Color.White;
                dodaj.Text = "Dodaj";
                dodaj.Font = new Font("Serif", 12);
                dodaj.Width = 80;
                dodaj.Height = 30;
                uredi.Name = "btnUredi";
                uredi.Left = dodaj.Left;
                uredi.Top = dodaj.Bottom + 10; ;
                uredi.BackColor = Color.Black;
                uredi.ForeColor = Color.White;
                uredi.Text = "Uredi";
                uredi.Font = new Font("Serif", 12);
                uredi.Width = 80;
                uredi.Height = 30;
                cancel.Name = "btnCancel";
                cancel.Left = dodaj.Left;
                cancel.Top = uredi.Bottom + 10; ;
                cancel.BackColor = Color.Black;
                cancel.ForeColor = Color.White;
                cancel.Text = "Otkazi";
                cancel.Font = new Font("Serif", 12);
                cancel.Width = 80;
                cancel.Height = 30;
                ukloni.Name = "btnUkloni";
                ukloni.Left = dodaj.Left;
                ukloni.Top = cancel.Bottom + 10; ;
                ukloni.BackColor = Color.Black;
                ukloni.ForeColor = Color.White;
                ukloni.Text = "Ukloni";
                ukloni.Font = new Font("Serif", 12);
                ukloni.Width = 80;
                ukloni.Height = 30;
                ime.Name = "tbIme";
                ime.Left = ukloni.Left;
                ime.Top = ukloni.Bottom + 10;
                ime.Width = datum.Width;
                ime.Height = 25;
                ime.Font = new Font("Serif", 12);
                ime.Text = "ime";
                ime.BackColor = Color.Black;
                ime.ForeColor = Color.White;
                ime.GotFocus += ImeGost_GotFocus;
                ime.LostFocus += ImeGost_LostFocus;
                prezime.Name = "tbPrezime";
                prezime.Left = ukloni.Left;
                prezime.Top = ime.Bottom + 10;
                prezime.Width = datum.Width;
                prezime.Height = 25;
                prezime.Font = new Font("Serif", 12);
                prezime.Text = "prezime";
                prezime.BackColor = Color.Black;
                prezime.ForeColor = Color.White;
                prezime.GotFocus += PrezimeGost_GotFocus;
                prezime.LostFocus += PrezimeGost_LostFocus;
                datum.Left = ukloni.Left;
                datum.Top = prezime.Bottom + 10;
                datum.Name = "dtpDatum";
                broj.Name = "tbBroj";
                broj.Left = ukloni.Left;
                broj.Top = datum.Bottom + 10;
                broj.Width = datum.Width;
                broj.Height = 25;
                broj.Font = new Font("Serif", 12);
                broj.Text = "Broj telefona";
                broj.BackColor = Color.Black;
                broj.ForeColor = Color.White;
                broj.GotFocus += BrojGost_GotFocus;
                broj.LostFocus += BrojGost_LostFocus;
                cancel.Click += Cancel_Click;
                dodaj.Click += DodajGosta_Click1;
                ukloni.Click += UkloniGosta_Click1;
                uredi.Click += UrediGosta_Click1;
                controlsG.Add(lbGosti);
                controlsG.Add(dodaj);
                controlsG.Add(uredi);
                controlsG.Add(cancel);
                controlsG.Add(ukloni);
                controlsG.Add(ime);
                controlsG.Add(prezime);
                controlsG.Add(datum);
                controlsG.Add(broj);
                foreach (Control control1 in Controls)
                {
                    control1.Hide();
                }
                foreach (Control control in controlsG)
                {
                    Controls.Add(control);
                }
            }
            else
            {
                foreach (Control control1 in Controls)
                {
                    control1.Hide();
                }
                foreach (Control control in controlsG)
                {
                    control.Show();
                }
            }
            if (File.Exists(putanja))
            {
                Stream fs = File.OpenRead(putanja);
                List<Gost> gosti = new List<Gost>();
                ListBox lbGosti = new ListBox();
                BinaryFormatter bf = new BinaryFormatter();
                gosti = bf.Deserialize(fs) as List<Gost>;
                fs.Close();
                foreach (Control control in Controls)
                {
                    if (control.Name == "lbGosti")
                    {
                        lbGosti = control as ListBox;
                    }
                }
                lbGosti.DataSource = gosti;

            }
            else
            {
                MessageBox.Show("Administrator jos nije dodao goste u bazu!");

            }
        }

        private void BrojGost_LostFocus(object sender, EventArgs e)
        {
            TextBox broj = sender as TextBox;
            if (broj.Text == "" || broj.Text == "Broj")
            {
                broj.Text = "Broj";
            }
        }

        private void BrojGost_GotFocus(object sender, EventArgs e)
        {
            TextBox broj = sender as TextBox;
            broj.Text = "";
        }

        private void PrezimeGost_LostFocus(object sender, EventArgs e)
        {
            TextBox prezime = sender as TextBox;
            if(prezime.Text == "" || prezime.Text == "Prezime")
            {
                prezime.Text = "Prezime";
            }
            
        }

        private void PrezimeGost_GotFocus(object sender, EventArgs e)
        {
            TextBox prezime = sender as TextBox;
            prezime.Text = "";
        }

        private void ImeGost_LostFocus(object sender, EventArgs e)
        {
            TextBox ime = sender as TextBox;
            if (ime.Text == "" || ime.Text == "Ime")
            {
                ime.Text = "Ime";
            }
        }

        private void ImeGost_GotFocus(object sender, EventArgs e)
        {
            TextBox ime = sender as TextBox;
            ime.Text = "";
        }

        private void UrediGosta_Click1(object sender, EventArgs e)
        {

            ListBox lbGosti = new ListBox();
            foreach (Control control in Controls)
            {
                if (control.Name == "lbGosti")
                {
                    lbGosti = control as ListBox;
                }
            }
            TextBox ime = new TextBox();
            TextBox prezime = new TextBox();
            TextBox broj = new TextBox();

            foreach (Control control in Controls)
            {
                if (control.Name == "tbIme")
                {
                    ime = control as TextBox;
                }
                if (control.Name == "tbPrezime")
                {
                    prezime = control as TextBox;
                }
                if (control.Name == "tbBroj")
                {
                    broj = control as TextBox;
                }
            }
            Stream fs = File.OpenRead(putanja);
            BinaryFormatter bf = new BinaryFormatter();
            List<Gost> gosti = new List<Gost>();
            gosti = bf.Deserialize(fs) as List<Gost>;
            fs.Close();
            Gost item = null;
            if (lbGosti.SelectedItem != null)
            {
                item = lbGosti.SelectedItem as Gost;
                int index = lbGosti.SelectedIndex;
                if (ime.Text == "")
                {
                    ime.Text = gosti[index].Ime;
                }
                if (prezime.Text == "")
                {
                    prezime.Text = gosti[index].Prezime;
                }
                if (broj.Text == "")
                {
                    broj.Text = gosti[index].Telefon;
                }
                gosti[index].Ime = ime.Text;
                gosti[index].Prezime = prezime.Text;
                gosti[index].Telefon = broj.Text;
                fs = File.OpenWrite(putanja);
                bf.Serialize(fs, gosti);
                fs.Close();
                lbGosti.DataSource = gosti;
                MessageBox.Show("Uspesno ste uredili gosta!");
            }
            else
            {
                MessageBox.Show("Niste izabrali gosta za uredjivanje!");
            }
        }
    

        private void UkloniGosta_Click1(object sender, EventArgs e)
        {
            ListBox lbGosti = new ListBox();
            foreach (Control control in Controls)
            {
                if (control.Name == "lbGosti")
                {
                    lbGosti = control as ListBox;
                }
            }
            if (lbGosti.Items.Count > 0)
            {
                Stream fs = File.OpenRead(putanja);
                BinaryFormatter bf = new BinaryFormatter();
                List<Gost> gosti = new List<Gost>();
                gosti = bf.Deserialize(fs) as List<Gost>;
                Gost item = lbGosti.SelectedItem as Gost;
                fs.Close();
                for (int i = 0; i < gosti.Count; i++)
                {
                    if (gosti[i].Ime == item.Ime && gosti[i].Prezime == item.Prezime && gosti[i].Datumrodjenja == item.Datumrodjenja && gosti[i].Telefon == item.Telefon)
                    {
                        gosti.RemoveAt(i);
                        fs = File.OpenWrite(putanja);
                        bf.Serialize(fs, gosti);
                        lbGosti.DataSource = gosti;
                        fs.Close();
                        MessageBox.Show("Uklonili ste gosta");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("U bazi trenutno nema gostiju!");
            }
        }

        private void DodajGosta_Click1(object sender, EventArgs e)
        {
            List<Gost> gosti = new List<Gost>();
            if (File.Exists(putanja))
            { 
                Stream fs = File.OpenRead(putanja);
                BinaryFormatter bf = new BinaryFormatter();
                gosti = bf.Deserialize(fs) as List<Gost>;
                fs.Close();
            }
            TextBox ime = new TextBox();
            TextBox prezime = new TextBox();
            DateTimePicker datum = new DateTimePicker();
            TextBox broj = new TextBox();
            foreach (Control control in Controls)
            {
                if (control.Name == "tbIme")
                {
                    ime = control as TextBox;
                }
                if (control.Name == "tbPrezime")
                {
                    prezime = control as TextBox;
                }
                if (control.Name == "dtpDatum")
                {
                    datum = control as DateTimePicker;
                }
                if (control.Name == "tbBroj")
                {
                    broj = control as TextBox;
                }
            }
            if (ime.Text != "ime" && ime.Text != "" && prezime.Text != "" && prezime.Text != "prezime" && broj.Text != "" && broj.Text != "broj")
            {
                if (gosti.Count != 0)
                {
                    Gost gost = new Gost((gosti[gosti.Count - 1].Id) + 1, ime.Text, prezime.Text, datum.Value.Date, broj.Text);
                    gosti.Add(gost);
                    FileStream fs2 = new FileStream(putanja, FileMode.Create);
                    fs2.Close();
                    Stream fs1 = File.OpenWrite(putanja);
                    ListBox lbGosti = new ListBox();
                    BinaryFormatter bf1 = new BinaryFormatter();
                    bf1.Serialize(fs1, gosti);
                    fs1.Close();
                    foreach (Control control in Controls)
                    {
                        if (control.Name == "lbGosti")
                        {
                            lbGosti = control as ListBox;
                        }
                    }
                    lbGosti.DataSource = gosti;
                }
                else
                {
                    Gost gost = new Gost(1, ime.Text, prezime.Text, datum.Value.Date, broj.Text);
                    gosti.Add(gost);
                    FileStream fs2 = new FileStream(putanja, FileMode.Create);
                    fs2.Close();
                    Stream fs1 = File.OpenWrite(putanja);
                    ListBox lbGosti = new ListBox();
                    BinaryFormatter bf1 = new BinaryFormatter();
                    bf1.Serialize(fs1, gosti);
                    fs1.Close();
                    foreach (Control control in Controls)
                    {
                        if (control.Name == "lbGosti")
                        {
                            lbGosti = control as ListBox;
                        }
                    }
                    lbGosti.DataSource = gosti;
                }
                MessageBox.Show("Uspesno ste dodali gosta u bazu!");
            }
            else
            {
                MessageBox.Show("Niste uneli sve potrebne informacije!");
            }
        }
    

        private void Cancel_Click(object sender, EventArgs e)
        {
            foreach(Control control in Controls)
            {
                control.Hide();
            }
            foreach(Control control1 in controlsP)
            {
                control1.Show();
                this.Width = 800;
                this.Height = 500;
            }
        }
    }
}
