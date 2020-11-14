using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pekseg
{
    class Pekseg
    {
        private string nev;
        private List<Pekaru> termekek;
        private DateTime alapitva;
        public Pekseg(string nev, List<Pekaru> termekek, DateTime alapitva)
        {
            this.nev = nev;
            this.termekek = termekek;
            this.alapitva = alapitva;
        }

        public string Nev { get => nev; set => nev = value; }
        public DateTime Alapitva { get => alapitva; }
        internal List<Pekaru> Termekek { get => termekek; }

        public override string ToString()
        {
            return String.Format(this.nev+" - "+this.alapitva.ToString("yyyy. MM. dd"));
        }

        public double PekarukAtlagosAra()
        {
            if (this.termekek.Count==0)
            {
                return 0;
            }
            else
            {
                double sum = 0;
                for (int i = 0; i <this.termekek.Count; i++)
                {
                    sum += this.termekek[i].Ar;
                }
                return sum / this.termekek.Count;
            }
        }
        public int LegolcsobbTermek()
        {
            int legolcsobb = 0;
            for (int i = 0; i < this.termekek.Count; i++)
            {
                if (this.termekek[i].Ar <this.termekek[legolcsobb].Ar)
                {
                    legolcsobb = i;
                }
            }
            return legolcsobb;
        }
        public int LegdragabbTermek()
        {
            int dragabb = 0;
            for (int i = 0; i < this.termekek.Count; i++)
            {
                if (this.termekek[i].Ar > this.termekek[dragabb].Ar)
                {
                    dragabb = i;
                }
            }
            return dragabb;
        }
        public int LaktozmentesPekaruk()
        {
            int sum = 0;
            for (int i = 0; i < this.termekek.Count; i++)
            {
                if (this.termekek[i].Laktozmentes)
                {
                    sum++;
                }
            }
            return sum;
        }
    }
}
