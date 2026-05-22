using BlazorApp20.Models;

namespace BlazorApp20.Services
{
    // ✅ Primary constructor
    public class AuthService(SupabaseService supabaseService)
    {
        public event Action? OnChange;
        private void Notify() => OnChange?.Invoke();

        public UserModel? CurrentUser { get; private set; }
        public bool IsLoggedIn => CurrentUser != null;

        public async Task<bool> Login(string email, string password)
        {
            var session = await supabaseService.Login(email, password);
            if (session != null)
            {
                CurrentUser = new UserModel { Username = email };
                Notify();
                return true;
            }
            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
            Notify();
        }
    }
}
















