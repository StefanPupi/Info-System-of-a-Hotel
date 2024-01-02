using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelPelicula
{
    [Serializable]
    class Soba
    {
        int id;
        int brojsobe;
        int brojkreveta;
        string tipsobe;
        double cena;
        int popust;
        int minbrdana;
        int dostupno;

        public Soba(int brojsobe, int brojkreveta, string tipsobe, double cena, int popust, int minbrdana)
        {
            Id = brojsobe;
            Dostupno = 1;
            this.Brojsobe = brojsobe;
            this.Brojkreveta = brojkreveta;
            this.Tipsobe = tipsobe;
            this.Cena = cena;
            this.Popust = popust;
            this.Minbrdana = minbrdana;
        }

        public int Brojsobe { get => brojsobe; set => brojsobe = value; }
        public int Brojkreveta { get => brojkreveta; set => brojkreveta = value; }
        public string Tipsobe { get => tipsobe; set => tipsobe = value; }
        public double Cena { get => cena; set => cena = value; }
        public int Popust { get => popust; set => popust = value; }
        public int Minbrdana { get => minbrdana; set => minbrdana = value; }
        public int Dostupno { get => dostupno; set => dostupno = value; }
        public int Id { get => id; set => id = value; }

        public bool proveriDostupnost()
        {

            if (this.dostupno == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void dostupna()
        {
            this.dostupno = 1;
        }

        public void nedstupna()
        {
            this.dostupno = 0;
        }

        public override string ToString()
        {
            return $"ID: {id}, BS: {brojsobe}, BK: {brojkreveta}, TS: {tipsobe}, C: {cena}, BD, {minbrdana}, D: {dostupno}";
        }
    }
}
