using ApiProjeKamp.WebUI.Dtos.YummyEventDtos;
using ApiProjeKamp.WebUI.Dtos.YummyEventDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class YummyEventController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public YummyEventController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> YummyEventList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44349/api/YummyEvents");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultYummyEventDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateYummyEvent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateYummyEvent(CreateYummyEventDto createYummyEventDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createYummyEventDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMesasge = await client.PostAsync("https://localhost:44349/api/YummyEvents", stringContent);
            if (responseMesasge.IsSuccessStatusCode)
            {
                return RedirectToAction("YummyEventList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteYummyEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:44349/api/YummyEvents/{id}");
            return RedirectToAction("YummyEventList");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateYummyEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44349/api/YummyEvents/GetYummyEvent/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateYummyEventDto>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateYummyEvent(UpdateYummyEventDto updateYummyEventDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateYummyEventDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44349/api/YummyEvents", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("YummyEventList");
            }
            return View();
        }
    }
}
