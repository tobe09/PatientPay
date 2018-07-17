using System.Web.Mvc;

namespace PatientPay.MvcWebApp.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoginAuthorizationFilter());
        }
    }
}