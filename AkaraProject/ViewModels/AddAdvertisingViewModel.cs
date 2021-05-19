using AkaraProject.Models;
using AkaraProject.Models.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AkaraProject.ViewModels
{
    public class AddAdvertisingViewModel
    {
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

        public ICollection<Comment> comments { get; set; }

    }
}