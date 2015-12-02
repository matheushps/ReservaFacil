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

namespace Ensalamento.Web.UI.Controllers
{
    [RoutePrefix("Bloco")]
    public class BlocosController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Blocos
        [Route("Listar")]
        public ActionResult Index()
        {
            return View(db.Blocos.ToList());
        }

        // GET: Blocos/Details/5
        [Route("Mostrar")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloco bloco = db.Blocos.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            return View(bloco);
        }

        // GET: Blocos/Create
        [Route("Cadastrar")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blocos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Cadastrar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlocoId,Nome,Localizacao,DataCadastro")] Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                bloco.DataCadastro = DateTime.Now.ToLocalTime();
                db.Blocos.Add(bloco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloco);
        }

        //Validação para primeira vizualização de sala\\
        [Route("NenhumBlocoSala")]
        public ActionResult CadastroBlocoParaSala()
        {
            return View("PrimeiroBloco");
        }

        [Route("NenhumBlocoSala")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroBlocoParaSala([Bind(Include = "BlocoId,Nome,Localizacao,DataCadastro")] Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                bloco.DataCadastro = DateTime.Now.ToLocalTime();
                db.Blocos.Add(bloco);
                db.SaveChanges();
                return RedirectToAction("Listar","Sala");
            }

            return View(bloco);
        }

        ///Validação para Auditório\\\
        [Route("NenhumBlocoAuditorio")]
        public ActionResult CadastroBlocoParaAuditorio()
        {
            return View("PrimeiroBloco");
        }

        [Route("NenhumBlocoAuditorio")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroBlocoParaAuditorio([Bind(Include = "BlocoId,Nome,Localizacao,DataCadastro")] Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                bloco.DataCadastro = DateTime.Now.ToLocalTime();
                db.Blocos.Add(bloco);
                db.SaveChanges();
                return RedirectToAction("Listar", "Auditorio");
            }

            return View(bloco);
        }
        ///Validação para Laboratório\\\
        [Route("NenhumBlocoLaboratorio")]
        public ActionResult CadastroBlocoParaLaboratorio()
        {
            return View("PrimeiroBloco");
        }

        [Route("NenhumBlocoLaboratorio")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroBlocoParaLaboratorio([Bind(Include = "BlocoId,Nome,Localizacao,DataCadastro")] Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                bloco.DataCadastro = DateTime.Now.ToLocalTime();
                db.Blocos.Add(bloco);
                db.SaveChanges();
                return RedirectToAction("Listar", "Laboratorio");
            }

            return View(bloco);
        }
        // GET: Blocos/Edit/5
        [Route("Editar")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloco bloco = db.Blocos.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            return View(bloco);
        }

        // POST: Blocos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlocoId,Nome,Localizacao,DataCadastro")] Bloco bloco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloco);
        }

        // GET: Blocos/Delete/5
        [Route("Apagar")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloco bloco = db.Blocos.Find(id);
            if (bloco == null)
            {
                return HttpNotFound();
            }
            return View(bloco);
        }

        // POST: Blocos/Delete/5
        [Route("Apagar")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bloco bloco = db.Blocos.Find(id);
            db.Blocos.Remove(bloco);
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
