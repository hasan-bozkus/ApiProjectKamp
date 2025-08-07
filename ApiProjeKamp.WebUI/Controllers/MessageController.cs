using ApiProjeKamp.WebUI.Dtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static ApiProjeKamp.WebUI.Controllers.AIController;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MessageList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44349/api/Messages");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.SendDate = DateTime.Now;
            createMessageDto.IsRead = false;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMesasge = await client.PostAsync("https://localhost:44349/api/Messages", stringContent);
            if (responseMesasge.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:44349/api/Messages/{id}");
            return RedirectToAction("MessageList");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44349/api/Messages/GetMessage/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateMessageDto>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMessageDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44349/api/Messages", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("MessageList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AnswerMessageWitpOpenAI(int id, string prompt)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44349/api/Messages/GetMessage/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
            prompt = value.MessageDetails;

            //ahahtar ezildi
            var apiKey = "";
            using var clientMessage = new HttpClient();
            clientMessage.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "Sen bir restoran için kullanıcıların göndermiş oldukları mesajları detaylı ve olabildiğince olumlu, müşteri memnuniyeti gözeten cevaplar veren bir yapay zeka aracısın. Amacımız kullanıcı tarafından gönderilen mesajlara en olumlu ve mantıklı cevapları sunabilmek" },
                    new { role = "user", content = prompt }
                },
                temperature = 0.5
            };

            var response = await clientMessage.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                var content = result.choices[0].message.content;
                ViewBag.answerAI = content;
            }
            else
            {
                ViewBag.answerAI = "Bir hata oluştu: " + response.StatusCode;
            }
            return View(value);
        }
    }
}
