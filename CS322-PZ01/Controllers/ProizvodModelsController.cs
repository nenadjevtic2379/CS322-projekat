using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS322_PZ01.Models;
using Microsoft.AspNet.Identity;

namespace CS322_PZ01.Controllers
{
    public class ProizvodModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProizvodModels
        public ActionResult Index(string search)
        {
           
            var proizvod = db.proizvod.Include(p => p.auto).Include(p => p.kategorija);
           // var product = from pr in db.proizvod select pr;
            if (!String.IsNullOrEmpty(search))
            {
                proizvod = proizvod.Where(pr => pr.auto.AutoNaziv.Contains(search));
            }
            return View(proizvod.ToList());
        }

        // GET: ProizvodModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProizvodModel proizvodModel = db.proizvod.Find(id);
            if (proizvodModel == null)
            {
                return HttpNotFound();
            }
            return View(proizvodModel);
        }

        // GET: ProizvodModels/Create
        public ActionResult Create()
        {
            ProizvodModel pm = new ProizvodModel();
            ViewBag.AutoID = new SelectList(db.auto, "AutoID", "AutoNaziv");
            ViewBag.KategorijaID = new SelectList(db.kategorija, "KategorijaID", "KategorijaNaziv");
            return View(pm);
        }

        // POST: ProizvodModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProizvodiID,ProizvodiModel,DatumProizvodnje,Cena,KategorijaID,AutoID,Slika")] ProizvodModel proizvodModel, HttpPostedFileBase image1)
        {

            if (image1 != null)
            {
                proizvodModel.Slika = new byte[image1.ContentLength];
                image1.InputStream.Read(proizvodModel.Slika, 0, image1.ContentLength);
            }

            if (ModelState.IsValid)
            {
                db.proizvod.Add(proizvodModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutoID = new SelectList(db.auto, "AutoID", "AutoNaziv", proizvodModel.AutoID);
            ViewBag.KategorijaID = new SelectList(db.kategorija, "KategorijaID", "KategorijaNaziv", proizvodModel.KategorijaID);
            return View(proizvodModel);
        }

        // GET: ProizvodModels/Edit/5
        public ActionResult Edit(int? id, HttpPostAttribute image1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProizvodModel proizvodModel = db.proizvod.Find(id);
            if (proizvodModel == null)
            {
                
                return HttpNotFound();
            }
            //  ViewBag.image1 = (from i in db.proizvod select i.Slika).Where(i => i.ProizvodiID.Equals(id));


           // var base64 = Convert.ToBase64String(proizvodModel.Slika);

           
            ViewBag.AutoID = new SelectList(db.auto, "AutoID", "AutoNaziv", proizvodModel.AutoID);
            ViewBag.KategorijaID = new SelectList(db.kategorija, "KategorijaID", "KategorijaNaziv", proizvodModel.KategorijaID);
            return View(proizvodModel);
        }

        /*
          ======

            ORDER

        =======
         */
         [Authorize(Roles =("User"))]
        public ActionResult Order(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProizvodModel proizvodModel = db.proizvod.Find(id);
            
            if (proizvodModel == null)
            {

                return HttpNotFound();
            }

            ViewBag.status = 0;
            ViewBag.datum = DateTime.Now;
            ViewBag.username = User.Identity.GetUserName();
            
            ViewBag.auto = (from i in db.proizvod join a in db.auto on i.AutoID equals a.AutoID where i.ProizvodiID == id select a.AutoNaziv);
           ViewBag.kategorija = (from i in db.proizvod join a in db.kategorija on i.KategorijaID equals a.KategorijaID where i.ProizvodiID == id select a.KategorijaNaziv);
            ViewBag.price = (from i in db.proizvod where i.ProizvodiID == id select i.Cena);
            ViewBag.model = (from i in db.proizvod where i.ProizvodiID == id select i.ProizvodiModel);
            ViewBag.AutoID = new SelectList(db.auto, "AutoID", "AutoNaziv", proizvodModel.AutoID);
            ViewBag.KategorijaID = new SelectList(db.kategorija, "KategorijaID", "KategorijaNaziv", proizvodModel.KategorijaID);
            return View(proizvodModel);
        }
        [Authorize(Roles = ("User"))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order([Bind(Include = "NarudzbinaID,UserName,ProizvodiModel,Cena,AutoID,KategorijaID,Datum,Status")] NarudzbinaModel narudzbinaModel)
        {

   

            if (ModelState.IsValid)
            {
                db.narudzbina.Add(narudzbinaModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.auto = new SelectList(db.auto, "AutoID", "AutoNaziv", narudzbinaModel.AutoID);
            ViewBag.kategorija = new SelectList(db.kategorija, "KategorijaID", "KategorijaNaziv", narudzbinaModel.KategorijaID);
            return View(narudzbinaModel);
        }





        // POST: ProizvodModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProizvodiID,ProizvodiModel,DatumProizvodnje,Cena,KategorijaID,AutoID,Slika")] ProizvodModel proizvodModel, HttpPostedFileBase image1)
        {

            if (image1 != null)
            {
                proizvodModel.Slika = new byte[image1.ContentLength];
                image1.InputStream.Read(proizvodModel.Slika, 0, image1.ContentLength);
            }

            if (ModelState.IsValid)
            {
                db.Entry(proizvodModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.AutoID = new SelectList(db.auto, "AutoID", "AutoNaziv", proizvodModel.AutoID);
            ViewBag.KategorijaID = new SelectList(db.kategorija, "KategorijaID", "KategorijaNaziv", proizvodModel.KategorijaID);
            return View(proizvodModel);
        }

        // GET: ProizvodModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProizvodModel proizvodModel = db.proizvod.Find(id);
            if (proizvodModel == null)
            {
                return HttpNotFound();
            }
            return View(proizvodModel);
        }

        // POST: ProizvodModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProizvodModel proizvodModel = db.proizvod.Find(id);
            db.proizvod.Remove(proizvodModel);
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
