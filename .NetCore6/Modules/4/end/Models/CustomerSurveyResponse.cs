

namespace Globomantics.Survey.Models
{
    public class CustomerSurveyResponse
    {

        [Key]
        public Guid Id { get; set; }

        public Guid SurveyId { get; set; }


        public List<SurveyAnswer>? Answers { get; set; }

        public CustomerSurveyResponse()
        {
            Answers = new List<SurveyAnswer>();
        }

        public CustomerSurveyResponse(Guid surveyId, List<SurveyAnswer>? answers = default, Guid id = new Guid())
        {
            Id = id;
            SurveyId = surveyId;
            Answers = answers;
        }
    }
}
