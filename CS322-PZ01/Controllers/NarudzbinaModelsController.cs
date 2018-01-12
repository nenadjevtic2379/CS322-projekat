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
    public class NarudzbinaModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NarudzbinaModels
        public ActionResult Index()
        {
            var narudzbina = db.narudzbina.Include(n => n.auto).Include(n => n.kategorija);
            return View(narudzbina.ToList());
        }

        public ActionResult MojeNarudzbine()
        {
            var narudzbina = db.narudzbina.Include(n => n.auto).Include(n => n.kategorija);
            return View(narudzbina.ToList());
        }

        // GET: NarudzbinaModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NarudzbinaModel narudzbinaModel = db.narudzbina.Find(id);
            if (narudzbinaModel == null)
            {
                return HttpNotFound();
            }
            return View(narudzbinaModel);
        }


        // GET: NarudzbinaModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NarudzbinaModel narudzbinaModel = db.narudzbina.Find(id);
            if (narudzbinaModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutoID = new SelectList(db.auto, "AutoID", "AutoNaziv", narudzbinaModel.AutoID);
            ViewBag.KategorijaID = new SelectList(db.kategorija, "KategorijaID", "KategorijaNaziv", narudzbinaModel.KategorijaID);
            return View(narudzbinaModel);
        }

        // POST: NarudzbinaModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NarudzbinaID,UserName,ProizvodiModel,Cena,KategorijaID,AutoID,Datum,Status")] NarudzbinaModel narudzbinaModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(narudzbinaModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutoID = new SelectList(db.auto, "AutoID", "AutoNaziv", narudzbinaModel.AutoID);
            ViewBag.KategorijaID = new SelectList(db.kategorija, "KategorijaID", "KategorijaNaziv", narudzbinaModel.KategorijaID);
            return View(narudzbinaModel);
        }

        // GET: NarudzbinaModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NarudzbinaModel narudzbinaModel = db.narudzbina.Find(id);
            if (narudzbinaModel == null)
            {
                return HttpNotFound();
            }
            return View(narudzbinaModel);
        }

        // POST: NarudzbinaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NarudzbinaModel narudzbinaModel = db.narudzbina.Find(id);
            db.narudzbina.Remove(narudzbinaModel);
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
