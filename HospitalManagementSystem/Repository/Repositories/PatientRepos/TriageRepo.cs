using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class TriageRepo : Repo<Triage>, ITriageRepo
    {
        public TriageRepo(AppDbContext context) : base(context)
        {
        }
    }
}
