using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice;
namespace CaculatriceTest
{
    [TestClass]
    public class FactorielTest
    {
        [TestMethod]
        public void TestCalcul1()
        {
            //Arrange
            Factoriel op = new Factoriel();

            //act
            op.Calculer(4,4);
            Single res = op.Resultat;
            //Assert
            Assert.AreEqual(24, res);

            //act
            op.Calculer(5, 5);
            res = op.Resultat;
            //Assert
            Assert.AreEqual(120, res);
        }
    }
}
