using ApiProjeKamp.WebUI.Dtos.ChefDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace ApiProjeKamp.WebUI.ViewComponents.DashboardViewComponents
{
    public class _DashboardWidgetsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int r1, r2,r3, r4;
            Random rnd = new Random();
            r1 = rnd.Next(1, 35);
            r2 = rnd.Next(1, 35);
            r3 = rnd.Next(1, 35);
            r4 = rnd.Next(1, 35);

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44349/api/Reservations/GetTotalReservationCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.totalReservationCount = jsonData;
                ViewBag.totalReservationCountr1 = r1;
            }

            var responseMessage2 = await client.GetAsync("https://localhost:44349/api/Reservations/GetTotalCustomerCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.totalCustomerCount = jsonData;
                ViewBag.totalCustomerCountr2 = r2;
            }

            var responseMessage3 = await client.GetAsync("https://localhost:44349/api/Reservations/GetPendingReservation");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.getPendingReservation = jsonData;
                ViewBag.getPendingReservationr3 = r3;
            }

            var responseMessage4 = await client.GetAsync("https://localhost:44349/api/Reservations/GetApprovedReservation");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                ViewBag.getApprovedReservation = jsonData;
                ViewBag.getApprovedReservationr4 = r4;
            }
            return View();
        }
    }
}
