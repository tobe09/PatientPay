using PatientPay.BusinessLogicLayer.AdminLogin;
using PatientPay.BusinessObjects.AdminLogin;
using PatientPay.MvcWebApp.Constants;
using PatientPay.MvcWebApp.Factories;
using PatientPay.MvcWebApp.ViewModels;
using System.Web.Mvc;

namespace PatientPay.MvcWebApp.Controllers
{
    public class AdminLoginController : BaseController
    {
        private IAdminLoginService adminLoginService;

        public AdminLoginController()
        {
            adminLoginService = ServiceFactory.GetService<IAdminLoginService>();
        }

        public AdminLoginController(IAdminLoginService testSvc)
        {
            adminLoginService = testSvc;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminLoginViewModel viewModel)
        {
            AdminLoginInfo adminInfo = adminLoginService.DoLogin(viewModel);

            if (adminInfo.HasError())
            {
                SetErrorMessages(adminInfo.ErrorMessages);
                return View(viewModel);
            }

            Session[Values.AdminKey] = adminInfo.Administrator;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout(AdminLoginViewModel viewModel)
        {
            Session[Values.AdminKey] = null;

            return RedirectToAction("Login"); 
        }
    }
}