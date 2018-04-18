using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace mdsCLS
{
    public class Contact
    {
        public Contact()
        {
            isDefault = false;
            this.dateCreation = DateTime.Now;

        } //Obligatoire pour la serialization XML
        public Contact(String pType, String pAdresse):this()
        {
            Type = pType;
            Adresse = pAdresse;
        }
        [XmlAttribute("Type")]
        public String Type { get; set; }
        public String Adresse { get; set; }
        [XmlElement("defaut")]
        public Boolean isDefault { get; set; }
        public DateTime dateCreation { get; set; }
        [XmlIgnore()]
        public String MyProperty { get; set; }

        /// <summary>
        /// Serialization en XML
        /// </summary>
        public void ToXml(String pFileName )
        {
            XmlSerializer oXml = new XmlSerializer(typeof(Contact));

            System.IO.StreamWriter osw = new System.IO.StreamWriter(pFileName);
            oXml.Serialize(osw, this);
            osw.Close();

        }//ToXml

        public void fromXML(String pFileName)
        {
            XmlSerializer oXml = new XmlSerializer(typeof(Contact));

            System.IO.StreamReader osr = new System.IO.StreamReader(pFileName);

            Contact oContact = (Contact)oXml.Deserialize(osr);
            this.Type = oContact.Type;
            this.Adresse = oContact.Adresse;
            this.isDefault = oContact.isDefault;
            this.dateCreation = oContact.dateCreation;
        }
    }// Class


}
