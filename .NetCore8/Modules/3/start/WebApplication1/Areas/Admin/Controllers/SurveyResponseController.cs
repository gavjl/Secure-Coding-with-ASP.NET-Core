using Globomantics.Survey.Areas.Admin.ViewModels;

namespace Globomantics.Survey.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SurveyResponseController : Controller
    {
        private readonly GlobomanticsSurveyDbContext _globomanticsSurveyDbContext;

        public SurveyResponseController(GlobomanticsSurveyDbContext globomanticsSurveyDbContext)
        {
            _globomanticsSurveyDbContext = globomanticsSurveyDbContext;
        }

        [HttpGet("Admin/SurveyResponses/{Id:guid}")]
        public IActionResult Index(Guid id)
        {
            CustomerSurvey? customerSurvey = _globomanticsSurveyDbContext.CustomerSurveys
                .Include(x => x.Questions).FirstOrDefault(x => x.Id == id);

            List<CustomerSurveyResponse>? customerSurveyResponse = _globomanticsSurveyDbContext.CustomerSurveyResponses
                .Include(x => x.Answers)
                .Where(x => x.SurveyId == id).ToList();

            SurveyResponseViewModel surveyResponseViewModel = new SurveyResponseViewModel(
                customerSurvey,
                customerSurveyResponse
                );
            return View(surveyResponseViewModel);
        }
    }
}
