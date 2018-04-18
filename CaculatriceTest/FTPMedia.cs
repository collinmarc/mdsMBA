using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculatrice;

namespace CaculatriceTest
{
    public class FTOMedia : Calculatrice.Media
    {
        //injection de dépendance
        public void setWS(Calculatrice.WSMedia.ISBNSoap pWS)
        {
            oWS = pWS;
        }


    }
}
