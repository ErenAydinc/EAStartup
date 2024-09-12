using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.EAInfrastructure
{
    public class TranslationService : ITranslationService
    {
        private readonly HttpClient _httpClient;

        public TranslationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //   public async Task<string> TranslateAsync(string text, string targetLanguage)
        //   {
        //       // Google Translate API için URL
        //       var url = $"https://translation.googleapis.com/language/translate/v2?key=AIzaSyByno5di9rdYn_6dEeskN_6A8Uxqf3jvms";

        //       // İstek verisi
        //       var requestContent = new StringContent(
        //$"{{\"q\": \"{text}\", \"target\": \"{targetLanguage}\"}}",
        //Encoding.UTF8,
        //"application/json");

        //       var response = await _httpClient.PostAsync(url, requestContent);
        //       response.EnsureSuccessStatusCode();

        //       var responseJson = await response.Content.ReadAsStringAsync();

        //       // JSON yanıtını parse ederek çevirilmiş metni çıkarın
        //       var jsonDocument = JsonDocument.Parse(responseJson);
        //       var translatedText = jsonDocument
        //           .RootElement
        //           .GetProperty("data")
        //           .GetProperty("translations")[0]
        //           .GetProperty("translatedText")
        //           .GetString();

        //       return translatedText;
        //   }

        //public async Task<string> TranslateAsync(string text, string targetLanguage)
        //{
        //    var url = "https://libretranslate.de/translate";

        //    // İstek verisi
        //    var requestContent = new StringContent(
        //        $"{{\"q\": \"{text}\", \"source\": \"en\", \"target\": \"{targetLanguage}\"}}",
        //        Encoding.UTF8,
        //        "application/json");

        //    using (var httpClient = new HttpClient())
        //    {
        //        var response = await httpClient.PostAsync(url, requestContent);
        //        response.EnsureSuccessStatusCode();

        //        var responseJson = await response.Content.ReadAsStringAsync();

        //        // JSON yanıtını parse ederek çevirilmiş metni çıkarın
        //        var jsonDocument = JsonDocument.Parse(responseJson);
        //        var translatedText = jsonDocument
        //            .RootElement
        //            .GetProperty("translatedText")
        //            .GetString();

        //        return translatedText;
        //    }
        //}
    }
}
