﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/client/add")]
        public ActionResult Create()
        {
            if (Stylist.GetAll().Count == 0)
            {
                return View("Error");
            }
            else
            {
                return View(Stylist.GetAll());
            }
        }

        [HttpGet("/clients")]
        public ActionResult Main()
        {
            return View(Client.GetAll());
        }

        [HttpPost("/clients")]
        public ActionResult IndexPost()
        {
            string name = Request.Form["name"];
            int stylistId = int.Parse(Request.Form["stylist"]);

            Client newClient = new Client(name, stylistId);
            newClient.Save();

            Stylist existingStylist = Stylist.Find(stylistId);
            newClient.AddStylist(existingStylist);

            return RedirectToAction("Main");
        }

        [HttpGet("/client/{id}/edit")]
        public ActionResult Update(int id)
        {
            Client editClient = Client.Find(id);

            return View(editClient);
        }

        [HttpPost("/client/{id}/update")]
        public ActionResult UpdatePost(int id, int newStylistId)
        {
            Client editClient = Client.Find(id);
            string name = Request.Form["new-name"];
            editClient.Edit(name);

            if (newStylistId > 0)
            {
                Stylist newStylist = Stylist.Find(newStylistId);
                editClient.AddStylist(newStylist);
            }

            return RedirectToAction("Main");
        }

        [HttpGet("/client/{id}/show")]
        public ActionResult Details(int id)
        {
            Client clientDetails = Client.Find(id);

            return View(clientDetails);
        }

        [HttpGet("/client/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Client deleteClient = Client.Find(id);
            deleteClient.Delete();

            return RedirectToAction("Main");
        }

        [HttpGet("/clients/delete")]
        public ActionResult DeleteAll()
        {
            Client.DeleteAll();

            return RedirectToAction("Main");
        }
    }
}