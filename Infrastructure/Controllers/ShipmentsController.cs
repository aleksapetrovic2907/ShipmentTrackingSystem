﻿using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Retrieves all shipments from the system.
        /// </summary>
        /// <returns>A list of all available shipments.</returns>
        [HttpGet]
        public IActionResult GetAllShipments()
        {
            _logger.LogInformation("All shipments retrieved successfully");
            return Ok(_shipmentService.GetAllShipments());
        }

        /// <summary>
        /// Retrieves a specific shipment by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the shipment.</param>
        /// <returns>The requested shipment if found</returns>
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

        /// <summary>
        /// Adds a new shipment to the system.
        /// </summary>
        /// <param name="shipment">The shipment details to be added.</param>
        /// <returns>The created shipment with its assigned ID.</returns>
        [HttpPost]
        public IActionResult AddShipment([FromBody] Shipment shipment)
        {
            _shipmentService.AddShipment(shipment);
            return CreatedAtAction(nameof(GetShipmentById), new { id = shipment.Id }, shipment);
        }

        /// <summary>
        /// Updates an existing shipment.
        /// </summary>
        /// <param name="id">The unique ID of the shipment to update.</param>
        /// <param name="shipment">The updated shipment details.</param>
        /// <response code="204">Shipment updated successfully.</response>
        /// <response code="400">The shipment ID in the request does not match the ID in the payload.</response>
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

        /// <summary>
        /// Deletes a shipment by its unique ID.
        /// </summary>
        /// <param name="id">The unique ID of the shipment to delete.</param>
        /// <response code="204">Shipment deleted successfully.</response>
        /// <response code="404">Shipment not found.</response>
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
