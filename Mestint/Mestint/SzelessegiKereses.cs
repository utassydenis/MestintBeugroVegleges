using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint
{
    internal class SzelessegiKereses : GrafKereso
    {
        Queue<Csucs> Nyilt;
        List<Csucs> Zart;
        bool korFigyeles;
        public SzelessegiKereses(Csucs startCsucs, bool korFigyeles) : base(startCsucs)
        {
            Nyilt = new Queue<Csucs>();
            Nyilt.Enqueue(startCsucs);
            Zart = new List<Csucs>();
            this.korFigyeles = korFigyeles;
        }

        public SzelessegiKereses(Csucs startCsucs) : this(startCsucs, true)
        {

        }

        public override Csucs Kereses()
        {
            if (korFigyeles)
            {
                return TerminalisCsucsKereses();
            }
            return TerminalisCsucsKeresesGyorsan();
        }
        private Csucs TerminalisCsucsKereses()
        {
            while (Nyilt.Count != 0)
            {
                Csucs C = Nyilt.Dequeue();
                List<Csucs> ujCsucsok = C.Kiterjesztes();
                foreach (Csucs D in ujCsucsok)
                {
                    if (D.TerminelisCsucsE())
                    {
                        return D;
                    }
                    if (!Zart.Contains(D) && !Nyilt.Contains(D))
                    {
                        Nyilt.Enqueue(D);
                    }
                }
                Zart.Add(C);
            }
            return null;
        }
        private Csucs TerminalisCsucsKeresesGyorsan()
        {
            while (Nyilt.Count != 0)
            {
                Csucs C = Nyilt.Dequeue();
                List<Csucs> ujCsucsok = C.Kiterjesztes();
                foreach (Csucs D in ujCsucsok)
                {
                    if (D.TerminelisCsucsE())
                    {
                        return D;
                    }
                    Nyilt.Enqueue(D);
                }
            }
            return null;
        }
    }
}
