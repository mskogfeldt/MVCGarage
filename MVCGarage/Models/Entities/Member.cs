using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.Entities
{
    [Index(nameof(PersonalIdentityNumber), IsUnique = true)]
    public class Member
    {        
        public int Id { get; set; }
        [Required]
        public DateTime ProMembershipToDate { get; set; }
        [Required] 
        [StringLength(13)]
        //TODO make similar uniquecheck? [Remote(action: "CheckIfRegIsUnique", controller: "Vehicles")]
        public string? PersonalIdentityNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
        public bool HasReceived2YearsProMembership { get; set; }
        public List<Vehicle> Vehicles { get; set; } = null!;
    }
}
