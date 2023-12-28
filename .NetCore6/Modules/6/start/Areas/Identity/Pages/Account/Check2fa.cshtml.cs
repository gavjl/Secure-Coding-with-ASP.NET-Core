#nullable disable

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Globomantics.Survey.Areas.Identity.Pages.Account
{
    public class Check2faModel : PageModel
    {
        private const string TokenProvider = "Authenticator";
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<Check2faModel> _logger;

        public Check2faModel(
            UserManager<IdentityUser> userManager,
            ILogger<Check2faModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(6, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Text)]
            [Display(Name = "Authenticator code")]
            public string TwoFactorCode { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                throw new InvalidOperationException($"Unable to load two-factor authentication user.");
            }

            if (!user.TwoFactorEnabled)
            {
                return Redirect("/Identity/Account/Manage/EnableAuthenticator");
            }
            ReturnUrl = returnUrl;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                throw new InvalidOperationException($"Unable to load two-factor authentication user.");
            }

            if (!user.TwoFactorEnabled)
            {
                return Redirect("/Identity/Account/Manage/EnableAuthenticator");
            }

            bool result = await _userManager.VerifyTwoFactorTokenAsync(user, TokenProvider, Input.TwoFactorCode);

            if (result)
            {
                _logger.LogInformation("User with ID '{UserId}' passed 2fa check.", user.Id);
                string email = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
                HttpContext.Session.SetString(email + EnforceStepUpAttribute.StepUpAllowPathName, returnUrl.ToLower());
                return LocalRedirect(returnUrl);
            }
            else
            {
                _logger.LogWarning("Invalid authenticator code entered for user with ID '{UserId}'.", user.Id);
                ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
                return Page();
            }
        }
    }
}
