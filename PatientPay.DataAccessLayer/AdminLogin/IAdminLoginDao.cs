using PatientPay.BusinessObjects.AdminLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientPay.DataAccessLayer.AdminLogin
{
    public interface IAdminLoginDao
    {
        Admin GetLoginAdmin(IAdminLoginData iAdminLoginData);
    }
}
