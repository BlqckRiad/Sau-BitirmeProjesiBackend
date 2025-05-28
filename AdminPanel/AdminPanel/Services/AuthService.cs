using System.Text.Json;
using AdminPanel.Models;
using Microsoft.AspNetCore.Http;

namespace AdminPanel.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string BaseUrl = "https://bitirmeuser.enesozbuganli.com";

        public AuthService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<LoginResponse> LoginAsync(string emailOrTelNo, string password)
        {
            var loginData = new { emailOrTelNo, password };
            var response = await _httpClient.PostAsJsonAsync("/api/Login/AdminLogin", loginData);
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonSerializer.Deserialize<LoginResponse>(content);
                
                // Session'a kaydet
                _httpContextAccessor.HttpContext.Session.SetString("authData", content);
                
                return loginResponse;
            }
            
            throw new Exception("Login failed");
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.Session.GetString("authData") != null;
        }

        public LoginResponse GetCurrentUser()
        {
            var authData = _httpContextAccessor.HttpContext?.Session.GetString("authData");
            if (!string.IsNullOrEmpty(authData))
            {
                return JsonSerializer.Deserialize<LoginResponse>(authData);
            }
            return null;
        }
    }
} 