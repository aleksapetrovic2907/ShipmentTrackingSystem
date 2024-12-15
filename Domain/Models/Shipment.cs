using Domain.Enums;

namespace Domain.Model
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public string Naziv { get; set; }
        public ShipmentStatus Status { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime? DatumIsporuke { get; set; }
    }
}
