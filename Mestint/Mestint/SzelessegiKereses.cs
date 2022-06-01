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
                Csucs kiterjesztesreKivalasztott = Nyilt.Dequeue();
                List<Csucs> gyerekCsucsok = kiterjesztesreKivalasztott.Kiterjesztes();
                foreach (Csucs gyerekCsucs in gyerekCsucsok)
                {
                    if (gyerekCsucs.TerminelisCsucsE())
                    {
                        return gyerekCsucs;
                    }
                    if (!Zart.Contains(gyerekCsucs) && !Nyilt.Contains(gyerekCsucs))
                    {
                        Nyilt.Enqueue(gyerekCsucs);
                    }
                }
                Zart.Add(kiterjesztesreKivalasztott);
            }
            return null;
        }
        private Csucs TerminalisCsucsKeresesGyorsan()
        {
            while (Nyilt.Count != 0)
            {
                Csucs kiterjesztesreKivalasztott = Nyilt.Dequeue();
                List<Csucs> gyerekCsucsok = kiterjesztesreKivalasztott.Kiterjesztes();
                foreach (Csucs gyerekCsucs in gyerekCsucsok)
                {
                    if (gyerekCsucs.TerminelisCsucsE())
                    {
                        return gyerekCsucs;
                    }
                    Nyilt.Enqueue(gyerekCsucs);
                }
            }
            return null;
        }
    }
}
