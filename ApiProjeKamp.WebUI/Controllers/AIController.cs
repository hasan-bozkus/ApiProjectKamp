﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace ApiProjeKamp.WebUI.Controllers
{
    public class AIController : Controller
    {
        [HttpGet]
        public IActionResult CreateRecipeWithOpenAI()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipeWithOpenAI(string prompt)
        {
            //anahtar ezildi
            var apiKey = "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";
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "system", content = "Sen bir restoran için yemek önerileri yapan bir yapay zeka aracısın. Amacımız kullanıcı tarafından girilen malzemelere göre yemek tarifi önerisinde bulunmak." },
                    new { role = "user", content = prompt }
                },
                temperature = 0.5
            };

            var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<OpenAIResponse>();
                var content = result.choices[0].message.content;
                ViewBag.Recipe = content;
            }
            else
            {
                ViewBag.Recipe = "Bir hata oluştu: " + response.StatusCode;
            }

            return View();
        }

        public class OpenAIResponse
        {
            public List<Choice> choices { get; set; }
        }

        public class Choice
        {
            public Message message { get; set; }
        }

        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }
    }
}
