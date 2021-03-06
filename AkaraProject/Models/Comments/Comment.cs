using AkaraProject.Models.Users;
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
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        //===============Navigation Properites================//
        public Advertising Advertising { set; get; }
        [ForeignKey(nameof(Advertising))]

        public Guid? AdvertisingId { set; get; }

        public User User { set; get; }
        [ForeignKey(nameof(User))]

        public Guid? UserId { set; get; }

    }
}
