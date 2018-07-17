using PatientPay.BusinessLogicLayer.AdminLogin;
using PatientPay.BusinessObjects.AdminLogin;
using System.Web.Http;

namespace PatientPay.MvcWebApp.ApiControllers
{
    public class AdminLoginController : ApiController
    {
        private IAdminLoginService adminLoginService;

        public AdminLoginController()
        {
            adminLoginService = new AdminLoginService();
        }

        public AdminLoginController(IAdminLoginService testLoginService)
        {
            adminLoginService = testLoginService;
        }

        [HttpPost]
        public AdminLoginInfo DoLogin(AdminLoginData adminLoginData)
        {
            return adminLoginService.DoLogin(adminLoginData);
        }
    }
}
