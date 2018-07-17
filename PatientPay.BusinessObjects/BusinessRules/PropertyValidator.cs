using System.ComponentModel.DataAnnotations;

namespace PatientPay.BusinessObjects.BusinessRules
{
    public class PropertyValidator
    {
        public static string ErrorMessage { get; private set; }
        public static string Affectedproperty { get; private set; }

        private static ValidationResult ErrorResult()
        {
            return new ValidationResult(ErrorMessage, new[] { Affectedproperty });
        }

        private static ValidationResult SuccessResult()
        {
            return ValidationResult.Success;
        }

        public static ValidationResult ValidateUsername(string username)
        {
            if (username == null || username.Trim().Length < 3)
            {
                ErrorMessage = "Username should contain 3 or more characters.";
                Affectedproperty = "Username";
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidatePassword(string password)
        {
            if (password == null || password.Trim().Length < 8)
            {
                ErrorMessage = "Password should contain 8 or more characters.";
                Affectedproperty = "Password";
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidateName(string name, string nameType)
        {
            if (name == null || name.Trim().Length < 3)
            {
                ErrorMessage = nameType + " should contain 3 or more characters.";
                Affectedproperty = nameType;
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidateEmail(string email)
        {
            if (email == null || email.Trim().Length < 5)
            {
                ErrorMessage = "Email should contain 5 or more characters.";
                Affectedproperty = "Email address";
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidatePhoneNo(long phoneNo, string numType)
        {
            if (phoneNo < 7000000000 || phoneNo > 10000000000)
            {
                ErrorMessage = "Please enter a valid phone number. (e.g 08136831102)";
                Affectedproperty = numType;
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidateAddress(string address)
        {
            if (address == null || address.Trim().Length < 8)
            {
                ErrorMessage = "Please enter a valid address.";
                Affectedproperty = "Address";
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidateAmount(double amount)
        {
            if (amount <= 0)
            {
                ErrorMessage = "Please enter a valid amount.";
                Affectedproperty = "Amount";
                return ErrorResult();
            }
            else if (amount > 100000000)
            {
                ErrorMessage = "Amount is too large.";
                Affectedproperty = "Amount";
                return ErrorResult();
            }

            return SuccessResult();
        }

        public static ValidationResult ValidateString(string value, string valueType)
        {
            if (value == null || value.Trim().Length == 0)
            {
                ErrorMessage = valueType + " is empty.";
                Affectedproperty = valueType;
                return ErrorResult();
            }

            return SuccessResult();
        }
    }
}
