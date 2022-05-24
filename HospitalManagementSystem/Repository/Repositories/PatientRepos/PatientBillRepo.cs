using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class PatientBillRepo : Repo<PatientBill>, IPatientBillRepo
    {
        public PatientBillRepo(AppDbContext context) : base(context)
        {
        }
    }
}
