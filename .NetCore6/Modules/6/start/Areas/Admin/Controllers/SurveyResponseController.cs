using System.Xml;
using Globomantics.Survey.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Globomantics.Survey.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class SurveyResponseController : Controller
    {
        private readonly GlobomanticsSurveyDbContext _globomanticsSurveyDbContext;

        public SurveyResponseController(GlobomanticsSurveyDbContext globomanticsSurveyDbContext)
        {
            _globomanticsSurveyDbContext = globomanticsSurveyDbContext;
        }

        [HttpGet("Admin/SurveyResponses/{Id:guid}")]
        [EnforceStepUp]
        public IActionResult Index(Guid id)
        {
            CustomerSurvey? customerSurvey = _globomanticsSurveyDbContext.CustomerSurveys
                .Include(x => x.Questions).FirstOrDefault(x => x.Id == id);

            customerSurvey.Questions = customerSurvey.Questions.OrderBy(x => x.Question).ToList();

            List<CustomerSurveyResponse>? customerSurveyResponses = _globomanticsSurveyDbContext.CustomerSurveyResponses
                .Include(x => x.Answers)
                .Where(x => x.SurveyId == id).ToList();

            foreach (var customerSurveyResponse in customerSurveyResponses)
            {
                customerSurveyResponse.Answers = customerSurveyResponse.Answers.OrderBy(x => x.Question).ToList();
            } 

            SurveyResponseViewModel surveyResponseViewModel = new SurveyResponseViewModel(
                customerSurvey,
                customerSurveyResponses
                );
            return View(surveyResponseViewModel);
        }

        [HttpGet("Admin/SurveyResponse/upload")]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost("Admin/SurveyResponse/upload")]
        public IActionResult Upload(string xmlContent)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.XmlResolver = new XmlUrlResolver(); 
            xmlDocument.LoadXml(xmlContent);
            string output = xmlDocument.InnerText;

            return View("uploadResponse", output);
        }
    }


}
