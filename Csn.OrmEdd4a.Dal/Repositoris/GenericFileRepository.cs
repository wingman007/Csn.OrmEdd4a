using Csn.OrmEdd4a.Dal.DataMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd4a.Dal.Repositoris
{
    public class GenericFileRepository<T> : IRepository<T> where T : class
    {
        private readonly IDataMapper<T> _dataMapper;

        private List<T> _dataSet;

        public GenericFileRepository(IDataMapper<T> dataMapper)
        {
            _dataMapper = dataMapper;
            // _dataSet = _dataMapper.GetAll();
        }
        public IEnumerable<T> GetAll()
        {
            // throw new NotImplementedException();
            // return _dataSet;
            return _dataMapper.GetAll();
        }

        public T Get(object id)
        {
            // The models should implement the same interface IId I have to make sure all entities have Id
            // throw new NotImplementedException();
            return _dataMapper.Get(id);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            // throw new NotImplementedException();
            // IQueryable<T> dataSet = (IQueryable<T>)_dataSet;
            IQueryable<T> dataSet = (IQueryable<T>)_dataMapper.GetAll();
            return dataSet.Where<T>(predicate);
        }

        public void Add(T entity)
        {
            // throw new NotImplementedException();
            // _dataSet.Add(entity);
            _dataMapper.Insert(entity);
        }

        public void Remove(T entity)
        {
            // throw new NotImplementedException();
            // _dataSet.Remove(entity);
            _dataMapper.Delete(entity);
        }

        public T Update(T entity)
        {
            // throw new NotImplementedException();
            _dataMapper.Update(entity);
            return entity; // ???
        }
    }
}
