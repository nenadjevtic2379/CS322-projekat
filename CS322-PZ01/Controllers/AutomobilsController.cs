using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS322_PZ01.Models;

namespace CS322_PZ01.Controllers
{
    public class AutomobilsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Automobils
        public ActionResult Index()
        {
            return View(db.auto.ToList());
        }

        // GET: Automobils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobil automobil = db.auto.Find(id);
            if (automobil == null)
            {
                return HttpNotFound();
            }
            return View(automobil);
        }

        // GET: Automobils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Automobils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AutoID,AutoNaziv")] Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                db.auto.Add(automobil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(automobil);
        }

        // GET: Automobils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobil automobil = db.auto.Find(id);
            if (automobil == null)
            {
                return HttpNotFound();
            }
            return View(automobil);
        }

        // POST: Automobils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutoID,AutoNaziv")] Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automobil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(automobil);
        }

        // GET: Automobils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automobil automobil = db.auto.Find(id);
            if (automobil == null)
            {
                return HttpNotFound();
            }
            return View(automobil);
        }

        // POST: Automobils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automobil automobil = db.auto.Find(id);
            db.auto.Remove(automobil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
