using PatientPay.BusinessObjects.FindPayment;
using PatientPay.BusinessObjects.RegisterPatient;
using System.Collections.Generic;

namespace PatientPay.DataAccessLayer.FindPayment
{
    public interface IFindPaymentDao
    {
        List<PatientFoundDetails> GetByDetail(string patientId);
        PatientData GetPatientData(string patientId);
        List<PaymentBreakdown> GetBreakDown(string patientId);
        string GetCreatingAdminName(string patientId);

        PaymentBreakdownInfo GetPaymentBreakdownInfo(string patientGivenId);

        /*List<PatientFoundDetails> GetByPatientsId(string patientId);
        List<PatientFoundDetails> GetByUsername(string username);
        List<PatientFoundDetails> GetByEmail(string email);
        List<PatientFoundDetails> GetByPhoneNo(string phoneNo);*/
    }
}
