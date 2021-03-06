﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtiesTest : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }

        public SpecialtiesTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=matt_smith_test;";
        }

        [TestMethod]
        public void GetAll_InitialSetsEmpty_0_0()
        {
            int result = Specialty.GetAll().Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_DBAssignsIdToSpecialty_Id()
        {
            Specialty testClass = new Specialty("Facials");
            testClass.Save();

            Specialty savedClass = Specialty.GetAll()[0];

            int result = savedClass.Id;
            int testId = testClass.Id;

            Assert.AreEqual(testId, result);
        }
    }
}