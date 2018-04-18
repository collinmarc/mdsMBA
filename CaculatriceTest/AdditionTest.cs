using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice;
namespace CaculatriceTest
{
    [TestClass]
    public class AdditionTest
    {
        [TestMethod]
        public void TestConstructeurAVide()
        {
            Addition op = new Addition();

            Assert.AreEqual(false, op.Etat);
            Assert.AreEqual(0, op.Resultat);
        }


        [TestMethod]
        public void TestConstructeurAvecParamsEtat()
        {
            Addition op = new Addition(12, 3);
            Assert.AreEqual(true, op.Etat);
        }
        [TestMethod]
        public void TestConstructeurAvecParamsResultat()
        {
            //Arrange
            Addition op = new Addition(12, 3);
            //Act
            Single res = op.Resultat;
            //Assert
            Assert.AreEqual(15, res);
        }
        [TestMethod]
        public void testCalculerParamReturn()
        {
            //Arrange
            Addition op = new Addition();
            //Act
            Boolean res = op.Calculer(12,3) ;
            //Assert
            Assert.IsTrue(res);

        }
        [TestMethod]
        public void testCalculerParamAtrributs()
        {
            //Arrange
            Addition op = new Addition(12,5);
            //Act
            Boolean res = op.Calculer(3, 2);
            //Assert
            Assert.AreEqual(3, op.Op1);
            Assert.AreEqual(2, op.Op2);

        }
        [TestMethod]
        public void testCalculerParamEtat()
        {
            //Arrange
            Addition op = new Addition();
            //Act
            Boolean res = op.Calculer(3, 2);
            //Assert
            Assert.AreEqual(true, op.Etat);

        }
        [TestMethod]
        public void testCalculerParamResultat1()
        {
            //Arrange
            Addition op = new Addition();
            //Act
            op.Calculer(12, 3);
            Single res = op.Resultat;
            //Assert
            Assert.AreEqual(15,res);

        }
        [TestMethod]
        public void testCalculerParamResultat2()
        {
            //Arrange
            Addition op = new Addition(5,4);
            //Act
            op.Calculer(12, 3);
            Single res = op.Resultat;
            //Assert
            Assert.AreEqual(15, res);

        }

        /// <summary>
        /// Test la methode calculer sur une Addition vide
        /// </summary>
        [TestMethod]
        public void testCalculerSansParamReturn()
        {
            //Arrange
            Addition op = new Addition();
            //Act
            
            Boolean res = op.Calculer();

            //Assert
            Assert.IsTrue(res);
            Assert.AreEqual(0,op.Resultat);

        }
        /// <summary>
        /// Test le code Retour methode calculer sur une Addition non  vide
        /// </summary>
        [TestMethod]
        public void testCalculerSansParamReturn2()
        {
            //Arrange
            Addition op = new Addition(5,2);
            //Act

            Boolean res = op.Calculer();

            //Assert
            Assert.IsTrue(res);

        }

        /// <summary>
        /// Test le code Retour methode calculer sur une Addition non  vide
        /// </summary>
        [TestMethod]
        public void testCalculerSansParamResultat()
        {
            //Arrange
            Addition op = new Addition(5, 2);
            //Act

           op.Calculer();
            Single res = op.Resultat;
            //Assert
            Assert.AreEqual(7,res);

        }
        /// <summary>
        /// Test le code Retour methode calculer sur une Addition non  vide
        /// </summary>
        [TestMethod]
        public void testCalculerSansParamEtat()
        {
            //Arrange
            Addition op = new Addition(5, 2);
            //Act

            op.Calculer();
            Boolean res = op.Etat;
            //Assert
            Assert.AreEqual(true,res);

        }
        [TestMethod]
        public void TestEqualsNull()
        {
            Addition op = new Addition(12, 4);
            Object obj = null; ;
            Assert.IsFalse(op.Equals(obj));
        }

        [TestMethod]
        public void TestEqualsNonAddition()
        {
            Addition op = new Addition(12, 4);
            Assert.IsFalse(op.Equals(new Exception()));
        }
        [TestMethod]
        public void TestEqualsAdditionEgales()
        {
            Addition op = new Addition(12, 3);
            Assert.IsTrue(op.Equals(new Addition(11, 4)));
            Assert.IsTrue(op.Equals(op));
        }

        [TestMethod]
        public void TestEqualsAdditionNonEgales()
        {
            Addition op = new Addition(12, 3);
            Assert.IsFalse(op.Equals(new Addition(10, 2)));
        }
        [TestMethod]
        public void TestToStringEtatTrue()
        {
            Addition op = new Addition(12, 3);
            Assert.AreEqual("Addition(12+3)=15", op.ToString());
        }
        [TestMethod]
        public void TestToStringEtatFalse()
        {
            Addition op = new Addition();
            Assert.AreEqual("Addition non effectuée", op.ToString());
        }

    }
}
