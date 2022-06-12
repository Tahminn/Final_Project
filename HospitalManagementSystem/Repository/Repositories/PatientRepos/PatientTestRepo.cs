using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class PatientTestRepo : Repo<PatientTest>, IPatientTestRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<PatientTest> entities;

        public PatientTestRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<PatientTest>();
        }
    }
}
