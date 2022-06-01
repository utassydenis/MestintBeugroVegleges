using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint
{
    internal class GyumolcsAllapot : AbsztraktAllapot
    {
        /*
        13 alam
        46 körte
        59 barack
        1a 1k = 2b
        1a 1b = 2k
        1b 1k = 2a
         */
        int alma;
        int korte;
        int barack;

        public GyumolcsAllapot(int alma, int korte, int barack)
        {
            this.alma = alma;
            this.korte = korte;
            this.barack = barack;
        }

        public override bool AllapotE() //Post Condition
        {
            return alma >= 0 && korte >=0 && barack >= 0;
        }

        public override bool CelAllapotE()
        {
            return (alma == 0 && korte == 0) || (alma == 0 && barack == 0) || (korte == 0 && barack == 0);
        }

        public override int OperatorokSzama()
        {
            return 3;
        }

        public override bool SzuperOperator(int i)
        {
            switch (i)
            {
                case 0:
                    return Kereskedik(1, 2);
                    break;
                case 1:
                    return Kereskedik(1, 3);
                    break;
                case 2:
                    return Kereskedik(2, 3);
                    break;
                default:
                    return false;
            }
        }
        /*
        1 = alma
        2 = körte
        3 = barack
         */
        public bool preKereskedik(int egyik, int masik) //Precondition
        {
            if(egyik == 1 && masik == 2 && alma > 0 && korte > 0) //alma körte
            {
                return true;
            }
            if (egyik == 1 && masik == 3 && alma > 0 && barack > 0) //alma barack
            {
                return true;
            }
            if (egyik == 2 && masik == 3 && korte > 0 && barack > 0) //körte barack
            {
                return true;
            }
            return false;
        }
        /*
        1 = alma
        2 = körte
        3 = barack
         */

        public bool Kereskedik(int egyik, int masik)
        {
            if (!preKereskedik(egyik,masik))
            {
                return false;
            }
            GyumolcsAllapot mentes = (GyumolcsAllapot)Clone();

            if(egyik == 1 && masik == 2) //alma körte
            {
                alma--;
                korte--;
                barack += 2;
            }
            else if(egyik == 1 && masik == 3)
            {
                alma--;
                barack--;
                korte += 2;
            }
            else //if(egyik == 2 && masik == 3)// 2 és 3 körte barak
            {
                korte--;
                barack--;
                alma+= 2;
            }

            if (AllapotE())
            {
                return true;
            }
            alma = mentes.alma;
            barack = mentes.barack;
            korte = mentes.korte;
            return false;
        }
        public override string ToString()
        {
            return "Alma:" + alma + " Körte:" + korte + " Barack:" + barack;
        }

        public override bool Equals(object a)
        {
            GyumolcsAllapot aa = (GyumolcsAllapot)a;
            return aa.alma == alma && aa.barack == barack && aa.korte == korte;
        }
        public override int GetHashCode()
        {
            return alma.GetHashCode() + korte.GetHashCode() + barack.GetHashCode();
        }
    }
}
