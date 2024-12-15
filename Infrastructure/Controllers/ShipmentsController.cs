using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain.Models;

namespace Infrastructure.Controllers
{
    [ApiController]
    [Route("api/shipments")]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;
        private readonly ILogger<ShipmentsController> _logger;

        public ShipmentsController(IShipmentService shipmentService, ILogger<ShipmentsController> logger)
        {
            _shipmentService = shipmentService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllShipments()
        {
            _logger.LogInformation("All shipments retrieved successfully");
            return Ok(_shipmentService.GetAllShipments());
        }

        [HttpGet("{id}")]
        public IActionResult GetShipmentById(Guid id)
        {
            var targetShipment = _shipmentService.GetShipmentById(id);

            if (targetShipment == null)
            {
                _logger.LogWarning("Requested shipment {ShipmentId} not found", id);
                return NotFound();
            }

            _logger.LogInformation("Shipment {ShipmentId} retrieved successfully", id);
            return Ok(targetShipment);
        }

        [HttpPost]
        public IActionResult AddShipment([FromBody] Shipment shipment)
        {
            _shipmentService.AddShipment(shipment);
            return CreatedAtAction(nameof(GetShipmentById), new { id = shipment.Id }, shipment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShipment(Guid id, [FromBody] Shipment shipment)
        {
            if (id != shipment.Id)
            {
                _logger.LogError("Shipment ID mismatch. Expected {ExpectedId}, got {ReceivedId}", id, shipment.Id);
                return BadRequest();
            }

            _shipmentService.UpdateShipment(shipment);
            _logger.LogInformation("Shipment {ShipmentId} updated successfully", id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShipment(Guid id)
        {
            var shipment = _shipmentService.GetShipmentById(id);

            if (shipment == null)
            {
                _logger.LogWarning("Failed to delete shipment. Shipment {ShipmentId} not found", id);
                return NotFound();
            }

            _shipmentService.DeleteShipment(id);
            _logger.LogInformation("Shipment {ShipmentId} deleted successfully", id);
            return NoContent();
        }
    }
}
