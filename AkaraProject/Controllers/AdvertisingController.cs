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
        // GET: Advertising
        public ActionResult Index()
        {
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
                    BuildingStatus = BuildingStatus.Open,
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