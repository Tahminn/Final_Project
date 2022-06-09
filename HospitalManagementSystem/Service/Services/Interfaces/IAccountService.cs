using Domain.Entities;
using Service.DTOs.AccountDTOs;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task Register(RegisterDTO registerDTO);
        Task<string> Login(AppUser user);
    }
}
