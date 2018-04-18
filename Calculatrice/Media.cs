using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Calculatrice
{
    public enum etatMedia
    {
        NOUVEAU,
            DISPONIBLE,
            EMPRUNTE,
            A_REPARER,
            A_SUPPRIMER
    }
    public class Media
    {


        public String ISBN { get; set; }
        public String Auteur { get; set; }
        public DateTime DateParution { get; set; }

        protected WSMedia.ISBNSoap oWS ;

        public override String ToString()
        {
            return ISBN + ";" + Auteur + ";" + DateParution.ToShortDateString();
        }

        public virtual String test (String pStr)
        {
            return pStr;
        }
        public Media()
        {
                oWS = new WSMedia.SBNSoapClient();
        }


 
        public Boolean getInfos()
        {
            // Appel Du WS ......
            //Recupération de la réponse
            if (ISBN == "")
            {
                Auteur = "#NA";
                DateParution = Convert.ToDateTime("01/01/1970");
                return true;
            }
            else
            {

                if (isISBNcorrect())
                {
                    String str = oWS.GetISBNInformation(ISBN);
                    String[] tab = str.Split(';');
                    Auteur = tab[0];
                    DateParution = Convert.ToDateTime(tab[1]);
                    return true;
                }

                else
                {
                    return false;
                }
            }

        }

        private Boolean isISBNcorrect()
        {

            Regex myRegex = new Regex("[0-9]{3}-[0-9]-[0-9]{3}-[0-9]{5}-[0-9]");
            return myRegex.IsMatch(ISBN);
        }

        public etatMedia etat{ get; set; }

        public Boolean MettreEnRayon()
        {
            return false;
        }
        public Boolean MettreAuRebut()
        {
            return false;
        }
        public Boolean Emprunter()
        {
            return false;
        }
        public Boolean RendreOK()
        {
            return false;
        }
        public Boolean RendreAReparer()
        {
            return false;
        }
        public Boolean Reparer()
        {
            return false;
        }
        public Boolean RendrePerdu()
        {
            return false;
        }

        /// <summary>
        /// Renvoie l'object sous forme d'une chaine XML
        /// </summary>
        /// <returns></returns>
        public String ToXML()
        {

            XmlSerializer oSer = new XmlSerializer(typeof(Media));

            //System.IO.StringWriter osw = new System.IO.StringWriter();
            System.IO.StreamWriter osw = new System.IO.StreamWriter(ISBN+".xml");

            oSer.Serialize(osw,this);

            osw.Close();
            return osw.ToString();

        }
        public static Media fromXML(String pISBN)
        {

            XmlSerializer oSer = new XmlSerializer(typeof(Media));

//            System.IO.StringReader osR = new System.IO.StringReader(pXML);
            System.IO.StreamReader osR = new System.IO.StreamReader(pISBN+".xml");

            Object obj = oSer.Deserialize(osR);
            osR.Close();

            return (Media) obj;

        }

        public virtual String test()
        {
            return "ATESTER";
        }
    }
}
