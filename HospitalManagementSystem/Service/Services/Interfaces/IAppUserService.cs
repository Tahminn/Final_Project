using Domain.Entities;
using Service.DTOs;
using Service.DTOs.ControllerPropDTOs.UserDTOs;
using Service.DTOs.ControllerPropDTOs.UserDTOs.GetUser;
using Service.DTOs.EntityDTOs.AccountDTOs;
using Service.Utilities.Pagination;
using System.Linq.Expressions;

namespace Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<Paginate<GetUsersDTO>> GetAll(int take, int lastPatientId, int page);
        Task Create(CreateUserDTO createUser);
    }
}
