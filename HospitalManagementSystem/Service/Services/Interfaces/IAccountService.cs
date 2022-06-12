using Domain.Entities;
using Service.DTOs.ControllerPropDTOs.AccountDTOs;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task Register(RegisterDTO registerDTO);
        Task<string> Login(User user);
    }
}
