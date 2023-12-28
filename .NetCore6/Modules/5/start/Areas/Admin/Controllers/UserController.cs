using Globomantics.Survey.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Globomantics.Survey.Areas.Admin.Controllers
{
    [Authorize]
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
            UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel(user);
            return View(userDetailsViewModel);
        }

    }
}
