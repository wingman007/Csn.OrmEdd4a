using Csn.OrmEdd4a.Dal.Repositoris;
using Csn.OrmEdd4a.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd4a.Dal.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public EfUnitOfWork(DbContext context)
        {
            _context = context;

            Persons = new GenericEfRepository<Person>(_context);
            Phones = new GenericEfRepository<Phone>(_context);
        }
        public IRepository<Person> Persons { get; protected set; }

        public IRepository<Phone> Phones  { get; protected set; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
