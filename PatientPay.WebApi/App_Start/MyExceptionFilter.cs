using PatientPay.BusinessObjects.Abstractions;
using PatientPay.BusinessObjects.Enumeration;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace PatientPay.WebApi.App_Start
{
    public class MyExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            Type type = context.ActionContext.ActionDescriptor.ReturnType;
            var info = GetResponseObject(type);

            //send defined response
            context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, info);// "No data was posted");
        }

        public static object GetResponseObject(Type type, string message = "An unexpected error has occured", string property = null)
        {
            if (!(Activator.CreateInstance(type) is IInfo info))
            {
                return message;
            }

            var validationMsg = new ValidationResult(message);
            if (property != null) validationMsg = new ValidationResult(message, new[] { property });

            info.ErrorMessages.Add(validationMsg);
            info.StatusCode = StatusCode.Failure;

            return info;
        }
    }
}