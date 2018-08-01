using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProPrioRest.Models;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace ProPrioRest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
            var response = Request.CreateResponse<Task>(System.Net.HttpStatusCode.Created, task);
            return response;

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