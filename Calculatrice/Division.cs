using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    public class Division : Operation
    {
        public Division():base()
        {
        }
        public Division(Single pOp1, Single pOp2):base(pOp1, pOp2)
        {
        }

        public override Boolean Calculer()
        {
            if (Op2 == 0)
            {
                Etat = false;
                throw new ArgumentException("Op2 = 0");
            }
                Resultat = this.Op1 / Op2;
                Etat = true;
            return Etat;
        }

        public override string ToString()
        {
            if (Etat)
            {
                return String.Format("Division({0}/{1})={2}", Op1, Op2, Resultat);
            }
            else
            {
                return "Division non effectuée";
            }
        }



    }
}
