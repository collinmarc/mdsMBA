using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CaculatriceTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {

            if (System.IO.File.Exists("TOTO.txt"))
            {
                System.IO.File.GetCreationTime("toto.txt");
                System.IO.File.Copy("toto.txt", "titi.txt");
                System.IO.File.Move("toto.txt", "tata.txt");
                System.IO.File.CreateText("nouveauFichier.txt");
            }

            System.IO.FileInfo oFileInfo = new System.IO.FileInfo("TOTO.txt");
            if (oFileInfo.Exists)
            {
                Console.Write(oFileInfo.CreationTime);
                Console.Write(oFileInfo.LastAccessTime);
                Console.Write(oFileInfo.LastWriteTime);
                Console.Write(oFileInfo.Length);
                Console.Write(oFileInfo.Extension);
                Console.Write(oFileInfo.Name);
                Console.Write(oFileInfo.FullName);
                oFileInfo.CopyTo("titi.txt");
                oFileInfo.MoveTo("tata.txt");
                oFileInfo.CreateText();
            }
            String[] tab = System.IO.Directory.GetFiles("c:\temp");
            List<String> olst = new List<string>( System.IO.Directory.EnumerateFiles("c:\temp"));

            String[] tabD = System.IO.Directory.GetDirectories("c:\temp");
            List<String> olstD = new List<string>(System.IO.Directory.EnumerateDirectories("c:\temp"));


        }
    }
}
