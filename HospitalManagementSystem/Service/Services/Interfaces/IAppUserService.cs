using Domain.Entities;
using Service.DTOs;
using System.Linq.Expressions;

namespace Service.Services.Interfaces
{
    public interface IAppUserService
    {
        Task<List<UserDTO>> GetUsers(Expression<Func<AppUser, bool>> predicate);
        Task<UserDTO> GetUser(Expression<Func<AppUser, bool>> predicate);
    }
}
