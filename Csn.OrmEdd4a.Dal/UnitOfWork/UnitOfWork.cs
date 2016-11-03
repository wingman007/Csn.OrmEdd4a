using Csn.OrmEdd4a.Dal.DataMappers;
using Csn.OrmEdd4a.Dal.Repositoris;
using Csn.OrmEdd4a.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd4a.Dal.UnitOfWork
{
    public class UnitOfWork // : IUnitOfWork
    {
        // private readonly PersonRepository _persons;
        public UnitOfWork()
        {
            // _persons = new PersonRepository(new PersonDataMapper());
            // Persons = new PersonRepository(new PersonDataMapper());
        }
        //public PersonRepository Persons
        //{
        //    get { return _persons; } // throw new NotImplementedException();
        //}

        public IRepository<Person> Persons { get; protected set; }

        public IRepository<Phone> Phones { get; protected set; }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
