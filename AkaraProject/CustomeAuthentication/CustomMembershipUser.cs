using AkaraProject.Models.Roles;
using AkaraProject.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace AkaraProject.CustomeAuthentication
{
    public class CustomMembershipUser : MembershipUser
    {
        #region User Properties

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }

        public  string RoleName { get; set; }

        #endregion

        public CustomMembershipUser(User user) : base("CustomMembership", user.UserName, user.Id, user.Email, string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserId = user.Id;
            Name = user.UserName;
            UserEmail = user.Email;
            Phone = user.PhoneNumber;
            Image = user.Image;
            Password = user.Password;
            RoleName = user.Role?.Name;
        }
    }
}