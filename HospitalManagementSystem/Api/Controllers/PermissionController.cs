using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Constants;
using Service.Helpers;
using Service.Models;
using Service.Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class PermissionController : ControllerBase
    {
        private readonly IRoleClaimsService _roleClaimsService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public PermissionController(IRoleClaimsService roleClaimsService,
                                    RoleManager<IdentityRole> roleManager)
        {
            _roleClaimsService = roleClaimsService;
            _roleManager = roleManager;
        }

        [Route("get-permissions")]
        [HttpGet]
        public async Task<ActionResult> Index(string roleId)
        {
            var roleClaims = await _roleClaimsService.GetRoleClaims(roleId);
            return Ok(roleClaims);
        }

        [Route("update-permissions")]
        [HttpPost]
        public async Task<IActionResult> Update(PermissionDTO model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            var selectedClaims = model.RoleClaims.Where(a => a.Selected).ToList();
            foreach (var claim in selectedClaims)
            {
                await _roleManager.AddPermissionClaim(role, claim.Value);
            }
            return Ok(new { roleId = model.RoleId });
        }
    }
}
