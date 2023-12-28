namespace Globomantics.Survey.ViewModels
{
    public class RangeResponseViewModel : IValidatableObject
    {
        public Guid SurveyId { get; set; }

        [Range(1, 10)]
        public int RangeValue { get; set; }

        [RegularExpression(@"^[0-9a-zA-Z'\-\s]{0,100}$", ErrorMessage = "Invalid Characters.")]
        public string? Comment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RangeValue < 5 && (Comment == null || Comment.Length == 0))
            {
                yield return new ValidationResult("Please add a comment for scores below 5");
            }
        }
    }
}
