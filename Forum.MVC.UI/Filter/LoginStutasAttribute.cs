using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Forum.MVC.UI.Filter
{
    public class LoginStutasAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Session["user"]!=null)
            {
                if (filterContext.HttpContext.Session["user"].ToString() == "Admin")
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                        { "controller", "Admin" },
                        { "action", "Index" }
                        });
                }
                else if (filterContext.HttpContext.Session["user"].ToString() == "Moderator")
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                        { "controller", "Admin" },
                        { "action", "Index" }
                        });
                }
                else if (filterContext.HttpContext.Session["user"].ToString() == "Stusent")
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                        { "controller", "Login" },
                        { "action", "Page" }
                        });
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}