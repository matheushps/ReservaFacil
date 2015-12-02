
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ensalamento.Dominio;
using Ensalamento.ORM;
using Ensalamento.BO;

namespace Ensalamento.Web.UI.Controllers
{
    [RoutePrefix("Sala")]
    public class SalasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Salas
        [Route("Listar")]
        public ActionResult Index()
        {
            var blocos = db.Blocos.ToList();
            var pessoas = db.Pessoas.ToList();
            var contaSalas = db.Salas.ToList();

            if (pessoas.Count <= 0)
            {
                return RedirectToAction("NenhumUsuarioSala", "Usuario");
            }
            else if (blocos.Count <= 0)
            {
                return RedirectToAction("NenhumBlocoSala", "Bloco");

            }
            else if (contaSalas.Count <=0)
            {
                return View("NenhumaSala");
            }
            else
            {
                var salas = db.Salas.Include(s => s.Bloco);
                return View(salas.ToList());
            }
        }

        // GET: Salas/Details/5
        [Route("Mostrar")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // GET: Salas/Create
        [Route("Cadastrar")]
        public ActionResult Create()
        {
            var blocos = db.Blocos.ToList();

            if (blocos.Count <= 0)
            {
                return RedirectToAction("NenhumBlocoSala", "Bloco");
            }
            else { 

                ViewBag.BlocoId = new SelectList(db.Blocos, "BlocoId", "Nome");
                return View();
            }
        }

        // POST: Salas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Cadastrar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalaId,Nome,Capacidade,Status,DataCadastro,BlocoId")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                var salaBo = new SalaBo();
                salaBo.Adicionar(sala);
                return RedirectToAction("Index");
            }

            ViewBag.BlocoId = new SelectList(db.Blocos, "BlocoId", "Nome", sala.BlocoId);
            return View(sala);
        }

        // GET: Salas/Edit/5
        [Route("Editar")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlocoId = new SelectList(db.Blocos, "BlocoId", "Nome", sala.BlocoId);
            return View(sala);
        }

        // POST: Salas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalaId,Nome,Capacidade,Status,DataCadastro,BlocoId")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlocoId = new SelectList(db.Blocos, "BlocoId", "Nome", sala.BlocoId);
            return View(sala);
        }

        // GET: Salas/Delete/5
        [Route("Apagar")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Salas.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // POST: Salas/Delete/5
        [Route("Apagar")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sala sala = db.Salas.Find(id);
            db.Salas.Remove(sala);
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
