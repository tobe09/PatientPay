using PatientPay.BusinessObjects.General;
using System.Collections.Generic;

namespace PatientPay.BusinessObjects.FindPayment
{
    public class FindPaymentInfo: BasicInfo
    {
        public List<PatientFoundDetails> PatientsFound { get; set; }
    }
}
