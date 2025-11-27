using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebUI.ViewComponents.HomePageViewComponents
{
    public class _HomePageStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePageStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:44349/api/Statistics/ProductCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                ViewBag.productCount = jsonData;
            }

            var response2Message = await client.GetAsync("https://localhost:44349/api/Statistics/ReservationCount");
            if (response2Message.IsSuccessStatusCode)
            {
                var jsonData = await response2Message.Content.ReadAsStringAsync();
                ViewBag.reservationCount = jsonData;
            }

            var response3Message = await client.GetAsync("https://localhost:44349/api/Statistics/ChefCount");
            if (response3Message.IsSuccessStatusCode)
            {
                var jsonData = await response3Message.Content.ReadAsStringAsync();
                ViewBag.chefCount = jsonData;
            }

            var response4Message = await client.GetAsync("https://localhost:44349/api/Statistics/TotalGuestCount");
            if (response4Message.IsSuccessStatusCode)
            {
                var jsonData = await response4Message.Content.ReadAsStringAsync();
                ViewBag.totalGuestCount = jsonData;
            }

            return View();
        }
    }
}
