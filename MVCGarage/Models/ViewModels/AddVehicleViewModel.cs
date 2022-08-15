using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels
{
    [Index(nameof(RegistrationNumber), IsUnique = true)]
    public class AddVehicleViewModel
    {
        public int Id { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public Color Color { get; set; }

        [Required]
        [Display(Name = "Type of Vehicle")]
        public int VehicleTypeId { get; set; }

        [RequiredIfVehicleTypeIdIs0AndStringLength(50)]
        [Display(Name = "Vehicle Type Name")]
        public string? VehicleTypeName { get; set; }
        [Display(Name = "Vehicle Type Needed Size")]
        [Range(0.0, double.MaxValue)]
        public double VehicleTypeNeededSize { get; set; }

        public bool VehicleTypeStartOpen { get; set; }
        public List<VehicleType> VehicleTypes { get; set; } = new List<VehicleType>();

        [Required]
        [StringLength(40)]
        [Display(Name = "Registration Number")]
        [Remote(action: "CheckIfRegIsUnique", controller: "Vehicles")]
        public string? RegistrationNumber { get; set; }

        [Required]
        [StringLength(40)]
        public string? Brand { get; set; }

        [Required]
        [StringLength(40)]
        public string? Model { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Number of Wheels")]
        public int WheelCount { get; set; }

        public bool AddSuccess { get; set; } = false;
    }

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
                if(s.Length > StringLength)
                    return new ValidationResult(GetErrorMessageStringLength());
            }

            return ValidationResult.Success;
        }
    }
}
