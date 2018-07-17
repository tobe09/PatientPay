using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PatientPay.WebApi.App_Start
{
    public class PostDataFilter : ActionFilterAttribute
    {
        //best to return a string response or a different type, to ensure that the developer codes against it.
        //This was done for testing purposes.
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string method = actionContext.Request.Method.Method;
            Dictionary<string, object> data = actionContext.ActionArguments;
            var enumerator = data.Values.GetEnumerator();

            //if a single value is posted, it must not be null
            if (method == "POST" && data.Count == 1 && enumerator.MoveNext() && enumerator.Current == null)
            {
                Type type = actionContext.ActionDescriptor.ReturnType;
                var info = MyExceptionFilter.GetResponseObject(type, "No data was posted", "PostedData");
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, info);// "No data was posted");
            }
        }
    }
}