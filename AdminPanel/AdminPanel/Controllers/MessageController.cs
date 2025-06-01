using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdminPanel.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public MessageController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://bitirmeiys.enesozbuganli.com/api/Contact/GetAllContacts");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var messages = JsonSerializer.Deserialize<List<MessageModel>>(content);
                return View(messages);
            }

            return View(new List<MessageModel>());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessageStatus(int contactId)
        {
            var client = _httpClientFactory.CreateClient();
            var dto = new { ItemID = contactId };
            var content = new StringContent(JsonSerializer.Serialize(dto), System.Text.Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync("https://bitirmeiys.enesozbuganli.com/api/Contact/CheckContact", content);
            
            if (response.IsSuccessStatusCode)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }

    public class MessageModel
    {
        public int contactID { get; set; }
        public string contactUserEmail { get; set; }
        public string contactUserName { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public bool isChecked { get; set; }
        public DateTime createdDate { get; set; }
    }
} 