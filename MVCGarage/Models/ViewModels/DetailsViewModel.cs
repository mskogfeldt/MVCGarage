using Microsoft.EntityFrameworkCore;
using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels
{

    [Index(nameof(RegistrationNumber), IsUnique = true)]
    public class DetailsViewModel
    {
        public int Id { get; set; }
        [Required]
        public Color Color { get; set; }
        [Required]
        [Display(Name = "Type of Vehicle")]
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
        [Display(Name = "Number of Wheels")]
        public int WheelCount { get; set; }
        [Required]
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }
        [Display(Name = "Parked Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d\\d\\ hh\\h\\ mm\\m}")]
        public TimeSpan ParkedTime { get; set; }

    }

}
