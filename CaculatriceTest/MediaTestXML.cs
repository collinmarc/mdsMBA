using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice;
namespace CaculatriceTest
{
    [TestClass]
    public class MediaTestXML
    {
        [TestMethod]
        public void TestToXML()
        {
            //Arranage
            Media oMedia = new Media();
            oMedia.ISBN = "MonISBN";
            oMedia.Auteur = "Monauteur";
            oMedia.DateParution = new DateTime(2018,03,12);

            //Act
            String str = oMedia.ToXML();

            //assert
            Assert.IsTrue(System.IO.File.Exists("MonISBN.xml"));


        }
        [TestMethod]
        public void TestFromXML()
        {
            //Arrange
            Media oMedia = new Media();
            oMedia.ISBN = "MonISBN";
            oMedia.Auteur = "MonAuteur";
            oMedia.DateParution = new DateTime(2018, 03, 12);
            String str = oMedia.ToXML();

            //Act
            Media oMedia2 = Media.fromXML("MonISBN");

            //Assert
            Assert.AreEqual("MonISBN", oMedia2.ISBN);
            Assert.AreEqual("MonAuteur", oMedia2.Auteur);
            Assert.AreEqual(new DateTime(2018, 03, 12), oMedia2.DateParution);



        }
    }
}
