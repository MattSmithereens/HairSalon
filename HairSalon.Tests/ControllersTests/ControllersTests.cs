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
            // PASSED
            HomeController testHomeController = new HomeController();
            ActionResult indexView = testHomeController.View();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }
    }
}