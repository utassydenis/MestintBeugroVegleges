using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mestint
{
    internal abstract class AbsztraktAllapot : ICloneable
    {
        public abstract bool AllapotE();
        public abstract bool CelAllapotE();

        public abstract int OperatorokSzama();

        public abstract bool SzuperOperator(int i);

        public virtual object Clone()
        {
            return MemberwiseClone();
        }

        public override bool Equals(object a)
        {
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
