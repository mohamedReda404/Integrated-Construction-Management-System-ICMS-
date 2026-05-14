using System.Net.Http.Headers;
using System.Text.Json;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class GroqService : IGroqService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GroqService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> AskAsync(string userMessage)
        {
            var apiKey = _configuration["Groq:ApiKey"]?.Trim();

            var requestBody = new
            {
                model = "llama-3.3-70b-versatile",
                messages = new[]
                {
            new { role = "system", content = "You are ICMS assistant." },
            new { role = "user", content = userMessage }
        },
                temperature = 0.7,
                max_tokens = 1024
            };

            var json = JsonSerializer.Serialize(requestBody);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.groq.com/openai/v1/chat/completions"),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var response = await _httpClient.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return result;

            using var doc = JsonDocument.Parse(result);

            return doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();
        }
    }
}
