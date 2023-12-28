
namespace Globomantics.Survey.Models
{
    public class CustomerSurvey
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = String.Empty;

        public bool IsRange { get; set; } = false;

        public string SurveyCompleteMessage { get; set; } = String.Empty;

        public string ExpectedEmailDomain { get; set; } = String.Empty;

        public List<SurveyQuestion> Questions { get; set; } = null!;

        public CustomerSurvey()
        {

        }

        public CustomerSurvey(Guid id, string title, String surveyCompleteMessage, string expectedEmailDomain, bool isRange = false)
        {
            Id = id;
            Title = title;
            SurveyCompleteMessage = surveyCompleteMessage;
            ExpectedEmailDomain = expectedEmailDomain;
            IsRange = isRange;
        }

    }
}
