﻿using Domain.Models;

namespace Application.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly List<Shipment> _shipments = new();

        public IEnumerable<Shipment> GetAllShipments() => _shipments;

        public Shipment GetShipmentById(Guid id) => _shipments.FirstOrDefault(s => s.Id == id);

        public void AddShipment(Shipment shipment)
        {
            shipment.Id = Guid.NewGuid();
            shipment.CreatedAt = DateTime.UtcNow;
            _shipments.Add(shipment);
        }

        public void UpdateShipment(Shipment shipment)
        {
            var targetShipment = GetShipmentById(shipment.Id);

            if (targetShipment != null)
            {
                targetShipment.Name = shipment.Name;
                targetShipment.Status = shipment.Status;
                targetShipment.DeliveredAt = shipment.DeliveredAt;
            }
        }

        public void DeleteShipment(Guid id) => _shipments.RemoveAll(s => s.Id == id);
    }
}
