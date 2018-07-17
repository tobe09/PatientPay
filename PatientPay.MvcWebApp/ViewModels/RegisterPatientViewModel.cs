using PatientPay.BusinessObjects.RegisterPatient;
using System.ComponentModel.DataAnnotations;

namespace PatientPay.MvcWebApp.ViewModels
{
    public class RegisterPatientViewModel : BaseViewModel, IPatientData
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        public string LastName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Phone Number (Office)")]
        public long PhoneNo { get; set; }
        [Display(Name = "Phone Number (Home)")]
        public long? PhoneNo2 { get; set; }
        [Display(Name = "Residential Address")]
        public string HomeAddress { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}