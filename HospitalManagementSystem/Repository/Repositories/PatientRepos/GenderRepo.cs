using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class GenderRepo : Repo<Gender>, IGenderRepo
    {
        public GenderRepo(AppDbContext context) : base(context)
        {
        }
    }
}
