using Csn.OrmEdd4a.Dal.Repositoris;
using Csn.OrmEdd4a.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd4a.Dal.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // PersonRepository Persons { get; }

        IRepository<Person> Persons { get; }

        IRepository<Phone> Phones { get; }
        void SaveChanges(); // Complete(), Flush();
    }
}
