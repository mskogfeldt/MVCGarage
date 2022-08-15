using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels
{
    [Index(nameof(RegistrationNumber), IsUnique = true)]
    public class ChangeViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Color Color { get; set; }
        [Required]
        [StringLength(40)]
        [Display(Name = "Registration Number")]
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
        public bool ModifySuccess { get; set; } = false;
        public string? Error { get; set; }

        [Display(Name = "Type of Vehicle")]
        public string VehicleTypeName { get; set; } = string.Empty;
        [Display(Name = "First Name")]
        public string OwnerFirstName { get; set; } = string.Empty;
        [Display(Name = "Last Name")]
        public string OwnerLastName { get; set; } = string.Empty;
    }
}
