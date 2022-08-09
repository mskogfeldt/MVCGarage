using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.Entities
{
    [Index(nameof(RegistrationNumber), IsUnique = true)]
    public class Vehicle
    {        
        public int Id { get; set; }
        [Required]
        public Color Color { get; set; }
       
        [Required] 
        [StringLength(40)]
        [Remote(action: "CheckIfRegIsUnique", controller: "Vehicles")]
        public string? RegistrationNumber { get; set; }
        [Required]
        [StringLength(40)]
        public string? Brand { get; set; }
        [Required]
        [StringLength(40)]
        public string? Model { get; set; }
        [Range(0, int.MaxValue)]
        public int WheelCount { get; set; }

        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; } = null!;
        
        public int MemberId { get; set; }
        public List<PSpot> PSpots { get; set; } = null!;
    }
}
