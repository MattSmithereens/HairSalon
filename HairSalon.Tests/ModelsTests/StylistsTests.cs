using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTest : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        public StylistTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=matt_smith_test;";
        }

        [TestMethod]
        public void SetGetVariables_SetsGets_True()
        {
            Stylist salonTest = new Stylist("new", 1)
            {
                Name = "Brutus Beefcake",
                //StylistContact = "stylist@email.com",
                Id = 1
            };
            Assert.AreEqual("Brutus Beefcake", salonTest.Name);
            //Assert.AreEqual("stylist@email.com", salonTest.StylistContact);
            Assert.AreEqual(1, salonTest.Id);
        }

        [TestMethod]
        public void GetAll_DBSetEmpty_0()
        {
            int result = Stylist.GetAll().Count;
            Assert.AreEqual(0, result);
        }

        //[TestMethod]
        //public void Save_SavesStylistToDatabase_StylistList()
        //{
        //    Stylist salonTest = new Stylist("Brutus", 0);
        //    salonTest.Save();

        //    List<Stylist> actual = new List<Stylist> { salonTest };
        //    List<Stylist> expected = Stylist.GetAll();

        //    CollectionAssert.AreEqual(actual, expected);
        //}

        [TestMethod]
        public void Save_DBAssignsStylistId_Id()
        {
            Stylist salonTest = new Stylist("Brutus Beefcake", 0);
            salonTest.Save();

            Stylist testStylist = Stylist.GetAll()[0];

            int actual = testStylist.Id;
            int expected = salonTest.Id;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Find_FindsStylistInDB_Stylist()
        {
            Stylist actual = new Stylist("Vidal Sassoon", 0);
            actual.Save();

            Stylist expected = Stylist.Find(actual.Id);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetClients_FindsAllClientsInDatabase_ClientList()
        {
            Stylist salonTest = new Stylist("Bojack", 0);
            salonTest.Save();

            Client testClient = new Client("Horseman");
            testClient.Save();

            salonTest.AddClient(testClient);

            Assert.AreEqual(testClient, salonTest.GetClients()[0]);
        }

    }
}
