using AkaraProject.Models.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkaraProject
{
    public class CustomSerializeModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }

        public List<Role> Role { get; set; }

    }
}