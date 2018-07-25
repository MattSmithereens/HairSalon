using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialitiesTest : IDisposable
    {
        public void Dispose()
        {
            Specialty.DeleteAll();
        }

        public SpecialitiesTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=matt_smith_test;";
        }

        [TestMethod]
        public void GetAll_DBWiped_0()
        {
            int result = Specialty.GetAll().Count;

            Assert.AreEqual(0, result);
        }

        //[TestMethod]
        //public void Save_SavesSpecialtyToDB_SpecialtyList()
        //{
        //    Specialty testSpec = new Specialty("Dreds");
        //    testSpec.Save();

        //    List<Specialty> expected = Specialty.GetAll();
        //    List<Specialty> actual = new List<Specialty> { testSpec };

        //    CollectionAssert.AreEqual(actual, expected);
        //}


        [TestMethod]
        public void Save_DBAssignsIdToSpecialty_Id()
        {
            Specialty testSpec = new Specialty("Dreds");
            testSpec.Save();

            Specialty savedClass = Specialty.GetAll()[0];

            int actual = savedClass.Id;
            int expected = testSpec.Id;

            Assert.AreEqual(actual, expected);
        }




    }
}