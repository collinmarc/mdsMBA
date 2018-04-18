using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite;
using System.IO;
using mdsCLS;

namespace mdsTU
{
    [TestClass]
    public class SQLiteTest
    {
        [TestMethod]
        public void TestAccess()
        {
            SQLiteConnection dbConn = new SQLiteConnection("Data Source=mydb.db;Version=3");
            dbConn.Open();
            dbConn.Close();

            Assert.IsTrue(File.Exists("mydb.db"));
        }
        [TestMethod]
        public void TestCREATETABLE()
        {
            SQLiteConnection dbConn = new SQLiteConnection("Data Source=mydb.db;Version=3");
            dbConn.Open();

            SQLiteCommand oCmd = dbConn.CreateCommand();
            oCmd.CommandText=
                "CREATE TABLE IF NOT EXISTS CONTACT(id int PRIMARY KEY,Type text, Addresse text, Defaut bit)";

            oCmd.ExecuteNonQuery();
            dbConn.Close();
        }

        [TestMethod]
        public void TestINSERT()
        {
            SQLiteConnection dbConn = new SQLiteConnection("Data Source=mydb.db;Version=3");
            dbConn.Open();

            SQLiteCommand oCmd = dbConn.CreateCommand();
            oCmd.CommandText =
                "INSERT INTO CONTACT (Type, Addresse, Defaut ) VALUES ('MAIL', 'a@a.com',0)";

            oCmd.ExecuteNonQuery();
            dbConn.Close();
        }

        [TestMethod]
        public void TestSELECT()
        {
            SQLiteConnection dbConn = new SQLiteConnection("Data Source=mydb.db;Version=3");
            dbConn.Open();

            SQLiteCommand oCmd = dbConn.CreateCommand();
            oCmd.CommandText =
                "SELECT Type, Addresse, Defaut FROM CONTACT";

            SQLiteDataReader oReader =  oCmd.ExecuteReader();

            while (oReader.Read())
            {
                Contact oContact = new Contact();
                // Lecture des données
                int n = oReader.GetOrdinal("Type");
                oContact.Type = oReader.GetString(n);
                n = oReader.GetOrdinal("Addresse");
                oContact.Adresse = oReader.GetString(n);
                n = oReader.GetOrdinal("Defaut");
                oContact.isDefault = oReader.GetBoolean(n);

                Assert.AreEqual("MAIL", oContact.Type);
                Assert.AreEqual("a@a.com", oContact.Adresse);

            }

            oReader.Close();

            dbConn.Close();
        }
        [TestMethod]
        public void TestUPDATE()
        {
            SQLiteConnection dbConn = new SQLiteConnection("Data Source=mydb.db;Version=3");
            dbConn.Open();

            SQLiteCommand oCmd = dbConn.CreateCommand();
            oCmd.CommandText =
                "UPDATE CONTACT SET addresse = @p1";
            oCmd.Parameters.Add(new SQLiteParameter("@P1", "Marc@marc.com"));

            oCmd.ExecuteNonQuery();

            dbConn.Close();
        }
    }
}
