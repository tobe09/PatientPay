using PatientPay.BusinessObjects.General;

namespace PatientPay.BusinessObjects.AdminLogin
{
    public class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public long PhoneNo { get; set; }
        public long? PhoneNo2 { get; set; }
        public string HomeAddress { get; set; }
    }
}
