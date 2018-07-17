using PatientPay.BusinessObjects.BusinessRules;
using PatientPay.BusinessObjects.General;

namespace PatientPay.BusinessObjects.AdminLogin
{
    public class AdminLoginData: BasicData, IAdminLoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public override bool IsValid()
        {
            Validate(PropertyValidator.ValidateUsername, Username);
            Validate(PropertyValidator.ValidatePassword, Password);

            return base.IsValid();
        }
    }
}
