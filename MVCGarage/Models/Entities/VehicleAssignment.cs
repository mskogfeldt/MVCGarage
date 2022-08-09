namespace MVCGarage.Models.Entities
{
    public class VehicleAssignment
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int PSpotId { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
