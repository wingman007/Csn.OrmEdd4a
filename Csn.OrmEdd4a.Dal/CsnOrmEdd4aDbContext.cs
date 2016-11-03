namespace Csn.OrmEdd4a.Dal
{
    using Csn.OrmEdd4a.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class CsnOrmEdd4aDbContext : IdentityDbContext<User>
    {
        public CsnOrmEdd4aDbContext()
            : base("CsnOrmEdd4aConnection")
        {
        }

        public virtual IDbSet<Person> Persons { get; set; }

        public virtual IDbSet<Phone> Phones { get; set; }
    }
}
