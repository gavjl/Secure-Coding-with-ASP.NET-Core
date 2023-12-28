using Microsoft.AspNetCore.Identity;

namespace Globomantics.Survey.Areas.Identity.Data;

public class GloboSurveyUser : IdentityUser
{
    [PersonalData]
    public string ? Name { get; set; }

    [PersonalData]
    public DateTime DOB { get; set; }
}

