using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class UserRolesController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Route("GetUserRoles")]
        [HttpGet]
        public async Task<IActionResult> Index(string userId)
        {
            var viewModel = new List<UserRolesDTO>();
            var user = await _userManager.FindByIdAsync(userId);
            foreach (var role in _roleManager.Roles.ToList())
            {
                var UserRolesDTO = new UserRolesDTO
                {
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    UserRolesDTO.Selected = true;
                }
                else
                {
                    UserRolesDTO.Selected = false;
                }
                viewModel.Add(UserRolesDTO);
            }
            var model = new ManageUserRolesDTO()
            {
                UserId = userId,
                UserRoles = viewModel
            };

            return Ok(model);
        }

        [Route("UpdateUserRoles")]
        [HttpPost]
        public async Task<IActionResult> Update(string id, ManageUserRolesDTO model)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            result = await _userManager.AddToRolesAsync(user, model.UserRoles.Where(x => x.Selected).Select(y => y.RoleName));
            var currentUser = await _userManager.GetUserAsync(User);
            await _signInManager.RefreshSignInAsync(currentUser);
            await Service.Seeds.DefaultUsers.SeedSuperAdminAsync(_userManager, _roleManager);
            return Ok(new { userId = id });
        }
    }
}