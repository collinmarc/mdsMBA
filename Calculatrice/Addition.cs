using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    public class Addition : Operation
    {
        public Addition():base()
        {
        }
        public Addition(Single pOp1, Single pOp2): base(pOp1, pOp2)
        {
        }
        public override Boolean Calculer()
        {
           Resultat = this.Op1 + Op2;
           Etat = true;
           return Etat;
        }

        public override string ToString()
        {
            if (Etat)
            {
                return String.Format("Addition({0}+{1})={2}", Op1, Op2, Resultat);
            }
            else
            {
                return "Addition non effectuée";
            }
        }



    }
}
