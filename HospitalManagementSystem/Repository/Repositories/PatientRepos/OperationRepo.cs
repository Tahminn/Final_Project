using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class OperationRepo : Repo<Operation>, IOperationRepo
    {
        public OperationRepo(AppDbContext context) : base(context)
        {
        }
    }
}
