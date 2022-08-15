using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels.Members
{
    public class IndexMemberViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nr Of Vehicles")]
        public int? NrOfVehicles { get; set; }
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Display(Name = "Birth Date")]
        public string? BirthDate { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
    }
}
