using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaculatriceTest
{
    [TestClass]
    public class BidonTest
    {
        public TestContext TestContext { get; set; }

        Calculatrice.Bidon oBidon;

        [TestInitialize]
        public void SetUp()
        {
            oBidon = new Calculatrice.Bidon();
            Console.WriteLine("Création du Contexte" +  TestContext.TestName );

            TestContext.WriteLine("Message de test");
        }
        [TestCleanup]
        public void Teardown()
        {
            oBidon = null;
            Console.WriteLine("Suppresssion du Contexte");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestM1Sup10bis()
        {

            oBidon.M1(15);

            Console.WriteLine("Ceci est un message de test");
        }
        /// <summary>
        /// Vérifie que la méthode M1 leve un exception si le paramètre est >10
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestM1Sup10()
        {

            oBidon.M1(15);

            Console.WriteLine("Ceci est un message de test");
        }
        /// <summary>
        /// Vérifie que la méthode M1 leve un exception si le paramètre est >10
        /// </summary>
        [TestMethod]
        public void TestM1inf10()
        {

            oBidon.M1(5);

            Console.WriteLine("Le test réussit car je n'ai pas eu d'exception");
        }
        /// <summary>
        /// Vérifie que la méthode M1 leve un exception si le paramètre est >10
        /// </summary>
        [TestMethod]
        public void TestM1Egale10()
        {

            oBidon.M1(10);

            Console.WriteLine("Le test réussit car je n'ai pas eu d'exception");
        }
        /// <summary>
        /// Vérifie que la méthode M2 attends un nbre de secondes
        /// </summary>
        [TestMethod]
        [Timeout(3999)]
        public void TestM2()
        {

            oBidon.M2(3);


        }

        [TestMethod,Ignore]
        [ExpectedException(typeof(ArgumentException))]
        public void TestM1Sup10ter()
        {

            oBidon.M1(15);

            Console.WriteLine("Ceci est un message de test");
        }

    }//BidonTest
}
