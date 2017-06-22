using LTWeb_05.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb_05.Filter
{
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CurrentContext.IsLogged() == false)
            {
                //string controller = filterContext.RouteData.Values["controller"].ToString();
                //string action = filterContext.RouteData.Values["action"].ToString();
                //filterContext.Result = new RedirectResult(string.Format("~/Account/Login?retUrl=/{0}/{1}", controller, action));
                //return;
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}