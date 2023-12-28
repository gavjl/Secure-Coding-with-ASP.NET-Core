
namespace Globomantics.Survey.Models
{
    public class SurveyQuestion
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("SurveyId")]
        public CustomerSurvey? Survey { get; set; }

        public Guid SurveyId { get; set; }

        public string Question { get; set; } = String.Empty;

        public string Answer { get; set; } = String.Empty;

        public String PossibleAnswers { get; set; }

        public SurveyQuestion(Guid surveyId, Guid id, string question, String possibleAnswers = "")
        {
            SurveyId = surveyId;
            Id = id;
            Question = question;
            PossibleAnswers = possibleAnswers;
        }
    }
}


