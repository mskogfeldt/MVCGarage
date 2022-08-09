namespace MVCGarage.Models.Entities
{
    public class VehicleAssignment
    {
        public int Id { get; set; }
        // Payload
        public DateTime ArrivalDate { get; set; }

        //Foreign key
        public int PSpotId { get; set; }
        
        //Foreign key
        public int VehicleId { get; set; }
        
        //Nav props
        public Vehicle Vehicle { get; set; } = null!;
        public PSpot PSpot { get; set; } = null!;
    }
}
