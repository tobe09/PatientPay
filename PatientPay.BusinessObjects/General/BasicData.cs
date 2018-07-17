using PatientPay.BusinessObjects.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientPay.BusinessObjects.General
{
    public class BasicData : IData
    {
        public List<ErrorContainer> ErrorMessages { get; set; } = new List<ErrorContainer>();

        public virtual bool IsValid()
        {
            return ErrorMessages.Count == 0;
        }

        public void Validate<T>(Func<T, ValidationResult> validateMethod, T valueToValidate)
        {
            var validationResult = validateMethod(valueToValidate);
            AddErrorMessage(validationResult);
        }

        public void Validate<T, TExtra>(Func<T, TExtra, ValidationResult> validateMethod, T valueToValidate, TExtra extraValues)
        {
            var validationResult = validateMethod(valueToValidate, extraValues);
            AddErrorMessage(validationResult);
        }

        private void AddErrorMessage(ValidationResult validationResult)
        {
            if (validationResult != ValidationResult.Success)
            {
                string propertyName = null;
                var enumerator = validationResult.MemberNames.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    propertyName = enumerator.Current;
                }
                ErrorMessages.Add(new ErrorContainer { ErrorMessage = validationResult.ErrorMessage, PropertyName = propertyName });
            }
        }
    }
}
