using ApiProjeKamp.WebUI.Dtos.ChefDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class ChefController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ChefController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ChefList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44349/api/Chefs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultChefDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateChef()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateChef(CreateChefDto createChefDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createChefDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMesasge = await client.PostAsync("https://localhost:44349/api/Chefs", stringContent);
            if (responseMesasge.IsSuccessStatusCode)
            {
                return RedirectToAction("ChefList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteChef(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:44349/api/Chefs/{id}");
            return RedirectToAction("ChefList");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateChef(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44349/api/Chefs/GetChef/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateChefDto>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateChef(UpdateChefDto updateChefDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateChefDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44349/api/Chefs", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ChefList");
            }
            return View();
        }
    }
}
