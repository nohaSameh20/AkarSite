﻿using AkaraProject.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AkaraProject.Models.Comments
{
    [Table(nameof(Comment))]
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Advertising> Advertisings { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
