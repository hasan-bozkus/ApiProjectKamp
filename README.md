# Yummy Api Proje Kampı (Asp.Net Core 9.0 Api - Mvc)

## Projenin Maksadı

Yummy Api Proje kampı, uygulamada Api ve Yapay Zeka teknolojilerini bir resotran sistemine entegre edebilmenin potansiyelini göstermektir. Proje kapsamında, misafirlerin çevrim içi olarak rezervasyon yapabilmeleri, işletme ile iletişime geçebilmeleri ve restoran hakkında bilgi edinebilmeleri hedeflenmektedir. Geliştirilen sistem, restoran tarafında sunulan ürünlerin (yemeklerin), etkinliklerin, şeflerin, misafir yorumlarının, rezervasyonların, iletişim taleplerinin ve mesajların merkezi bir yönetim paneli üzerinden kontrol edilmesine imkân tanımayı amaçlamaktadır. Ayrıca yapay zekâ destekli özellikler sayesinde, restoran yönetim süreçlerinin daha verimli hâle getirilmesi, müşteri taleplerinin daha hızlı analiz edilmesi ve kullanıcı deneyiminin iyileştirilmesi hedeflenmektedir. Böylece hem restoran işletmelerinin dijital dönüşümüne katkı sağlanacak hem de API tabanlı, yapay zekâ destekli modern bir sistemin gerçek bir senaryo üzerinde nasıl uygulanabileceği gösterilecektir.

yummy Api Proje Kampı; Asp.Net Core 6.0 Api - Mvc, Entity Framework Core, Open AI, Gemini, Hugging Face ve Claude vb. öne çıkan yapay zeka modelleri kullanılarak geliştirildi.

## 🔧 Teknik Yapı ve Mimarisi
💎 .Net Core 6.0 Web Api <br />
💎 .Net Core 6.0 Mvc <br />
💎 EntityFramework Core <br />
💎 Open AI: /v1/chat/completions - gpt-3.5-turbo (Tarif Oluşturma) <br />
💎 Open AI: /v1/chat/completions - gpt-4o-mini (AI ile Canlı Sohbet) <br />
💎 Hugging Face: /models/Helsinki-NLP/opus-mt-tr-en (İletişim - Çeviri) <br />
💎 Hugging Face: /models/unitary/toxic-bert (İletişim - Toxicity) <br />
💎 Open AI: /v1/chat/completions - gpt-3.5-turbo (İletişim Talebinin Cevaplanması) <br />
💎 Open AI: /v1/chat/completions - gpt-4.1-mini (Dashboard Menü Oluşturma) <br />
💎 Anthropic Claude: Projenin Tasarımsal Düzenlenmesi <br />
💎 SignalR - (Delta, Choice ve Chat Stream Chunk) <br />
💎 Bootstrap <br />
💎 JavaScript (JQuery) <br />
💎 Html - Css <br />

![.NET](https://img.shields.io/badge/.NET%209.0-purple?logo=dotnet)
![Entity Framework](https://img.shields.io/badge/EntityFrameworkCore-green)
![Gemini](https://img.shields.io/badge/Google-Gemini-red?logo=google)
![OpenAI](https://img.shields.io/badge/OpenAI-API-blue?logo=openai)
![Hugging Face](https://img.shields.io/badge/HuggingFace-Spaces-yellow?logo=huggingface&logoColor=black)
![Anthropic](https://img.shields.io/badge/Anthropic-Claude-A16D21?logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI5NjAiIGhlaWdodD0iOTYwIiB2aWV3Qm94PSIwIDAgNzUgNzUiPgogIDxwYXRoIGZpbGw9IiNGRkZGRkYiIGQ9Ik0zNy41IDBDMTYuNzgzIDAgMCAxNi43ODMgMCAzNy41UzE2Ljc4MyA3NSA1MC4yMTcgNzVsMjAuNjI4LTIwLjYyOUEzNy40NjcgMzcuNDY3IDAgMDA3NSA1MC4yMTdWNUN6Ii8+CiAgPHBhdGggZmlsbD0iI0ExNkQyMSIgZD0iTTAgNDkuMDk3QTM3LjUgMzcuNSAwIDAwMzcuNSA3NXMzNy41LTI2LjcwMyAzNy41LTI2LjcwM1YwTDM3LjUgMTkuNjk1em02MC4wMzQtNDQuNDc3LTYwLjAzNCA2MC4wMzR2MTAuMzQ5QTM3LjUgMzcuNSAwIDAwNDkuMDk3IDc1TDU2LjgyIDY3Ljg4IDU2LjgyIDY2LjczTDYwLjA1NyA2NEM2MC4wNTcgNTUuODg5IDYwLjAzNCAzOC43MyA2MC4wMzQgNC42MnptMTQuNjM2IDQyLjY3NEEzNy41IDM3LjUgMCAwMDY2Ljg4IDY2LjgzN2w2Ljg4NS02Ljg4NSAzLjI0Ny0zLjI0N1YyNS44ODJsLTExLjk5Mi0xMS45OTJWMjQuMjJ6Ii8+Cjwvc3ZnPg==)
![SignalR](https://img.shields.io/badge/ASP.NET-SignalR-darkblue?logo=signalr)
![jQuery](https://img.shields.io/badge/jQuery-JavaScript-0769AD?logo=jquery&logoColor=white)

## Projeye İlişkin Bazı Görseller

![1](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/guestpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20201816.png)
![2](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/guestpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20201841.png)
![3](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/guestpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20201855.png)
![4](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/guestpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20202234.png?)
![5](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/guestpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20202303.png)
![6](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/guestpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20202331.png)
![7](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/guestpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20202356.png)
![8](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/guestpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20202418.png)
![9](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/guestpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20202431.png)
![10](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/guestpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20202453.png)
![11](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20202833.png)
![12](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20202850.png)
![13](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20202926.png)
![14](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20202946.png)
![15](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20203002.png)
![16](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20203020.png)
![17](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20203034.png)
![18](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20203048.png)
![19](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20203104.png)
![20](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20203150.png)
![21](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20203210.png)
![22](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20203229.png)
![23](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20203248.png)
![24](https://github.com/hasan-bozkus/ApiProjectKamp/blob/master/ApiProjeKamp.WebUI/wwwroot/adminpanelimages/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-12-15%20203304.png)
