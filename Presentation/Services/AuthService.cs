using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Presentation.Services
{
    public class AuthService
    {
        /// <summary>
        /// Gets the current authentication state.
        /// </summary>
        public bool IsAuthenticated { get; private set; } = false;

        /// <summary>
        /// Event triggered when the authentication state changes.
        /// </summary>
        public event Action? OnAuthStateChanged;

        private readonly HttpClient _httpClient;
        private string? _jwtToken;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Logs the user in by sending a request to the backend.
        /// </summary>
        public async Task LogInAsync()
        {
            var response = await _httpClient.PostAsync("api/auth/login", null);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<AuthResponse>();
                _jwtToken = result?.Token;

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _jwtToken);

                IsAuthenticated = true;
                OnAuthStateChanged?.Invoke();
            }
        }

        /// <summary>
        /// Logs the user out by clearing the JWT token.
        /// </summary>
        public async Task LogOutAsync()
        {
            var response = await _httpClient.PostAsync("api/auth/logout", null);

            if (response.IsSuccessStatusCode)
            {
                _jwtToken = null;
                _httpClient.DefaultRequestHeaders.Authorization = null;

                IsAuthenticated = false;
                OnAuthStateChanged?.Invoke();
            }
        }

        private class AuthResponse
        {
            public string? Token { get; set; }
        }
    }
}
