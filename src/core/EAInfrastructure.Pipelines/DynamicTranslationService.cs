using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.EAInfrastructure
{
    public class DynamicTranslationService
    {
        private readonly ITranslationService _translationService;

        public DynamicTranslationService(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        public async Task<T> TranslateAsync<T>(T entity, string targetLanguage)
        {
            var json = JsonSerializer.Serialize(entity);
            var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
            var translatedJson = await TranslateElementAsync(jsonElement, targetLanguage);

            return JsonSerializer.Deserialize<T>(translatedJson.GetRawText());
        }

        private async Task<JsonElement> TranslateElementAsync(JsonElement element, string targetLanguage)
        {
            var jsonDoc = JsonDocument.Parse(element.GetRawText());
            var root = jsonDoc.RootElement.Clone();

            using (var stream = new MemoryStream())
            {
                using (var writer = new Utf8JsonWriter(stream))
                {
                    writer.WriteStartObject();

                    foreach (var property in root.EnumerateObject())
                    {
                        if (property.Value.ValueKind == JsonValueKind.String)
                        {
                            var translatedText = await _translationService.TranslateAsync(property.Value.GetString(), targetLanguage);
                            writer.WriteString(property.Name, translatedText);
                        }
                        else if (property.Value.ValueKind == JsonValueKind.Object)
                        {
                            writer.WritePropertyName(property.Name); // Anahtar adını belirtin
                            var translatedSubElement = await TranslateElementAsync(property.Value, targetLanguage);
                            translatedSubElement.WriteTo(writer);
                        }
                        else if (property.Value.ValueKind == JsonValueKind.Array)
                        {
                            writer.WritePropertyName(property.Name); // Anahtar adını belirtin
                            writer.WriteStartArray();
                            foreach (var item in property.Value.EnumerateArray())
                            {
                                var translatedItem = await TranslateElementAsync(item, targetLanguage);
                                translatedItem.WriteTo(writer);
                            }
                            writer.WriteEndArray();
                        }
                        else
                        {
                            writer.WritePropertyName(property.Name); // Anahtar adını belirtin
                            property.Value.WriteTo(writer);
                        }
                    }

                    writer.WriteEndObject();
                }

                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    var translatedJson = await reader.ReadToEndAsync();
                    return JsonDocument.Parse(translatedJson).RootElement;
                }
            }
        }
    }
}
