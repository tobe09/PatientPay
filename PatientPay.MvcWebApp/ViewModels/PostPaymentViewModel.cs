using PatientPay.BusinessObjects.PostPayment;
using System.ComponentModel.DataAnnotations;

namespace PatientPay.MvcWebApp.ViewModels
{
    public class PostPaymentViewModel: BaseViewModel, IPostPaymentData
    {
        [Display(Name = "Patient Id")]
        public string PatientGivenId { get; set; }
        public string Username { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public double Amount { get; set; }
        public string Description { get; set; }
        public bool SubmitDisabled { get; set; } = true;
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }        
    }
}