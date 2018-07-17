using PatientPay.BusinessLogicLayer.PostPayment;
using PatientPay.BusinessObjects.FindPayment;
using PatientPay.BusinessObjects.PostPayment;
using PatientPay.MvcWebApp.Constants;
using PatientPay.MvcWebApp.Factories;
using PatientPay.MvcWebApp.ViewModels;
using System.Web.Mvc;

namespace PatientPay.MvcWebApp.Controllers
{
    public class PostPaymentController : BaseController
    {
        private IPostPaymentService postPaymentService;

        public PostPaymentController()
        {
            postPaymentService = ServiceFactory.GetService<IPostPaymentService>();
        }

        public PostPaymentController(IPostPaymentService testSvc)
        {
            postPaymentService = testSvc;
        }

        public ActionResult SavePayment()
        {
            var patientFound = Session[Values.SearchedPatientKey];
            PostPaymentViewModel viewModel = new PostPaymentViewModel();
            if (patientFound != null)
            {
                var patient = (PatientFoundDetails)patientFound;
                viewModel.PatientGivenId = patient.PatientGivenId;
                viewModel.Username = patient.Username;
                viewModel.FirstName = patient.FirstName;
                viewModel.LastName = patient.LastName;
                viewModel.SubmitDisabled = false;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SavePayment(PostPaymentViewModel viewModel)
        {
            viewModel.CreatedBy = Admin.Id;
            var info = postPaymentService.SavePayment(viewModel);

            if (info.HasError())
            {
                SetErrorMessages(info.ErrorMessages);
                viewModel.SubmitDisabled = false;
            }
            else
            {
                SetSuccessMessage(info.SuccessMessage);
                ClearFields(viewModel);
                viewModel.SubmitDisabled = true;
            }

            return View(viewModel);
        }

        public ActionResult GetDetailsByPatientId(string patientId)
        {
            PatientBasicInfo patientInfo = postPaymentService.GetPatientDetailById(patientId);

            return Json(patientInfo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDetailsByUsername(string username)
        {
            PatientBasicInfo patientInfo = postPaymentService.GetPatientDetailByUsername(username);

            return Json(patientInfo, JsonRequestBehavior.AllowGet);
        }
    }
}