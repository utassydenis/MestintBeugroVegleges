using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Csucs startCsucs;
            GrafKereso kereso;

            startCsucs = new Csucs(new GyumolcsAllapot(13, 46, 59));


            Console.WriteLine("\nSzélességi keresés");
            kereso = new SzelessegiKereses(startCsucs, true);
            kereso.megoldasKiirasa(kereso.Kereses());

            Console.ReadKey();


        }
    }
}
