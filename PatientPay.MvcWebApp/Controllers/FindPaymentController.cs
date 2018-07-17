using PatientPay.BusinessLogicLayer.FindPayment;
using PatientPay.BusinessObjects.FindPayment;
using PatientPay.BusinessObjects.RegisterPatient;
using PatientPay.MvcWebApp.Constants;
using PatientPay.MvcWebApp.Factories;
using PatientPay.MvcWebApp.ViewModels;
using System.Web.Mvc;

namespace PatientPay.MvcWebApp.Controllers
{
    public class FindPaymentController : BaseController
    {
        private IFindPaymentService findPaymentService;

        public FindPaymentController()
        {
            findPaymentService = ServiceFactory.GetService<IFindPaymentService>();
        }

        public FindPaymentController(IFindPaymentService testSvc)
        {
            findPaymentService = testSvc;
        }


        public ActionResult Search()
        {
            return View(new FindPaymentViewModel());
        }

        [HttpPost]
        public ActionResult Search(FindPaymentViewModel viewModel)
        {
            FindPaymentInfo info = findPaymentService.GetSearchedPatients(viewModel);

            if (info.HasError())
            {
                SetErrorMessages(info.ErrorMessages);
            }
            else
            {
                SetSuccessMessage(info.SuccessMessage);
                viewModel.PatientsFound = info.PatientsFound;
                Session[Values.SearchedPatientKey] = info.PatientsFound[0];   //set found patient to be referenced from post payment page
            }

            return View(viewModel);
        }
        
        [HttpGet]
        public ActionResult GetPatientHistory(string patientId)
        {
            PaymentBreakdownInfo breakdownInfo = findPaymentService.GetPaymentBreakdown(patientId);
            if (breakdownInfo.HasError())
            {
                SetErrorMessages(breakdownInfo.ErrorMessages);
                //return RedirectToAction("Search");
                return new HttpNotFoundResult($"Patient Id ({patientId}) does not exist");
            }
            //update found patient to be referenced from post payment page
            //Session[Values.SearchedPatientKey] = new PatientFoundDetails
            //{
            //    Username = breakdownInfo.PatientData.Username,
            //    FirstName = breakdownInfo.PatientData.FirstName,
            //    LastName = breakdownInfo.PatientData.LastName,
            //    PatientGivenId = breakdownInfo.PatientData.PatientGivenId,
            //    TotalAmount = breakdownInfo.Breakdown.Sum(b => b.Amount)
            //};

            Session[Values.SearchedPatientKey] = Mapper.Map<PatientData, PatientFoundDetails>(breakdownInfo.PatientData);//,
                //cfg => cfg.AfterMap((p, pfd) =>         //not needed
                //{
                //    pfd.TotalAmount = breakdownInfo.Breakdown.Sum(b => b.Amount);
                //}));

            return View(breakdownInfo);
        }
    }
}