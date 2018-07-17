using PatientPay.BusinessObjects.Abstractions;
using PatientPay.BusinessObjects.Enumeration;
using System.Collections.Generic;

namespace PatientPay.BusinessObjects.General
{
    public class BasicInfo : IInfo
    {
        public List<ErrorContainer> ErrorMessages { get; set; } = new List<ErrorContainer>();

        public StatusCode StatusCode { get; set; } = StatusCode.Success;       //default

        public string SuccessMessage { get; set; }

        public bool HasError()
        {
            return StatusCode != StatusCode.Success || ErrorMessages.Count > 0;
        }
    }
}
