using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class BedRepo : Repo<Bed>, IBedRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Bed> entities;

        public BedRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Bed>();
        }
    }
}
