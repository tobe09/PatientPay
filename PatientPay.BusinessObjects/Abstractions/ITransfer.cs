using PatientPay.BusinessObjects.General;
using System.Collections.Generic;

namespace PatientPay.BusinessObjects.Abstractions
{
    public interface ITransfer
    {
        List<ErrorContainer> ErrorMessages { get; set; }            //to denote error(s) in object properties
    }
}
