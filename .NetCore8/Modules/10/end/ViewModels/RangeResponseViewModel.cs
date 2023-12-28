namespace Globomantics.Survey.ViewModels
{
    public class RangeResponseViewModel
    {
        public Guid SurveyId { get; set; }

        public int RangeValue { get; set; }

        [RegularExpression(@"^[0-9a-zA-Z'\-\s]{0,100}$", ErrorMessage = "Invalid Characters.")]
        public string? Comment { get; set; }
    }
}
