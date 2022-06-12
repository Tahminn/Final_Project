using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class OperationRepo : Repo<Operation>, IOperationRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Operation> entities;

        public OperationRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Operation>();
        }
    }
}
