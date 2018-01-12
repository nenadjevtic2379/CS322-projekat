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
    public class KomentarisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

      
        // GET: Komentaris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentari komentari = db.komentari.Find(id);
            if (komentari == null)
            {
                return HttpNotFound();
            }
            return View(komentari);
        }

        
        // GET: Komentaris/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.username = User.Identity.GetUserName();
            return View();
        }

        // POST: Komentaris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KomentarID,UserName,Tekst")] Komentari komentari)
        {
            if (ModelState.IsValid)
            {
                db.komentari.Add(komentari);
                db.SaveChanges();
                return RedirectToAction("CommAndRes");
            }

            ViewBag.username = User.Identity.GetUserName();
            return View(komentari);
        }

        // GET: Komentaris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentari komentari = db.komentari.Find(id);
            if (komentari == null)
            {
                return HttpNotFound();
            }
            return View(komentari);
        }

        // POST: Komentaris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KomentarID,UserName,Tekst")] Komentari komentari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(komentari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CommAndRes");
            }
            return View(komentari);
        }

        /* 
         * 
         * 
         * 
         * ODGOVOR
         * 
         * 
         *  
         */
         [Authorize]
        public ActionResult Odgovor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentari komentari = db.komentari.Find(id);
            if (komentari == null)
            {
                return HttpNotFound();
            }

            ViewBag.username = User.Identity.GetUserName();
            ViewBag.komentarID = id;

            return View(komentari);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Odgovor([Bind(Include = "OdgovorID,KomentarID,UserName,Odgovor")] Odgovori odgovori)
        {
            if (ModelState.IsValid)
            {
                db.odgovori.Add(odgovori);
                db.SaveChanges();
                return RedirectToAction("CommAndRes");
            }

            ViewBag.odgovor = User.Identity.GetUserName();
            return View(odgovori);
        }

       public ActionResult CommAndRes()
        {
            Forum forum = new Forum();
            forum.komentari = db.komentari.ToList();
            forum.odgovori = db.odgovori.ToList();
            return View(forum);
        }




        // GET: Komentaris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komentari komentari = db.komentari.Find(id);
            if (komentari == null)
            {
                return HttpNotFound();
            }
            return View(komentari);
        }

        // POST: Komentaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Komentari komentari = db.komentari.Find(id);
            db.komentari.Remove(komentari);
            db.SaveChanges();
            return RedirectToAction("CommAndRes");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        // GET: Odgovoris/Delete/5
        public ActionResult ObrisiOdgovor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Odgovori odgovori = db.odgovori.Find(id);
            if (odgovori == null)
            {
                return HttpNotFound();
            }
            return View(odgovori);
        }

        // POST: Odgovoris/Delete/5
        [HttpPost, ActionName("ObrisiOdgovor")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiOdgovorConfirmed(int id)
        {
            Odgovori odgovori = db.odgovori.Find(id);
            db.odgovori.Remove(odgovori);
            db.SaveChanges();
            return RedirectToAction("CommAndRes");
        }

    }
}
