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
    public class KategorijaModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KategorijaModels
        public ActionResult Index()
        {
            return View(db.kategorija.ToList());
        }

        // GET: KategorijaModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategorijaModel kategorijaModel = db.kategorija.Find(id);
            if (kategorijaModel == null)
            {
                return HttpNotFound();
            }
            return View(kategorijaModel);
        }

        // GET: KategorijaModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KategorijaModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KategorijaID,KategorijaNaziv")] KategorijaModel kategorijaModel)
        {
            if (ModelState.IsValid)
            {
                db.kategorija.Add(kategorijaModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategorijaModel);
        }

        // GET: KategorijaModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategorijaModel kategorijaModel = db.kategorija.Find(id);
            if (kategorijaModel == null)
            {
                return HttpNotFound();
            }
            return View(kategorijaModel);
        }

        // POST: KategorijaModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KategorijaID,KategorijaNaziv")] KategorijaModel kategorijaModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategorijaModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategorijaModel);
        }

        // GET: KategorijaModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategorijaModel kategorijaModel = db.kategorija.Find(id);
            if (kategorijaModel == null)
            {
                return HttpNotFound();
            }
            return View(kategorijaModel);
        }

        // POST: KategorijaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KategorijaModel kategorijaModel = db.kategorija.Find(id);
            db.kategorija.Remove(kategorijaModel);
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
