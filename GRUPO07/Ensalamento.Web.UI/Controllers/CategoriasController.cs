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
    [RoutePrefix("CategoriaUsuario")]
    public class CategoriasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Categorias
        [Route("Listar")]
        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }

        // GET: Categorias/Details/5
        [Route("Mostrar")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categorias/Create
        [Route("Cadastrar")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Cadastrar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaId,Nome,DataCadastro")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.DataCadastro = DateTime.Now.ToLocalTime();
                db.Categorias.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        //Será exibida esta action quando não existir nenhuma categoria cadastrada
        //E o usuario tentar acessar Usuarios

        [Route("NenhumaCategoriaUsuarioSala")]
        public ActionResult CadastroCategoriaParaSala()
        {
            return View("PrimeiraCategoria");
        }

        [Route("NenhumaCategoriaUsuarioSala")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroCategoriaParaSala([Bind(Include = "CategoriaId,Nome,DataCadastro")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.DataCadastro = DateTime.Now.ToLocalTime();
                db.Categorias.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Listar", "Sala");
            }

            return View(categoria);
        }

        [Route("NenhumaCategoriaUsuarioLaboratorio")]
        public ActionResult CadastroCategoriaParaLaboratorio()
        {
            return View("PrimeiraCategoria");
        }

        [Route("NenhumaCategoriaUsuarioLaboratorio")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroCategoriaParaLaboratorio([Bind(Include = "CategoriaId,Nome,DataCadastro")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.DataCadastro = DateTime.Now.ToLocalTime();
                db.Categorias.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Listar", "Laboratorio");
            }

            return View(categoria);
        }

        [Route("NenhumaCategoriaUsuarioAuditorio")]
        public ActionResult CadastroCategoriaParaAuditorio()
        {
            return View("PrimeiraCategoria");
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("NenhumaCategoriaUsuarioAuditorio")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroCategoriaParaAuditorio([Bind(Include = "CategoriaId,Nome,DataCadastro")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.DataCadastro = DateTime.Now.ToLocalTime();
                db.Categorias.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Listar", "Auditorio");
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        [Route("Editar")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaId,Nome,DataCadastro")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        [Route("Apagar")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [Route("Apagar")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            db.Categorias.Remove(categoria);
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
