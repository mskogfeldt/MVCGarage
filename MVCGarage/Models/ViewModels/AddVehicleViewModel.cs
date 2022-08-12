using Microsoft.AspNetCore.Mvc;
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
}
