using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TranslateApp
{
    public class TranslationService
    {
        private readonly HttpClient httpClient;
        private const string MyMemoryApiUrl = "https://api.mymemory.translated.net/get";

        public TranslationService()
        {
            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<string> TranslateAsync(string text, string sourceLang, string targetLang)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            try
            {
                string url = $"{MyMemoryApiUrl}?q={Uri.EscapeDataString(text)}&langpair={sourceLang}|{targetLang}";
                
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(jsonResponse);

                string? translatedText = json["responseData"]?["translatedText"]?.ToString();

                if (string.IsNullOrEmpty(translatedText))
                {
                    throw new Exception("Çeviri sonucu alınamadı.");
                }

                return translatedText;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"İnternet bağlantısı hatası: {ex.Message}");
            }
            catch (TaskCanceledException)
            {
                throw new Exception("İstek zaman aşımına uğradı. Lütfen tekrar deneyin.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Çeviri hatası: {ex.Message}");
            }
        }
    }
}

