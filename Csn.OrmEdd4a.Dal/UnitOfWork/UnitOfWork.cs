using Csn.OrmEdd4a.Dal.DataMappers;
using Csn.OrmEdd4a.Dal.Repositoris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd4a.Dal.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly PersonRepository _persons;
        public UnitOfWork()
        {
            _persons = new PersonRepository(new PersonDataMapper());
        }
        public PersonRepository Persons
        {
            get { return _persons; } // throw new NotImplementedException();
        }

        public void SaveAll()
        {
            throw new NotImplementedException();
        }
    }
}
