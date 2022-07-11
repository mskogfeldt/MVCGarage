using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<IndexParkedVehicleViewModel>? VehicleList { get; set; }
        [MaxLength(50)]
        public string? RegistrationNumber { get; set; }
    }
}
