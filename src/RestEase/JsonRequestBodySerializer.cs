﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RestEase
{
    /// <summary>
    /// Default IRequestBodySerializer, using Json.NET
    /// </summary>
    public class JsonRequestBodySerializer : RequestBodySerializer
    {
        /// <summary>
        /// Gets or sets the serializer settings to pass to JsonConvert.SerializeObject
        /// </summary>
        public JsonSerializerOptions? JsonSerializerSettings { get; set; }

        /// <inheritdoc/>
        public override HttpContent? SerializeBody<T>(T body, RequestBodySerializerInfo info)
        {
            if (body == null)
                return null;

            var content = new StringContent(JsonSerializer.Serialize(body, this.JsonSerializerSettings));

            const string contentType = "application/json";
            if (content.Headers.ContentType == null)
            {
                content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            }
            else
            {
                content.Headers.ContentType.MediaType = contentType;
            }
            return content;
        }
    }
}
