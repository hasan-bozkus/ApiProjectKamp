using ApiProjeKamp.WebUI.Dtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {

            var client = new HttpClient();
            var apiKey = "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";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            try
            {
                var translateRequestBody = new
                {
                    inputs = createMessageDto.MessageDetails,
                };
                var translateJson = JsonConvert.SerializeObject(translateRequestBody);
                var translateContent = new StringContent(translateJson, Encoding.UTF8, "application/json");

                var translateResponse = await client.PostAsync("https://api-inference.huggingface.co/models/Helsinki-NLP/opus-mt-tr-en", translateContent);
                var translateResponseString = await translateResponse.Content.ReadAsStringAsync();

                string englisText = createMessageDto.MessageDetails;
                if (translateResponseString.TrimStart().StartsWith("["))
                {
                    var translateDoc = JsonDocument.Parse(translateResponseString);
                    englisText = translateDoc.RootElement[0].GetProperty("translation_text").GetString();
                    ViewBag.EnglisText = englisText;
                }

                var toxicRequestBody = new
                {
                    inputs = englisText
                };

                var toxicJson = JsonConvert.SerializeObject(toxicRequestBody);
                var toxicContent = new StringContent(toxicJson, Encoding.UTF8, "application/json");
                var toxicResponse = await client.PostAsync("https://api-inference.huggingface.co/models/unitary/toxic-bert", toxicContent);
                var toxicResponseString = await toxicResponse.Content.ReadAsStringAsync();

                if (toxicResponseString.TrimStart().StartsWith("["))
                {
                    var toxicDoc = JsonDocument.Parse(toxicResponseString);
                    foreach(var item in toxicDoc.RootElement[0].EnumerateArray())
                    {
                        string label = item.GetProperty("label").GetString();
                        double score = item.GetProperty("score").GetDouble();

                        if(score > 0.5)
                        {
                            createMessageDto.Status = "Toksik Mesaj";
                        }
                    }
                }
                if(string.IsNullOrEmpty(createMessageDto.Status))
                {
                    createMessageDto.Status = "Mesaj Alındı";
                }
            }
            catch (Exception ex)
            {
                createMessageDto.Status = "Onay Bekliyor";
            }

            createMessageDto.SendDate = DateTime.Now;
            createMessageDto.IsRead = false;

            var client2 = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMesasge = await client2.PostAsync("https://localhost:44349/api/Messages", stringContent);
            if (responseMesasge.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
