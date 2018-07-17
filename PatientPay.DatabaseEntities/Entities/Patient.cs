using PatientPay.BusinessObjects.BusinessRules;
using PatientPay.DatabaseEntities.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientPay.DatabaseEntities.Entities
{
    public class Patient : IEntity
    {
        public Patient()
        {
            Payments = new List<Payment>();
        }

        public int Id { get; set; }
        public string PatientGivenId { get; set; }
        [CustomValidation(typeof(PropertyValidator), nameof(PropertyValidator.ValidateUsername))]  //redundant, already applied at business logic level
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

        //public virtual Administrator CreatingAdmin { get; set; }    //would use normally, cant use due to experimentation (it is internal)
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
