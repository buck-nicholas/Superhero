﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperHeroCreator.Models;


namespace SuperHeroCreator.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SuperHero
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Read()
        {
            var requiredData =
                from x in db.SuperHero
                select x;
            return View(requiredData);
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] SuperHeroModels superHero)
        {
            if (ModelState.IsValid)
            {
                // add to and save to db
                db.SuperHero.Add(superHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.superHero = new SelectList(db.SuperHero);
            return View(superHero);
        }

        
    }
}