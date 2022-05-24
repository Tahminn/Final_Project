using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class BedRepo : Repo<Bed>, IBedRepo
    {
        public BedRepo(AppDbContext context) : base(context)
        {
        }
    }
}
