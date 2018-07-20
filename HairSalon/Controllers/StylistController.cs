﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult New()
        {
            return View();
        }

        //[HttpPost("/stylists")]
        //public ActionResult Create(string name)
        //{
        //    Stylist stylist = new Stylist(name);
        //    stylist.Save();
        //    return RedirectToAction("Index");
        //}

        [HttpGet("/stylists/{id}")]
        public ActionResult Show(int id)
        {
            Stylist stylist = Stylist.Find(id);
            return View(stylist);
        }

        [HttpGet("/stylists/{id}/edit")]
        public ActionResult Edit(int id)
        {
            Stylist stylist = Stylist.Find(id);
            return View(stylist);
        }

        //[HttpPost("/stylists/{id}/update")]
        //public ActionResult Update(int id, string first_name) //, string last_name
        //{
        //    Stylist stylist = Stylist.Find(id);
        //    stylist.first_name = first_name;
        //    //stylist.last_name = last_name;
        //    stylist.Update();
        //    return RedirectToAction("Index");
        //}

    }
}
