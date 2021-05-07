using AkaraProject.Models.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AkaraProject.ViewModels
{
    public class RegisterViewModel
    {
        public Guid UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string UserEmail { get; set; }

       
        public string Phone { get; set; }

        
        public string Image { get; set; }

        [Required]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Password mismatch")]
        public string ConfirmPassword { get; set; }

        public Guid RoleId { get; set; }
    }
}