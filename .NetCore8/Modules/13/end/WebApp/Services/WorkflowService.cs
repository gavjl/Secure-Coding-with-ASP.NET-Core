using Newtonsoft.Json;

namespace Globomantics.Survey.Services
{
    public static class WorkflowService
    {
        private const string KeyTemplate = "SurveyState_{0}";

        public static void SetStatus(ISession session, Guid surveyId, WorkflowStatus value)
        {
            string key = string.Format(KeyTemplate, surveyId);
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static WorkflowStatus? GetStatus(ISession session, Guid surveyId)
        {
            string key = string.Format(KeyTemplate, surveyId);
            string? value = session.GetString(key);
            if (value == null)
            {
                return null;
            }
            WorkflowStatus? workflowStatus = JsonConvert.DeserializeObject<WorkflowStatus>(value);

            return workflowStatus;
        }

        public static void CompletedStep(this ISession session, Guid surveyId, int stepNumberCompleted)
        {
            WorkflowStatus? workflowStatus = GetStatus(session, surveyId);
            if (workflowStatus == null)
            {
                workflowStatus = new WorkflowStatus(surveyId);
            }

            workflowStatus.CurrentStep = stepNumberCompleted;

            SetStatus(session, surveyId, workflowStatus);
        }

        public static bool CanAccessStep(this ISession session, Guid surveyId, int stepNumberToAccess)
        {
            WorkflowStatus? workflowStatus = GetStatus(session, surveyId);
            if (workflowStatus == null || workflowStatus.SurveyId != surveyId)
            {
                return false;
            }

            if (workflowStatus.CurrentStep == stepNumberToAccess - 1)
            {
                return true;
            }

            return false;
        }
    }

}