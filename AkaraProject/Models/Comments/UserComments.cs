//using AkaraProject.Models.Users;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Web;

//namespace AkaraProject.Models.Comments
//{
//    [Table(nameof(UserComments))]
//    public class UserComments
//    {
//        [Key]
//        public Guid Id { get; set; }

//        public User User { set; get; }
         
//        [ForeignKey(nameof(User))]
//        public Guid UserId { set; get; }

//        public Comment Comment { set; get; }
        
//        [ForeignKey(nameof(Comment))]
//        public Guid CommentId { set; get; }
//    }
//}