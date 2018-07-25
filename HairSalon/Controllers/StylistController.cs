using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using HairSalon.ViewModels;

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
        public ActionResult ViewAll()
        {
            return View(Stylist.GetAll());
        }

        [HttpPost("/stylists")]
        public ActionResult ViewAllPost()
        {
            string name = Request.Form["name"];

            Stylist newStylist = new Stylist(name);
            newStylist.Save();

            return RedirectToAction("ViewAll");
        }

        [HttpGet("/stylists/{id}/details")]
        public ActionResult Details(int id)
        {
            Stylist stylistDetails = Stylist.Find(id);

            return View(stylistDetails);
        }

        [HttpGet("/stylists/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Stylist deleteStylist = Stylist.Find(id);
            deleteStylist.Delete();

            return RedirectToAction("ViewAll");
        }

        [HttpGet("/stylist/confirm")]
        public ActionResult Confirm()
        {
            return View();
        }

        [HttpGet("/stylists/delete")]
        public ActionResult DeleteAll()
        {
            Stylist.DeleteAll();

            return RedirectToAction("ViewAll");
        }

        [HttpGet("/stylist/{id}/update")]
        public ActionResult Update(int id)
        {
            Stylist editStylist = Stylist.Find(id);
            StylistViewModel viewModel = new StylistViewModel(editStylist);

            return View(viewModel);
        }

        [HttpGet("/stylist/{id}/specialty/{specialtyId}/remove")]
        public ActionResult RemoveSpecialty(int id, int specialtyId)
        {
            Stylist existingStylist = Stylist.Find(id);
            Specialty existingSpecialty = Specialty.Find(specialtyId);
            existingStylist.RemoveSpecialty(existingSpecialty);

            return RedirectToAction("Details", id);
        }
    }
}