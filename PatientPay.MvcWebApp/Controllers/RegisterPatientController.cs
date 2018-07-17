using PatientPay.BusinessLogicLayer.RegisterPatient;
using PatientPay.MvcWebApp.Factories;
using PatientPay.MvcWebApp.ViewModels;
using System.Web.Mvc;

namespace PatientPay.MvcWebApp.Controllers
{
    public class RegisterPatientController : BaseController
    {
        private IRegisterPatientService registerPatientSvervice;

        public RegisterPatientController()
        {
            registerPatientSvervice = ServiceFactory.GetService<IRegisterPatientService>();
        }

        public RegisterPatientController(IRegisterPatientService testSvc)
        {
            registerPatientSvervice = testSvc;
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegisterPatientViewModel viewModel)
        {
            viewModel.CreatedBy = Admin.Id;
            var regInfo = registerPatientSvervice.RegisterPatient(viewModel);

            if (regInfo.HasError())
            {
                SetErrorMessages(regInfo.ErrorMessages);
            }
            else
            {
                SetSuccessMessage($"{regInfo.SuccessMessage}<br/>Patient Id: {regInfo.PatientGivenId}");
                ClearFields(viewModel);
            }

            return View(viewModel);
        }
    }
}