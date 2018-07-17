using PatientPay.BusinessObjects.BusinessRules;
using PatientPay.BusinessObjects.General;

namespace PatientPay.BusinessObjects.FindPayment
{
    public class FindPaymentData : BasicData, IFindPaymentData
    {
        public string ValueEntered { get; set; }
        //public string SelectedCriterion { get; set; }

        public override bool IsValid()
        {
            Validate(PropertyValidator.ValidateString, ValueEntered, "Value Entered");

            return base.IsValid();
        }
    }
}
