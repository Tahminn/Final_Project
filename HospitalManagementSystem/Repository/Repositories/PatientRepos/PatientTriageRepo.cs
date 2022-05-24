using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class PatientTriageRepo : Repo<PatientTriage>, IPatientTriageRepo
    {
        public PatientTriageRepo(AppDbContext context) : base(context)
        {
        }
    }
}