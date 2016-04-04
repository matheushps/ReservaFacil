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
    [RoutePrefix("Reserva")]
    public class ReservasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Reservas
        [Route("Listar")]
        public ActionResult Index()
        {
            var salas = db.Salas.ToList();
            var laboratorios = db.Laboratorios.ToList();
            var auditorios = db.Auditorios.ToList();

            if ((salas.Count > 0) || (laboratorios.Count > 0) || (auditorios.Count > 0))
            {
                var reservas = db.Reservas.Include(r => r.Auditorios).Include(r => r.Laboratorios).Include(r => r.Pesssoas).Include(r => r.Salas);
                return View(reservas.ToList());

            }
            else
            {
                return View("NenhumRegistro");
            }
        }

        // GET: Reservas/Details/5
        [Route("Mostrar")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reservaBo = new ReservaBo();
            var reserva = reservaBo.Mostrar(id.Value);

            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reservas/Create
        [Route("Cadastrar")]
        public ActionResult Create()
        {
            var salas = db.Salas.ToList();
            var laboratorios = db.Laboratorios.ToList();
            var auditorios = db.Auditorios.ToList();

            if ((salas.Count > 0) || (laboratorios.Count > 0) || (auditorios.Count > 0))
            {
                ViewBag.AuditorioId = new SelectList(db.Auditorios, "AuditorioId", "Nome");
                ViewBag.LaboratorioId = new SelectList(db.Laboratorios, "LaboratorioId", "Nome");
                ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Nome");
                ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "Nome");
                return View();
            }
            else
            {
                return View("NenhumRegistro");
            }
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("cadastrar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservaId,DataInicio,DataFim,HoraInicio,HoraFim,DataCadastro,PessoaId,SalaId,LaboratorioId,AuditorioId")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                var ReservaBo = new ReservaBo();
                ReservaBo.Adicionar(reserva);
                return RedirectToAction("Index");
            }

            ViewBag.AuditorioId = new SelectList(db.Auditorios, "AuditorioId", "Nome", reserva.AuditorioId);
            ViewBag.LaboratorioId = new SelectList(db.Laboratorios, "LaboratorioId", "Nome", reserva.LaboratorioId);
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Nome", reserva.PessoaId);
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "Nome", reserva.SalaId);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        [Route("Editar")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuditorioId = new SelectList(db.Auditorios, "AuditorioId", "Nome", reserva.AuditorioId);
            ViewBag.LaboratorioId = new SelectList(db.Laboratorios, "LaboratorioId", "Nome", reserva.LaboratorioId);
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Nome", reserva.PessoaId);
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "Nome", reserva.SalaId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservaId,DataInicio,DataFim,HoraInicio,HoraFim,DataCadastro,PessoaId,SalaId,LaboratorioId,AuditorioId")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                var reservaBo = new ReservaBo();
                reservaBo.Editar(reserva);
                return RedirectToAction("Index");
            }
            ViewBag.AuditorioId = new SelectList(db.Auditorios, "AuditorioId", "Nome", reserva.AuditorioId);
            ViewBag.LaboratorioId = new SelectList(db.Laboratorios, "LaboratorioId", "Nome", reserva.LaboratorioId);
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Nome", reserva.PessoaId);
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "Nome", reserva.SalaId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        [Route("Apagar")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [Route("Apagar")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var ReservaBo = new ReservaBo();
            ReservaBo.Apagar(id);
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
