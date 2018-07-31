using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProPrioRest.Models;

namespace ProPrioRest.Controllers
{
    public class TaskController : ApiController
    {
        ToDoDBEntities db = new ToDoDBEntities();
        protected override void Dispose(bool disposing)
        { if (disposing) { db.Dispose(); } base.Dispose(disposing); }
        public TaskController() { db.Configuration.ProxyCreationEnabled = false; }


        // GET api/<controller>
        public List<Task> GetTasks()
        {
            return db.Tasks.ToList();
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