namespace Csn.OrmEdd4a.Dal.Migrations
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using Csn.OrmEdd4a.Models;
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<Csn.OrmEdd4a.Dal.CsnOrmEdd4aDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Csn.OrmEdd4a.Dal.CsnOrmEdd4aDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            if (!(context.Users.Any(u => u.UserName == "admin@example.com")))
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var userToInsert = new User { UserName = "admin@example.com", PhoneNumber = "0797697898" };
                userManager.Create(userToInsert, "P@ssw0rd"); // Password@123
            }
            
        }
    }
}
