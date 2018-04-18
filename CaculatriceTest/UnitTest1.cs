using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Calculatrice;

namespace CaculatriceTest
{
    [TestClass]
    public class testMediaMOQ
    {
        [TestMethod]
        public void TestMethod1()
        {
            Media oMedia = new Media();

            oMedia.ISBN = "AQWZSX";
            oMedia.Auteur = "COLLIN";
            oMedia.DateParution = new DateTime(1978,12, 23);

            Assert.AreEqual("AQWZSX;COLLIN;23/12/1978", oMedia.ToString());

            Mock<Media> mediaMock = new Mock<Media>();
            Media oMediaMOQ = mediaMock.Object;
            Assert.IsNull( oMediaMOQ.ToString());

            mediaMock.Setup(obj => obj.ToString()).Returns("TOTO");
 
            oMediaMOQ.ISBN = "AQWZSX";
            oMediaMOQ.Auteur = "COLLIN";
            oMediaMOQ.DateParution = new DateTime(1978, 12, 23);

            Assert.AreNotEqual("AQWZSX;COLLIN;23/12/1978", oMediaMOQ.ToString());
            Assert.AreEqual("TOTO", oMediaMOQ.ToString());

            mediaMock.Setup(obj => obj.ToString()).CallBase();
            Assert.AreEqual("AQWZSX;COLLIN;23/12/1978", oMediaMOQ.ToString());

            mediaMock.SetupSequence(obj => obj.ToString()).Returns("TOTO").Returns("TITI").CallBase();
            Assert.AreEqual("TOTO", oMediaMOQ.ToString());
            Assert.AreEqual("TITI", oMediaMOQ.ToString());
            Assert.AreEqual("AQWZSX;COLLIN;23/12/1978", oMediaMOQ.ToString());

            //mediaMock.Setup(obj => obj.test(It.IsAny<String>())).Returns("RIEN");
            //Assert.AreEqual("RIEN", oMediaMOQ.test("ESSAI"));
            mediaMock.Setup(obj => obj.test("MARC")).Returns("COLLIN");
            mediaMock.Setup(obj => obj.test("COLLIN")).Returns("MARC");
            Assert.AreEqual("MARC", oMediaMOQ.test("COLLIN"));
            Assert.AreEqual("COLLIN", oMediaMOQ.test("MARC"));



        }
    }
}
