using PatientPay.BusinessObjects.Abstractions;
using PatientPay.BusinessObjects.General;
using System;

namespace PatientPay.BusinessObjects.FindPayment
{
    public class PaymentBreakdown
    {
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
