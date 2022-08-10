using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels.Members
{
    [Index(nameof(PersonalIdentityNumber), IsUnique = true)]
    public class RegisterViewModel
	{
        public int Id { get; set; }
        [Required]
        [StringLength(13)]
		[Display(Name = "Personal Identity Number")]
        [Remote(action: "CheckIfPINIsUnique", controller: "Members")]
        public string? PersonalIdentityNumber { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        public bool RegisterSuccess { get; set; } = false;

		//public string? Error { get; set; }
	}
}
