using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculatrice;

namespace CaculatriceTest
{
    /// <summary>
    /// Description résumée pour ClientTest
    /// </summary>
    [TestClass]
    public class ClientTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestNormlEcinf1000Cmdinf1000()
        {
            // Assign
            Client oClient = new Client();
            oClient.Type = Client.TypeClient.NORMAL;
            oClient.MtEc = new Random().Next(0,1000);

            // Act
            Boolean bRes = oClient.Accepte(new Random().Next(0,1000));

            // Assert
            Assert.IsTrue(bRes);
        }
        [TestMethod]
        public void TestNormlEcinf1000Cmd1000_5000()
        {
            // Assign
            Client oClient = new Client();
            oClient.Type = Client.TypeClient.NORMAL;
            oClient.MtEc = new Random().Next(0, 1000);

            // Act
            Boolean bRes = oClient.Accepte(new Random().Next(1000, 5000));

            // Assert
            Assert.IsTrue(bRes);
        }

        [DataTestMethod]
        [DataRow(Client.TypeClient.NORMAL, 556, 750, true,DisplayName="Normal-Ec<1000-Cmd<1000")]
        [DataRow(Client.TypeClient.NORMAL, 556, 2000, true, DisplayName = "Normal-Ec<1000-Cmd[1000-5000]")]
        [DataRow(Client.TypeClient.NORMAL, 556, 7000, true, DisplayName = "Normal-Ec<1000-Cmd>5000")]
        [DataRow(Client.TypeClient.NORMAL, 2245, 750, true, DisplayName = "Normal-Ec[1000-3000]-Cmd<1000")]
        [DataRow(Client.TypeClient.NORMAL, 2245, 2000, true, DisplayName = "Normal-Ec[1000-3000]-Cmd[1000-5000]")]
        [DataRow(Client.TypeClient.NORMAL, 2245, 7000, false, DisplayName = "Normal-Ec[1000-3000]-Cmd>5000")]
        [DataRow(Client.TypeClient.NORMAL, 4678, 750, true, DisplayName = "Normal-Ec>3000-Cmd<1000")]
        [DataRow(Client.TypeClient.NORMAL, 4678, 2000, false, DisplayName = "Normal-Ec>3000-Cmd[1000-5000]")]
        [DataRow(Client.TypeClient.NORMAL, 4678, 7000, false, DisplayName = "Normal-Ec>3000-Cmd>5000")]

        [DataRow(Client.TypeClient.PREMIUM, 556, 750, true, DisplayName = "Premium-Ec>3000-Cmd>5000")]
        [DataRow(Client.TypeClient.PREMIUM, 556, 2000, true, DisplayName = "Premium-Ec>3000-Cmd>5000")]
        [DataRow(Client.TypeClient.PREMIUM, 556, 7000, true, DisplayName = "Premium-Ec>3000-Cmd>5000")]
        [DataRow(Client.TypeClient.PREMIUM, 2245, 750, true, DisplayName = "Premium-Ec>3000-Cmd>5000")]
        [DataRow(Client.TypeClient.PREMIUM, 2245, 2000, true, DisplayName = "Premium-Ec>3000-Cmd>5000")]
        [DataRow(Client.TypeClient.PREMIUM, 2245, 7000, true, DisplayName = "Premium-Ec>3000-Cmd>5000")]
        [DataRow(Client.TypeClient.PREMIUM, 4678, 750, true, DisplayName = "Premium-Ec>3000-Cmd>5000")]
        [DataRow(Client.TypeClient.PREMIUM, 4678, 2000, true, DisplayName = "Premium-Ec>3000-Cmd>5000")]
        [DataRow(Client.TypeClient.PREMIUM, 4678, 7000, false, DisplayName = "Premium-Ec>3000-Cmd>5000")]

        [DataRow(Client.TypeClient.A_SURVEILLER, 556, 750, true, DisplayName = "ASurv-Ec<1000-Cmd<1000")]
        [DataRow(Client.TypeClient.A_SURVEILLER, 556, 2000, true, DisplayName = "ASurv-Ec<1000-Cmd[1000-5000]")]
        [DataRow(Client.TypeClient.A_SURVEILLER, 556, 7000, false, DisplayName = "ASurv-Ec<1000-Cmd>5000")]
        [DataRow(Client.TypeClient.A_SURVEILLER, 2245, 750, true, DisplayName = "ASurv-Ec[1000-3000]-Cmd<1000")]
        [DataRow(Client.TypeClient.A_SURVEILLER, 2245, 2000, false, DisplayName = "ASurv-Ec[1000-3000]-Cmd[1000-5000]")]
        [DataRow(Client.TypeClient.A_SURVEILLER, 2245, 7000, false, DisplayName = "ASurv-Ec[1000-3000]-Cmd>5000")]
        [DataRow(Client.TypeClient.A_SURVEILLER, 4678, 750, true, DisplayName = "ASurv-Ec>3000-Cmd<1000")]
        [DataRow(Client.TypeClient.A_SURVEILLER, 4678, 2000, false, DisplayName = "ASurv-Ec>3000-Cmd[10000-5000]")]
        [DataRow(Client.TypeClient.A_SURVEILLER, 4678, 7000, false, DisplayName = "ASurv-Ec>3000-Cmd>5000")]

        public void TestParametre(Client.TypeClient pType, Single pMtEc, Single pMtCmd, Boolean pResult)
        {
            // Assign
            Client oClient = new Client();
            oClient.Type = pType;
            oClient.MtEc = pMtEc;

            // Act
            Boolean bRes = oClient.Accepte(pMtCmd);

            // Assert
            Assert.AreEqual(pResult,bRes);
        }
    }
}
