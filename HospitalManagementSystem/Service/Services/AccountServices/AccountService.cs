using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Service.DTOs.ControllerPropDTOs.AccountDTOs;
using Service.Services.Interfaces;
using System.Security.Claims;

namespace Service.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(UserManager<User> userManager,
                              IMapper mapper,
                              RoleManager<IdentityRole> roleManager,
                              ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        public async Task<bool> Register(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<User>(registerDTO);
            await _userManager.CreateAsync(user, registerDTO.Password);
            var result = await _userManager.AddToRoleAsync(user, "Member");
            return result.Succeeded;
        }

        public async Task<string> Login(User user)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);

            List<IdentityRole> identityRoles = new();

            foreach (var role in roles)
            {
                var identityRole = await _roleManager.FindByNameAsync(role);
                identityRoles.Add(identityRole);
            }

            List<Claim> roleClaims = new();

            foreach (var identityRole in identityRoles)
            {
                var claims = await _roleManager.GetClaimsAsync(identityRole);
                foreach (var claim in claims)
                {
                    roleClaims.Add(claim);
                }
            }

            var accessToken = await _tokenService.GenerateJwtToken(user, roleClaims);

            return accessToken;
        }
    }
}
