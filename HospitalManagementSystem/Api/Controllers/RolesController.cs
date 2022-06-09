using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return Ok(roles);
        }

        [Route("AddRoles")]
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName == null) return BadRequest(string.Empty);

            await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));

            return Ok();
        }
    }
}