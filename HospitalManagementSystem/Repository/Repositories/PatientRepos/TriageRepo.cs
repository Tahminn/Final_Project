using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class TriageRepo : Repo<Triage>, ITriageRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Triage> entities;

        public TriageRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Triage>();
        }
    }
}
