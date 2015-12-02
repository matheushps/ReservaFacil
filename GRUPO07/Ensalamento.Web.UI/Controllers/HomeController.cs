using Ensalamento.Dominio;
using Ensalamento.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ensalamento.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private Contexto db = new Contexto();

        public ActionResult Index()
        {
            var salas = db.Salas.ToList();
            var laboratorios = db.Laboratorios.ToList();
            var auditorios = db.Auditorios.ToList();

            if (salas.Count <= 0)
            {
                return View("AlertaSala");
            }
            else if (laboratorios.Count <= 0)
            {
                return View("AlertaLaboratorio");
            }
            else if (auditorios.Count <= 0)
            {
                return View("AlertaAuditorio");
            }

            else
            {
                return View();
            }
        }
    }
}