using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KrGamesFinal.Models;

namespace KrGamesFinal.Controllers
{
    public class MidiaController : Controller
    {
        private Context db = new Context();

        // GET: Midia
        public ActionResult Index()
        {
            return View(db.Midias.ToList());
        }

        // GET: Midia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Midia midia = db.Midias.Find(id);
            if (midia == null)
            {
                return HttpNotFound();
            }
            return View(midia);
        }

        // GET: Midia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Midia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MidiaId,MidiaJogo")] Midia midia)
        {
            if (ModelState.IsValid)
            {
                db.Midias.Add(midia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(midia);
        }

        // GET: Midia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Midia midia = db.Midias.Find(id);
            if (midia == null)
            {
                return HttpNotFound();
            }
            return View(midia);
        }

        // POST: Midia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MidiaId,MidiaJogo")] Midia midia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(midia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(midia);
        }

        // GET: Midia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Midia midia = db.Midias.Find(id);
            if (midia == null)
            {
                return HttpNotFound();
            }
            return View(midia);
        }

        // POST: Midia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Midia midia = db.Midias.Find(id);
            db.Midias.Remove(midia);
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
