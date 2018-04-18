using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mdsCLS;
using System.Xml.Serialization;
using System.Diagnostics;

namespace mdsTU
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void TestCreationClient()
        {

            Client oClient = ClientFactory.creerClient(MyEnums.TYPECLIENT.NORMAL, "TOTO");

            Assert.IsTrue("TOTO" == oClient.Nom);
            Assert.IsTrue(MyEnums.TYPECLIENT.NORMAL == oClient.TypeClient);

            oClient = ClientFactory.creerClient(MyEnums.TYPECLIENT.PREMIUM, "TITI");
            Assert.IsTrue("TITI" == oClient.Nom);
            Assert.IsTrue(MyEnums.TYPECLIENT.PREMIUM== oClient.TypeClient);

            oClient = ClientFactory.creerClient(MyEnums.TYPECLIENT.ASURVEILLER, "TUTU");
            Assert.IsTrue("TUTU" == oClient.Nom);
            Assert.IsTrue(MyEnums.TYPECLIENT.ASURVEILLER== oClient.TypeClient);
        }
        [TestMethod]
        public void TestCalculeClientNormal()
        {
            Client oClient = ClientFactory.creerClient(MyEnums.TYPECLIENT.NORMAL, "Marc");

            oClient.EnCours = 500;
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(500));
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(2500));
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(5500));

            oClient.EnCours = 1500;
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(500));
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(2500));
            Assert.AreEqual(MyEnums.RESULTAT.REFUSEE, oClient.Calcule(5500));

            oClient.EnCours = 5500;
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(500));
            Assert.AreEqual(MyEnums.RESULTAT.REFUSEE, oClient.Calcule(2500));
            Assert.AreEqual(MyEnums.RESULTAT.REFUSEE, oClient.Calcule(5500));

        } // TestCalculeNormal
        [TestMethod]
        public void TestCalculeClientPremium()
        {
            Client oClient = ClientFactory.creerClient(MyEnums.TYPECLIENT.PREMIUM, "Marc");

            oClient.EnCours = 500;
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(500));
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(2500));
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(5500));

            oClient.EnCours = 1500;
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(500));
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(2500));
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(5500));

            oClient.EnCours = 5500;
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(500));
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(2500));
            Assert.AreEqual(MyEnums.RESULTAT.REFUSEE, oClient.Calcule(5500));

        } // TestCalculePremium
        [TestMethod]
        public void TestCalculeClientAsurveiller()
        {
            Client oClient = ClientFactory.creerClient(MyEnums.TYPECLIENT.ASURVEILLER, "Marc");

            oClient.EnCours = 500;
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(500));
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(2500));
            Assert.AreEqual(MyEnums.RESULTAT.REFUSEE, oClient.Calcule(5500));

            oClient.EnCours = 1500;
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(500));
            Assert.AreEqual(MyEnums.RESULTAT.REFUSEE, oClient.Calcule(2500));
            Assert.AreEqual(MyEnums.RESULTAT.REFUSEE, oClient.Calcule(5500));

            oClient.EnCours = 5500;
            Assert.AreEqual(MyEnums.RESULTAT.ACCEPTEE, oClient.Calcule(500));
            Assert.AreEqual(MyEnums.RESULTAT.REFUSEE, oClient.Calcule(2500));
            Assert.AreEqual(MyEnums.RESULTAT.REFUSEE, oClient.Calcule(5500));

        } // TestCalculeAsurveiller


        [TestMethod]
        public void testCSV()
        {
            //Suppression du fichier initial
            if (System.IO.File.Exists("CLT1.csv"))
            {
                System.IO.File.Delete("CLT1.csv");
            }

            // Creation d'un client
            Client oClient = ClientFactory.creerClient(MyEnums.TYPECLIENT.NORMAL, "Johnny");
            oClient.Num = 1;
            oClient.EnCours = 200;

            oClient.lstContact.Add(new Contact("TelPro", "06070809000"));
            oClient.lstContact.Add(new Contact("mail", "a@a.com"));

            //Sauvegarde d'un client
            Assert.IsTrue(oClient.toCSV());
            Assert.IsTrue(System.IO.File.Exists("CLT1.csv"));

            //rechargement d'un client
            oClient = Client.fromCSV(1);

            // Verification du client
            Assert.AreEqual(MyEnums.TYPECLIENT.NORMAL, oClient.TypeClient);
            Assert.AreEqual(1, oClient.Num);
            Assert.AreEqual("Johnny", oClient.Nom);
            Assert.AreEqual(1, oClient.Num);
            Assert.AreEqual(200, oClient.EnCours);

            //Verification de la liste des clients
            Assert.AreEqual(2, oClient.lstContact.Count);
            Assert.AreEqual("TelPro", oClient.lstContact[0].Type);
            Assert.AreEqual("06070809000", oClient.lstContact[0].Adresse);
            Assert.AreEqual("mail", oClient.lstContact[1].Type);
            Assert.AreEqual("a@a.com", oClient.lstContact[1].Adresse);


        }

        [TestMethod]
        public void testCSVinexistant()
        {
            //Suppression du fichier initial
            if (System.IO.File.Exists("CLT1234.csv"))
            {
                System.IO.File.Delete("CLT1234.csv");
            }

            Client oClient = Client.fromCSV(1234);

            Assert.IsNull(oClient);
        }


        [TestMethod]
        public void MyTestMethod()
        {
            Client oClient = ClientFactory.creerClient(MyEnums.TYPECLIENT.NORMAL, "Test");
            oClient.EnCours = 500;
            oClient.lstContact.Add(new Contact("Tel", "09080706005"));
            oClient.lstContact.Add(new Contact("mail", "a@a.com"));
            oClient.lstContact.Add(new Contact("Twit", "#TEST#"));
            oClient.dateDernCommande = DateTime.Today;


            XmlSerializer oxml = new XmlSerializer(typeof(Client));
            System.IO.StreamWriter osw = new System.IO.StreamWriter("test1.xml");

            oxml.Serialize(osw,oClient);

            Process.Start("test1.xml");
        }
    }
}
