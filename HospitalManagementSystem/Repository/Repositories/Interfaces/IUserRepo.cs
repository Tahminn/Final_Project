using Domain.Entities;
using System.Linq.Expressions;

namespace Repository.Repositories.Interfaces
{
    public interface IUserRepo
    {
        Task CreateAsync(User entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(User entity);
        Task<User> FindAsync(Expression<Func<User, bool>> predicate);
        Task<IEnumerable<User>> FindAllAsync(Expression<Func<User, bool>> predicate);
        Task<List<User>> GetAllAsync(int take, int lastPatientId);
    }
}
