

using Microsoft.Data.Sqlite;

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

        public ActionResult SurveyCompleteMessageAdo(string id)
        {
            string message = "";

            using (var command = _globomanticsSurveyDbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = 
                    "Select SurveyCompleteMessage from CustomerSurveys where id = @id";
                command.Parameters.Add(new SqliteParameter("@id", id.ToUpper()));
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

            return Redirect("Survey/SurveyCompleteMessage/" + id);
        }

    }
}
