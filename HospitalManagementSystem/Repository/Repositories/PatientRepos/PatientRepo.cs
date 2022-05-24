using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Repository.Repositories.PatientRepos
{
    public class PatientRepo : Repo<Patient>, IPatientRepo
    {

        private readonly AppDbContext _context;
        private readonly DbSet<Patient> entities;

        public PatientRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Patient>();
        }

        public async new Task<IEnumerable<Patient>> FindAllAsync(Expression<Func<Patient, bool>> predicate)
        {
            if (predicate is null)
            {
                return await entities
                    .Include(m => m.Gender)
                    .ToListAsync();
            }
            else
            {
                return await entities.Where(predicate).Include(m => m.Gender).ToListAsync();
            }
        }

    }
}
