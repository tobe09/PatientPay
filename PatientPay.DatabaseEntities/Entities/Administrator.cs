using PatientPay.BusinessObjects.BusinessRules;
using PatientPay.DatabaseEntities.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace PatientPay.DatabaseEntities.Entities
{

    //not being used, nevertheless it is preferable to use a seperate project for database entity models
    class Administrator : IEntity
    {
        public int Id { get; set; }
        [CustomValidation(typeof(PropertyValidator), nameof(PropertyValidator.ValidateUsername))]  //not great for ddd
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value == null ? value : value.Trim(); }
        }
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
