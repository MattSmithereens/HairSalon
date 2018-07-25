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
            int experience = int.Parse(Request.Form["exp"]);

            Stylist newStylist = new Stylist(name, experience);
            newStylist.Save();

            return RedirectToAction("ViewAll");
        }

        [HttpGet("/stylist/{id}/update")]
        public ActionResult Update(int id)
        {
            Stylist editStylist = Stylist.Find(id);
            StylistViewModel viewModel = new StylistViewModel(editStylist);

            return View(viewModel);
        }

        [HttpPost("/stylist/{id}/update")]
        public ActionResult UpdatePost(int id, int newClientId, int newSpecialtyId)
        {
            Stylist editStylist = Stylist.Find(id);
            string name = Request.Form["new-name"];
            editStylist.Edit(name);

            if (newClientId > 0)
            {
                Client newClient = Client.Find(newClientId);
                editStylist.AddClient(newClient);
            }

            if (newSpecialtyId > 0)
            {
                Specialty newSpecialty = Specialty.Find(newSpecialtyId);
                editStylist.AddSpecialty(newSpecialty);
            }

            return RedirectToAction("ViewAll");
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

            return RedirectToAction("ViewAll");
        }

        [HttpGet("/stylists/delete")]
        public ActionResult DeleteAll()
        {
            Stylist.DeleteAll();

            return RedirectToAction("ViewAll");
        }

        [HttpGet("/stylist/{id}/client/{clientId}/remove")]
        public ActionResult RemoveClient(int id, int clientId)
        {
            Stylist existingStylist = Stylist.Find(id);
            Client existingClient = Client.Find(clientId);
            existingStylist.RemoveClient(existingClient);

            return RedirectToAction("Details", id);
        }

        [HttpGet("/stylist/{id}/specialty/{specialtyId}/remove")]
        public ActionResult RemoveSpecialty(int id, int specialtyId)
        {
            Stylist existingStylist = Stylist.Find(id);
            Specialty existingSpecialty = Specialty.Find(specialtyId);
            existingStylist.RemoveSpecialty(existingSpecialty);

            return RedirectToAction("Details", id);
        }


        [HttpGet("/stylist/confirm")]
        public ActionResult Confirm()
        {
            return View();
        }
    }
}