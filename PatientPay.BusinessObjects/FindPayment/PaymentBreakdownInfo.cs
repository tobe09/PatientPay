using PatientPay.BusinessObjects.General;
using PatientPay.BusinessObjects.RegisterPatient;
using System.Collections.Generic;

namespace PatientPay.BusinessObjects.FindPayment
{
    public class PaymentBreakdownInfo : BasicInfo
    {
        public string CreatingAdminName { get; set; }
        public PatientData PatientData { get; set; }
        public List<PaymentBreakdown> Breakdown { get; set; }
    }
}
