

namespace Csn.OrmEdd4a.WebApi.Controllers
{
    using Csn.OrmEdd4a.Dal;
    using Csn.OrmEdd4a.Dal.UnitOfWork;
    using Csn.OrmEdd4a.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    public class PersonsController : ApiController
    {
        private IUnitOfWork db = new EfUnitOfWork(new CsnOrmEdd4aDbContext());

        //private IUnitOfWork db = new AdoUnitOfWork(new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\fmi\Source\Repos\Csn.OrmEdd4a\Csn.OrmEdd4a.Console\App_Data\CsnOrmEdd4a.mdb;Persist Security Info=True"));

        public IEnumerable<Person> Get()
        {
            using (db)
            {
                return db.Persons.GetAll();
            } 
        }

        // [HttpGet]
        public Person Get(int id)
        {
            using (db)
            {
                return db.Persons.Get(id);
            }
        }

        // [HttpPost]
        public IHttpActionResult Post([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persons.Add(person);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.Id }, person);
        }

        public IHttpActionResult Put([FromUri] int id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
                // return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "person id doesn't match"); //, ex);
            }

            if (null == db.Persons.Get(id))
            {
                return NotFound();
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                //    "Person with Id " + id.ToString() + " not found to update");
            }

            try
            {
                // Person personFromDb = db.Persons.Get(id);
                // personFromDb.Id = person.Id;
                // person.Name = person.Name;

                person.Id = id;
                db.Persons.Update(person);
                db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent); 
        }

        public IHttpActionResult Delete(int id)
        {
            Person person = db.Persons.Get(id);
            if (person == null)
            {
                return NotFound();
            }
            db.Persons.Remove(person);
            db.SaveChanges();

            return Ok(person);
        }

    }
}
