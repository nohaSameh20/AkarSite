using AkaraProject.Models;
using AkaraProject.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkaraProject.ViewModels
{
    public class AdevrtisingViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }

        public int Area { get; set; }

        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }

        public BuildingStatus BuildingStatus { get; set; }
        public AdvertisingStatuse AdvertisingStatuse { get; set; }

        public UnitType UnitType { get; set; }
        public int NoRoom { get; set; }

        public string Location { get; set; }
        public Guid UserId { set; get; }
        public string Owner { set; get; }
        public string OwnerPhone { set; get; }

        public string Subject { get; set; }

        public string Content { get; set; }
        public DateTime? CommentCreatedAt { get; set; }

        public ICollection<Comment> comments { get; set; }
    }
}