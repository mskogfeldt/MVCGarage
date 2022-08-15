using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels.Members
{
    public class ListViewModel
    {
        public IEnumerable<IndexMemberViewModel> MemberList { get; set; } = new List<IndexMemberViewModel>();
        [Display(Name = "Personal Identity Number")]
        public string? SearchPersonalIdentityNumber { get; set; }
        [Display(Name = "Name")]
        public string? SearchName { get; set; }
        public bool HasExpandedSearchItem { get; set; } = false;
    }
}
