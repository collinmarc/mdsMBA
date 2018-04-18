using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdsCLS
{
    public class ClientASurveiller : Client
    {
        public ClientASurveiller()
        {

        }
        public ClientASurveiller(String pNom) : base(pNom, MyEnums.TYPECLIENT.ASURVEILLER)
        {

        }

        public override MyEnums.RESULTAT Calcule(Single pMontant)
        {
            MyEnums.RESULTAT vReturn = MyEnums.RESULTAT.ACCEPTEE;

            if (pMontant >5000)
            {
                vReturn = MyEnums.RESULTAT.REFUSEE;
            }
            if (this.EnCours > 1000 && pMontant>1000)
            {
                vReturn = MyEnums.RESULTAT.REFUSEE;
            }

            return vReturn;
        }
    }
}
