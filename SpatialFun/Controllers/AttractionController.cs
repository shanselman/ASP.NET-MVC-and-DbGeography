using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class AttractionController : Controller
    {
        private AttractionContext db = new AttractionContext();

        //
        // GET: /Attraction/

        public ActionResult Index()
        {
            return View(db.TouristAttractions.ToList());
        }

        //
        // GET: /Attraction/Details/5

        public ActionResult Details(int id = 0)
        {
            TouristAttraction touristattraction = db.TouristAttractions.Find(id);
            if (touristattraction == null)
            {
                return HttpNotFound();
            }
            return View(touristattraction);
        }

        //
        // GET: /Attraction/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Attraction/Create

        [HttpPost]
        public ActionResult Create(TouristAttraction touristattraction)
        {
            if (ModelState.IsValid)
            {
                db.TouristAttractions.Add(touristattraction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(touristattraction);
        }

        //
        // GET: /Attraction/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TouristAttraction touristattraction = db.TouristAttractions.Find(id);
            if (touristattraction == null)
            {
                return HttpNotFound();
            }
            return View(touristattraction);
        }

        //
        // POST: /Attraction/Edit/5

        [HttpPost]
        public ActionResult Edit(TouristAttraction touristattraction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(touristattraction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(touristattraction);
        }

        //
        // GET: /Attraction/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TouristAttraction touristattraction = db.TouristAttractions.Find(id);
            if (touristattraction == null)
            {
                return HttpNotFound();
            }
            return View(touristattraction);
        }

        //
        // POST: /Attraction/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TouristAttraction touristattraction = db.TouristAttractions.Find(id);
            db.TouristAttractions.Remove(touristattraction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}