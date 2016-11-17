

namespace Csn.OrmEdd4a.WebApi.Controllers
{
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
        private IUnitOfWork db = new AdoUnitOfWork(new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\fmi\Source\Repos\Csn.OrmEdd4a\Csn.OrmEdd4a.Console\App_Data\CsnOrmEdd4a.mdb;Persist Security Info=True"));

        public IEnumerable<Person> Get()
        {
            return db.Persons.GetAll();
        }

        // [HttpGet]
        public Person Get(int id)
        {
            return db.Persons.Get(id);
        }

        public void Post([FromBody] Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
        }

        public void Put([FromUri] int id, [FromBody] Person person)
        {
            // Person personFromDb = db.Persons.Get(id);
            // personFromDb.Id = person.Id;
            // person.Name = person.Name;

            person.Id = id;
            db.Persons.Update(person);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Person person = db.Persons.Get(id);
            db.Persons.Remove(person);
            db.SaveChanges();
        }

    }
}
