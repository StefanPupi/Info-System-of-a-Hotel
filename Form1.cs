using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace HotelPelicula
{
    public partial class Form1 : Form
    {
        List<Control> controlsP;
        List<Control> controlsA;
        List<Control> controlsR;
        
        string putanja;
        public Form1()
        {
            InitializeComponent();
            controlsA = new List<Control>();
            controlsR = new List<Control>();
            controlsP = new List<Control>();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PictureBox logo = new PictureBox();
            Button admin = new Button();
            Button recepcioner = new Button();

            logo.Name = "imgLogo";
            admin.Name = "btnAdmin";
            recepcioner.Name = "btnRecepcioner";
            logo.Image = Properties.Resources.logo;
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.Height = 145;
            logo.Width = 104;
            logo.Top = 60;
            logo.Left = ClientSize.Width / 2 - logo.Width / 2;
            admin.Height = 54;
            recepcioner.Height = 54;
            admin.Width = 143;
            recepcioner.Width = 143;
            admin.Top = logo.Top + logo.Height + 30;
            admin.Left = ClientSize.Width / 2 - admin.Width / 2;
            recepcioner.Left = ClientSize.Width / 2 - recepcioner.Width / 2;
            recepcioner.Top = admin.Top + admin.Height + 30;
            admin.Text = "Prijavi se kao Administrator";
            recepcioner.Text = "Prijavi se kao Recepcioner";
            admin.Font = new Font("Microsoft Sans Serif", 12);
            recepcioner.Font = new Font("Microsoft Sans Serif", 12);
            admin.BackColor = Color.Black;
            recepcioner.BackColor = Color.Black;
            admin.ForeColor = Color.White;
            recepcioner.ForeColor = Color.White;
            admin.Click += Admin_Click;
            recepcioner.Click += Recepcioner_Click;
            controlsP.Add(logo);
            controlsP.Add(admin);
            controlsP.Add(recepcioner);
            foreach (Control control in controlsP)
            {
                Controls.Add(control);
            }
        }

        private void Recepcioner_Click(object sender, EventArgs e)
        {
            Button recepcioner = null;
            PictureBox logo = null;
            foreach (Control control in Controls)
            {
                if (control.Name == "imgLogo")
                {
                    logo = control as PictureBox;
                }
                if (control.Name == "btnRecepcioner")
                {
                    recepcioner = control as Button;
                }
                if (control.Name != "imgLogo" && control as Button != recepcioner)
                {
                    control.Hide();
                }
            }
            recepcioner.Hide();

            if (controlsR.Count == 0)
            {
                Label korisnicko = new Label();
                TextBox ime = new TextBox();
                Label sifra = new Label();
                TextBox password = new TextBox();
                Button login = new Button();
                Button cancel = new Button();


                korisnicko.Top = logo.Bottom + 10;
                korisnicko.Text = "Korisnicko ime:";
                korisnicko.Width = 150;
                korisnicko.Font = new Font("Serif", 12);
                korisnicko.Name = "lbKorisnicko";
                ime.Width = 200;
                ime.Height = 10;
                ime.Left = ClientSize.Width / 2 - ime.Width / 2;
                ime.Top = korisnicko.Bottom + 10;
                ime.BackColor = Color.Black;
                ime.ForeColor = Color.White;
                ime.Font = new Font("Serif", 12);
                ime.Name = "tbIme";
                korisnicko.Left = ime.Left;
                sifra.Left = korisnicko.Left;
                sifra.Top = ime.Bottom + 10;
                sifra.Text = "Sifra:";
                sifra.Font = new Font("Serif", 12);
                sifra.Name = "lbSifra";
                password.Left = ime.Left;
                password.Top = sifra.Bottom + 10;
                password.BackColor = Color.Black;
                password.ForeColor = Color.White;
                password.Font = new Font("Serif", 12);
                password.Width = 200;
                password.Height = 10;
                password.Name = "tbSifra";
                password.PasswordChar = '*';
                login.Left = password.Left;
                login.Top = password.Bottom + 10;
                login.Text = "Potvrdi";
                login.Font = new Font("Serif", 12);
                login.BackColor = Color.Black;
                login.ForeColor = Color.White;
                login.Width = password.Width / 2 - 5;
                login.Name = "btnLogin";
                cancel.Left = login.Right + 10;
                cancel.Top = login.Top;
                cancel.Text = "Otkazi";
                cancel.Font = new Font("Serif", 12);
                cancel.BackColor = Color.Black;
                cancel.ForeColor = Color.White;
                cancel.Name = "btnCancel";
                cancel.Width = password.Width / 2 - 5;
                login.Height = cancel.Height = 27;
                login.Click += Login_Click;
                cancel.Click += Cancel_Click;
                controlsR.Add(korisnicko);
                controlsR.Add(ime);
                controlsR.Add(sifra);
                controlsR.Add(password);
                controlsR.Add(login);
                controlsR.Add(cancel);
                foreach (Control control in controlsR)
                {
                    Controls.Add(control);
                }
            }
            else
            {
                foreach (Control control in controlsR)
                {
                    control.Show();
                }
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            putanja = "korisnici.bin";
            List<Korisnik> korisnici = new List<Korisnik>();
            if (!File.Exists(putanja))
            {
                Stream fs = File.Open(putanja, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                Korisnik korisnik = new Korisnik("recepcioner", "recepcioner", "recepcioner", "recepcioner");
                Korisnik korisnik1 = new Korisnik("admin", "admin", "admin", "administrator");
                korisnici.Add(korisnik);
                korisnici.Add(korisnik1);
                bf.Serialize(fs, korisnici);
                fs.Close();
            }
            TextBox korime = new TextBox();
            TextBox sifra = new TextBox();
            foreach (Control control in Controls)
            {
                if (control.Name == "tbIme")
                {
                    korime = control as TextBox;
                }
                if (control.Name == "tbSifra")
                {
                    sifra = control as TextBox;
                }
            }
            Stream fs1 = File.OpenRead(putanja);
            BinaryFormatter bf1 = new BinaryFormatter();
            korisnici.Clear();
            korisnici = bf1.Deserialize(fs1) as List<Korisnik>;
            int flag = 0;
            foreach (Korisnik korisnik1 in korisnici)
            {
                if (korisnik1.Korisnickoime.ToLower() == korime.Text && korisnik1.Sifra == sifra.Text && korisnik1.Vrsta.ToLower() == "recepcioner")
                {
                    RecepcionerForma rf = new RecepcionerForma();
                    rf.Show();
                    this.Hide();
                    flag++;
                    break;
                }
            }
            if (flag == 0)
            {
                MessageBox.Show("Niste uneli tacne podatke!");
            }
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Button admin = null;
            PictureBox logo = null;
            foreach (Control control in Controls)
            {
                if(control.Name == "imgLogo")
                {
                    logo = control as PictureBox;
                }
                if (control.Name == "btnAdmin")
                {
                    admin = control as Button;
                }
                if(control.Name != "imgLogo" && control as Button != admin)
                {
                    control.Hide();
                }
            }
            admin.Hide();

            if (controlsA.Count == 0)
            {
                Label korisnicko = new Label();
                TextBox ime = new TextBox();
                Label sifra = new Label();
                TextBox password = new TextBox();
                Button login = new Button();
                Button cancel = new Button();


                korisnicko.Top = logo.Bottom + 10;
                korisnicko.Text = "Korisnicko ime:";
                korisnicko.Width = 150;
                korisnicko.Font = new Font("Serif", 12);
                korisnicko.Name = "lbKorisnicko";
                ime.Width = 200;
                ime.Height = 10;
                ime.Left = ClientSize.Width / 2 - ime.Width / 2;
                ime.Top = korisnicko.Bottom + 10;
                ime.BackColor = Color.Black;
                ime.ForeColor = Color.White;
                ime.Font = new Font("Serif", 12);
                ime.Name = "tbIme";
                korisnicko.Left = ime.Left;
                sifra.Left = korisnicko.Left;
                sifra.Top = ime.Bottom + 10;
                sifra.Text = "Sifra:";
                sifra.Font = new Font("Serif", 12);
                sifra.Name = "lbSifra";
                password.Left = ime.Left;
                password.Top = sifra.Bottom + 10;
                password.BackColor = Color.Black;
                password.ForeColor = Color.White;
                password.Font = new Font("Serif", 12);
                password.Width = 200;
                password.Height = 10;
                password.Name = "tbSifra";
                password.PasswordChar = '*';
                login.Left = password.Left;
                login.Top = password.Bottom + 10;
                login.Text = "Potvrdi";
                login.Font = new Font("Serif", 12);
                login.BackColor = Color.Black;
                login.ForeColor = Color.White;
                login.Width = password.Width / 2 - 5;
                login.Name = "btnLogin";
                cancel.Left = login.Right + 10;
                cancel.Top = login.Top;
                cancel.Text = "Otkazi";
                cancel.Font = new Font("Serif", 12);
                cancel.BackColor = Color.Black;
                cancel.ForeColor = Color.White;
                cancel.Name = "btnCancel";
                cancel.Width = password.Width / 2 - 5;
                login.Height = cancel.Height = 27;
                login.Click += Login_Click1;
                cancel.Click += Cancel_Click;
                controlsA.Add(korisnicko);
                controlsA.Add(ime);
                controlsA.Add(sifra);
                controlsA.Add(password);
                controlsA.Add(login);
                controlsA.Add(cancel);
                foreach (Control control in controlsA)
                {
                    Controls.Add(control);
                }
            }
            else
            {
                foreach(Control control in controlsA)
                {
                    control.Show();
                }
            }
        }

        private void Login_Click1(object sender, EventArgs e)
        {
            putanja = "korisnici.bin";
            List<Korisnik> korisnici = new List<Korisnik>();
            if (!File.Exists(putanja))
            {
                Stream fs = File.Open(putanja, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                Korisnik korisnik = new Korisnik("admin", "admin", "admin", "administrator");
                Korisnik korisnik1 = new Korisnik("recepcioner", "recepcioner", "recepcioner", "recepcioner");
                korisnici.Add(korisnik);
                korisnici.Add(korisnik1);
                bf.Serialize(fs, korisnici);
                fs.Close();
            }
            TextBox korime = new TextBox();
            TextBox sifra = new TextBox();
            foreach (Control control in Controls)
            {
                if (control.Name == "tbIme")
                {
                    korime = control as TextBox;
                }
                if (control.Name == "tbSifra")
                {
                    sifra = control as TextBox;
                }
            }
            Stream fs1 = File.OpenRead(putanja);
            BinaryFormatter bf1 = new BinaryFormatter();
            korisnici.Clear();
            korisnici = bf1.Deserialize(fs1) as List<Korisnik>;
            int flag = 0;
            foreach (Korisnik korisnik1 in korisnici)
            {
                if (korisnik1.Korisnickoime.ToLower() == korime.Text && korisnik1.Sifra == sifra.Text && korisnik1.Vrsta.ToLower() == "administrator")
                {
                    AdminForma af = new AdminForma();
                    af.Show();
                    this.Hide();
                    fs1.Close();
                    flag = 1;
                    break;
                }
            }
            if (flag == 0)
            {
                MessageBox.Show("Niste uneli tacne podatke!");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Button cancel = null;
            Button login = null;
            Label lb1 = null;
            Label lb2 = null;
            Form forma = FindForm();
            foreach (Control control1 in Controls)
            {
                if(control1.Name == "btnCancel")
                {
                    cancel = control1 as Button;
                }
                if(control1.Name == "btnLogin")
                {
                    login = control1 as Button;
                }
                if(control1.Name == "lbKorisnicko")
                {
                    lb1 = control1 as Label;
                }
                if (control1.Name == "lbSifra")
                {
                    lb2 = control1 as Label;
                }
            }
            foreach (Control control in Controls)
            {
                if(control as Button != cancel)
                {
                    control.Hide();
                }
            }
            lb1.Hide();
            lb2.Hide();
            login.Hide();
            cancel.Hide();
            foreach (Control control2 in controlsP)
            {
                control2.Visible = true;
                forma.Controls.Add(control2);
            }
        }

        
    }       
}
