using System.Web.Http.ExceptionHandling;

namespace PatientPay.WebApi.App_Start
{
    public class MyExceptionLogger: ExceptionLogger
    {
        //Log unhandled exceptions
        public override void Log(ExceptionLoggerContext context)
        {
            //Write the exception to log
            var ex = context.Exception;
            var log = ex.ToString();            
        }
    }
}