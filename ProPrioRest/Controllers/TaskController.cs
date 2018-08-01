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
        ToDoDBEntities1 db = new ToDoDBEntities1();
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
        public HttpResponseMessage Post([FromUri] Task task)
        {
            if (ModelState.IsValid)
            {

                task.Date = DateTime.Now;
                db.Tasks.Add(task);
                db.SaveChanges();
                var response = Request.CreateResponse<Task>(System.Net.HttpStatusCode.Created, task);
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest); ;
            
          
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromUri]Task task)
        {
            var basetask = db.Tasks.Where(t => t.Task_Id == id);
            if (!basetask.Any())
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Task with ID");
            }
            else
            {

                Task old = basetask.FirstOrDefault();
                old.Category_Important = task.Category_Important;
                old.Category_Urgent = task.Category_Urgent;
                old.Deadline = task.Deadline;
                old.Description = task.Description;
                old.Done = task.Done;
                old.Subject = task.Subject;
                old.Photo = task.Photo;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, old);
            }

        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public HttpResponseMessage DeleteTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task != null)
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


        }
    }
}