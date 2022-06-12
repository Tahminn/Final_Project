using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly DbSet<User> entities;
        public UserRepo(AppDbContext context,
                        UserManager<User> userManager)
        {
            _context = context;
            entities = _context.Set<User>();
            _userManager = userManager;
        }
        public async Task CreateAsync(User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            await entities.AddAsync(entity);
            await _userManager.AddToRoleAsync(entity, "Member");
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindAsync(Expression<Func<User, bool>> predicate)
        {
            User entity = await entities.FirstOrDefaultAsync(predicate);

            if (entity is null) throw new NullReferenceException(nameof(entity));

            return entity;
        }

        public async Task<IEnumerable<User>> FindAllAsync(Expression<Func<User, bool>> predicate)
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

        //public async Task<List<User>> GetAllAsync(int take, int lastPatientId)
        //{
        //    try
        //    {
        //        List<User> user = await entities
        //                .Where(p => p.Id < lastPatientId)
        //                .Include(p => p.User)
        //                .Include(p => p.Patient)
        //                .ThenInclude(p => p.Gender)
        //                .OrderByDescending(p => p.Id)
        //                .Take(take)
        //                .ToListAsync();

        //        return patients;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
