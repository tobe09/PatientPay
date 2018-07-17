using PatientPay.BusinessLogicLayer.AdminLogin;
using PatientPay.BusinessObjects.AdminLogin;
using System.Web.Http;

namespace PatientPay.WebApi.Controllers
{
    public class AdminLoginController : ApiController
    {
        private IAdminLoginService adminLoginService;

        public AdminLoginController() => adminLoginService = new AdminLoginService();

        public AdminLoginController(IAdminLoginService testLoginService) => adminLoginService = testLoginService;

        [HttpPost]
        public AdminLoginInfo DoLogin(AdminLoginData adminLoginData) => adminLoginService.DoLogin(adminLoginData);
    }
}
