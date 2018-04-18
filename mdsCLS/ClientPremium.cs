using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdsCLS
{
    public class ClientPremium : Client
    {
        public ClientPremium()
        {

        }
        public ClientPremium(String pNom) : base(pNom, MyEnums.TYPECLIENT.PREMIUM)
        {

        }

        public override MyEnums.RESULTAT Calcule(Single pMontant)
        {
            MyEnums.RESULTAT vReturn = MyEnums.RESULTAT.ACCEPTEE;

            if (this.EnCours > 3000 && pMontant > 5000)
            {
                vReturn = MyEnums.RESULTAT.REFUSEE;
            }

            return vReturn;
        }
    }
}
