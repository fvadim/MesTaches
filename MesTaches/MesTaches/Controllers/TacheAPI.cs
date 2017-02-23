using MesTaches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MesTaches.API.Controllers
{

    public class OkDto
    {
        public int TacheId { get; set; }
    }

    public class TacheAPI : ApiController
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        [HttpPost]
        public IHttpActionResult SetDone(int id)
        {
            var tache = from t in db.Taches
                        where t.Id == id
                        select t;
            tache.First().EndDT = DateTime.Today;
            db.SaveChanges();
            return Ok();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}