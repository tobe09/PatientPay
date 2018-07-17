using PatientPay.BusinessObjects.RegisterPatient;

namespace PatientPay.DataAccessLayer.RegisterPatient
{
    public interface IRegisterPatientDao
    {
        int RegisterPatient(PatientData patientData);
        bool UsernameExists(string username);
        bool EmailExists(string email);
        bool PhoneNoExists(long phoneNo);
        int GetLastPatientId();
    }
}
