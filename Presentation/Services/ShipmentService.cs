using System.Net.Http.Json;
using Domain.Models;

namespace Presentation.Services
{
    /// <summary>
    /// Service for managing shipments through the backend API.
    /// </summary>
    public class ShipmentService
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentService"/> class.
        /// </summary>
        /// <param name="httpClient">The HttpClient used for API requests.</param>
        public ShipmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves a list of all shipments from the backend API.
        /// </summary>
        /// <returns>A list of shipments.</returns>
        public async Task<List<Shipment>> GetAllShipmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Shipment>>("shipments")
                   ?? new List<Shipment>();
        }

        /// <summary>
        /// Retrieves a specific shipment by its ID.
        /// </summary>
        /// <param name="id">The ID of the shipment to retrieve.</param>
        /// <returns>The shipment if found, otherwise null.</returns>
        public async Task<Shipment?> GetShipmentByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Shipment>($"shipments/{id}");
        }

        /// <summary>
        /// Adds a new shipment to the backend API.
        /// </summary>
        /// <param name="shipment">The shipment to add.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public async Task<bool> AddShipmentAsync(Shipment shipment)
        {
            var response = await _httpClient.PostAsJsonAsync("shipments", shipment);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Updates an existing shipment in the backend API.
        /// </summary>
        /// <param name="shipment">The updated shipment data.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public async Task<bool> UpdateShipmentAsync(Shipment shipment)
        {
            var response = await _httpClient.PutAsJsonAsync($"shipments/{shipment.Id}", shipment);
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Deletes a shipment by its ID.
        /// </summary>
        /// <param name="id">The ID of the shipment to delete.</param>
        /// <returns>True if the deletion was successful, otherwise false.</returns>
        public async Task<bool> DeleteShipmentAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"shipments/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
