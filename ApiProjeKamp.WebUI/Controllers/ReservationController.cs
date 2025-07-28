using ApiProjeKamp.WebUI.Dtos.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ReservationList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44349/api/Reservations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateReservation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMesasge = await client.PostAsync("https://localhost:44349/api/Reservations", stringContent);
            if (responseMesasge.IsSuccessStatusCode)
            {
                return RedirectToAction("ReservationList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"https://localhost:44349/api/Reservations/{id}");
            return RedirectToAction("ReservationList");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44349/api/Reservations/GetReservation/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateReservationDto>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation(UpdateReservationDto updateReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateReservationDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44349/api/Reservations", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ReservationList");
            }
            return View();
        }
    }
}
