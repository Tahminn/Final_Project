using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Service.DTOs.ControllerPropDTOs.AccountDTOs;
using Service.Services.Interfaces;

namespace Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IRoleClaimsService _roleClaimsService;
        private readonly AppDbContext _context;

        public AccountController(UserManager<User> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                  SignInManager<User> signInManager,
                                 ITokenService tokenService,
                                 IEmailService emailService,
                                 IAccountService accountService,
                                 AppDbContext context,
                                 IHttpContextAccessor httpContextAccessor)
        /*IRoleClaimsService roleClaimsService*/
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _accountService = accountService;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            //_roleClaimsService = roleClaimsService;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var result = await _accountService.Register(registerDTO);
            User User = await _userManager.FindByEmailAsync(registerDTO.Email);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(User);
            var link = Url.Action(nameof(VerifyEmail), "Account", new { userId = User.Id, token = code }, Request.Scheme, Request.Host.ToString());
            await _emailService.RegisterEmail(registerDTO, link);
            return Ok(result);
        }

        [HttpGet]
        [Route("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmail(string userId, string token)
        {
            if (userId == null || token == null) return BadRequest();

            User user = await _userManager.FindByIdAsync(userId);

            if (user is null) return BadRequest();

            await _userManager.ConfirmEmailAsync(user, token);

            //await _signInManager.SignInAsync(user, false);

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
            var accessToken = await _accountService.Login(user);

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
            var email = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;

            var user = await _userManager.FindByEmailAsync(email);

            if (user is null) return NotFound();

            return Ok(user);
        }
    }
}
