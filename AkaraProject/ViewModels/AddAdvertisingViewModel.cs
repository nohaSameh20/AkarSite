using AkaraProject.Models;
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
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Area is required")]
        public int Area { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public BuildingStatus BuildingStatus { get; set; }
        public AdvertisingStatuse AdvertisingStatuse { get; set; }

        [Required(ErrorMessage = "UnitType is required")]
        public UnitType UnitType { get; set; }
        public int NoRoom { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
        public Guid UserId { set; get; }
    }
}