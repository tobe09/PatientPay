using PatientPay.DatabaseEntities.Abstractions;
using System;

namespace PatientPay.DataAccessLayer.Context
{
    class Administrator: IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public long PhoneNo { get; set; }
        public long? PhoneNo2 { get; set; }
        public string HomeAddress { get; set; }
        public string CreatedBy { get; set; } = "SuperUser";
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
