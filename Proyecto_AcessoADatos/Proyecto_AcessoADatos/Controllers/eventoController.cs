using Proyecto_AcessoADatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto_AcessoADatos.Controllers
{
    public class eventoController : ApiController
    {

        // GET: api/evento
        public List<eventoDTO> Get()
        {
            //Devuelve un array de eventos en formato JSON
            var repo = new eventoRepository();
            /*List<evento> eventos = repo.Retrieve();*/
            List<eventoDTO> e = repo.RetrieveDTO();
            return e;
        }


        // GET: api/evento/5
        public List<evento> Get(int id)
        {
            var repo = new eventoRepository();
            List<evento> e= repo.Retrieve();
            return e;
        }

        // POST: api/evento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/evento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/evento/5
        public void Delete(int id)
        {
        }
    }
}
