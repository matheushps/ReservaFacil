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
    [RoutePrefix("Laboratorio")]
    public class LaboratoriosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Laboratorios
        [Route("Listar")]
        public ActionResult Index()
        {
            var blocos = db.Blocos.ToList();
            var pessoas = db.Pessoas.ToList();
            var contaLaboratorios = db.Laboratorios.ToList();

            if (pessoas.Count <= 0)
            {
                return RedirectToAction("NenhumUsuarioLaboratorio", "Usuario");
            }
            else if (blocos.Count <= 0)
            {
                return RedirectToAction("NenhumBlocoLaboratorio", "Bloco");
            }
            else if (contaLaboratorios.Count <= 0)
            {
                return View("NenhumLaboratorio");
            }

            else
            {
                var laboratorios = db.Laboratorios.Include(l => l.Bloco);
                return View(laboratorios.ToList());
            }
        }

        // GET: Laboratorios/Details/5
        [Route("Mostrar")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var laboratorioBo = new LaboratorioBo();
            var laboratorio = laboratorioBo.Mostrar(id.Value);

            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            return View(laboratorio);
        }

        // GET: Laboratorios/Create
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

        // POST: Laboratorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Cadastrar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LaboratorioId,Nome,Capacidade,Status,DataCadastro,BlocoId")] Laboratorio laboratorio)
        {
            if (ModelState.IsValid)
            {

                var laboratorioBo = new LaboratorioBo();
                laboratorioBo.Adicionar(laboratorio);
                return RedirectToAction("Index");
            }

            ViewBag.BlocoId = new SelectList(db.Blocos, "BlocoId", "Nome", laboratorio.BlocoId);
            return View(laboratorio);
        }

        // GET: Laboratorios/Edit/5
        [Route("Editar")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Laboratorio laboratorio = db.Laboratorios.Find(id);

            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlocoId = new SelectList(db.Blocos, "BlocoId", "Nome", laboratorio.BlocoId);
            return View(laboratorio);
        }

        // POST: Laboratorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LaboratorioId,Nome,Capacidade,Status,DataCadastro,BlocoId")] Laboratorio laboratorio)
        {
            if (ModelState.IsValid)
            {
                var laboratorioBo = new LaboratorioBo();
                laboratorioBo.Editar(laboratorio);
                return RedirectToAction("Index");
                
            }
            ViewBag.BlocoId = new SelectList(db.Blocos, "BlocoId", "Nome", laboratorio.BlocoId);
            return View(laboratorio);
        }

        // GET: Laboratorios/Delete/5
        [Route("Apagar")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratorio laboratorio = db.Laboratorios.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            return View(laboratorio);
        }

        // POST: Laboratorios/Delete/5
        [Route("Apagar")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {          
            var laboratorioBo = new LaboratorioBo();
            laboratorioBo.Apagar(id);
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
