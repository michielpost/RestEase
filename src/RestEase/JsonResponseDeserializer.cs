using System.Net.Http;
using System.Text.Json;

namespace RestEase
{
    /// <summary>
    /// Default implementation of IResponseDeserializer, using Json.NET
    /// </summary>
    public class JsonResponseDeserializer : ResponseDeserializer
    {
        /// <summary>
        /// Gets or sets the serializer settings to pass to JsonConvert.DeserializeObject{T}
        /// </summary>
        public JsonSerializerOptions? JsonSerializerSettings { get; set; }

        /// <inheritdoc/>
        public override T Deserialize<T>(string? content, HttpResponseMessage response, ResponseDeserializerInfo info)
        {
            return JsonSerializer.Deserialize<T>(content, this.JsonSerializerSettings);
        }
    }
}
