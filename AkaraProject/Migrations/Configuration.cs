namespace AkaraProject.Migrations
{
    using AkaraProject.Models.Roles;
    using AkaraProject.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AkaraProject.DataAccess.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AkaraProject.DataAccess.ApplicationDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            List<string> Roles = new List<string>() { "Admin", "User" };
            if (!context.Roles.Any(cnt => Roles.Contains(cnt.Name)))
            {
                List<Role> roles = new List<Role>()
                {
                   new Role(){Id=Guid.NewGuid(),Name="Admin"},
                   new Role(){Id=Guid.NewGuid(),Name="User"}
                };
                context.Roles.AddRange(roles);
                context.SaveChanges();
            }


            if (!context.Users.Any(cnt => cnt.Email.ToUpper() == "SYSTEM@ADMIN.COM"))
            {
                // Add admin 
                User admin = new User()
                {
                    Id = Guid.NewGuid(),
                    Email = "system@admin.com",
                    CreatedAt = DateTime.Now,
                    Password = "P@ssw0rd",
                    PhoneNumber = "01016069034",
                    UserName = "Admin",
                    RoleId = context.Roles.SingleOrDefault(obj => obj.Name == "Admin").Id,
                };

                // Update Database 
                context.Users.Add(admin);
                context.SaveChanges();

            }




        }
    }
}
