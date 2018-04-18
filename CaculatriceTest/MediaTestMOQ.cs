//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Calculatrice;

//namespace CaculatriceTest
//{
//    [TestClass]
//    public class MediaTestMOQ
//    {
//        [TestMethod]
//        public void TestMethod1()
//        {

//            Mock<Media> objMock = new Mock<Media>();
//            Media oWS = objMock.Object;
//            objMock.Setup(obj => obj.test()).Returns("TEST");


//            String str = oWS.test();
//            Assert.AreEqual("TEST", str);


//        }
//        [TestMethod]
//        public void TestMethod2()
//        {


//            Mock<Calculatrice.WSMedia.ISBNSoap> objMock = new Mock<Calculatrice.WSMedia.ISBNSoap>();
//            objMock.Setup(obj => obj.GetISBNInformation("COUCOU")).Returns("TEST");
//            objMock.Setup(obj => obj.GetISBNInformation("TOTO")).Returns("TITI");


//            Calculatrice.WSMedia.ISBNSoap oWS = objMock.Object;

//            String str = oWS.GetISBNInformation("COUCOU");
//            Assert.AreEqual("TEST", str);

//            str = oWS.GetISBNInformation("TOTO");
//            Assert.AreEqual("TITI", str);


//        }

//        [TestMethod]
//        [DataTestMethod]
//        [DataRow("978-2-212-13994-5", "Eric Sarrion", "01/01/2016")]
//      //  [DataRow("978-1-978-08265-6", "Christophe Collins", "18/01/2018")]
//        public void TestGetInfosISBNOKConnu(String pISBN, String pAuteur, String pDate)
//        {
//            Media oMedia = new FTOMedia();
//            oMedia.ISBN = pISBN;

//            //injection de dépendance
//            Mock<Calculatrice.WSMedia.ISBNSoap> objMock = new Mock<Calculatrice.WSMedia.ISBNSoap>();
//            Calculatrice.WSMedia.ISBNSoap oStub = objMock.Object;
//            Assert.IsNull(oStub.GetISBNInformation("978-2-212-13994-5"));
//            objMock.Setup(obj => obj.GetISBNInformation("978-2-212-13994-5")).Returns("Eric Sarrion;01/01/2016");
//            objMock.Setup(obj => obj.GetISBNInformation("978-1-978-08265-6")).Returns("Christophe Collins;18/01/2018");

//            ((FTOMedia)oMedia).setWS(oStub);
//            oMedia.getInfos();
//            Assert.AreEqual(pAuteur, oMedia.Auteur);
//            Assert.AreEqual(Convert.ToDateTime(pDate), oMedia.DateParution);
//        }

//        [TestMethod]
//        public void TestMOQ()
//        {

//            //injection de dépendance
//            Mock<Calculatrice.WSMedia.ISBNSoap> objMock = new Mock<Calculatrice.WSMedia.ISBNSoap>();
//            Calculatrice.WSMedia.ISBNSoap oStub = objMock.Object;

//            Assert.IsNull(oStub.GetISBNInformation("978-2-212-13994-5"));

//            objMock.Setup(obj => obj.GetISBNInformation("978-2-212-13994-5")).Returns("Eric Sarrion;01/01/2016");

//            Assert.AreEqual("Eric Sarrion;01/01/2016",oStub.GetISBNInformation("978-2-212-13994-5"));

//            objMock.Setup(obj => obj.GetISBNInformation("978-1-978-08265-6")).Returns("Christophe Collins;18/01/2018");

//            Assert.AreEqual("Christophe Collins;18/01/2018", oStub.GetISBNInformation("978-1-978-08265-6"));
//            Assert.AreEqual("Eric Sarrion;01/01/2016", oStub.GetISBNInformation("978-2-212-13994-5"));

//        }

//        [TestMethod]
//        [DataTestMethod]
//        [DataRow("978-2-212-13994-5", "Eric Sarrion", "01/01/2016")]
//        //  [DataRow("978-1-978-08265-6", "Christophe Collins", "18/01/2018")]
//        public void TestVerifyMOQ(String pISBN, String pAuteur, String pDate)
//        {
//            Media oMedia = new Media();
//            oMedia.ISBN = pISBN;

//            //injection de dépendance
//            Mock<Calculatrice.WSMedia.ISBNSoap> objMock = new Mock<Calculatrice.WSMedia.ISBNSoap>();
//            Calculatrice.WSMedia.ISBNSoap oStub = objMock.Object;
////            Assert.IsNull(oStub.GetISBNInformation("978-2-212-13994-5"));
//            objMock.Setup(obj => obj.GetISBNInformation("978-2-212-13994-5")).Returns("Eric Sarrion;01/01/2016");
//            objMock.Setup(obj => obj.GetISBNInformation("978-1-978-08265-6")).Returns("Christophe Collins;18/01/2018");

//            oMedia.SetWS(oStub);
//            oMedia.getInfos();
//            Assert.AreEqual(pAuteur, oMedia.Auteur);
//            Assert.AreEqual(Convert.ToDateTime(pDate), oMedia.DateParution);


//            objMock.Verify(obj => obj.GetISBNInformation(It.IsAny<String>()));
//            objMock.Verify(obj => obj.GetISBNInformation(pISBN));
//            objMock.Verify(obj => obj.GetISBNInformation(pISBN), Times.Exactly(1));
//            objMock.Verify(obj => obj.GetISBNInformation("978-1-978-08265-6"), Times.Never);
//        }
//    }
//}
