using Csn.OrmEdd4a.Dal.Repositoris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd4a.Dal.UnitOfWork
{
    interface IUnitOfWork
    {
        PersonRepository Persons { get; }

        void SaveAll(); // Complete(), Flush();
    }
}
