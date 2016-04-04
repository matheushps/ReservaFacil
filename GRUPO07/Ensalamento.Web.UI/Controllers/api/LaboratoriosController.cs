using Ensalamento.BO;
using Ensalamento.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ensalamento.Web.UI.Controllers.api
{
    public class LaboratoriosController : ApiController
    {
        // GET: api/Laboratorios
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Laboratorios/5
        public HttpResponseMessage Get(int id)
        {

            var laboratorioBo = new LaboratorioBo();

            Laboratorio obj = laboratorioBo.ObterPorId(id);

            var response = Request.CreateResponse(HttpStatusCode.OK, obj);

            return response;
            
        }

        // POST: api/Laboratorios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Laboratorios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Laboratorios/5
        public void Delete(int id)
        {
        }
    }
}
