using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    public class Client
    {
        public enum TypeClient
        {
            NORMAL = 0,
            PREMIUM = 1,
            A_SURVEILLER = 2,
            COLLABORATEUR = 3
        }

        public Client.TypeClient Type { get; set; }

        /// <summary>
        /// Montant de l'encours
        /// </summary>
        public Single MtEc { get; set; }

        /// <summary>
        /// Acceptation d'une commande
        /// </summary>
        /// <param name="pMtCmd">Montant de la commande</param>
        /// <returns></returns>
        public Boolean Accepte(Single pMtCmd )
        {
            if (Type == TypeClient.NORMAL && (MtEc > 1000 && MtEc < 3000) && pMtCmd > 5000)
            {
                return false;
            }
            if (Type == TypeClient.NORMAL && (MtEc > 3000 ) && (pMtCmd >1000 && pMtCmd < 5000))
            {
                return false;
            }
            if (Type == TypeClient.NORMAL && (MtEc > 3000) && ( pMtCmd > 5000))
            {
                return false;
            }
            if (Type == TypeClient.PREMIUM && (MtEc > 3000) && (pMtCmd > 5000))
            {
                return false;
            }
            if (Type == TypeClient.A_SURVEILLER && (MtEc > 3000) && (pMtCmd > 5000))
            {
                return false;
            }
            if (Type == TypeClient.A_SURVEILLER && (MtEc > 3000) && (pMtCmd > 5000))
            {
                return false;
            }
            if (Type == TypeClient.A_SURVEILLER && (MtEc > 1000 && MtEc<3000) && (pMtCmd>1000 && pMtCmd < 5000))
            {
                return false;
            }
            if (Type == TypeClient.A_SURVEILLER && (MtEc > 1000 && MtEc < 3000) && (pMtCmd >  5000))
            {
                return false;
            }
            if (Type == TypeClient.A_SURVEILLER && (MtEc < 1000) && (pMtCmd > 5000))
            {
                return false;
            }
            if (Type == TypeClient.A_SURVEILLER && (MtEc > 3000) && (pMtCmd > 1000  && pMtCmd < 5000))
            {
                return false;
            }
            return true;
        }

    }
}
