using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class BirthRepo : Repo<Birth>, IBirthRepo
    {
        public BirthRepo(AppDbContext context) : base(context)
        {
        }
    }
}
