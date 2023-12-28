
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
        
        [RegularExpression(@"^[0-9a-zA-Z'\-\s]{1,50}$", ErrorMessage = "Invalid Characters.")]
        public string Answer { get; set; } = null!;

        public SurveyAnswer()
        {

        }

        public SurveyAnswer(Guid surveyResponseId, int answer)
        {
            SurveyResponseId = surveyResponseId;
            Question = "Range";
            Answer = answer.ToString();
            Id = Guid.NewGuid();
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
