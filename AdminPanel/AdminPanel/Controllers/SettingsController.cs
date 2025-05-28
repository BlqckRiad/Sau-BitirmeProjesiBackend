using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using AdminPanel.Models;

namespace AdminPanel.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SettingsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request?.NewEmail))
                {
                    return Json(new { success = false, message = "E-posta adresi boş olamaz." });
                }
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync("https://bitirmeuser.enesozbuganli.com/api/UserUpdate/UserEmailUpdate", content);

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "E-posta başarıyla güncellendi." });
                }
                else
                {
                    return Json(new { success = false, message = "E-posta güncellenirken bir hata oluştu." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangePhone([FromBody] ChangePhoneRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request?.NewTelNo))
                {
                    return Json(new { success = false, message = "Telefon alanı boş olamaz." });
                }
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync("https://bitirmeuser.enesozbuganli.com/api/UserUpdate/UserTelNoUpdate", content);

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "Tel No başarıyla güncellendi." });
                }
                else
                {
                    return Json(new { success = false, message = "Tel No  güncellenirken bir hata oluştu." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserData([FromBody] ChangeUserDataRequest request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(
                    JsonSerializer.Serialize(request),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync("https://bitirmeuser.enesozbuganli.com/api/UserUpdate/UserUpdate", content);

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "User Data başarıyla güncellendi." });
                }
                else
                {
                    return Json(new { success = false, message = "User Data  güncellenirken bir hata oluştu." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserImage(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return Json(new { success = false, message = "Dosya yüklenemedi." });
                }

                var client = _httpClientFactory.CreateClient();

                // FormData oluştur
                var formData = new MultipartFormDataContent();
                var fileContent = new StreamContent(file.OpenReadStream());
                formData.Add(fileContent, "file", file.FileName);

                // Resmi yükle
                var imageResponse = await client.PostAsync("https://bitirmeiys.enesozbuganli.com/api/Image/AddImage", formData);
                
                if (!imageResponse.IsSuccessStatusCode)
                {
                    return Json(new { success = false, message = "Resim yüklenirken bir hata oluştu." });
                }

                var imageData = await imageResponse.Content.ReadFromJsonAsync<ImageResponse>();

                // Kullanıcı bilgilerini al
                var authData = HttpContext.Session.GetString("authData");
                if (string.IsNullOrEmpty(authData))
                {
                    return Json(new { success = false, message = "Kullanıcı bilgileri bulunamadı." });
                }

                var currentUser = JsonSerializer.Deserialize<LoginResponse>(authData);

                // Kullanıcı resmini güncelle
                var updateRequest = new UpdateUserImageRequest
                {
                    userID = currentUser.userID,
                    newImageID = imageData.imageID,
                    newImageUrl = imageData.imageUrl,
                    updatedUserID = currentUser.userID
                };

                var updateContent = new StringContent(
                    JsonSerializer.Serialize(updateRequest),
                    Encoding.UTF8,
                    "application/json"
                );

                var updateResponse = await client.PostAsync("https://bitirmeuser.enesozbuganli.com/api/UserUpdate/UserImageUpdate", updateContent);

                if (updateResponse.IsSuccessStatusCode)
                {
                    return Json(new { 
                        success = true, 
                        message = "Profil resmi başarıyla güncellendi.",
                        imageUrl = imageData.imageUrl,
                        imageID = imageData.imageID
                    });
                }
                else
                {
                    return Json(new { success = false, message = "Profil resmi güncellenirken bir hata oluştu." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }
    }
}
