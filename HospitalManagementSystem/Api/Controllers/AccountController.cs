﻿using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Service.DTOs.AccountDTOs;
using Service.Models;
using Service.Services.Interfaces;
using System.Security.Claims;

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
        private readonly IRoleClaimsService _roleClaimsService;
        private readonly AppDbContext _context;

        public AccountController(UserManager<AppUser> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                  SignInManager<AppUser> signInManager,
                                 ITokenService tokenService,
                                 IEmailService emailService,
                                 IAccountService accountService,
                                 AppDbContext context,
                                 IRoleClaimsService roleClaimsService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _accountService = accountService;
            _context = context;
            _roleClaimsService = roleClaimsService;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            await _accountService.Register(registerDTO);
            AppUser AppUser = await _userManager.FindByEmailAsync(registerDTO.Email);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(AppUser);
            var link = Url.Action(nameof(VerifyEmail), "Account", new { userId = AppUser.Id, token = code }, Request.Scheme, Request.Host.ToString());
            await _emailService.RegisterEmail(registerDTO, link);
            return Ok();
        }

        [HttpGet]
        [Route("confirm-email")]
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
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user is null) return NotFound();
            if (!await _userManager.CheckPasswordAsync(user, loginDTO.Password)) return Unauthorized();
            var accessToken = _accountService.Login(user);

            return Ok(accessToken);
        }

        //[HttpPost]
        //[Route("refresh")]
        //[AllowAnonymous]
        //public async Task<IActionResult> GetRefreshToken([FromBody] LoginDTO loginDTO)
        //{
        //    var user = await _userManager.FindByEmailAsync(loginDTO.Email);
        //    if (user is null) return NotFound();
        //    if (!await _userManager.CheckPasswordAsync(user, loginDTO.Password)) return Unauthorized();
        //    var roles = await _userManager.GetRolesAsync(user);

        //    string refreshToken = _tokenService.GenerateJwtToken(user.UserName, user.Name, user.Surname, 1440, (List<string>)roles);

        //    return Ok(refreshToken);
        //}

        [HttpPost]
        [Route("current-user")]
        public async Task<IActionResult> CurrentUser()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (currentUser is null) return NotFound();

            return Ok(currentUser);
        }

        [HttpPost]
        [Route("create-role")]
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
