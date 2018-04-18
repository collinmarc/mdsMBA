using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    public class WebServiceTest : IWebService
    {
        public string getInfos(string pIsbn)
        {
            return "Ceci est un test";
        }
    }
}
