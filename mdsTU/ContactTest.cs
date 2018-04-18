using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mdsCLS;

namespace mdsTU
{
    [TestClass]
    public class ContactTest
    {
        [TestMethod]
        public void TestToXML()
        {

            Contact oContact = new mdsCLS.Contact("TelPro", "060708009");
            oContact.MyProperty = "N'importeQuoi";
            oContact.ToXml("Test.xml");

            System.Diagnostics.Process.Start("test.xml");

            Contact oContact2 = new Contact();
            oContact2.fromXML("test.xml");

            Assert.AreEqual(oContact.Type, oContact2.Type);
            Assert.AreEqual(oContact.Adresse, oContact2.Adresse);
            Assert.AreEqual(oContact.isDefault, oContact2.isDefault);



        }
    }
}
