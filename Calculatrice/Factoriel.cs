using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    public class Factoriel : Operation
    {
        public override bool Calculer()
        {
            Resultat = 1;
            for (Int32 n =1; n<=Op1;n++)
            {
                Resultat = Resultat * n;
            }
            return true;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
