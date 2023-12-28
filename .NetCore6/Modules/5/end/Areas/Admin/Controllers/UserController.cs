using Globomantics.Survey.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Globomantics.Survey.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.AddToRoleAsync(user, "Administrator");
            return Redirect("/Admin/ViewUser/" + id);
        }

        [Authorize(Policy = "SuperAdmin")]
        [HttpPost("Admin/User/UnsetAdmin/{Id:guid}")]
        public async Task<IActionResult> UnsetAdmin(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.RemoveFromRoleAsync(user, "Administrator");
            return Redirect("/Admin/ViewUser/" + id);
        }

    }
}
