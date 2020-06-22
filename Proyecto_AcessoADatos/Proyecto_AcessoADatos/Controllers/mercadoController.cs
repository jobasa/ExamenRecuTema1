using Proyecto_AcessoADatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto_AcessoADatos.Controllers
{
    public class mercadoController : ApiController
    {

        // GET: api/mercado
        public List<mercadoDTO> Get()
        {
            //Devuelve un array de eventos en formato JSON
            var repo = new mercadoRepository();
            /*List<mercado> mercados = repo.Retrieve();*/
            List<mercadoDTO> d = repo.RetrieveDTO();
            return d;

        }

        // GET: api/mercado/5
        [Authorize(Roles = "Admin")]
        public List<mercado> Get(int id)
        {
            var repo = new mercadoRepository();
            List<mercado> d = repo.Retrieve();
            return d;
        }

        // POST: api/mercado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/mercado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/mercado/5
        public void Delete(int id)
        {
        }
    }
}
