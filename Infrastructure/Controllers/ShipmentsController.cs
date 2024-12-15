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

        public ShipmentsController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet]
        public IActionResult GetAllShipments() => Ok(_shipmentService.GetAllShipments());

        [HttpGet("{id}")]
        public IActionResult GetShipmentById(Guid id)
        {
            var targetShipment = _shipmentService.GetShipmentById(id);
            return targetShipment == null ? NotFound() : Ok(targetShipment);
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
            if (id != shipment.Id) return BadRequest();

            _shipmentService.UpdateShipment(shipment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShipment(Guid id)
        {
            _shipmentService.DeleteShipment(id);
            return NoContent();
        }
    }
}
