using NUnit.Framework;
using PatientPay.BusinessLogicLayer.AdminLogin;
using PatientPay.BusinessLogicLayer.Factories;
using PatientPay.BusinessObjects.AdminLogin;
using PatientPay.BusinessObjects.Enumeration;
using PatientPay.DataAccessLayer.AdminLogin;
using System.Linq;

namespace PatientPay.BusinessLogicLayer.Tests.AdminLoginTests
{
    [TestFixture]
    public class AdminLoginServiceTests
    {
        [TestCase("John", "Travolta")]
        [TestCase("JayJay", "Okocha123")]
        [TestCase("Cindy", "Eke")]      //test property validators seperately
        public void DoLogin_With_Wrong_Credentials(string username, string password)
        {
            DaoFactory.Register<IAdminLoginDao>(typeof(FakeAdminLoginDao));
            var adminLoginService = new AdminLoginService();
            IAdminLoginData loginData = new AdminLoginData { Username = username, Password = password };

            var loginInfo = adminLoginService.DoLogin(loginData);

            Assert.GreaterOrEqual(loginInfo.ErrorMessages.Count, 1);
            Assert.AreEqual(StatusCode.Failure, loginInfo.StatusCode);
            Assert.AreEqual(null, loginInfo.Administrator);
        }
        
        [TestCase("femi", "femifemi")]
        [TestCase("tobe", "tobetobe")]
        [TestCase("Fernando", "LLORENTE")]
        public void DoLogin_With_Right_Credentials(string username, string password)
        {
            //DaoFactory.Register<IAdminLoginDao>(typeof(FakeAdminLoginDao));  also works
            var adminLoginService = new AdminLoginService(new FakeAdminLoginDao());
            IAdminLoginData loginData = new AdminLoginData { Username = username, Password = password };

            var loginInfo = adminLoginService.DoLogin(loginData);

            Assert.AreEqual(0, loginInfo.ErrorMessages.Count);
            Assert.AreEqual(StatusCode.Success, loginInfo.StatusCode);
            Assert.AreEqual(username, loginInfo.Administrator.Username);
        }
    }

    class FakeAdminLoginDao : IAdminLoginDao
    {
        public Admin GetLoginAdmin(IAdminLoginData iAdminLoginData)
        {
            string[] usernamePassword = new[] { "FEMI,femifemi", "TOBE,tobetobe", "FERNANDO,LLORENTE" };
            if (usernamePassword.Contains(iAdminLoginData.Username.ToUpper() + "," + iAdminLoginData.Password))
                return new Admin { Username = iAdminLoginData.Username };
            else
                return null;
        }
    }
}
