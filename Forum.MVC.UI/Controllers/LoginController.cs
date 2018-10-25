using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Forum.Admin.Infrastructure;
using Forum.Entity;
using Forum.MVC.UI.Models;
using Forum.MVC.UI.Filter;
namespace Forum.MVC.UI.Controllers
{
    
    public class LoginController : Controller
    {
        private PasswordProtect protect;
       private DbContext _context;
        public LoginController(DbContext context)
        {
            if(protect==null)
            {
                protect = new PasswordProtect();
            }
                _context = context;
        }
        // GET: Login
        [HttpGet]
        [LoginStutas]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login login)
        {
            var pass = protect.CalculateMD5Hash(login.Passrowd);
            var model = _context.Set<User>().Where(u => u.email == login.Username && u.password ==pass ).Select(u => new {u.user_id,u.full_name,u.user_name,u.user_type,u.status,u.photo, u.email, u.password }).SingleOrDefault();
            var rank = _context.Set<Ranking>().Where(u => u.user_id == model.user_id).Select(u => u.points).SingleOrDefault();
          try { 
            if (login.Username == model.email && pass == model.password)
            {
                Session["user"] = Enum.GetName(typeof(Forum.Entity.UserType), model.user_type);
                    Session["userId"] = model.user_id;
                    Session["username"] = model.user_name;
                    Session["fullname"] = model.full_name;
                    Session["photo"] = model.photo;
                    Session["point"] = rank;
                    if(model.status==UserStatus.Active)
                    { 
                if (Session["user"].ToString() == "Admin")
                {
                        ViewBag.loginerror = null;
                        return RedirectToAction("Index", "Admin");
                }
                else if(Session["user"].ToString() == "Moderator")
                {
                        ViewBag.loginerror = null;
                            return RedirectToAction("Index", "Moderator");
                        }
                else if (Session["user"].ToString() == "Student")
                {
                    ViewBag.loginerror = null;
                        return RedirectToAction("Index","Post");
                }
            }
                }
            else
                {
                    ViewBag.loginerror = "You are Blocked or not Aproved By Admin";
                    return View();
                }
            }
            catch
           {
                ViewBag.loginerror = "Username Or Password Does Not Matched";
                return View();
           }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
        [LoginStutas]
        public ActionResult Page()
        {
            return View();
        }
    }
}