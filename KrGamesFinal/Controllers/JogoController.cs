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
    public class JogoController : Controller
    {
        private Context db = new Context();

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult ListarJogos()
        {
            return View(db.Jogos.ToList());
        }

        public ActionResult PesquisarJogo()
        {
            string JogoNome = Request.QueryString["nome"]; 
            return PartialView(db.Jogos.Where(x => x.JogoNome.Contains(JogoNome)).OrderBy(x => x.JogoNome).ToList());
            //return View(db.Jogos.Find("God"));
        }

        // GET: Jogo
        public ActionResult Index()
        {
            var jogos = db.Jogos.Include(j => j.GeneroJogo).Include(j => j.MidiaJogo);
            return View(jogos.ToList());
        }

        // GET: Jogo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // GET: Jogo/Create
        public ActionResult Create()
        {
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "GeneroJogo");
            ViewBag.MidiaId = new SelectList(db.Midias, "MidiaId", "MidiaJogo");
            return View();
        }

        // POST: Jogo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JogoId,JogoNome,JogoDescricao,JogoPreco,JogoQuantidade,JogoImagem,GeneroId,MidiaId")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                db.Jogos.Add(jogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "GeneroJogo", jogo.GeneroId);
            ViewBag.MidiaId = new SelectList(db.Midias, "MidiaId", "MidiaJogo", jogo.MidiaId);
            return View(jogo);
        }

        // GET: Jogo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "GeneroJogo", jogo.GeneroId);
            ViewBag.MidiaId = new SelectList(db.Midias, "MidiaId", "MidiaJogo", jogo.MidiaId);
            return View(jogo);
        }

        // POST: Jogo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JogoId,JogoNome,JogoDescricao,JogoPreco,JogoQuantidade,JogoImagem,GeneroId,MidiaId")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "GeneroJogo", jogo.GeneroId);
            ViewBag.MidiaId = new SelectList(db.Midias, "MidiaId", "MidiaJogo", jogo.MidiaId);
            return View(jogo);
        }

        // GET: Jogo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogo jogo = db.Jogos.Find(id);
            db.Jogos.Remove(jogo);
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
