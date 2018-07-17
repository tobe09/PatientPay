using PatientPay.MvcWebApp.Constants;
using System.Web.Mvc;
using System.Web.Routing;

namespace PatientPay.MvcWebApp.App_Start
{
    public class LoginAuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object admin = filterContext.HttpContext.Session[Values.AdminKey];
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;
            string path = controller + "/" + action;

            if (path != "AdminLogin/Login" && admin == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "AdminLogin" }, { "action", "Login" } });
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}