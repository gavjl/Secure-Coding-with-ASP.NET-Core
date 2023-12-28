using Globomantics.Survey.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Globomantics.Survey.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    // [ValidateAntiForgeryToken]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;
        private const string EmailBody = "<html><body> %%message%% </body></html>";

        public UserController(
            UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
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
            if (user == null)
                return NotFound($"User ID not found.");
            var roles = await _userManager.GetRolesAsync(user);

            bool isAdmin = roles.Any(x => x == "Administrator");

            UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel(user, isAdmin);
            return View(userDetailsViewModel);
        }

        
        [Authorize(Policy = "SuperAdmin")]
        [HttpPost("Admin/User/SetAdmin/{Id:guid}")]
        public async Task<IActionResult> SetAdmin(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound($"User ID not found.");  
            await _userManager.AddToRoleAsync(user, "Administrator");
            return Redirect("/Admin/ViewUser/" + id);
        }

        [Authorize(Policy = "SuperAdmin")]
        [HttpPost("Admin/User/UnsetAdmin/{Id:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnsetAdmin(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound($"User ID not found.");  
            await _userManager.RemoveFromRoleAsync(user, "Administrator");
            return Redirect("/Admin/ViewUser/" + id);
        }

        [HttpPost("Admin/User/SendEmail/{Id:guid}")]
        public async Task<IActionResult> SendEmail(Guid id, string message)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                throw new InvalidOperationException($"User not found.");
            if (user.Email == null)
                throw new InvalidOperationException($"Missing user email.");

            string htmlMessage = EmailBody
                .Replace("%%message%%", message);

            await _emailSender.SendEmailAsync(user.Email, 
                "Your Globomantics Account", 
                htmlMessage);

            return Redirect("/Admin/ViewUser/" + id);
        }

    }
}
