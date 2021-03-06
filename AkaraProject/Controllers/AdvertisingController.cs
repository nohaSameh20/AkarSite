using AkaraProject.DataAccess;
using AkaraProject.Models;
using AkaraProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AkaraProject.CustomeAuthentication;
using System.IO;
using System.Web.Helpers;
using System.Text;
using AkaraProject.Models.Comments;
namespace AkaraProject.Controllers
{
    public class AdvertisingController : Controller
    {
        ApplicationDBContext dBContext = new ApplicationDBContext();
        // GET: Advertising
        public ActionResult Index()
        {
            IQueryable<Advertising> query;
            List<Advertising> data;
            IEnumerable<AdevrtisingViewModel> result;
            var identity = (System.Web.HttpContext.Current?.User);
            if (ModelState.IsValid)
            {
                if (identity.IsInRole("Admin"))
                {
                    query = dBContext.Advertisings.Where(ob => ob.AdvertisingStatuse == AdvertisingStatuse.Pending && !ob.IsDeleted);
                    data = query.OrderByDescending(obj => obj.CreatedAt).ToList();
                    result = data.Select(obj => new AdevrtisingViewModel()
                    {
                        Id = obj.Id,
                        Area = obj.Area,
                        Description = obj.Description,
                        AdvertisingStatuse = obj.AdvertisingStatuse,
                        BuildingStatus = obj.BuildingStatus,
                        Image = obj.Image,
                        Location = obj.Location,
                        NoRoom = obj.NoRoom,
                        Price = obj.Price,
                        Title = obj.Title,
                        UnitType = obj.UnitType
                    });
                    return View(result);
                }
                query = dBContext.Advertisings.Where(ob => ob.AdvertisingStatuse == AdvertisingStatuse.Approved && !ob.IsDeleted);
                data = query.OrderByDescending(obj => obj.CreatedAt).ToList();
                result = data.Select(obj => new AdevrtisingViewModel()
                {
                    Id = obj.Id,
                    Area = obj.Area,
                    Description = obj.Description,
                    AdvertisingStatuse = obj.AdvertisingStatuse,
                    BuildingStatus = obj.BuildingStatus,
                    Image = obj.Image,
                    Location = obj.Location,
                    NoRoom = obj.NoRoom,
                    Price = obj.Price,
                    Title = obj.Title,
                    UnitType = obj.UnitType
                });

                return View(result);
            }
            return View();
        }


        public ActionResult ViewMyAdvertising()
        {
            IQueryable<Advertising> query;
            List<Advertising> data;
            IEnumerable<AdevrtisingViewModel> result;
            var user = System.Web.HttpContext.Current?.User.Identity.Name.Length;
            if (user != 0)
            {
                var identity = ((CustomPrincipal)System.Web.HttpContext.Current?.User);
                if (ModelState.IsValid)
                {
                    query = dBContext.Advertisings.Where(ob => ob.UserId == identity.UserId && !ob.IsDeleted);
                    data = query.OrderByDescending(obj => obj.CreatedAt).ToList();
                    result = data.Select(obj => new AdevrtisingViewModel()
                    {
                        Id = obj.Id,
                        Area = obj.Area,
                        Description = obj.Description,
                        AdvertisingStatuse = obj.AdvertisingStatuse,
                        BuildingStatus = obj.BuildingStatus,
                        Image = obj.Image,
                        Location = obj.Location,
                        NoRoom = obj.NoRoom,
                        Price = obj.Price,
                        Title = obj.Title,
                        UnitType = obj.UnitType
                    });
                    return View(result);
                }
            }
           
            return View();
        }

        public ActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public ActionResult Add(AddAdvertisingViewModel model)
        {
            ApplicationDBContext dBContext = new ApplicationDBContext();
            var identity = ((CustomPrincipal)System.Web.HttpContext.Current.User);
            if (ModelState.IsValid)
            {
                WebImage image = WebImage.GetImageFromRequest();
                if (image == null)
                {
                    TempData["ErrorMessage"] = "Please Add Image with extension jpg,jpeg,gif";
                    return RedirectToAction("Add");
                }
                    
                byte[] fileBytes = image.GetBytes();
                 
                string base64 = Convert.ToBase64String(fileBytes);

                Advertising advertising = new Advertising()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Area = model.Area,
                    AdvertisingStatuse = AdvertisingStatuse.Pending,
                    BuildingStatus = model.BuildingStatus,
                    Description = model.Description,
                    Location = model.Location,
                    NoRoom = model.NoRoom,
                    Price = model.Price,
                    Title = model.Title,
                    UnitType = model.UnitType,
                    UserId = identity.UserId,
                    Image= base64,
                    IsDeleted=false
                };

                dBContext.Advertisings.Add(advertising);
                dBContext.SaveChanges();
            }
            else
            {
                TempData["ErrorMessage"]="Some Thing Error,Please Call Customer Service";
                return RedirectToAction("Add");
            }
            TempData["SucessMessage"] = "Property Addedd Successfully!!";
            return RedirectToAction("Add", "Advertising");

        }

        public ActionResult Details()
        {

            HttpCookie Id = HttpContext.Request.Cookies.Get("AdvertisingId");
            var id = Guid.Parse(Id.Value.ToString());
            var adver = dBContext.Advertisings.Include("Comments.User").Include("Comments").Include("User").Where(o => o.Id == id && !o.IsDeleted).SingleOrDefault();

            AdevrtisingViewModel result = new AdevrtisingViewModel()
            {
                Id=adver.Id,
                AdvertisingStatuse=adver.AdvertisingStatuse,
                Description=adver.Description,
                Area=adver.Area,
                CreatedAt=adver.CreatedAt,
                BuildingStatus=adver.BuildingStatus,
                Image=adver.Image,
                Location=adver.Location,
                NoRoom=adver.NoRoom,
                Price=adver.Price,
                Title=adver.Title,
                UnitType=adver.UnitType,
                comments=adver.Comments,
                Owner=adver.User.UserName,
                OwnerPhone=adver.User.PhoneNumber
            };
          
            return View(result);
        }


        [HttpPost]
        public ActionResult AddComment(AdevrtisingViewModel model)
        {
           var user= System.Web.HttpContext.Current?.User.Identity.Name.Length;
            HttpCookie Id = HttpContext.Request.Cookies.Get("AdvertisingId");
            var id = Guid.Parse(Id.Value.ToString());
            ApplicationDBContext dBContext = new ApplicationDBContext();
            if (ModelState.IsValid)
            {
                Comment comment = new Comment()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Content=model.Content,
                    Subject=model.Subject,
                    AdvertisingId= id,
                };
                if (user != 0)
                {
                    var identity = ((CustomPrincipal)System.Web.HttpContext.Current?.User);
                    comment.UserId = identity.UserId;
                }
                dBContext.Comments.Add(comment);
                dBContext.SaveChanges();
            }
            else
            {
                return RedirectToAction("AddComment");
            }
            
            return RedirectToAction("Details", "Advertising");

        }


        public ActionResult Delete(Guid Id)
        {
            var adver = dBContext.Advertisings.SingleOrDefault(obj => obj.Id == Id);
            adver.IsDeleted = true;

            dBContext.SaveChanges();
            TempData["SucessMessage"] = $"Adevrising at {adver.Location} Deleted Successfully!!";
            return RedirectToAction("ViewMyAdvertising");
        }
    }
}