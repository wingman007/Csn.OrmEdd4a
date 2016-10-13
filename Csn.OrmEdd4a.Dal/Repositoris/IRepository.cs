using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd4a.Dal.Repositoris
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int id); 
        List<T> Find(Expression<Func<T,bool>> predicate);
        void Add(T entity);
        void Remove(T entity);
    }
}
