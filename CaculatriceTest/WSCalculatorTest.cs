using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice;

namespace CaculatriceTest
{
    [TestClass]
    public class WSCalculatorTest
    {
        [TestMethod]
        public void TestAdd()
        {
            Calculatrice.WSCalculatrice.CalculatorSoapClient oWS = new Calculatrice.WSCalculatrice.CalculatorSoapClient();

                int result = oWS.Add(3, 2);

            Assert.AreEqual(5, result);

        }
    }
}
