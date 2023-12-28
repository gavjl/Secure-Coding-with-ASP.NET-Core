using Globomantics.Survey.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

namespace Globomantics.Survey.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IDataProtectionProvider _provider;
        private readonly IDataProtector _protector;
        private readonly UserManager<GloboSurveyUser> _userManager;
        
        public HomeController(IDataProtectionProvider provider, 
         UserManager<GloboSurveyUser> userManager)
        {
            _userManager = userManager;
            _provider = provider;   
            _protector = _provider.
                CreateProtector("Globomantics.Survey.Areas.Admin.Controllers.HomeController");
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Admin/InitCookie")]
        public async Task<IActionResult> InitCookie()
        {
            string cookieProtectedData = "ProtectedData";
            string? cookieContents = Request.Cookies[cookieProtectedData];

            if (string.IsNullOrEmpty(cookieContents))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);

                string protectedData = _protector.Protect(user.Email);
                Console.WriteLine($"Initial data: {user.Email}");
                Console.WriteLine($"Protect data: {protectedData}");

                Response.Cookies.Append(
                    cookieProtectedData,
                    protectedData, 
                    new CookieOptions()
                    {
                        Secure = true,
                        HttpOnly = true, 
                        MaxAge = TimeSpan.FromHours(1)
                    });
            }
            else
            {
                string unprotectedCookie = _protector.Unprotect(cookieContents);
                Console.WriteLine($"Cookie contents: {cookieContents}");
                Console.WriteLine($"Unprotect cookie: {unprotectedCookie}");
            }
            return LocalRedirect("/Admin");
        }

    }
}
