using AkaraProject.CustomeAuthentication;
using AkaraProject.DataAccess;
using AkaraProject.Models;
using AkaraProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AkaraProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDBContext dBContext = new ApplicationDBContext();
         
        //[CustomAuthorize(Roles = "Admin")]
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
                    List<AdvertisingStatuse> statuse = new List<AdvertisingStatuse>() { AdvertisingStatuse.Pending, AdvertisingStatuse.Cancelled };
                    query = dBContext.Advertisings.Where(ob => statuse.Contains(ob.AdvertisingStatuse));
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

                 query = dBContext.Advertisings.Where(ob => ob.AdvertisingStatuse == AdvertisingStatuse.Approved);
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

       
        public ActionResult Approve(Guid Id)
        {
            var adver = dBContext.Advertisings.SingleOrDefault(obj => obj.Id == Id);
            if (adver.AdvertisingStatuse == AdvertisingStatuse.Pending)
                adver.AdvertisingStatuse = AdvertisingStatuse.Approved;
            dBContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Cancel(Guid Id)
        {
            var adver = dBContext.Advertisings.SingleOrDefault(obj => obj.Id == Id);
            if (adver.AdvertisingStatuse == AdvertisingStatuse.Pending)
                adver.AdvertisingStatuse = AdvertisingStatuse.Cancelled;
            dBContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid Id)
        {
            HttpCookie cookie = new HttpCookie("AdvertisingId", Id.ToString());
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);

            return RedirectToAction("Details", "Advertising");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Services()
        {
            return View();
        }
    }
}