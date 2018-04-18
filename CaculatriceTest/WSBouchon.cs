using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculatrice;

namespace CaculatriceTest
{
    public class WSBouchon:Calculatrice.WSMedia.ISBNSoap
    {
        // CODE Bouchonné

        public string GetISBNInformation(string pISBN)
        {
            if (pISBN == "978-2-212-13994-5")
            {
                return "Eric Sarrion;01/01/2016";
            }
            else
            {
                return "Christophe Collins;18/01/2018";
            }
        }

        public Task<string> GetISBNInformationAsync(string Code)
        {
            throw new NotImplementedException();
        }

        public Boolean ISBNExists(String pISBN)
        {
            if (pISBN == "999-9-999-99999-9")
            {
                return false;
            }
            else
            {
                return true;
            }
        }//        ISBNExists

    }
}
