using PatientPay.BusinessObjects.Abstractions;

namespace PatientPay.BusinessObjects.PostPayment
{
    public interface IPostPaymentData : ITrackData
    {
        string PatientGivenId { get; set; }
        string Username { get; set; }
        double Amount { get; set; }
        string Description { get; set; }
    }
}
