

using Globomantics.Survey.ViewModels;
using Microsoft.Data.Sqlite;
using Globomantics.Survey.Services;

namespace Globomantics.Survey.Controllers
{
    public class SurveyController : Controller
    {
        private readonly GlobomanticsSurveyDbContext _globomanticsSurveyDbContext;

        public SurveyController(GlobomanticsSurveyDbContext globomanticsSurveyDbContext)
        {
            _globomanticsSurveyDbContext = globomanticsSurveyDbContext;
        }

        [HttpGet("Survey/Step1/{Id:guid}")]
        public ActionResult ConfirmEmail(Guid id)
        {
            CustomerSurvey? customerSurvey = _globomanticsSurveyDbContext.CustomerSurveys
                .FirstOrDefault(x => x.Id == id);
            return View(customerSurvey);
        }

        [HttpPost("Survey/Step1/{Id:guid}")]
        public ActionResult ConfirmEmail(Guid id, string Email)
        {
            CustomerSurvey? customerSurvey = _globomanticsSurveyDbContext.CustomerSurveys.FirstOrDefault(x => x.Id == id);

            if (customerSurvey == null)
                 return NotFound();

            if (customerSurvey.ExpectedEmailDomain != "")
            {
                if (!Email.ToLower().EndsWith(customerSurvey.ExpectedEmailDomain.ToLower()))
                {
                    return BadRequest("Invalid domain");
                }
            }

            return Redirect("/Survey/Step2/" + id);
        }

        [HttpGet("Survey/Step2/{Id:guid}")]
        public ActionResult TakeSurvey(Guid id)
        {
            CustomerSurvey? customerSurvey = _globomanticsSurveyDbContext.CustomerSurveys
                .Include(x => x.Questions).FirstOrDefault(x => x.Id == id);

            if (customerSurvey == null)
                return NotFound();

            if (customerSurvey.IsRange)
            {
                return View("RangeSurvey", customerSurvey.Id);
            }
            else
            {
                return View(customerSurvey);
            }
        }

        public ActionResult SurveyCompleteMessageAdo(string id)
        {
            string message = "";

            using (var command = _globomanticsSurveyDbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = 
                    "Select SurveyCompleteMessage from CustomerSurveys where id = '" + id.ToUpper() + "'";
                _globomanticsSurveyDbContext.Database.OpenConnection();
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            message += reader.GetString(0) + "<br><br>";
                        }
                    }
                }
                finally
                {
                    _globomanticsSurveyDbContext.Database.CloseConnection();
                }
            }

            return View("SurveyCompleteMessage", message);
        }

       public ActionResult SurveyCompleteMessageEF(string id)
        {
            var results = _globomanticsSurveyDbContext
                .CustomerSurveys
                .FromSqlRaw("Select * from CustomerSurveys where id = {0}", id.ToUpper())
                .ToList();

            string message = "";
            foreach(var result in results)
            {
                message += result.SurveyCompleteMessage + "<br><br>";
            }

            return View("SurveyCompleteMessage", message);
        }

        [HttpPost("Survey/Step2/{Id:guid}")]
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

            return Redirect("Survey/SurveyCompleteMessageEF/" + id);
        }

        [HttpPost("Survey/RangeSurvey/{Id:guid}")]
        public async Task<ActionResult> CompleteRangeSurvey(Guid id, RangeResponseViewModel rangeResponseViewModel)
        {
            CustomerSurvey? customerSurvey = _globomanticsSurveyDbContext.CustomerSurveys
                .Include(x => x.Questions).FirstOrDefault(x => x.Id == id);

            List<SurveyAnswer> answers = new List<SurveyAnswer>();
            answers.Add(new SurveyAnswer(id, rangeResponseViewModel.RangeValue));

            _globomanticsSurveyDbContext.CustomerSurveyResponses.Add(new CustomerSurveyResponse(id, answers));

            await _globomanticsSurveyDbContext.SaveChangesAsync();

            return Redirect("/Survey/SurveyCompleteMessageEF/" + id);
        }

    }
}
