using Domain.Enums;

namespace Domain.Models
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ShipmentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
    }
}
