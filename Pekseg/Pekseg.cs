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
    }
}
