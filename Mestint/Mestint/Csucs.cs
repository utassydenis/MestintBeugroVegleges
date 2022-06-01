using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint
{
    internal class Csucs
    {
        AbsztraktAllapot allapot;
        int melyseg;
        Csucs szulo;

        public Csucs(AbsztraktAllapot kezdoAllapot)
        {
            allapot = kezdoAllapot;
            melyseg = 0;
            szulo = null;
        }

        public Csucs(Csucs szulo)
        {
            allapot = (AbsztraktAllapot)szulo.allapot.Clone();
            melyseg = szulo.melyseg + 1;
            this.szulo = szulo;
        }
        
        public Csucs GetSzulo()
        {
            return szulo;
        }

        public int GetMelyseg()
        {
            return melyseg;
        }

        public bool TerminelisCsucsE()
        {
            return allapot.CelAllapotE();
        }

        public int OperatorokSzama()
        {
            return allapot.OperatorokSzama();
        }

        public bool SzuperOperator(int i)
        {
            return allapot.SzuperOperator(i);
        }

        public override bool Equals(object? obj)
        {
            Csucs cs = (Csucs)obj;
            return allapot.Equals(cs.allapot);
        }

        public override int GetHashCode()
        {
            return allapot.GetHashCode();
        }
        public override string ToString()
        {
            return allapot.ToString();
        }

        public List<Csucs> Kiterjesztes()
        {
            List<Csucs> ujCsucsok = new List<Csucs>();
            for(int i = 0; i< OperatorokSzama(); i++)
            {
                Csucs ujCsucs = new Csucs(this);
                if (ujCsucs.SzuperOperator(i))
                {
                    ujCsucsok.Add(ujCsucs);
                }
            }
            return ujCsucsok;
        }
    }
}
