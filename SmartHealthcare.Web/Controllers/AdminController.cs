using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartHealthcare.Core.Entities;
using SmartHealthcare.Core.ViewModels;

namespace SmartHealthcare.Web.Controllers
{
    [Authorize(Roles = "Admin")] // ✅ Only Admin can access this controller
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // ✅ STEP 1: Show all users with their current roles
        // STEP 1: Show all users with their current roles
        public async Task<IActionResult> Index()
        {
            var users = new List<UserRoleViewModel>();
            var allUsers = _userManager.Users.ToList(); // Get all users first

            foreach (var user in allUsers)
            {
                var roles = await _userManager.GetRolesAsync(user); // Await properly
                var role = roles.FirstOrDefault() ?? "Unassigned";

                users.Add(new UserRoleViewModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    Role = role
                });
            }

            return View(users);
        }


        // ✅ STEP 2: Show Assign Role page (GET)
        [HttpGet]
        public async Task<IActionResult> AssignRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);

            var roles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Name
            });

            var viewModel = new AssignRoleViewModel
            {
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                SelectedRole = userRoles.FirstOrDefault(),
                Roles = roles
            };

            return View(viewModel);
        }

        // ✅ STEP 3: Save Assigned Role (POST)
        [HttpPost]
        public async Task<IActionResult> AssignRole(AssignRoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null) return NotFound();

            var existingRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, existingRoles);

            var result = await _userManager.AddToRoleAsync(user, model.SelectedRole);

            if (result.Succeeded)
                return RedirectToAction(nameof(Index));

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            // reload dropdown in case of failure
            model.Roles = _roleManager.Roles.Select(r => new SelectListItem { Text = r.Name, Value = r.Name });
            return View(model);
        }
    }
}
