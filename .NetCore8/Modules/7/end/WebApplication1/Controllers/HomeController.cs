using System.Diagnostics;
using Globomantics.Survey.Services;

namespace Globomantics.Survey.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly GlobomanticsApiService _thirdPatyApiCall;

        public HomeController(ILogger<HomeController> logger,
            GlobomanticsApiService thirdPatyApiCall)
        {
            _logger = logger;
            _thirdPatyApiCall = thirdPatyApiCall;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetPublicData()
        {
            return View("GetPublicData", await _thirdPatyApiCall.GetPublicData());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}