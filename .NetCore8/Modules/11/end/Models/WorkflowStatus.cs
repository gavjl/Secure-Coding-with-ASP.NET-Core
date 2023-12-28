
namespace Globomantics.Survey.Models
{
    public class WorkflowStatus
    {
        public Guid SurveyId { get; set; }

        public int CurrentStep { get; set; }

        public WorkflowStatus(Guid surveyId)
        {
            SurveyId = surveyId;
            CurrentStep = 1;
        }

    }
}


