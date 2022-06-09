using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Service.DTOs.AccountDTOs;
using Service.Services.Interfaces;
using System.Security.Claims;

namespace Service.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(UserManager<AppUser> userManager,
                              IMapper mapper,
                              RoleManager<IdentityRole> roleManager,
                              ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<AppUser>(registerDTO);
            await _userManager.CreateAsync(user, registerDTO.Password);
            await _userManager.AddToRoleAsync(user, "Member");
        }

        public async Task<string> Login(AppUser user)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);

            List<IdentityRole> identityRoles = new();

            foreach (var role in roles)
            {
                var identityRole = await _roleManager.FindByNameAsync(role);
                identityRoles.Add(identityRole);
            }

            List<IList<Claim>> roleClaims = new();

            foreach (var identityRole in identityRoles)
            {
                var claim = await _roleManager.GetClaimsAsync(identityRole);

                roleClaims.Add(claim);
            }

            string accessToken = _tokenService.GenerateJwtToken(user.UserName, user.Name, user.Surname, 20, (List<string>)roles, roleClaims);

            return accessToken;
        }
    }
}
