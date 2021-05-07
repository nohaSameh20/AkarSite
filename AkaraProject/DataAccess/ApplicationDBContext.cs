using AkaraProject.Models;
using AkaraProject.Models.Roles;
using AkaraProject.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AkaraProject.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
            : base("AkarDB")
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Advertising> Advertisings { get; set; }

    }


}