using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice;

namespace CaculatriceTest
{
    [TestClass]
    public class TestWebService
    {
          [TestMethod]
        public void TestISBNVide()
        {
            Media oMedia = new Media();
            oMedia.ISBN = "";

            oMedia.getInfos();

            Assert.AreEqual("#NA", oMedia.Auteur);
            Assert.AreEqual(Convert.ToDateTime("1970/01/01"), oMedia.DateParution);

        }
        [TestMethod]
        public void TestISBNOK1()
        {
            Media oMedia = new Media();
            oMedia.ISBN = "978-2-35024-593-9";

            // Creer un bouchon du WS
            //injecter dans le Média

            oMedia.getInfos();

            Assert.AreEqual("Peter", oMedia.Auteur);
            Assert.AreEqual(Convert.ToDateTime("2017/03/01"), oMedia.DateParution);

        }
        [TestMethod]
        public void TestISBNINCONNU()
        {
            Media oMedia = new Media();
            oMedia.ISBN = "999-9-99999-999-9";
            //..
            oMedia.getInfos();

            Assert.AreEqual("Inconnu", oMedia.Auteur);
            Assert.AreEqual(Convert.ToDateTime("1970/01/01"), oMedia.DateParution);

        }
        [TestMethod]
        public void TestISBNINCorrect()
        {
            Media oMedia = new Media();
            oMedia.ISBN = "RIEN";
            //..
            Assert.IsFalse(oMedia.getInfos());

            Assert.AreEqual("ISBNIncorrect", oMedia.Auteur);
            Assert.AreEqual(Convert.ToDateTime("1970/01/01"), oMedia.DateParution);

        }
    }
}
