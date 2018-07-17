using PatientPay.BusinessObjects.Abstractions;

namespace PatientPay.BusinessObjects.RegisterPatient
{
    public interface IPatientData : ITrackData
    {
        int Id { get; set; }
        string Username { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string Email { get; set; }
        long PhoneNo { get; set; }
        long? PhoneNo2 { get; set; }
        string HomeAddress { get; set; }
    }
}
