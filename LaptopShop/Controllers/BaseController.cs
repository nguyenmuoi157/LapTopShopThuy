using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LaptopShop.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public static string  loginsession = "loginsession";
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = Session[loginsession];
            if(session==null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}