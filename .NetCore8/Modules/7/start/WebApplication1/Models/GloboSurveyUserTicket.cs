using Microsoft.AspNetCore.Identity;

namespace Globomantics.Survey.Areas.Identity.Data;

// Add profile data for application users by adding properties to the GloboSurveyUser class
public class GloboSurveyUserTicket 
{

    [Key]
    public String ? Id { get; set; }

    public String ? UserId { get; set; }

    public string ? Title { get; set; }

    public string ? Message { get; set; }
}

