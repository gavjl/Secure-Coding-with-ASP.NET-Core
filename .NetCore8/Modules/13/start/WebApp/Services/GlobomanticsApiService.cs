
using System.Security.Authentication;

namespace Globomantics.Survey.Services
{
    public class GlobomanticsApiService
    {
        public async Task<string> GetPublicData(string url)
        {
            var handler = new HttpClientHandler
            {
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13
            };

            HttpClient client = new HttpClient(handler);

            HttpResponseMessage response = await client.GetAsync(url);
            string responseContent = "";
            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
            }

            return responseContent;
        }
    }

}