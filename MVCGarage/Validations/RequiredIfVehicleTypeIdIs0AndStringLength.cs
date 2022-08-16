using MVCGarage.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Validations
{
    public class RequiredIfVehicleTypeIdIs0AndStringLength : ValidationAttribute
    {
        public RequiredIfVehicleTypeIdIs0AndStringLength(int stringLength) => StringLength = stringLength;

        public int StringLength { get; }

        public string GetErrorMessageRequired() =>
            $"A Vehicle Type Name is needed when creating a new Vehicle Type.";

        public string GetErrorMessageStringLength() =>
            $"Vehicle Type Name should not exceed {StringLength} characters.";

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            var AddVehicleViewModel = (AddVehicleViewModel)validationContext.ObjectInstance;

            if (AddVehicleViewModel.VehicleTypeId == 0 && string.IsNullOrEmpty(value as string))
            {
                return new ValidationResult(GetErrorMessageRequired());
            }
            else if (AddVehicleViewModel.VehicleTypeId == 0)
            {
                string s = (string)value!;
                if (s.Length > StringLength)
                    return new ValidationResult(GetErrorMessageStringLength());
            }

            return ValidationResult.Success;
        }
    }
}
