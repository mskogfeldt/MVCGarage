using MVCGarage.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace MVCGarage.Models.ViewModels.Members
{
    public class ListViewModel
    {
        public IEnumerable<IndexMemberViewModel> MemberList { get; set; } = new List<IndexMemberViewModel>();
    }
}
