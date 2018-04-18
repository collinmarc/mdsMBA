using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice;
using Moq;

namespace CaculatriceTest
{
    [TestClass]
    public class MediaTest
    {
        /// <summary>
        /// Test avec l'injection de dépendance  et un bouchon
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {


            Media oMedia = new FTOMedia();
            // Création du bouchon
            Calculatrice.WSMedia.ISBNSoap oWSBouchon = new WSBouchon();
            //injection du bouchon
           ((FTOMedia) oMedia).setWS(oWSBouchon);

            oMedia.ISBN = "978-2-212-13994-5";
            oMedia.getInfos(); // Appel du WS bouchon

            Assert.AreEqual("Eric Sarrion", oMedia.Auteur);
            Assert.AreEqual(new DateTime(2016,01,01), oMedia.DateParution);

        }

        /// <summary>
        /// Test avec l'injection de dépendance  et un Mock
        /// </summary>
        [TestMethod]
        [DataTestMethod]
        [DataRow("978-2-212-13994-5", "Eric Sarrion", 2016, 01, 01)]
        [DataRow("978-1-978-08265-6", "Christophe Collins", 2018, 01, 18)]

       public void TestMethodMOQ1(String pIsbn, String pAuteur, int pYear, int pMonth, int pDay)
        {
            //Arrange
            //---------
            Media oMedia = new FTOMedia();
            // Création du bouchon Mock
            Calculatrice.WSMedia.ISBNSoap oWSBouchon=null;
            Mock<Calculatrice.WSMedia.ISBNSoap> WSMock = new Mock<Calculatrice.WSMedia.ISBNSoap>();
            oWSBouchon = WSMock.Object;

            //redinifition du comportement du Bouchon,
            WSMock.Setup(obj => obj.GetISBNInformation("978-2-212-13994-5")).Returns("Eric Sarrion;01/01/2016");
            WSMock.Setup(obj => obj.GetISBNInformation("978-1-978-08265-6")).Returns("Christophe Collins;18/01/2018");

            //injection du bouchon
            ((FTOMedia)oMedia).setWS(oWSBouchon);

            //ACT
            //_________
            oMedia.ISBN = pIsbn;
            oMedia.getInfos(); // Appel du WS bouchon

            //ASSERT
            //---------
            Assert.AreEqual(pAuteur, oMedia.Auteur);
            Assert.AreEqual(new DateTime(pYear, pMonth, pDay), oMedia.DateParution);


        }

        /// <summary>
        /// Vérification du nombre d'appel au WS
        /// </summary>
        /// <param name="pIsbn">ISBN demandé</param>
        /// <param name="pnbreAttendus">Nbre d'appels attendus</param>
        [TestMethod]
        [DataTestMethod]
        [DataRow("", 0)]
        [DataRow("TOTO", 0)]
        [DataRow("999-9-999-99999-9", 1)]
        [DataRow("978-2-212-13994-5", 1)]
        [DataRow("978-1-978-08265-6", 1)]

        public void TestMethodMOQVerify(String pIsbn, int pnbreAttendus)
        {
            //Arrange
            //---------
            Media oMedia = new FTOMedia();
            // Création du bouchon Mock
            Calculatrice.WSMedia.ISBNSoap oWSBouchon = null;
            Mock<Calculatrice.WSMedia.ISBNSoap> WSMock = new Mock<Calculatrice.WSMedia.ISBNSoap>();
            oWSBouchon = WSMock.Object;

            //redinifition du comportement du Bouchon,
            WSMock.Setup(obj => obj.GetISBNInformation(It.IsAny<String>())).Returns("Inconnu;31/12/3124");
            WSMock.Setup(obj => obj.GetISBNInformation("978-2-212-13994-5")).Returns("Eric Sarrion;01/01/2016");
            WSMock.Setup(obj => obj.GetISBNInformation("978-1-978-08265-6")).Returns("Christophe Collins;18/01/2018");

            //injection du bouchon
            ((FTOMedia)oMedia).setWS(oWSBouchon);

            //ACT
            //_________
            oMedia.ISBN = pIsbn;
            oMedia.getInfos(); // Appel du WS bouchon

            //ASSERT
            //---------
            WSMock.Verify(obj => obj.GetISBNInformation(pIsbn), Times.Exactly(pnbreAttendus));
            //Lambda expression

        }

        //  Vérification que la pelle avec ISBN Vide => Pas d'appel au WS
        //  Vérification que l'appel avec ISBN incorrect => Pas d'appel au WS
        //  Vérification que l'appel avec ISBN inconnu => 1 appel au WS
        //  Vérification que l'appel avec ISBN correct => 1 appel au WS



    }
}
