using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class BirthRepo : Repo<Birth>, IBirthRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Birth> entities;

        public BirthRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Birth>();
        }
    }
}
