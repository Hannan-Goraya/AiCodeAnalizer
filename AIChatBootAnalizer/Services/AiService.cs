using AIChatBootAnalizer.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AIChatBootAnalizer.Services
{
    public class AiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public AiService(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _apiKey = config["OpenAI:ApiKey"] ?? throw new Exception("OpenAI API key missing");
        }

        public async Task<string> ExplainAsync(string code, List<string> issues)
        {
            var prompt = $"Analyze the following {issues.Count} issue(s) in this code:\n\n{code}\n\nIssues:\n- {string.Join("\n- ", issues)}\n\nExplain clearly what is wrong and how to fix it.";

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _apiKey);

            var requestBody = new
            {
                model = "gpt-4o-mini", // or gpt-4o
                messages = new[]
                {
                    new { role = "system", content = "You are a code analysis assistant." },
                    new { role = "user", content = prompt }
                },
                max_tokens = 300
            };

            var response = await _httpClient.PostAsync(
                "https://api.openai.com/v1/chat/completions",
                new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json")
            );

            var responseJson = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(responseJson);
            return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
        }
    }
}
