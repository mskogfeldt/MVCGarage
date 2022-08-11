using MVCGarage.Models.ViewModels.Members;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Validations
{
    public class ValidateFirstName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string input)
            {
                var viewModel = validationContext.ObjectInstance as RegisterViewModel;
                if (viewModel is not null)
                {
                    if (viewModel.LastName != input)
                    {
                        return ValidationResult.Success;
                    }
                }
                else
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}
