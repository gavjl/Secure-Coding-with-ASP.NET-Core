using Microsoft.AspNetCore.Authorization;

namespace Globomantics.Survey.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class AvatarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Admin/Avatar")]
        public async Task<IActionResult> GetAvatar(string fileUrl)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(fileUrl);

            string responseContent = "";

            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
            }

            return View("DisplayFile", responseContent); 
        }
    }
}