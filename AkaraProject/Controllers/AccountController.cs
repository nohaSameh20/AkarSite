using AkaraProject.CustomeAuthentication;
using AkaraProject.DataAccess;
using AkaraProject.Models.Roles;
using AkaraProject.Models.Users;
using AkaraProject.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AkaraProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginView, string ReturnUrl = "")
        {
            ApplicationDBContext dBContext = new ApplicationDBContext();
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(loginView.Name, loginView.Password))
                {
                    var user = (CustomMembershipUser)Membership.GetUser(loginView.Name, false);
                    if (user != null)
                    {
                        CustomSerializeModel userModel = new CustomSerializeModel()
                        {
                            UserId = user.UserId,
                            Name = user.Name,
                            UserEmail = user.Email,
                            Image=user.Image,
                            Phone=user.Phone,
                            RoleName=user.RoleName,
                            Password=user.Password,
                        };
                       
                        string userData = JsonConvert.SerializeObject(userModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                            (
                            1, loginView.Name, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
                            );

                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie("Cookie1", enTicket);
                        Response.Cookies.Add(faCookie);
                    }
                    
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            ModelState.AddModelError("", "Something Wrong : Username or Password invalid ^_^ ");
            return View(loginView);
        }


        [HttpGet]
        public ActionResult Registration()
        {
            ApplicationDBContext dBContext = new ApplicationDBContext();
            var roles = dBContext.Roles.All(obj => true);
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegisterViewModel registrationView)
        {
            bool statusRegistration = false;
            string messageRegistration = string.Empty;

            if (ModelState.IsValid)
            {
                // Email Verification  
                string userName = Membership.GetUserNameByEmail(registrationView.UserEmail);
                if (!string.IsNullOrEmpty(userName))
                {
                    ModelState.AddModelError("Warning Email", "Sorry: Email already Exists");
                    return View(registrationView);
                }

                //Save User Data   
                using (ApplicationDBContext dbContext = new ApplicationDBContext())
                {
                    var user = new User()
                    {
                        UserName = registrationView.Name,
                        PhoneNumber = registrationView.Phone,
                        Image = registrationView.Image,
                        Email = registrationView.UserEmail,
                        Password = registrationView.Password,
                        Id = Guid.NewGuid(),
                        CreatedAt=DateTime.Now,
                        RoleId=dbContext.Roles.SingleOrDefault(ob=>ob.Name== "User").Id
                    };
                    

                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();

                }


                
                messageRegistration = "Your account has been created successfully. ^_^";
                statusRegistration = true;
            }
            else
            {
                messageRegistration = "Something Wrong!";
            }
            ViewBag.Message = messageRegistration;
            ViewBag.Status = statusRegistration;

            return View(registrationView);
        }


        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }


        

    }
}