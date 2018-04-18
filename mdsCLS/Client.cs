using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace mdsCLS
{
    [XmlInclude(typeof(ClientNormal))]
    [XmlInclude(typeof(ClientASurveiller))]
    [XmlInclude(typeof(ClientPremium))]
    public abstract class Client
    {

        public String Nom { get; set; }
        public MyEnums.TYPECLIENT TypeClient { get; set; }
        public Int32 Num { get; set; }
        public Single EnCours { get; set; }
        public List<Contact> lstContact { get; set; }
        [XmlIgnore()]
        public DateTime dateDernCommande { get; set; }
        [XmlElement("lastCmd")]
        public String dateDernCommandeXML {
            get{
                return dateDernCommande.ToString("dd/MM/yyyy");
                }
            set {
                dateDernCommande = Convert.ToDateTime(value);
                }
        }
        [XmlIgnore()]
        public Int32 numDernCommande { get; set; }

        public Client()
        { }
        public Client (String pNom, MyEnums.TYPECLIENT pType)
        {
            this.Nom = pNom;
            this.TypeClient = pType;
            lstContact = new List<Contact>();
        }
        public abstract MyEnums.RESULTAT Calcule(Single pMontant);

        /// <summary>
        /// Ecrit le contenu du client dans un fichier CSV
        /// le fichier cree est "CLT<Num>.csv"
        /// </summary>
        /// <returns></returns>
        public Boolean toCSV()
        {
            Boolean bReturn = false;
            if (Num <1 )
            {
                throw new InvalidOperationException("le numéro doit être renseigné");
            }

            try
            {
                String strFilename = "CLT" + this.Num + ".csv";
                String strCSV = "" + this.Num + ";" + this.Nom + ";" + this.TypeClient + ";" + this.EnCours;
                File.WriteAllText(strFilename, strCSV);
                StreamWriter ofs = File.AppendText(strFilename);
                ofs.WriteLine();
                foreach (Contact oItem in lstContact)
                {

                    strCSV = oItem.Type + ";" + oItem.Adresse;
                    ofs.WriteLine(strCSV);
                }
                ofs.Close();

                bReturn = true;
            }
            catch  (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERR en écriture" + ex.Message);
                bReturn = false;
            }
            return bReturn;
        }
        /// <summary>
        /// Lecture depuis un fichier CSV
        /// </summary>
        /// <param name="pNum"></param>
        /// <returns></returns>
        public static Client fromCSV(Int32 pNum)
        {
            Client oReturn = null;
           if (pNum < 1)
            {
                throw new InvalidOperationException("Le numéro doit être supérieur à 1");
            }
            try
            {
                String strFilename = "CLT" + pNum + ".csv";
                if (File.Exists(strFilename))
                {
                    String[] strLines = System.IO.File.ReadAllLines(strFilename);
                    String[] tabLine1 = strLines[0].Split(';');

                    MyEnums.TYPECLIENT nType = (MyEnums.TYPECLIENT)Enum.Parse(typeof(MyEnums.TYPECLIENT), tabLine1[2]);
                    String strNom = tabLine1[1];
                    oReturn = ClientFactory.creerClient(nType, strNom);
                    oReturn.Num = Convert.ToInt32(tabLine1[0]);
                    oReturn.EnCours = Convert.ToSingle(tabLine1[3]);

                    Boolean bPremiereligne = true;
                    foreach (String str in strLines)
                    {
                        if (bPremiereligne)
                        {
                            bPremiereligne = false;
                        }
                        else
                        {
                            String[] tabcontact = str.Split(';');
                            Contact oContact = new Contact(tabcontact[0], tabcontact[1]);
                            oReturn.lstContact.Add(oContact);
                        }

                    }
                }
                else
                {
                    oReturn = null;
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERR en lecture" + ex.Message);
                oReturn = null;
            }
            return oReturn;


        }
    }
}
