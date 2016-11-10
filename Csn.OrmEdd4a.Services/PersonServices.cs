using Csn.OrmEdd4a.Dal.DataMappers;
using Csn.OrmEdd4a.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd4a.Services
{
    public class PersonServices : IServices<Person>
    {
        public List<Person> GetAll()
        {
            IDataMapper<Person> personDm = new PersonFileDataMapper();
            List<Person> persons = personDm.GetAll();
            return persons;
        }
    }
}
