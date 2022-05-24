using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class PatientTestRepo : Repo<PatientTest>, IPatientTestRepo
    {
        public PatientTestRepo(AppDbContext context) : base(context)
        {
        }
    }
}
