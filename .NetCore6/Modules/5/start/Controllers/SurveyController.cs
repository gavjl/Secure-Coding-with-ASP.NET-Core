

namespace Globomantics.Survey.Controllers
{
    public class SurveyController : Controller
    {
        private readonly GlobomanticsSurveyDbContext _globomanticsSurveyDbContext;

        public SurveyController(GlobomanticsSurveyDbContext globomanticsSurveyDbContext)
        {
            _globomanticsSurveyDbContext = globomanticsSurveyDbContext;
        }

        public ActionResult TakeSurvey(Guid id)
        {
            CustomerSurvey? customerSurvey = _globomanticsSurveyDbContext.CustomerSurveys
                .Include(x => x.Questions).FirstOrDefault(x => x.Id == id);
            return View(customerSurvey);
        }

        [HttpPost]
        public async Task<ActionResult> CompleteSurvey(Guid id, SurveyAnswer[] questions)
        {
            CustomerSurvey? customerSurvey = _globomanticsSurveyDbContext.CustomerSurveys
                .Include(x => x.Questions).FirstOrDefault(x => x.Id == id);

            CustomerSurveyResponse customerSurveyResponse = new CustomerSurveyResponse(id, questions.ToList());
            foreach (SurveyAnswer answer in questions)
            {
                answer.SurveyResponse = customerSurveyResponse;
            }

            _globomanticsSurveyDbContext.CustomerSurveyResponses.Add(new CustomerSurveyResponse(id, questions.ToList()));

            await _globomanticsSurveyDbContext.SaveChangesAsync();

            return View(viewName: "SurveyComplete", model: customerSurvey);
        }

    }
}
