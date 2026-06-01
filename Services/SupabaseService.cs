using Supabase;
using Supabase.Gotrue;

namespace BlazorApp20.Services
{
    public class SupabaseService()
    {
        private Supabase.Client? _client;
        private const string SupabaseUrl = "https://uaijvcuebosrvpqhefum.supabase.co";
        private const string SupabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InVhaWp2Y3VlYm9zcnZwcWhlZnVtIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NzkyNTA3NTksImV4cCI6MjA5NDgyNjc1OX0.9zY1ZO63W25Hz0ewPR-qJyap0m14gl6gcFGJpKGUzBU";

        public string FavoriteCity { get; set; } = string.Empty;
        public string FavoriteWeather { get; set; } = string.Empty;

        // ✅ Store session token in memory across navigations
        private string? _savedAccessToken;
        private string? _savedRefreshToken;

        public async Task Initialize()
        {
            if (_client == null)
            {
                var options = new SupabaseOptions { AutoConnectRealtime = false };
                _client = new Supabase.Client(SupabaseUrl, SupabaseKey, options);
                await _client.InitializeAsync();
            }

            // ✅ Restore session if we have saved tokens but no current session
            if (_client.Auth.CurrentSession == null
                && _savedAccessToken != null
                && _savedRefreshToken != null)
            {
                try
                {
                    await _client.Auth.SetSession(_savedAccessToken, _savedRefreshToken);
                }
                catch
                {
                    _savedAccessToken = null;
                    _savedRefreshToken = null;
                }
            }
        }

        public async Task<Session?> Login(string email, string password)
        {
            await Initialize();
            var response = await _client!.Auth.SignInWithPassword(email, password);

            // ✅ Save tokens so session survives page reload
            if (response?.AccessToken != null)
            {
                _savedAccessToken = response.AccessToken;
                _savedRefreshToken = response.RefreshToken;
            }

            return response;
        }

        public async Task<bool> SignUp(string email, string password)
        {
            await Initialize();
            try
            {
                var session = await _client!.Auth.SignUp(email, password);
                return session?.User != null;
            }
            catch
            {
                return false;
            }
        }

        public async Task Logout()
        {
            if (_client == null) return;
            await _client.Auth.SignOut();
            FavoriteCity = string.Empty;
            FavoriteWeather = string.Empty;
            // ✅ Clear saved tokens on logout
            _savedAccessToken = null;
            _savedRefreshToken = null;
            _client = null;
        }

        public User? GetUser() => _client?.Auth.CurrentUser;
        public bool IsLoggedIn() => _client?.Auth.CurrentSession != null;
    }
}
