using System.Web;
using Globomantics.Survey.Areas.Admin.ViewModels;
using Globomantics.Survey.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Globomantics.Survey.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<GloboSurveyUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<UserController> _logger;
        private const string EmailBody = "<html><body> %%message%% </body></html>";
        
        public UserController(
            UserManager<GloboSurveyUser> userManager, IEmailSender emailSender,
            ILogger<UserController> logger)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet("Admin/ViewUser/{Id:guid}")]
        public async Task<IActionResult> ViewUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var roles = await _userManager.GetRolesAsync(user);

            bool isAdmin = roles.Any(x => x == "Administrator");

            UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel(user, isAdmin);
            return View(userDetailsViewModel);
        }

        [Authorize(Policy = "SuperAdmin")]
        [HttpPost("Admin/User/SetAdmin/{Id:guid}")]
        public async Task<IActionResult> SetAdmin(Guid id)
        {
            var targetUser = await _userManager.FindByIdAsync(id.ToString());
            var loggedInUser = await _userManager.GetUserAsync(HttpContext.User);
            await _userManager.AddToRoleAsync(targetUser, "Administrator");

            _logger.LogWarning("User {LoggedInUser} SetAdmin for: {TargetUser}.", 
                loggedInUser.Id,
                targetUser.Id);

            return Redirect("/Admin/ViewUser/" + id);
        }

        [Authorize(Policy = "SuperAdmin")]
        [HttpPost("Admin/User/UnsetAdmin/{Id:guid}")]
        public async Task<IActionResult> UnsetAdmin(Guid id)
        {
            var targetUser = await _userManager.FindByIdAsync(id.ToString());
            var loggedInUser = await _userManager.GetUserAsync(HttpContext.User);
            await _userManager.RemoveFromRoleAsync(targetUser, "Administrator");

            _logger.LogWarning("User {LoggedInUser} UnsetAdmin for: {TargetUser}.", 
                loggedInUser.Id,
                targetUser.Id);

            return Redirect("/Admin/ViewUser/" + id);
        }


        [HttpPost("Admin/User/SendEmail/{Id:guid}")]
        public async Task<IActionResult> SendEmail(Guid id, string message)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                throw new InvalidOperationException($"User not found.");
            }

            string htmlMessage = EmailBody
                .Replace("%%message%%", HttpUtility.HtmlEncode(message));

            await _emailSender.SendEmailAsync(user.Email, 
                "Your Globomantics Account", 
                htmlMessage);

            return Redirect("/Admin/ViewUser/" + id);
        }

    }
}
