using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class DepartmentRepo : Repo<Department>, IDepartmentRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Department> entities;

        public DepartmentRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Department>();
        }
    }
}
