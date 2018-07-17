using PatientPay.BusinessLogicLayer.Abstractions;
using PatientPay.BusinessLogicLayer.Factories;
using PatientPay.BusinessObjects.AdminLogin;
using PatientPay.DataAccessLayer.AdminLogin;

namespace PatientPay.BusinessLogicLayer.AdminLogin
{
    public class AdminLoginService : BaseService, IAdminLoginService
    {
        private IAdminLoginDao adminLoginDao;

        public AdminLoginService()
        {
            adminLoginDao = DaoFactory.GetDao<IAdminLoginDao>();
        }

        public AdminLoginService(IAdminLoginDao testDao)
        {
            adminLoginDao = testDao;
        }

        public AdminLoginInfo DoLogin(IAdminLoginData iAdminLoginData)
        {
            AdminLoginInfo adminInfo = new AdminLoginInfo();

            AdminLoginData adminLoginData = Mapper.Map<IAdminLoginData, AdminLoginData>(iAdminLoginData);
            if (!adminLoginData.IsValid())
            {
                return GetErrorResponse<AdminLoginInfo>(adminLoginData.ErrorMessages);
            }

            Admin admin = adminLoginDao.GetLoginAdmin(adminLoginData);

            if (admin == null)
            {
                return GetErrorResponse<AdminLoginInfo>("Invalid username/password.");
            }

            adminInfo.Administrator = admin;

            return GetSuccessResponse("Successfully Validated", adminInfo);
        }
    }
}
