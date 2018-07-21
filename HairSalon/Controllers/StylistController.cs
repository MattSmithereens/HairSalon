using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
        [HttpGet("/stylist/add")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet("/stylists")]
        public ActionResult Main()
        {
            return View(Stylist.GetAll());
        }

        [HttpPost("/stylists")]
        public ActionResult ViewAllPost()
        {
            string name = Request.Form["name"];
            int experience = int.Parse(Request.Form["exp"]);

            Stylist newStylist = new Stylist(name, experience);
            newStylist.Save();

            return RedirectToAction("Main");
        }

        [HttpGet("/stylist/{id}/details")]
        public ActionResult Details(int id)
        {
            Stylist stylistDetails = Stylist.Find(id);

            return View(stylistDetails);
        }

        [HttpGet("/stylist/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Stylist deleteStylist = Stylist.Find(id);
            deleteStylist.Delete();

            return RedirectToAction("Main");
        }

        [HttpGet("/stylists/delete")]
        public ActionResult DeleteAll()
        {
            Stylist.DeleteAll();

            return RedirectToAction("Main");
        }


    }
}