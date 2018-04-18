using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdsCLS
{
    public static class ClientFactory
    {

        public static Client creerClient (MyEnums.TYPECLIENT pType, String pNom )
        {
            Client oClient = null;
            switch (pType)
            { 
                case MyEnums.TYPECLIENT.ASURVEILLER:
                    oClient = new ClientASurveiller(pNom);
                    break;
                case MyEnums.TYPECLIENT.NORMAL:
                    oClient = new ClientNormal(pNom);
                    break;
                case MyEnums.TYPECLIENT.PREMIUM:
                    oClient = new ClientPremium(pNom);
                    break;
            }
            return oClient;
        }

    }
}
