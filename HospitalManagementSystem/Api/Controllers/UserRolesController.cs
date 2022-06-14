using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.ControllerPropDTOs.AccountDTOs;

namespace Api.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class UserRolesController : BaseController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(UserManager<User> userManager,
                                   SignInManager<User> signInManager,
                                   RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [Route("get-all")]
        [HttpPost]
        public async Task<IActionResult> Index([FromBody]string userId)
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

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ManageUserRolesDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            result = await _userManager.AddToRolesAsync(user, model.UserRoles.Where(x => x.Selected).Select(y => y.RoleName));
            var currentUser = await _userManager.GetUserAsync(User);
            await _signInManager.RefreshSignInAsync(currentUser);
            await Service.Seeds.DefaultUsers.SeedSuperAdminAsync(_userManager, _roleManager);
            return Ok(new { userId = model.Id });
        }
    }
}