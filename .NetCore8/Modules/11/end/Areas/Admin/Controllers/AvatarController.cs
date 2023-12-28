using Microsoft.AspNetCore.Authorization;

namespace Globomantics.Survey.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class AvatarController : Controller
    {
        private List<string> _allowedDomains = 
            new List<string>{
                "http://avatars.globomantics.com:5126/", 
                "https://avatars.globomantics.com:7126/"
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Admin/Avatar")]
        public async Task<IActionResult> GetAvatar(string fileUrl)
        {
            if (_allowedDomains.Where(x => fileUrl.ToLower().StartsWith(x)).Count() == 0)
            {
                ModelState.AddModelError("File", "Domain not allowed");
                return View("Index");
            }
            
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