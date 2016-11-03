using Csn.OrmEdd4a.Dal.DataMappers;
using Csn.OrmEdd4a.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd4a.Dal.Repositoris
{
    public class PersonRepository // : IRepository<Person>
    {
        private  List<Person> _dataSet;
        private readonly IDataMapper<Person> _dataMapper;

        public PersonRepository(IDataMapper<Person> dataMapper)
        {
            _dataMapper = dataMapper;
            // _dataSet = dataMapper.GetAll();
        }

        public List<Person> GetAll()
        {
            // throw new NotImplementedException();
            return GetDataSet();
        }

        public Person Get(int id)
        {
            // throw new NotImplementedException();
            return GetDataSet().Find(p => p.Id == id);
        }

        public List<Person> Find(System.Linq.Expressions.Expression<Func<Person, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Person entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Person entity)
        {
            throw new NotImplementedException();
        }

        private List<Person> GetDataSet()
        {
            if (_dataSet == null)
            {
                _dataSet = _dataMapper.GetAll();
            }
            return _dataSet;
        }

        public Person Update(Person entity)
        {
            throw new NotImplementedException();
        }

    }
}
