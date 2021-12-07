using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WizardWorldApi.Tests.Integrations.Extensions {
    public static class HttpContentExtensions {
        public static async Task<T> DeserializeAsync<T>(this HttpContent content) {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            options.Converters.Add(new JsonStringEnumConverter());
            return await JsonSerializer.DeserializeAsync<T>(await content.ReadAsStreamAsync(), options);
        }
    }
}