using PatientPay.BusinessObjects.BusinessRules;
using PatientPay.BusinessObjects.General;
using System;

namespace PatientPay.BusinessObjects.RegisterPatient
{
    public class PatientData : BasicData, IPatientData
    {
        public int Id { get; set; }
        public string PatientGivenId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public long PhoneNo { get; set; }
        public long? PhoneNo2 { get; set; }
        public string HomeAddress { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public override bool IsValid()
        {
            Validate(PropertyValidator.ValidateUsername, Username);
            Validate(PropertyValidator.ValidateName, FirstName, "First name");
            Validate(PropertyValidator.ValidateName, LastName, "Last name");
            Validate(PropertyValidator.ValidateEmail, Email);
            Validate(PropertyValidator.ValidatePhoneNo, PhoneNo, "First phone number");
            if (PhoneNo2 != null)
            {
                Validate(PropertyValidator.ValidatePhoneNo, (long)PhoneNo2, "Second phone number");
            }
            Validate(PropertyValidator.ValidateAddress, HomeAddress);

            return base.IsValid();
        }
    }
}
