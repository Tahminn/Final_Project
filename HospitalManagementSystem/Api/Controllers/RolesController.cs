using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class RolesController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return Ok(roles);
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] string roleName)
        {
            if (roleName == null) return BadRequest(string.Empty);

            await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));

            return Ok();
        }
    }
}