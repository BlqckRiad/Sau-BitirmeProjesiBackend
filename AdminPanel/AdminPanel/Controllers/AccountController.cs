using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AdminPanel.Services;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("authData") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                var response = await _authService.LoginAsync(email, password);
                var jsonResponse = System.Text.Json.JsonSerializer.Serialize(response);
                HttpContext.Session.SetString("authData", jsonResponse);

                // JavaScript kodu ile localStorage'a veri ekle
                TempData["AuthScript"] = $@"
                    <script>
                        localStorage.setItem('authData', '{jsonResponse.Replace("'", "\\'")}');
                        window.location.href = '/Home/Index';
                    </script>
                ";

                return Content(TempData["AuthScript"].ToString(), "text/html");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = "Invalid email or password";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["LogoutScript"] = @"
                <script>
                    localStorage.removeItem('authData');
                    window.location.href = '/Account/Login';
                </script>
            ";
            return Content(TempData["LogoutScript"].ToString(), "text/html");
        }
    }
} 