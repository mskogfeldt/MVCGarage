namespace MVCGarage.Models.ViewModels
{

    public class IndexViewModel
    {
        public IEnumerable<ParkedVehicleViewModel> ParkedVehicles { get; set; } = new List<ParkedVehicleViewModel>();
    }
}
