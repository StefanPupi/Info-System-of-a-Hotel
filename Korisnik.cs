using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPelicula
{
    [Serializable]
    class Korisnik
    {
        static int ID=1;
        int id;
        string ime;
        string prezime;
        string korisnickoime;
        string sifra;
        string vrsta;
        
        public Korisnik(string ime, string prezime, string sifra, string vrsta)
        {
            Id = ID;
            ID++;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Korisnickoime = $"{this.ime}{Id}";
            this.Sifra = sifra;
            this.Vrsta = vrsta;
        }

        public Korisnik(int id, string ime, string prezime, string sifra, string vrsta)
        {
            this.Id = id;
            this.ime = ime;
            this.prezime = prezime;
            korisnickoime = ime + id;
            this.sifra = sifra;
            this.vrsta = vrsta;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Korisnickoime { get => korisnickoime; set => korisnickoime = value; }
        public string Sifra { get => sifra; set => sifra = value; }
        public string Vrsta { get => vrsta; set => vrsta = value; }
        public int Id { get => id; set => id = value; }

        public bool proveri(string ime, string sifra1, string vrsta)
        {
            if (this.korisnickoime == ime && sifra == sifra1 && this.vrsta.ToLower() == vrsta.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public override string ToString()
        {
            return $"ID: {Id}, I: {ime}, P: {prezime}, KI: {korisnickoime}, S: {sifra}, TK: {vrsta}";
        }
    }
}
