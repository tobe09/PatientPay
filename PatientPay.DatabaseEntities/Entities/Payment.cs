using PatientPay.DatabaseEntities.Abstractions;
using System;

namespace PatientPay.DatabaseEntities.Entities
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
