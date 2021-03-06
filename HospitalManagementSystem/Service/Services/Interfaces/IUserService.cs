using Domain.Entities;
using Service.DTOs;
using Service.DTOs.ControllerPropDTOs.UserDTOs;
using Service.DTOs.ControllerPropDTOs.UserDTOs.GetUser;
using Service.DTOs.ControllerPropDTOs.UserDTOs.PutUser;
using Service.DTOs.EntityDTOs.AccountDTOs;
using Service.Utilities.Pagination;
using System.Linq.Expressions;

namespace Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<IList<GetUsersDTO>> GetAll(string roleName);
        Task Create(CreateUserDTO createUser);
        Task<GetUsersDTO> GetByUserName(string id);
        Task Put(PutUserDTO putUserDTO);
        Task Delete(string id);
    }
}
