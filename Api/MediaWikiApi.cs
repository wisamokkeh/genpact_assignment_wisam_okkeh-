using System.Text.Json;

namespace AutomationWiki.Api
{
    public class MediaWikiApi
    {
        private readonly HttpClient _httpClient;
        public MediaWikiApi(HttpClient? client = null)
        {
            _httpClient = client ?? new HttpClient
            {
                BaseAddress = new Uri("https://en.wikipedia.org")
            };

            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "AutomationWikiAssignment/1.0 (contact: wisamokkeh2@gmail.com)"
            );
        }

        public async Task<string> GetSectionApi()
        {
            var sectionsJson = await _httpClient.GetStringAsync(
                "/w/api.php?action=parse&page=Playwright_(software)&prop=sections&format=json"
                );

            var doc = JsonDocument.Parse(sectionsJson);
            var sections = doc.RootElement.GetProperty("parse")
            .GetProperty("sections")
            .EnumerateArray();

            string? index = sections.FirstOrDefault(s =>
             string.Equals(
                s.GetProperty("line").GetString(),
                 "Debugging features",
                  StringComparison.OrdinalIgnoreCase
                  )
                  )
                .GetProperty("index")
                .GetString();

            if (index == null)
            {
                throw new Exception("Section: Debugging features not found");
            }

            var jsonText = await _httpClient.GetStringAsync(
              $"/w/api.php?action=parse&page=Playwright_(software)&section={index}&prop=text&format=json"
              );

            var docText = JsonDocument.Parse(jsonText);
            return docText.RootElement
            .GetProperty("parse")
            .GetProperty("text")
            .GetProperty("*")
            .GetString() ?? "";
        }

    }
}
