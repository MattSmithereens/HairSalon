using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistsTest : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }

        public StylistsTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=matt_smith_test;";
        }

        [TestMethod]
        public void GetAll_InitialSetsEmpty_0()
        {
            int result = Stylist.GetAll().Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_DBAssignsIdToStylist_Id()
        {
            Stylist testClass = new Stylist("Fabio", 0);
            testClass.Save();

            Stylist savedClass = Stylist.GetAll()[0];

            int result = savedClass.Id;
            int testId = testClass.Id;

            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void RemoveClient_SeparateStylistClient_Stylist()
        {
            Stylist testClass = new Stylist("Vidal");
            testClass.Save();

            Client testClient = new Client("Tyra");
            testClient.Save();

            testClass.AddClient(testClient);
            testClass.RemoveClient(testClient);

            Assert.AreEqual(0, testClass.GetClients().Count);
        }

        [TestMethod]
        public void RemoveSpecialty_SeparateStylistSpecialty_Stylist()
        {
            Stylist testClass = new Stylist("Vidal");
            testClass.Save();

            Specialty testSpecialty = new Specialty("Facials");
            testSpecialty.Save();

            testClass.AddSpecialty(testSpecialty);
            testClass.RemoveSpecialty(testSpecialty);

            Assert.AreEqual(0, testClass.GetSpecialties().Count);
        }
    }
}
