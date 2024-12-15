using Domain.Models;

namespace Application.Services
{
    public interface IShipmentService
    {
        IEnumerable<Shipment> GetAllShipments();
        Shipment GetShipmentById(Guid id);
        void AddShipment(Shipment shipment);
        void UpdateShipment(Shipment shipment);
        void DeleteShipment(Guid id);
    }
}
