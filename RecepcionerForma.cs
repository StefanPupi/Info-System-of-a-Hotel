using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelPelicula
{
    public partial class RecepcionerForma : Form
    {
        List<Control> controlsR;
        List<Control> controlsP;
        List<Control> controlsPr;
        string putanja;
        public RecepcionerForma()
        {
            InitializeComponent();
            controlsR = new List<Control>();
            controlsP = new List<Control>();
            controlsPr = new List<Control>();
        }

        private void RecepcionerForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void RecepcionerForma_Load(object sender, EventArgs e)
        {
            PictureBox logo = new PictureBox();
            Button provera = new Button();
            Button dodaj = new Button();

            logo.Name = "imgLogo";
            provera.Name = "btnProvera";
            dodaj.Name = "btnDodaj";
            provera.Text = "Proveri rezervaciju";
            dodaj.Text = "Dodaj rezervaciju";
            logo.Image = Properties.Resources.logo;
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.Height = 145;
            logo.Width = 104;
            logo.Top = 60;
            logo.Left = ClientSize.Width / 2 - logo.Width / 2;
            provera.Width = dodaj.Width = 150;
            provera.Height = dodaj.Height = 50;
            provera.BackColor = dodaj.BackColor = Color.Black;
            provera.ForeColor = dodaj.ForeColor = Color.White;
            provera.Font = dodaj.Font = new Font("Serif", 12);
            provera.Left = ClientSize.Width / 2 - provera.Width - 5;
            dodaj.Left = ClientSize.Width / 2 + 5;
            provera.Top = dodaj.Top = logo.Bottom + 20;
            dodaj.Click += Dodaj_Click;
            provera.Click += Provera_Click;
            controlsP.Add(logo);
            controlsP.Add(provera);
            controlsP.Add(dodaj);

            foreach (Control control in controlsP)
            {
                Controls.Add(control);
            }

            
        }

        private void Provera_Click(object sender, EventArgs e)
        {
            ListBox lbRezervacije = new ListBox();

            Button cancel = new Button();
            if (controlsPr.Count == 0)
            {
                
                

                lbRezervacije.Left = 100;
                lbRezervacije.Top = 60;
                lbRezervacije.Width = 600;
                lbRezervacije.Height = 300;
                lbRezervacije.BackColor = Color.Black;
                lbRezervacije.ForeColor = Color.White;
                lbRezervacije.Name = "lbGosti";
                lbRezervacije.Font = new Font("Serif", 8);
                lbRezervacije.ScrollAlwaysVisible = true;
                cancel.Name = "btnCancel";
                cancel.Left = ClientSize.Width / 2 - cancel.Width / 2;
                cancel.Top = lbRezervacije.Bottom + 10; 
                cancel.BackColor = Color.Black;
                cancel.ForeColor = Color.White;
                cancel.Text = "Otkazi";
                cancel.Font = new Font("Serif", 12);
                cancel.Width = 80;
                cancel.Height = 30;
                
                cancel.Click += Cancel_Click;
                controlsPr.Add(lbRezervacije);
                
                controlsPr.Add(cancel);
                

                foreach (Control control1 in Controls)
                {
                    control1.Hide();
                }
                foreach (Control control in controlsPr)
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
                foreach (Control control in controlsPr)
                {
                    control.Show();
                }
            }
            if (File.Exists("rezervacije.bin"))
            {
                List<Rezervacija> rezervacije = new List<Rezervacija>();
                Stream fs = File.OpenRead("rezervacije.bin");
                BinaryFormatter bf = new BinaryFormatter();
                rezervacije = bf.Deserialize(fs) as List<Rezervacija>;
                lbRezervacije.DataSource = rezervacije;
            }
        }

        private void Dodaj_Click(object sender, EventArgs e)
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
                Label ukupnaCena = new Label();
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
                uredi.Click += UrediRezervaciju_Click;
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

        private void UrediRezervaciju_Click(object sender, EventArgs e)
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
                    if (control2.Name == "cbTip")
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
                    if (item.Id == rezervacija.Id)
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
                    if (item.Idsobe == soba.Id)
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
                MessageBox.Show("Uspesno ste uklonili rezervaciju!");
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
                if (item != null && item1 != null)
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

            private void Cancel_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                control.Hide();
            }
            foreach (Control control1 in controlsP)
            {
                control1.Show();
            }
        }
    }
}
