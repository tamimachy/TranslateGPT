using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;
using TranslateGPT.DTOs;
using TranslateGPT.Models;

namespace TranslateGPT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly List<string> mostUsedLanguages = new List<string> {
            "English", "Spanish", "French", "German", "Chinese", "Japanese", "Russian", "Portuguese", "Arabic", "Hindi", "Tamil","Turkish", "Urdu", "Italian","Korean", "Bangla"
        };
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, HttpClient httpClient)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            ViewBag.Languages = mostUsedLanguages;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> OpenAIGPT(string query, string selectedLanguage)
        {
            var openAIKey = _configuration["OpenAI:ApiKey"];

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", openAIKey);

            //Define the request payload
            var payload = new
            {
                model = "gpt-4o-mini",
                messages = new object[]
                {
                    new { role = "system", content = $"Translate to {selectedLanguage}" },
                    new { role = "user", content = query }
                },
                temperature = 0,
                max_tokens = 256,
            };
            string jsonPayload = JsonConvert.SerializeObject(payload);
            HttpContent httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            
            //Send request to OpenAI API
            var responseMessage = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", httpContent);
            var responseMessageJson = await responseMessage.Content.ReadAsStringAsync();
            
            // Return a response to the client
            var response = JsonConvert.DeserializeObject<OpenAIResponse>(responseMessageJson);
            ViewBag.Result = responseMessageJson;
            // ViewBag.Result = response.Choices[0].Message.Content;
            ViewBag.Languages = mostUsedLanguages;

            return View("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
