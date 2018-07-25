using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Controllers;
using HairSalon.Models;
using System;

namespace HairSalon.Tests.HomeControllersTests
{
    [TestClass]
    public class ControllersTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            HomeController salonTest = new HomeController();
            ActionResult indexView = salonTest.View();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }
    }
}