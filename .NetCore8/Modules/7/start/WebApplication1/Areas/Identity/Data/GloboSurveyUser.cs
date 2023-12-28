using Microsoft.AspNetCore.Identity;

namespace Globomantics.Survey.Areas.Identity.Data;

public class GloboSurveyUser : IdentityUser
{
    public string ? Name { get; set; }

    public DateTime DOB { get; set; }
}

