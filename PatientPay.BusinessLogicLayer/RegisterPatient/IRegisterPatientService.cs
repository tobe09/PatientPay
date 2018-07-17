using PatientPay.BusinessObjects.RegisterPatient;

namespace PatientPay.BusinessLogicLayer.RegisterPatient
{
    public interface IRegisterPatientService
    {
        PatientInfo RegisterPatient(IPatientData iPatientData);
    }
}
