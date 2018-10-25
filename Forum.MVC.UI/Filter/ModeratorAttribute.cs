using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Forum.MVC.UI.Filter
{
    public class ModeratorAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           if (filterContext.HttpContext.Session["user"].ToString() == "Moderator")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Admin" },
                        { "action", "Index" }
                    });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}