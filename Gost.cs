using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPelicula
{
    [Serializable]
    class Gost
    {
        
        int id;
        string ime;
        string prezime;
        DateTime datumrodjenja;
        string telefon;

        public Gost(int id, string ime, string prezime, DateTime datumrodjenja, string telefon)
        {
            this.Id = id;
            
            this.Ime = ime;
            this.Prezime = prezime;
            this.Datumrodjenja = datumrodjenja;
            this.Telefon = telefon;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime Datumrodjenja { get => datumrodjenja; set => datumrodjenja = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return $"ID: {Id}, I: {ime}, P: {prezime}, DR: {datumrodjenja}, BT: {telefon}";
        }
    }
}
