namespace MVCGarage.Models.ViewModels
{

    public class IndexViewModel
    {
        public IEnumerable<IndexParkedVehicleViewModel> ParkedVehicles { get; set; } = new List<IndexParkedVehicleViewModel>();
    }
}
