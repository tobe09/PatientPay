using PatientPay.BusinessObjects.AdminLogin;
using PatientPay.DataAccessLayer.Abstractions;
using PatientPay.DataAccessLayer.Context;
using PatientPay.Utilities.Hashing;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PatientPay.DataAccessLayer.AdminLogin
{
    public class AdminLoginDao : BaseDao, IAdminLoginDao
    {
        public AdminLoginDao() : base() { }
        public AdminLoginDao(PayContext testContext) : base(testContext) { }

        public Admin GetLoginAdmin(IAdminLoginData iAdminLoginData)
        {
            string password = StringSecure.Encrypt(iAdminLoginData.Password);

            Expression<Func<Administrator, bool>> func = adm =>
                  (adm.Username.Equals(iAdminLoginData.Username.Trim(), StringComparison.OrdinalIgnoreCase) ||
                  adm.Email.Equals(iAdminLoginData.Username.Trim(), StringComparison.OrdinalIgnoreCase))
                  && adm.Password == password;

            Admin admin = GetSingleFilteredAsInfo<Administrator, Admin>(func);

            return Mapper.Map<Administrator, Admin>(GetDbContext().Administrators.FirstOrDefault(func));
        }
    }
}
