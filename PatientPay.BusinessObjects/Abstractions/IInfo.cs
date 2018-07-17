using PatientPay.BusinessObjects.Enumeration;

namespace PatientPay.BusinessObjects.Abstractions
{
    public interface IInfo : ITransfer
    {
        string SuccessMessage { get; set; }
        StatusCode StatusCode { get; set; }
        bool HasError();
    }
}
