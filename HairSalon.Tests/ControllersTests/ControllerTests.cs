using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Controllers;
using HairSalon.Models;
using System;

namespace HairSalon.Tests.HomeControllerTests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // PASSED
            HomeController salonTest = new HomeController();
            ActionResult indexView = salonTest.View();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }
    }
}