using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd4a.Dal.DataMappers
{
    public interface IDataMapper<T> where T : class
    {
        int GetNextId();

        void Insert(T entity);

        List<T> GetAll();

        T Get(object id); // int

        void Update(T entity);

        void Delete(T entity); // int id
    }
}
