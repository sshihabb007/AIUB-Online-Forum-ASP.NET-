using Forum.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Admin.Infrastructure;
using Forum.MVC.UI.MvcUser.Interface;
using Forum.MVC.UI.Filter;

namespace Forum.MVC.UI.Controllers
{
    [LoginValidation]
    public class userController : Controller
    {
        private PasswordProtect protect = new PasswordProtect();
        private IUsersModelServices _users;
        private IComplainsModelServices _complains;
        private IChangeInfoRequestModelServices _changeInfoRequest;
        public userController(IUsersModelServices services,IComplainsModelServices complains,IChangeInfoRequestModelServices change)
        {
            _users = services;
            _complains = complains;
            _changeInfoRequest = change;
        }
        // GET: user
        [HttpGet]
        public ActionResult Index()
        {
            return View(_users.GetById(Convert.ToInt32(Session["userId"].ToString())));
        }
        [HttpGet]
        public ActionResult UpdateInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateInfo(ChangeInfoRequests change)
        {
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ChangePass()
        {
            return View(_users.GetById(Convert.ToInt32(Session["userId"].ToString())));
        }
        [HttpGet]
        public ActionResult ChangePhoto()
        {
            
            return View(_users.GetById(Convert.ToInt32(Session["userId"].ToString())));
        }
        [HttpPost]
        public ActionResult ChangePhoto(Models.Users users)
        {
            _users.ChangePhoto(users);
           return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult NewComplain()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewComplain(Complains com)
        {
            _complains.Addcomplain(com);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult ChangePass(Models.Users user)
        {
            var pass = protect.CalculateMD5Hash(user.Password);
                _users.ChangePassById(user.Id, user.Password, user.NewPassword);
                return RedirectToAction("Index");


        }
    }
}