using System;
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
        public ActionResult Details(int id)
        {
            var requiredData =
                (from x in db.SuperHero
                 where x.ID == id
                 select x).First();
            return View(requiredData);
        }
        public ActionResult List()
        {
            var requiredData =
                from x in db.SuperHero
                select x;
            return View(requiredData);
        }
        public ActionResult Edit(int id)
        {
            var requiredData =
                (from x in db.SuperHero
                 where x.ID == id
                 select x).First();
            return View(requiredData);
        }
        public ActionResult Delete(int id)
        {
            var requiredData =
                (from x in db.SuperHero
                 where x.ID == id
                 select x).First();
            return View(requiredData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] SuperHeroModels superHero)
        {
            var requiredData =
                (from x in db.SuperHero
                 where x.ID == superHero.ID
                 select x).First();
            requiredData.Name = superHero.Name;
            requiredData.AlterEgo = superHero.AlterEgo;
            requiredData.PrimaryAbility = superHero.PrimaryAbility;
            requiredData.SecondaryAbility = superHero.SecondaryAbility;
            requiredData.CatchPhrase = superHero.CatchPhrase;
            db.SaveChanges();            
            return View(superHero);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] SuperHeroModels superHero)
        {
            if (ModelState.IsValid)
            {
                db.SuperHero.Add(superHero);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.superHero = new SelectList(db.SuperHero);
            return View(superHero);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SuperHeroModels superHero)
        {
            var requiredData =
                (from x in db.SuperHero
                 where x.ID == superHero.ID
                 select x).First();
            if (ModelState.IsValid)
            {
                db.SuperHero.Remove(requiredData);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(superHero);
        }
    }
}