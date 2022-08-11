using MVCGarage.Models.ViewModels.Members;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Validations
{
    public class ValidatePersonalIdentityNumber : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string input)
            {
                if (Personnummer.Personnummer.Valid(input))
                {
                    var age = new Personnummer.Personnummer(input).Age;
                    if (age >= 18)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Members must be at least 18 years old.");
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
