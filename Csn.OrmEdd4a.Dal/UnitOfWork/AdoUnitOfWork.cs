namespace Csn.OrmEdd4a.Dal.UnitOfWork
{
    using Csn.OrmEdd4a.Dal.DataMappers;
    using Csn.OrmEdd4a.Dal.Repositoris;
    using Csn.OrmEdd4a.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AdoUnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;

        public AdoUnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            Persons = new GenericAdoRepository<Person>(new PersonAdoDataMapper(_connection));
        }
        public IRepository<Person> Persons { get; protected set; }

        public IRepository<Phone> Phones { get; protected set; }

        public void SaveChanges()
        {
            // throw new NotImplementedException();
        }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }
    }
}
