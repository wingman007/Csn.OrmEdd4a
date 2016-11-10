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
    public class FileUnitOfWork : IUnitOfWork
    {
        private readonly string _directoryPath;

        public FileUnitOfWork()
        {
            Persons = new GenericFileRepository<Person>(new PersonFileDataMapper());
        }
        public FileUnitOfWork(string directoryPath)
        {
            // Access to the path 'C:\Program Files (x86)\IIS Express\Person.csv' is denied.
            _directoryPath = directoryPath;
            Persons = new GenericFileRepository<Person>(new PersonFileDataMapper(_directoryPath + "\\Person.csv"));
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
