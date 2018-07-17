using PatientPay.BusinessObjects.FindPayment;

namespace PatientPay.BusinessLogicLayer.FindPayment
{
    public interface IFindPaymentService
    {
        FindPaymentInfo GetSearchedPatients(IFindPaymentData iFindPaymentData);
        PaymentBreakdownInfo GetPaymentBreakdown(string patientId);
    }
}
