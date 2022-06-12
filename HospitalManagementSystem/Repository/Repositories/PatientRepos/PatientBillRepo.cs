using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class PatientBillRepo : Repo<PatientBill>, IPatientBillRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<PatientBill> entities;

        public PatientBillRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<PatientBill>();
        }
    }
}
