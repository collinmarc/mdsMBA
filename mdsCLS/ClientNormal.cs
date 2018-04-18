using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdsCLS
{
    public class ClientNormal : Client
    {

        public ClientNormal() { }
        public ClientNormal(String pNom) : base(pNom, MyEnums.TYPECLIENT.NORMAL)
        {

        }

        /// <summary>
        /// Refus si : 
        ///* 1000<Encours<3000  et Montant>5000
        ///* encours>3000 et Montant >1000
        /// </summary>
        /// <param name="pMontant"></param>
        /// <returns></returns>
        public override MyEnums.RESULTAT Calcule(Single pMontant)
        {
            MyEnums.RESULTAT vReturn = MyEnums.RESULTAT.ACCEPTEE;

            if (this.EnCours >1000 && this.EnCours< 3000 &&  pMontant>5000)
            {
                vReturn = MyEnums.RESULTAT.REFUSEE;
            }
            if (this.EnCours > 3000 && pMontant > 1000)
            {
                vReturn = MyEnums.RESULTAT.REFUSEE;
            }

            return vReturn;
        }
    }
}
