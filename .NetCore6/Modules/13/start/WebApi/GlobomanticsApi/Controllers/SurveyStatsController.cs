using GlobomanticsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobomanticsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyStatsController : ControllerBase
    {

        [HttpGet(Name = "SurveyStats")]
        public SurveyStats Get(string? userEmail)
        {
            return new SurveyStats { UserEmail = userEmail, CompletedSurveys = 6 };
        }
    }
}