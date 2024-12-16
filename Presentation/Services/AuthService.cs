namespace Presentation.Services
{
    /// <summary>
    /// Service for managing user authentication state.
    /// </summary>
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

        /// <summary>
        /// Logs the user in by setting the authentication flag to true.
        /// </summary>
        public void LogIn()
        {
            IsAuthenticated = true;
            OnAuthStateChanged?.Invoke();
        }

        /// <summary>
        /// Logs the user out by setting the authentication flag to false.
        /// </summary>
        public void LogOut()
        {
            IsAuthenticated = false;
            OnAuthStateChanged?.Invoke();
        }
    }
}
