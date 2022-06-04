using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint
{
    internal class TablaJatekAllapot : AbsztraktAllapot
    {
        private static char[,] tabla = new char[,]
            {
                {'S',' ',' ',' ','K',' ',' ',' '},
                {' ',' ','K',' ',' ',' ','K',' '},
                {' ',' ','F',' ',' ',' ',' ','F'},
                {' ',' ','K',' ','K',' ',' ',' '},
                {'K','F',' ','K',' ',' ',' ','K'},
                {' ',' ',' ','K',' ','F','K',' '},
                {' ',' ','K',' ',' ',' ',' ','K'},
                {'K',' ',' ','F',' ',' ',' ','C'}
            };
        private int mennyitLep;
        private int posX;
        private int posY;
        public TablaJatekAllapot(int posX, int posY, int mennyitLep)
        {
            this.posX = posX;
            this.posY = posY;
            this.mennyitLep = mennyitLep;
        }

        public override bool AllapotE()
        {
            return posY < 8 && posX >= 0 && posY < 8 && posY >=0;
        }

        public override bool CelAllapotE()
        {
            return tabla[posX,posY] == 'C';
        }

        public override int OperatorokSzama()
        {
            return 4;
        }

        public override bool SzuperOperator(int i)
        {
            switch (i)
            {
                case 0:
                    return Lep("fel");
                case 1:
                    return Lep("le");
                case 2:
                    return Lep("jobbra");
                case 3:
                    return Lep("balra");
                default:
                    return false;
            }
        }
        public bool PreLep(string irany)
        {
            switch (irany)
            {
                case "fel":
                    return posY - mennyitLep >= 0 && tabla[posX, posY - mennyitLep] != 'F';
                case "le":
                    return posY + mennyitLep < 8 && tabla[posX, posY + mennyitLep] != 'F';
                case "jobbra":
                    return posX + mennyitLep < 8 && tabla[posX + mennyitLep, posY] != 'F';
                case "balra":
                    return posX - mennyitLep >= 0 && tabla[posX - mennyitLep, posY] != 'F';
                default:
                    return false;
            }
        }
        public bool Lep(string irany)
        {
            if (!PreLep(irany))
            {
                return false;
            }
            TablaJatekAllapot mentes = (TablaJatekAllapot)Clone();
            switch (irany)
            {
                case "fel":
                    posY -= mennyitLep;
                    break;
                case "le":
                    posY += mennyitLep;
                    break;
                case "jobbra":
                    posX += mennyitLep;
                    break;
                case "balra":
                    posX -= mennyitLep;
                    break;
                default:
                    return false;
            }
            if (tabla[posX, posY] == 'K' && mennyitLep == 2)
            {
                mennyitLep = 3;
            }
            else if (tabla[posX, posY] == 'K' && mennyitLep == 3)
            {
                mennyitLep = 2;
            }
            if (AllapotE())
            {
                return true;
            }
            posX = mentes.posX;
            posY = mentes.posY;
            mennyitLep = mentes.mennyitLep;
            return false;
        }
        public override string ToString()
        {
            return "Bábu helyzete: " + posX + ". sor, " + posY +". oszlop és a mező értéke: " + (tabla[posX,posY] == ' ' ? "üres" : tabla[posX,posY]) + " ,következő körben léphet:" + mennyitLep;
        }
        public override bool Equals(object a)
        {
            TablaJatekAllapot aa = (TablaJatekAllapot)a;
            return aa.posX == posX && aa.posY == posY && aa.mennyitLep == mennyitLep;
        }
        public override int GetHashCode()
        {
            return posX.GetHashCode() + posY.GetHashCode() + mennyitLep.GetHashCode();
        }
    }
}
