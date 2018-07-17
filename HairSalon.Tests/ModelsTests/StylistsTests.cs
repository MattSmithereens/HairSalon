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
            Stylist stylist = new Stylist("new")
            {
                first_name = "Brutus",
                //stylist.last_name = "Beefcake";
                id = 2
            };
            Assert.AreEqual("Brutus", stylist.first_name);
            //Assert.AreEqual("Beefcake", stylist.last_name);
            Assert.AreEqual(2, stylist.id);
        }

        [TestMethod]
        public void GetAll_DBSetEmpty_0()
        {
            int result = Stylist.GetAll().Count;
            Assert.AreEqual(0, result);
        }

    }
}
