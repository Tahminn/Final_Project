using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Service.DTOs.AccountDTOs;
using Service.Services.Interfaces;

namespace Service.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager,
                              IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<AppUser>(registerDTO);
            await _userManager.CreateAsync(user, registerDTO.Password);
            await _userManager.AddToRoleAsync(user, "Member");
        }
    }
}
