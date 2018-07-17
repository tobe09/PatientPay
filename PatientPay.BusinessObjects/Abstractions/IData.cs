namespace PatientPay.BusinessObjects.Abstractions
{
    public interface IData: ITransfer
    {
        bool IsValid();
    }
}
