using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class PaymentRepo : Repo<Payment>, IPaymentRepo
    {
        public PaymentRepo(AppDbContext context) : base(context)
        {
        }
    }
}
