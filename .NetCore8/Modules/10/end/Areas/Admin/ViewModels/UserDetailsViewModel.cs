using Globomantics.Survey.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Globomantics.Survey.Areas.Admin.ViewModels
{
    public class UserDetailsViewModel
    {
        public GloboSurveyUser User { get; set; }

        public bool IsAdmin { get; set; }

        public UserDetailsViewModel(GloboSurveyUser user, bool isAdmin)
        {
            User = user;
            IsAdmin = isAdmin;
        }

    }
}
