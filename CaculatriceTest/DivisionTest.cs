using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice;
namespace CaculatriceTest
{
    [TestClass]
    public class DivisionTest
    {
        [TestMethod]
        public void TestConstructeurAVide()
        {
            Division op = new Division();

            Assert.AreEqual(false, op.Etat);
            Assert.AreEqual(0, op.Resultat);
        }


        [TestMethod]
        public void TestConstructeurAvecParamsEtat()
        {
            Division op = new Division(12, 3);
            Assert.AreEqual(true, op.Etat);
        }
        [TestMethod]
        public void TestConstructeurAvecParamsResultat()
        {
            //Arrange
            Division op = new Division(12, 3);
            //Act
            Single res = op.Resultat;
            //Assert
            Assert.AreEqual(4, res);
        }
        [TestMethod]
        public void testCalculerParamReturn()
        {
            //Arrange
            Division op = new Division();
            //Act
            Boolean res = op.Calculer(12,3) ;
            //Assert
            Assert.IsTrue(res);

        }
        [TestMethod]
        public void testCalculerParamAtrributs()
        {
            //Arrange
            Division op = new Division(12,5);
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
            Division op = new Division();
            //Act
            Boolean res = op.Calculer(3, 2);
            //Assert
            Assert.AreEqual(true, op.Etat);

        }
        [TestMethod]
        public void testCalculerParamResultat1()
        {
            //Arrange
            Division op = new Division();
            //Act
            op.Calculer(12, 3);
            Single res = op.Resultat;
            //Assert
            Assert.AreEqual(4,res);

        }
        [TestMethod]
        public void testCalculerParamResultat2()
        {
            //Arrange
            Division op = new Division(5,4);
            //Act
            op.Calculer(12, 3);
            Single res = op.Resultat;
            //Assert
            Assert.AreEqual(4, res);

        }

        /// <summary>
        /// Test la methode calculer sur une Division vide
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testCalculerSansParamReturn()
        {
            //Arrange
            Division op = new Division();
            //Act
            
            Boolean res = op.Calculer();

            //Assert
            Assert.IsTrue(res);
            Assert.AreEqual(0,op.Resultat);

        }
        /// <summary>
        /// Test le code Retour methode calculer sur une Division non  vide
        /// </summary>
        [TestMethod]
        public void testCalculerSansParamReturn2()
        {
            //Arrange
            Division op = new Division(5,2);
            //Act

            Boolean res = op.Calculer();

            //Assert
            Assert.IsTrue(res);

        }

        /// <summary>
        /// Test le code Retour methode calculer sur une Division non  vide
        /// </summary>
        [TestMethod]
        public void testCalculerSansParamResultat()
        {
            //Arrange
            Division op = new Division(5, 2);
            //Act

           op.Calculer();
            Single res = op.Resultat;
            //Assert
            Assert.AreEqual(2.5f,res);

        }
        /// <summary>
        /// Test le code Retour methode calculer sur une Division non  vide
        /// </summary>
        [TestMethod]
        public void testCalculerSansParamEtat()
        {
            //Arrange
            Division op = new Division(5, 2);
            //Act

            op.Calculer();
            Boolean res = op.Etat;
            //Assert
            Assert.AreEqual(true,res);

        }
        [TestMethod]
        public void TestEqualsNull()
        {
            Division op = new Division(12, 4);
            Object obj = null; ;
            Assert.IsFalse(op.Equals(obj));
        }

        [TestMethod]
        public void TestEqualsNonDivision()
        {
            Division op = new Division(12, 4);
            Assert.IsFalse(op.Equals(new Exception()));
        }
        [TestMethod]
        public void TestEqualsDivisionEgales()
        {
            Division op = new Division(12, 3);
            Assert.IsTrue(op.Equals(new Division(8, 2)));
            Assert.IsTrue(op.Equals(op));
        }

        [TestMethod]
        public void TestEqualsDivisionNonEgales()
        {
            Division op = new Division(12, 3);
            Assert.IsFalse(op.Equals(new Division(10, 2)));
        }
        [TestMethod]
        public void TestToStringEtatTrue()
        {
            Division op = new Division(12, 3);
            Assert.AreEqual("Division(12/3)=4", op.ToString());
        }
        [TestMethod]
        public void TestToStringEtatFalse()
        {
            Division op = new Division();
            Assert.AreEqual("Division non effectuée", op.ToString());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDivisionParZero()
        {
            Division op = new Division(8,0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDivisionParZero2()
        {
            Division op = new Division();
            op.Calculer(8, 0);
        }

    }
}
