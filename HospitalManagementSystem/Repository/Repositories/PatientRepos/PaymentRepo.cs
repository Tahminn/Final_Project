using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class PaymentRepo : Repo<Payment>, IPaymentRepo
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Payment> entities;

        public PaymentRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Payment>();
        }
    }
}
