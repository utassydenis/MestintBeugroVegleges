using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint
{
    internal abstract class GrafKereso
    {
        private Csucs startCsucs;

        public GrafKereso(Csucs startCsucs)
        {
            this.startCsucs = startCsucs;
        }

        protected Csucs GetStartCSucs()
        {
            return startCsucs;
        }

        public abstract Csucs Kereses();

        public void megoldasKiirasa(Csucs egyTerminalisCsucs)
        {
            if(egyTerminalisCsucs == null)
            {
                Console.WriteLine("Nincs megoldas");
                return;
            }
            Stack<Csucs> megoldas = new Stack<Csucs>();
            Csucs aktCsucs = egyTerminalisCsucs;
            while(aktCsucs != null)
            {
                megoldas.Push(aktCsucs);
                aktCsucs = aktCsucs.GetSzulo();
            }
            foreach(Csucs akt in megoldas)
            {
                Console.WriteLine(akt);
            }
        }
    }
}
