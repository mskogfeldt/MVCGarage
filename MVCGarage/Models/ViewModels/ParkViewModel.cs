using Microsoft.EntityFrameworkCore;
using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels
{
    [Index(nameof(RegistrationNumber), IsUnique = true)]
    public class ParkViewModel
    {
        public int Id { get; set; }
        [Required]
        public Color Color { get; set; }
        [Required]
        public VehicleType Type { get; set; }
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
        [Display(Name = "Wheel Count")]
        public int WheelCount { get; set; }
        public string? Error { get; set; }
        public int Price { get; set; }

    }
}
