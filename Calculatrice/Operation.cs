using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    public abstract class Operation
    {
        public Single Op1 { get; set; }
        public Single Op2 { get; set; }
        public Single Resultat { get; set; }
        public Boolean Etat { get; set; }
        public Operation()
        {
        }
        public Operation(Single pOp1, Single pOp2)
        {
            Op1 = pOp1;
            Op2 = pOp2;
            Calculer();
        }
        public Boolean Calculer(Single pOP1, Single pOP2)
        {
            Op1 = pOP1;
            Op2 = pOP2;
            return Calculer();
        }

        abstract public Boolean Calculer();

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                if (obj.GetType() == this.GetType())
                {
                    Operation op2 = (Operation)obj;
                    if (this.Etat == op2.Etat && this.Resultat == op2.Resultat)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }//Equals

        public abstract string ToString();



    }
}
