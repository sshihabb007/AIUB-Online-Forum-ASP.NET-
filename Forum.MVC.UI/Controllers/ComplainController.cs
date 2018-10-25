using Forum.Service;
using Forum.Web.Mvc.Models;
using Forum.MVC.UI.Custon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.MVC.UI.Filter;

namespace Forum.MVC.UI.Controllers
{
    [LoginValidation]
    public class ComplainController : Controller
    {
        private ComplainService _service;
        PostCustomServices _customService;
        public ComplainController(ComplainService service, PostCustomServices customService)
        {
            _service = service;
            _customService = customService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CreateComplain = new CustomComplain();
            return View(_customService.GetUser());
        }

        [HttpPost]
        public ActionResult Create(CustomComplain complain)
        {
            _customService.AddComplain(Convert.ToInt32(Session["userId"].ToString()), complain);
            return RedirectToAction("Index","Post",new { });
        }

        [HttpGet]
        public ActionResult Archive()
        {
            return View(_customService.GetAllComplain(Convert.ToInt32(Session["userId"].ToString())));
        }

        [HttpGet]
        public ActionResult Details(int id, int flag)
        {
            switch(flag)
            {
                case 1:
                    return View(_customService.GetComplainDetailsAboutMe(id));
                case 2:
                    return View(_customService.GetComplainDetailsFromMe(id));
                default:
                    return RedirectToAction("Index", "Post", new { });
            }
            
        }
    }
}