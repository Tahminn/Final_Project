using Domain.Entities;
using System.Linq.Expressions;

namespace Repository.Repositories.Interfaces
{
    public interface IAppUserRepo
    {
        Task CreateAsync(AppUser entity);
        Task UpdateAsync(AppUser entity);
        Task DeleteAsync(AppUser entity);
        Task<AppUser> FindAsync(Expression<Func<AppUser, bool>> predicate);
        Task<IEnumerable<AppUser>> FindAllAsync(Expression<Func<AppUser, bool>> predicate);
    }
}
