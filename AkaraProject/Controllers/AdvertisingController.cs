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
            IEnumerable<AddAdvertisingViewModel> result;
            var identity = (System.Web.HttpContext.Current?.User);
            if (ModelState.IsValid)
            {
                if (identity.IsInRole("Admin"))
                {
                    query = dBContext.Advertisings.Where(ob => ob.AdvertisingStatuse == AdvertisingStatuse.Pending);
                    data = query.OrderByDescending(obj => obj.CreatedAt).ToList();
                    result = data.Select(obj => new AddAdvertisingViewModel()
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
                result = data.Select(obj => new AddAdvertisingViewModel()
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
                    Image= base64
                };
                dBContext.Advertisings.Add(advertising);
                dBContext.SaveChanges();
            }
            else
            {
                return RedirectToAction("Add");
            }

            return RedirectToAction("Add", "Advertising");

        }

    }
}