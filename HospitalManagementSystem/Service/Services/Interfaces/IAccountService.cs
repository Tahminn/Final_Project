using Service.DTOs.AccountDTOs;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task Register(RegisterDTO registerDTO);
    }
}
