using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class AppUserRepo : IAppUserRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<AppUser> entities;
        public AppUserRepo(AppDbContext context)
        {
            _context = context;
            entities = _context.Set<AppUser>();
        }
        public async Task CreateAsync(AppUser entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AppUser entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AppUser entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<AppUser> FindAsync(Expression<Func<AppUser, bool>> predicate)
        {
            AppUser entity = await entities.FirstOrDefaultAsync(predicate);

            if (entity is null) throw new NullReferenceException(nameof(entity));

            return entity;
        }

        public async Task<IEnumerable<AppUser>> FindAllAsync(Expression<Func<AppUser, bool>> predicate)
        {
            if (predicate is null)
            {
                return await entities
                    .Include(e => e.Gender)
                    .Include(e => e.Occupation)
                    .Include(e => e.Department)
                    .ToListAsync();
            }
            else
            {
                return await entities
                    .Where(predicate)
                    .Include(e => e.Gender)
                    .Include(e => e.Occupation)
                    .Include(e => e.Department)
                    .ToListAsync();
            }
        }
    }
}
