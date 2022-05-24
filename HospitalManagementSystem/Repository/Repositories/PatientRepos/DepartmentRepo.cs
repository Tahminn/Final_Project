using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class DepartmentRepo : Repo<Department>, IDepartmentRepo
    {
        public DepartmentRepo(AppDbContext context) : base(context)
        {
        }
    }
}
