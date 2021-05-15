using AkaraProject.Models;
using AkaraProject.Models.Comments;
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
            // modelBuilder.Entity<UserComments>().HasKey(obj => new { obj.UserId, obj.CommentId });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Advertising> Advertisings { get; set; }
       // public DbSet<UserComments> UserComments { get; set; }

    }


}