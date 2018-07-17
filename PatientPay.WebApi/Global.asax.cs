using PatientPay.WebApi.App_Start;
using System;
using System.Web;
using System.Web.Http;

namespace PatientPay.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Filters.Add(new PostDataFilter());
            GlobalConfiguration.Configuration.Filters.Add(new MyExceptionFilter());
        }

        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            if (exception == null) return;

            //log the error
            Server.ClearError();
        }
    }
}
