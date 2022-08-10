using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels.Members
{
    public class MemberVehicleModel
    {
        public int Id { get; set; }
        [Display(Name = "Registration Number")]
        public string? RegistrationNumber { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
    }
}
