using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests.ControllerTests
{
    [TestClass]
    public class SpecialtyControllerTest
    {
        [TestMethod]
        public void Create_CorrectView_True()
        {
            SpecialtyController controller = new SpecialtyController();
            ActionResult createView = controller.Create();
            Assert.IsInstanceOfType(createView, typeof(ViewResult));
        }

        [TestMethod]
        public void Confirm_CorrectView_True()
        {
            SpecialtyController controller = new SpecialtyController();
            ActionResult createView = controller.Confirm();
            Assert.IsInstanceOfType(createView, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_CorrectView_True()
        {
            SpecialtyController controller = new SpecialtyController();
            ActionResult detailsView = controller.Details(1);
            Assert.IsInstanceOfType(detailsView, typeof(ViewResult));
        }

        [TestMethod]
        public void Update_CorrectView_True()
        {
            SpecialtyController controller = new SpecialtyController();
            ActionResult updateView = controller.Update(1);
            Assert.IsInstanceOfType(updateView, typeof(ViewResult));
        }

        [TestMethod]
        public void ViewAll_CorrectView_True()
        {
            SpecialtyController controller = new SpecialtyController();
            ActionResult viewAllView = controller.ViewAll();
            Assert.IsInstanceOfType(viewAllView, typeof(ViewResult));
        }
    }
}