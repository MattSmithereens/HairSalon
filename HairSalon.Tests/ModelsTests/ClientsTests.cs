using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests.ModelsTests
{
    [TestClass]
    public class ClientsTests
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }

        public ClientsTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=matt_smith_test;";
        }

        [TestMethod]
        public void GetAll_InitialSetsEmpty_0()
        {
            int result = Client.GetAll().Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToClient_Id()
        {
            Client testClient = new Client("Bob");
            testClient.Save();

            Client savedClient = Client.GetAll()[0];

            int result = savedClient.Id;
            int testId = testClient.Id;

            Assert.AreEqual(testId, result);
        }

    }
}
