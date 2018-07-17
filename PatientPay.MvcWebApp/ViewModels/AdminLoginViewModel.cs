using PatientPay.BusinessObjects.AdminLogin;
using System.ComponentModel.DataAnnotations;

namespace PatientPay.MvcWebApp.ViewModels
{
    public class AdminLoginViewModel: BaseViewModel, IAdminLoginData
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}