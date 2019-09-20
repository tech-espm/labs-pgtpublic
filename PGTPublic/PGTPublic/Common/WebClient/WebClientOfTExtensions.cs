using System.Net.Http;
using System.Net.Http.Headers;

namespace PGTPublic.Common.WebClient
{
    public static class WebClientOfTExtensions
    {
        private const string contentType = "application/json";

        public static void SetTokenBearer(this HttpRequestHeaders header, string token = null)
        {
            if (!string.IsNullOrEmpty(token))
            {
                header.Add("Authorization", "Bearer " + token);
            }
        }

        public static void SetHttpClientHeaders(this HttpClient client, string token = null)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            client.DefaultRequestHeaders.SetTokenBearer(token);
        }
    }
}
