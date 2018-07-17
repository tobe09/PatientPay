using PatientPay.BusinessObjects.BusinessRules;
using PatientPay.BusinessObjects.General;
using System;

namespace PatientPay.BusinessObjects.PostPayment
{
    public class PostPaymentData: BasicData, IPostPaymentData
    {
        public string PatientGivenId { get; set; }
        public string Username { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public override bool IsValid()
        {
            Validate(PropertyValidator.ValidateAmount, Amount);
            Validate(PropertyValidator.ValidateString, Description, "Description");

            return base.IsValid();
        }
    }
}
