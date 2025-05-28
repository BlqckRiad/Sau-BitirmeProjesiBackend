using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using AdminPanel.Models;

namespace AdminPanel.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://bitirmeuser.enesozbuganli.com";

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public IActionResult Index()
        {
            return View();
        }

        #region APIMODEL
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/User/GetAllUsers");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var users = JsonSerializer.Deserialize<List<LoginResponse>>(content);

                    // DataTables için uygun formatta veri döndür
                    return Json(new
                    {
                        data = users,
                        recordsTotal = users.Count,
                        recordsFiltered = users.Count
                    });
                }
                return StatusCode((int)response.StatusCode);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/Role/GetAllRoles");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var roles = JsonSerializer.Deserialize<List<RoleResponse>>(content);
                    return Json(roles);
                }
                return StatusCode((int)response.StatusCode);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUserRole([FromBody] ChangeRoleRequest request)
        {
            try
            {
                var authData = HttpContext.Session.GetString("authData");
                if (string.IsNullOrEmpty(authData))
                {
                    return Unauthorized();
                }

                var currentUser = JsonSerializer.Deserialize<LoginResponse>(authData);
                request.updatedUserID = currentUser.userID;

                var response = await _httpClient.PostAsJsonAsync("/api/UserUpdate/ChangeUserRoleID", request);
                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                return StatusCode((int)response.StatusCode);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        #endregion
    }
}