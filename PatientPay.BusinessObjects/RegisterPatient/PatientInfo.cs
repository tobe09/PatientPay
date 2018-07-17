using PatientPay.BusinessObjects.General;

namespace PatientPay.BusinessObjects.RegisterPatient
{
    public class PatientInfo: BasicInfo
    {
        public string PatientGivenId { get; set; }      //id of newly registered patient
    }
}
