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
    [RoutePrefix("Auditorio")]
    public class AuditoriosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Auditorios
        [Route("Listar")]
        public ActionResult Index()
        {
            var blocos = db.Blocos.ToList();
            var pessoas = db.Pessoas.ToList();
            var contaAuditorio = db.Auditorios.ToList();

            if (pessoas.Count <= 0)
            {
                return RedirectToAction("NenhumUsuarioAuditorio", "Usuario");
            }
            else if (blocos.Count <= 0)
            {
                return RedirectToAction("NenhumBlocoAuditorio", "Bloco");
            }
            else if (contaAuditorio.Count <= 0)
            {
                return View("NenhumAuditorio");
            }
            else
            {
                var auditorios = db.Auditorios.Include(a => a.Bloco);
                return View(auditorios.ToList());
            }
        }

        // GET: Auditorios/Details/5
        [Route("Mostrar")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditorio auditorio = db.Auditorios.Find(id);
            if (auditorio == null)
            {
                return HttpNotFound();
            }
            return View(auditorio);
        }

        // GET: Auditorios/Create
        [Route("Cadastrar")]
        public ActionResult Create()
        {
            var blocos = db.Blocos.ToList();

            if (blocos.Count <= 0)
            {
                return RedirectToAction("NenhumBlocoSala", "Bloco");
            }
            else
            {
                ViewBag.BlocoId = new SelectList(db.Blocos, "BlocoId", "Nome");
                return View();
            }
        }

        // POST: Auditorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Cadastrar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuditorioId,Nome,Capacidade,Status,DataCadastro,BlocoId")] Auditorio auditorio)
        {
            if (ModelState.IsValid)
            {
                var auditorioBo = new AuditorioBo();
                auditorioBo.Adicionar(auditorio);
                return RedirectToAction("Index");

            }

            ViewBag.BlocoId = new SelectList(db.Blocos, "BlocoId", "Nome", auditorio.BlocoId);
            return View(auditorio);
        }

        // GET: Auditorios/Edit/5
        [Route("Editar")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditorio auditorio = db.Auditorios.Find(id);
            if (auditorio == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlocoId = new SelectList(db.Blocos, "BlocoId", "Nome", auditorio.BlocoId);
            return View(auditorio);
        }

        // POST: Auditorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuditorioId,Nome,Capacidade,Status,DataCadastro,BlocoId")] Auditorio auditorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auditorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlocoId = new SelectList(db.Blocos, "BlocoId", "Nome", auditorio.BlocoId);
            return View(auditorio);
        }

        // GET: Auditorios/Delete/5
        [Route("Apagar")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auditorio auditorio = db.Auditorios.Find(id);
            if (auditorio == null)
            {
                return HttpNotFound();
            }
            return View(auditorio);
        }

        // POST: Auditorios/Delete/5
        [Route("Apagar")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auditorio auditorio = db.Auditorios.Find(id);
            db.Auditorios.Remove(auditorio);
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
