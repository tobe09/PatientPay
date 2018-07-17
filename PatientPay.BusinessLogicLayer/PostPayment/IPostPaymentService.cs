using PatientPay.BusinessObjects.General;
using PatientPay.BusinessObjects.PostPayment;

namespace PatientPay.BusinessLogicLayer.PostPayment
{
    public interface IPostPaymentService
    {
        BasicInfo SavePayment(IPostPaymentData iPaymentData);
        PatientBasicInfo GetPatientDetailById(string patientId);
        PatientBasicInfo GetPatientDetailByUsername(string username);
    }
}
