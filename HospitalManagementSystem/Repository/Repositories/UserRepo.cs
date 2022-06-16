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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DbSet<User> entities;
        public UserRepo(AppDbContext context,
                        UserManager<User> userManager,
                        RoleManager<IdentityRole> roleManager = null)
        {
            _context = context;
            entities = _context.Set<User>();
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task CreateAsync(User entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            await entities.AddAsync(entity);
            await _userManager.AddToRoleAsync(entity, "Doctor");
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

        //public async Task<IEnumerable<User>> FindAllAsync(Expression<Func<User, bool>> predicate)
        //{
        //    if (predicate is null)
        //    {
        //        return await entities
        //            .Include(e => e.Gender)
        //            .Include(e => e.Occupation)
        //            .Include(e => e.Department)
        //            .ToListAsync();
        //    }
        //    else
        //    {
        //        return await entities
        //            .Where(predicate)
        //            .Include(e => e.Gender)
        //            .Include(e => e.Occupation)
        //            .Include(e => e.Department)
        //            .ToListAsync();
        //    }
        //}

        //public async Task<List<User>> GetAllByRoleAsync(string roleName, int take, int skip)
        //{
        //    try
        //    {
        //        var role = await _roleManager.FindByNameAsync(roleName);

        //        var user = await _userManager.Users.Where(m => m.UserRoles.Contains(role));

        //        List<User> user = await entities
        //                .Where(m => m.UserRoles == role)
        //                .Include(m => m.UserRoles)
        //                .Include(p => p.Gender)
        //                .Include(p => p.Department)
        //                .Include(p => p.Occupation)
        //                .OrderByDescending(p => p.Id)
        //                .Skip(skip)
        //                .Take(take)
        //                .ToListAsync();

        //        return user;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        ////}
        //public async Task<int> GetCountByRoleAsync(string roleName)
        //{
        //    try
        //    {
        //        var role = await _roleManager.FindByNameAsync(roleName);
        //        int userCount = await entities
        //                //.Where(m => m.UserRoles == role)
        //                .CountAsync();

        //        return userCount;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
