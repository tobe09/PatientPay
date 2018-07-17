using PatientPay.BusinessLogicLayer.RegisterPatient;
using PatientPay.BusinessObjects.RegisterPatient;
using System.Threading.Tasks;
using System.Web.Http;

namespace PatientPay.WebApi.Controllers
{
    public class RegisterPatientController : ApiController
    {
        private IRegisterPatientService regPatientService;

        public RegisterPatientController() => regPatientService = new RegisterPatientService();

        public RegisterPatientController(IRegisterPatientService testService) => regPatientService = testService;

        [HttpPost]
        //also works with async/await setup
        public Task<PatientInfo> RegisterPatient(PatientData patientData) => GetPatientInfo(patientData).ContinueWith(r =>
        {
            return r.Result;
        });
        
        private Task<PatientInfo> GetPatientInfo(IPatientData patientData)
        {
            return Task.Factory.StartNew(() =>
            {
                return regPatientService.RegisterPatient(patientData);
            });
        }
    }
}
