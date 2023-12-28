
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace Globomantics.Survey.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class SurveyController : Controller
    {
        private readonly GlobomanticsSurveyDbContext _globomanticsSurveyDbContext;

        public SurveyController(GlobomanticsSurveyDbContext globomanticsSurveyDbContext)
        {
            _globomanticsSurveyDbContext = globomanticsSurveyDbContext;
        }

        [HttpGet("Admin/Surveys")]
        public IActionResult Index()
        {
            return View(_globomanticsSurveyDbContext.CustomerSurveys.ToList());
        }

        [HttpGet("Admin/Survey/{Id:guid}")]
        public IActionResult Survey(Guid id)
        {
            CustomerSurvey? customerSurvey = _globomanticsSurveyDbContext.CustomerSurveys
                .Include(x => x.Questions).FirstOrDefault(x => x.Id == id);
            return View(customerSurvey);
        }

        [HttpPost("Admin/SurveyReport")]
        public IActionResult SurveyReport([FromForm] string surveyName)
        {
            Regex regex = new Regex(@"^[a-zA-z\-\s]+$");
            if (!regex.IsMatch(surveyName))
            {
                throw new InvalidOperationException($"Invalid survey name.");
            }
            
            var p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.ArgumentList.Add("/c");
            p.StartInfo.ArgumentList.Add(@"C:\ps\RunReport.bat");
            p.StartInfo.ArgumentList.Add("–name");
            p.StartInfo.ArgumentList.Add(surveyName);
            p.Start();
            p.WaitForExit();

            return Redirect("/Admin/Surveys");
        }
    }
}
