using PatientPay.BusinessObjects.PostPayment;

namespace PatientPay.DataAccessLayer.PostPayment
{
    public interface IPostPaymentDao
    {
        int SavePayment(PostPaymentData paymentData);
        PatientBasicInfo GetPatientDetailById(string patientId);
        PatientBasicInfo GetPatientDetailByUsername(string username);
    }
}
