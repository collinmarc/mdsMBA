using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mdsCLS;

namespace mdsCLSTU
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            mdsCLS.WSISBN.ISBNSoap oClient = new mdsCLS.WSISBN.SBNSoapClient("ISBNSoap12");
            Assert.AreEqual("test", oClient.GetISBNInformation("TEST"));

        }
    }
}
