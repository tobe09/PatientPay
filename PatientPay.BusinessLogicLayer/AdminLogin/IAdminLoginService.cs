using PatientPay.BusinessObjects.AdminLogin;

namespace PatientPay.BusinessLogicLayer.AdminLogin
{
    public interface IAdminLoginService
    {
        AdminLoginInfo DoLogin(IAdminLoginData iAdminLoginData);
    }
}
