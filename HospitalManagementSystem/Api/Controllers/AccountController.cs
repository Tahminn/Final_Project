using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repository.Data;
using Service.DTOs.AccountDTOs;
using Service.Services.Interfaces;
using Service.Utilities.Helpers;
using System.IdentityModel.Tokens.Jwt;

namespace Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IAccountService _accountService;

        public AccountController(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                  SignInManager<AppUser> signInManager,
                                 ITokenService tokenService,
                                 IEmailService emailService,
                                 IAccountService accountService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _accountService = accountService;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            await _accountService.Register(registerDTO);
            AppUser appUser = await _userManager.FindByEmailAsync(registerDTO.Email);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            var link = Url.Action(nameof(VerifyEmail), "Account", new { userId = appUser.Id, token = code }, Request.Scheme, Request.Host.ToString());
            await _emailService.RegisterEmail(registerDTO, link);
            return Ok();
        }

        [HttpGet]
        [Route("Confirm-Email")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmail(string userId, string token)
        {
            if (userId == null || token == null) return BadRequest();

            AppUser user = await _userManager.FindByIdAsync(userId);

            if (user is null) return BadRequest();

            await _userManager.ConfirmEmailAsync(user, token);

            await _signInManager.SignInAsync(user, false);

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user is null) return NotFound();
            if (!await _userManager.CheckPasswordAsync(user, loginDTO.Password)) return Unauthorized();
            var roles = await _userManager.GetRolesAsync(user);
            string token = _tokenService.GenerateJwtToken(user.UserName, user.Name, user.Surname, (List<string>)roles);

            return Ok(token);
        }

        [HttpPost]
        [Route("GetMe")]
        public async Task<IActionResult> GetMe([FromBody] string username)
        {
            if (username == null) return BadRequest();

            var user = await _userManager.FindByEmailAsync(username);
            if (user is null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole([FromQuery] string role)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = role });
            return Ok();
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();

        }
    }
}
