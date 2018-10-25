using Forum.Admin.Infrastructure;
using Forum.Entity;
using Forum.MVC.UI.Filter;
using Forum.MVC.UI.Models;
using Forum.MVC.UI.MvcAdmin.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.MVC.UI.Controllers
{
    [LoginStutas]
    public class RegistrationController : Controller
    {
        private DbContext _context;
        private PasswordProtect protect = new PasswordProtect();
        public RegistrationController(DbContext context)
        {
            _context = context;
        }
        [HttpGet]
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Models.Users users)
        {
            string filename = Path.GetFileName(users.Photo.FileName);
            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Image/"), filename);
            users.PhotoUrl = "~/Image/" + filename;
            users.Photo.SaveAs(path);
            var pass = protect.CalculateMD5Hash(users.Password);
            User user = new User
            {
                address = users.Address,
                blood_group = users.BloodGroup,
                cgpa = users.CGPA,
                dateOfBirth = users.DateOfBirth,
                department = users.Department,
                email = users.Email,
                full_name = users.Name,
                gender = users.Gender,
                password = pass,
                phone = users.Phone,
                religion = users.Religion,
                status = UserStatus.Pending,
                photo = users.PhotoUrl,
                last_login = DateTime.Now,
                last_logout = DateTime.Now,
                last_posted = DateTime.Now,
                user_name = users.user_name,
                user_type=users.UserType
            };
            _context.Set<User>().Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index", "Login");
            
        }
    }
}