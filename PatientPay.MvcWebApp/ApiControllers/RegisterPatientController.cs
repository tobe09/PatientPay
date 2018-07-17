using PatientPay.BusinessLogicLayer.RegisterPatient;
using PatientPay.BusinessObjects.RegisterPatient;
using System.Web.Http;

namespace PatientPay.MvcWebApp.ApiControllers
{
    public class RegisterPatientController : ApiController
    {
        private IRegisterPatientService regPatientService;

        public RegisterPatientController()
        {
            regPatientService = new RegisterPatientService();
        }

        public RegisterPatientController(IRegisterPatientService testService)
        {
            regPatientService = testService;
        }

        [HttpPost]
        public PatientInfo RegisterPatient(PatientData patientData)
        {
            return regPatientService.RegisterPatient(patientData);
        }
    }
}
