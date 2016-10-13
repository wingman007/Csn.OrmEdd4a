using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd4a.Services
{
    public interface IServices<T> where T : class
    {
        List<T> GetAll();
    }
}
