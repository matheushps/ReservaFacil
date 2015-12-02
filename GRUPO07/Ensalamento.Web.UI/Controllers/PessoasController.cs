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
    [RoutePrefix("Usuario")]
    public class PessoasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Pessoas
        [Route("Listar")]
        public ActionResult Index()
        {
                var pessoas = db.Pessoas.Include(p => p.Categorias);
                return View(pessoas.ToList());
        }

        // GET: Pessoas/Details/5
        [Route("Mostrar")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoas/Create
        [Route("Cadastrar")]
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome");
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Cadastrar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoaId,Nome,Telefone,Status,DataCadastro,CategoriaId")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.DataCadastro = DateTime.Now.ToLocalTime();
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome", pessoa.CategoriaId);
            return View(pessoa);
        }

        //Validação para primeira vizualização de sala\\
        [Route("NenhumUsuarioSala")]
        public ActionResult CadastroUsuarioParaSala()
        {
            var categorias = db.Categorias.ToList();

            if (categorias.Count <= 0)
            {
                return RedirectToAction("NenhumaCategoriaUsuarioSala", "CategoriaUsuario");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome");
                return View("PrimeiroUsuario");
            }
        }

        [Route("NenhumUsuarioSala")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroUsuarioParaSala([Bind(Include = "PessoaId,Nome,Telefone,Status,DataCadastro,CategoriaId")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.DataCadastro = DateTime.Now.ToLocalTime();
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Listar", "Sala");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome", pessoa.CategoriaId);
            return View(pessoa);
        }

        //Validação para primeira vizualização de laboratorio\\
        [Route("NenhumUsuarioLaboratorio")]
        public ActionResult CadastroUsuarioParaLaboratorio()
        {
            var categorias = db.Categorias.ToList();

            if (categorias.Count <= 0)
            {
                return RedirectToAction("NenhumaCategoriaUsuarioLaboratorio", "CategoriaUsuario");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome");
                return View("PrimeiroUsuario");
            }
        }

        [Route("NenhumUsuarioLaboratorio")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroUsuarioParaLaboratorio([Bind(Include = "PessoaId,Nome,Telefone,Status,DataCadastro,CategoriaId")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.DataCadastro = DateTime.Now.ToLocalTime();
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Listar", "Laboratorio");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome", pessoa.CategoriaId);
            return View(pessoa);
        }
        //Validação para primeira vizualização de auditorio\\
        [Route("NenhumUsuarioAuditorio")]
        public ActionResult CadastroUsuarioParaAuditorio()
        {
            var categorias = db.Categorias.ToList();

            if (categorias.Count <= 0)
            {
                return RedirectToAction("NenhumaCategoriaUsuarioAuditorio", "CategoriaUsuario");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome");
                return View("PrimeiroUsuario");
            }
        }

        [Route("NenhumUsuarioAuditorio")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroUsuarioParaAuditorio([Bind(Include = "PessoaId,Nome,Telefone,Status,DataCadastro,CategoriaId")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.DataCadastro = DateTime.Now.ToLocalTime();
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Listar", "Auditorio");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome", pessoa.CategoriaId);
            return View(pessoa);
        }


        // GET: Pessoas/Edit/5
        [Route("Editar")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome", pessoa.CategoriaId);
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaId,Nome,Telefone,Status,DataCadastro,CategoriaId")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nome", pessoa.CategoriaId);
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        [Route("Apagar")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [Route("Apagar")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
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
