using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
    public class Bidon
    {
        /// <summary>
        /// renvoie une excdeption de type ArgumentException si le paramètre est > 10
        /// </summary>
        /// <param name="p"></param>
        public void M1(Int32 p)
        {

            if (p>10)
            {
                throw new ArgumentException("le param doit être inféreieur à 10");
            }
        }
        /// <summary>
        /// Attends un nombre de secondes
        /// </summary>
        /// <param name="pNbSec"></param>
        public void M2(Int32 pNbSec)
        {
            System.Threading.Thread.Sleep(3000);
        }
    }
}
