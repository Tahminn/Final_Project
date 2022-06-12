using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class PatientTriageRepo : Repo<PatientTriage>, IPatientTriageRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<PatientTriage> entities;

        public PatientTriageRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<PatientTriage>();
        }
    }
}