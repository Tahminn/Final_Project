using Service.DTOs.ControllerPropDTOs.AccountDTOs;

namespace Service.Services.Interfaces
{
    public interface IEmailService
    {
        Task RegisterEmail(RegisterDTO registerDTO, string link);

        Task ConfirmEmail(string userId, string token);
    }
}
