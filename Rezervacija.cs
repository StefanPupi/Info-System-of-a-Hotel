using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPelicula
{
    [Serializable]
    class Rezervacija
    {
        int id;
        int idsobe;
        int idgosta;
        DateTime datumod;
        DateTime datumdo;
        double ukupnacena;
        string tip;

        public Rezervacija(int id, int idsobe, int idgosta, DateTime datumod, DateTime datumdo, double ukupnacena, string tip)
        {
            this.Id = id;
            this.Idsobe = idsobe;
            this.Idgosta = idgosta;
            this.Datumod = datumod;
            this.Datumdo = datumdo;
            this.Ukupnacena = ukupnacena;
            this.Tip = tip;
        }

        public int Id { get => id; set => id = value; }
        public int Idsobe { get => idsobe; set => idsobe = value; }
        public int Idgosta { get => idgosta; set => idgosta = value; }
        public DateTime Datumod { get => datumod; set => datumod = value; }
        public DateTime Datumdo { get => datumdo; set => datumdo = value; }
        public double Ukupnacena { get => ukupnacena; set => ukupnacena = value; }
        public string Tip { get => tip; set => tip = value; }

        public override string ToString()
        {
            return $"IDR: {id}, IDG: {idgosta}, IDS: {idsobe}, Od/Do: {datumod}/{datumdo}. C: {ukupnacena}";
        }
    }
}
