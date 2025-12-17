using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TradeScope.Helpers
{
    public static class JsonHelpers
    {
        public static JsonSerializerOptions JsonOptions() => new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNamingPolicy = null, // mantém nomes como no C# (InitialCapital, etc.)
            Converters =
            {
                new JsonStringEnumConverter() // se tiver enums como WithdrawlFrequency
            }
        };

        public static string PrettyJson(string rawJson)
        {
            using var doc = JsonDocument.Parse(rawJson);
            return JsonSerializer.Serialize(doc.RootElement, JsonOptions());
        }
    }
}
