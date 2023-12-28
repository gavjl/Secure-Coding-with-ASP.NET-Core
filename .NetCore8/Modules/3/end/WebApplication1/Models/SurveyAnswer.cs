
namespace Globomantics.Survey.Models
{
    public class SurveyAnswer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("SurveyResponseId")]

        public CustomerSurveyResponse? SurveyResponse { get; set; }

        public Guid SurveyResponseId { get; set; }

        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;

        public SurveyAnswer()
        {

        }

        public SurveyAnswer(Guid surveyResponseId, string answer, string question)
        {
            SurveyResponseId = surveyResponseId;
            Answer = answer;
            Question = question;
            Id = Guid.NewGuid();
        }
    }
}
