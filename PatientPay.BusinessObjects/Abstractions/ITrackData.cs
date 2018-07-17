namespace PatientPay.BusinessObjects.Abstractions
{
    public interface ITrackData
    {
        int CreatedBy { get; set; }
        int? ModifiedBy { get; set; }
    }
}
