using AkaraProject.Models.Comments;
using AkaraProject.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AkaraProject.Models
{
    [Table(nameof(Advertising))]
    public class Advertising
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]

        public int Price { get; set; }

        [Required]
        public int Area { get; set; }

        [Required]
        public string Image { get; set; }


        public DateTime CreatedAt { get; set; }

        [Required]
        public BuildingStatus BuildingStatus { get; set; }

        public AdvertisingStatuse AdvertisingStatuse { get; set; }

        [Required]
        public UnitType UnitType { get; set; }

        [Required]
        public int NoRoom { get; set; }
        [Required]
        public string Location { get; set; }


        public User User { set; get; }
        [ForeignKey(nameof(User))]
        public Guid UserId { set; get; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}