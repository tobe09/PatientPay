using PatientPay.BusinessObjects.General;

namespace PatientPay.BusinessObjects.PostPayment
{
    public class PatientBasicInfo : BasicInfo
    {
        public string PatientGivenId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
