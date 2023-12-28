namespace Globomantics.Survey.Areas.Admin.ViewModels
{
    public class SurveyResponseViewModel
    {
        public List<CustomerSurveyResponse> SurveyResponses { get; set; }

        public CustomerSurvey? CustomerSurvey { get; set; }

        public SurveyResponseViewModel(CustomerSurvey? customerSurvey, List<CustomerSurveyResponse> surveyResponses)
        {
            CustomerSurvey = customerSurvey;
            SurveyResponses = surveyResponses;
        }

    }
}
