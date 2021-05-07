using AkaraProject.Models.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AkaraProject.Models.Users
{
    [Table(nameof(User))]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { set; get; }
        public string CreatedBy { get; set; }
        public Role Role { set; get; }

        [Required]
        [ForeignKey(nameof(Role))]
        public Guid RoleId { set; get; }

        public virtual ICollection<Advertising> Advertisings { get; set; }

    }
}