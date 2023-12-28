
using System.Security.Authentication;

namespace Globomantics.Survey.Controllers
{
    public class ApiDataController : Controller
    {
        private const string BaseApiUrl = @"https://localhost:7070/";
        private const string ApiTokenPath = BaseApiUrl + @"api/token";

        public class ApiLoginModel
        {
            [EmailAddress]
            public string? Email { get; set; }

            [DataType(DataType.Password)]
            public string? Password { get; set; }
        }

        [HttpGet("ApiData")]
        public async Task<ActionResult> Get(ApiLoginModel apiLoginModel)
        {
            return View("Index");
        }

        [HttpPost("ApiData/Login")]
        public async Task<ActionResult> GetToken(ApiLoginModel apiLoginModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var handler = new HttpClientHandler
            {
                SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13
            };

            HttpClient client = new HttpClient(handler);

            HttpResponseMessage response = await client.PostAsJsonAsync<ApiLoginModel>(ApiTokenPath, apiLoginModel);
            string responseContent = "";
            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
            }

            return Ok(responseContent);
        }

    }
}