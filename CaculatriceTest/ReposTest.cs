﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice;
using System.IO;

namespace CaculatriceTest
{
    [TestClass]
    public class ReposTest
    {
        [TestInitialize]
        public void Setup()
        {
            if (System.IO.Directory.Exists("REP1"))
            {
                System.IO.Directory.Delete("REP1", true);
            }
            System.IO.Directory.CreateDirectory("REP1");
        }

        [TestMethod]
        [ExpectedException (typeof(System.IO.DirectoryNotFoundException))]
        public void TestRepertoireInexistant()
        {
            if (System.IO.Directory.Exists("REP1"))
            {
                System.IO.Directory.Delete("REP1",true);
            }
            Assert.IsFalse(System.IO.Directory.Exists("REP1"));
            Repos MyRepos = new Repos();
            MyRepos.Organize("REP1");
            // Vérification de la levée l'exception DirectoryNotFoundException
        }

        [TestMethod]
        public void TestExistenceExistant()
        {
            Repos MyRepos = new Repos();
            MyRepos.Organize("REP1");
            // Vérification de la non levée l'exception DirectoryNotFoundExeption
        }

        [TestMethod]
        public void TestCréationdusousRepertoire()
        {
            if (System.IO.Directory.Exists("REP1/TXT"))
            {
                System.IO.Directory.Delete("REP1/TXT",true);
            }

            System.IO.File.CreateText("REP1/toto.txt").Close();
            Repos MyRepos = new Repos();
            MyRepos.Organize("REP1");
            //Test
            //RETest
            //ReTest    

            Assert.IsTrue(System.IO.Directory.Exists("REP1/TXT"));
        }
        /// <summary>
        /// Test de la non création du sous-répertoire s'il existe
        /// </summary>
        [TestMethod]
        public void TestCréationdusousRepertoire2()
        {
            if (!System.IO.Directory.Exists("REP1/TXT"))
            {
                System.IO.Directory.CreateDirectory("REP1/TXT");
            }
            System.IO.File.CreateText("REP1/TXT/adel.txt").Close(); 

            System.IO.File.CreateText("REP1/toto.txt").Close();
            Repos MyRepos = new Repos();
            MyRepos.Organize("REP1");

            Assert.IsTrue(System.IO.Directory.Exists("REP1/TXT"));
            Assert.IsTrue(System.IO.File.Exists("REP1/TXT/adel.txt"));
        }

        [TestMethod]
        public void TestDeplacementFichierTXT()
        {
            // ARRANGE

            if (System.IO.File.Exists("REP1/test.txt"))
            {
                System.IO.File.Delete("REP1/test.txt");
            }

            if (System.IO.File.Exists("REP1/TXT/test.txt"))
            {
                System.IO.File.Delete("REP1/TXT/test.txt");
            }
            System.IO.File.CreateText("REP1/test.txt").Close();

            //ACT
            Repos MyRepos = new Repos();
            MyRepos.Organize("REP1");

            //ASSERT
            Assert.IsTrue(System.IO.File.Exists("REP1/TXT/test.txt"));
            Assert.IsFalse(System.IO.File.Exists("REP1/test.txt"));
        }
        [TestMethod]
        public void TestDeplacementFichierTXTDansunsousRépertoire()
        {
            // ARRANGE

            if (System.IO.Directory.Exists("REP1/SREP"))
            {
                System.IO.Directory.Delete("REP1/SREP", true);
            }
            System.IO.Directory.CreateDirectory("REP1/SREP");
            System.IO.File.CreateText("REP1/SREP/test.txt").Close();
 
            //ACT
            Repos MyRepos = new Repos();
            MyRepos.Organize("REP1");

            //ASSERT
            Assert.IsTrue(System.IO.File.Exists("REP1/SREP/TXT/test.txt"));
            Assert.IsFalse(System.IO.File.Exists("REP1/SREP/test.txt"));
        }
        [TestMethod]
        public void TestDeplacement2Fichiers()
        {
            // ARRANGE

            System.IO.File.CreateText("REP1/test.txt").Close();
            System.IO.File.CreateText("REP1/test1.txt").Close();

            //ACT
            Repos MyRepos = new Repos();
            MyRepos.Organize("REP1");

            //ASSERT
            Assert.IsTrue(System.IO.File.Exists("REP1/TXT/test.txt"));
            Assert.IsTrue(System.IO.File.Exists("REP1/TXT/test1.txt"));
        }

        [TestMethod]
        public void TestDeplacementExtensionsMajuscules()
        {
            // ARRANGE

            System.IO.File.CreateText("REP1/test.TXT").Close();
            System.IO.File.CreateText("REP1/test1.TxT").Close();
            System.IO.File.CreateText("REP1/test2.tXt").Close();

            //ACT
            Repos MyRepos = new Repos();
            MyRepos.Organize("REP1");

            //ASSERT
            Assert.IsTrue(System.IO.File.Exists("REP1/TXT/test.txt"));
            Assert.IsTrue(System.IO.File.Exists("REP1/TXT/test1.TxT"));
            Assert.IsTrue(System.IO.File.Exists("REP1/TXT/test2.tXt"));
        }
        //Traitement d'un extension .txt
        // Verification de la création du sous répertoire s'il n'existe pas 
        // Verification de la non-création du sous répertoire s'il existe
        // Verification du déplacement du fichier s'il n'existe pas sans le sous Rep 
        // Verification du déplacement du fichier s'il existe dans le sous Rep 
    }
}
