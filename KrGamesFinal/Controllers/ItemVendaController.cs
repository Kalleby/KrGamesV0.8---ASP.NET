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
    public class ItemVendaController : Controller
    {
        private Context db = new Context();

        public ActionResult FinalizarCompra()
        {
            Util.Util.ResetarGuid();
            return View();
        }

        // GET: ItemVenda
        public ActionResult Index()
        {
            string carrinhoId = Util.Util.RetornarCarrinhoId();
            var itensVenda = db.ItensVenda.Where(i => i.CarrinhoId.Equals(carrinhoId));
            return View(itensVenda.ToList());
        }

        // GET: ItemVenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItensVenda.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            return View(itemVenda);
        }

        // GET: ItemVenda/Create
        public ActionResult Create(int id)
        {
            ItemVenda iv = new ItemVenda();

            string carrinhoId = Util.Util.RetornarCarrinhoId();
            iv = db.ItensVenda.FirstOrDefault(x => x.CarrinhoId.Equals(carrinhoId) && x.JogoId == id);
            if (iv == null)
            {
                iv = new ItemVenda();
                iv.CarrinhoId = Util.Util.RetornarCarrinhoId();
                iv.JogoId = id;
                iv.ItemVendaData = DateTime.Now;
                iv.ItemVendaQuantidade = 1;
                iv.Jogo = db.Jogos.Find(id);
                if (ModelState.IsValid)
                {
                    db.ItensVenda.Add(iv);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                iv.ItemVendaQuantidade++;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.JogoId = new SelectList(db.Jogos, "JogoId", "JogoNome", iv.JogoId);
            return View(iv);
        }

        // POST: ItemVenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemVendaId,JogoId,ItemVendaData,ItemVendaQuantidade,CarrinhoId")] ItemVenda itemVenda)
        {
            if (ModelState.IsValid)
            {
                db.ItensVenda.Add(itemVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JogoId = new SelectList(db.Jogos, "JogoId", "JogoNome", itemVenda.JogoId);
            return View(itemVenda);
        }

        // GET: ItemVenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItensVenda.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.JogoId = new SelectList(db.Jogos, "JogoId", "JogoNome", itemVenda.JogoId);
            return View(itemVenda);
        }

        // POST: ItemVenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemVendaId,JogoId,ItemVendaData,ItemVendaQuantidade,CarrinhoId")] ItemVenda itemVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JogoId = new SelectList(db.Jogos, "JogoId", "JogoNome", itemVenda.JogoId);
            return View(itemVenda);
        }

        // GET: ItemVenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItensVenda.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            return View(itemVenda);
        }

        // POST: ItemVenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemVenda itemVenda = db.ItensVenda.Find(id);
            db.ItensVenda.Remove(itemVenda);
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
