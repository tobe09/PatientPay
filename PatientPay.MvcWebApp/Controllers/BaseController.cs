using AutoMapper;
using PatientPay.BusinessObjects.AdminLogin;
using PatientPay.MvcWebApp.Abstractions;
using PatientPay.MvcWebApp.Constants;
using PatientPay.MvcWebApp.ViewModels;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PatientPay.BusinessObjects.General;

namespace PatientPay.MvcWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        public void SetSuccessMessage(string message)
        {
            SetMessage(message);
            TempData[Values.MsgCssClassKey] = CssClass.SuccessMsg;
        }

        public void SetErrorMessage(string message)
        {
            SetMessage(message);
            TempData[Values.MsgCssClassKey] = CssClass.ErrorMsg;
        }

        private void SetMessage(string message)
        {
            TempData[Values.ErrorMsgKey] = $"<ul> <li>{message}</li> <ul>";
        }

        public void SetErrorMessages(List<ErrorContainer> errorResults)
        {
            string message = "<ul>";
            foreach (var result in errorResults)
            {
                string property = result.PropertyName == null ? "": $"({result.PropertyName})";
                message += $"<li> {result.ErrorMessage} &nbsp; {property} </li>";
            }
            message += "</ul>";
            TempData[Values.ErrorMsgKey] = message;
            TempData[Values.MsgCssClassKey] = CssClass.ErrorMsg;
        }
        
        protected Admin Admin
        {
            get
            {
                return Session[Values.AdminKey] as Admin;
            }
        }

        public IMapper Mapper
        {
            get
            {
                return Mapping.GetMapper();
            }
        }
        
        public void ClearFields(BaseViewModel viewModel)
        {
            viewModel.ClearAllFields();
            ModelState.Clear();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            TempData[Values.ExceptionMsgKey] = "<ul> <li> An error has occured. </li> </ul>";
            Response.Redirect("~/Home/Index");
            filterContext.ExceptionHandled = true;
        }
    }
}