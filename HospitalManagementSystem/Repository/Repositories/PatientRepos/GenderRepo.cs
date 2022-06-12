using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class GenderRepo : Repo<Gender>, IGenderRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Gender> entities;

        public GenderRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Gender>();
        }
    }
}
