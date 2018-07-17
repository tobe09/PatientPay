using PatientPay.BusinessObjects.FindPayment;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PatientPay.MvcWebApp.ViewModels
{
    public class FindPaymentViewModel : BaseViewModel, IFindPaymentData
    {
        public string ValueEntered { get; set; }
        public List<PatientFoundDetails> PatientsFound { get; set; } = new List<PatientFoundDetails>();

        //not used
        //public List<SelectListItem> Criteria = new List<SelectListItem>() {
        //    new SelectListItem {Text = "Patient Id" },
        //    new SelectListItem {Text = "Username" },
        //    new SelectListItem {Text = "Email Address" },
        //    new SelectListItem {Text = "Phone Number" }
        //};
        //public string SelectedCriterion { get; set; }
    }
}