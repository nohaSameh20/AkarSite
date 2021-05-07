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
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase file { get; set; }
        public DateTime CreatedAt { get; set; }
        public BuildingStatus BuildingStatus { get; set; }
        public AdvertisingStatuse AdvertisingStatuse { get; set; }
        public UnitType UnitType { get; set; }
        public int NoRoom { get; set; }
        public string Location { get; set; }


        public User User { set; get; }
        [ForeignKey(nameof(User))]
        public Guid UserId { set; get; }

       
    }
}