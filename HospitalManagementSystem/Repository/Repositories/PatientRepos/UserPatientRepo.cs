using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.PatientRepos
{
    public class UserPatientRepo : Repo<UserPatient>, IUserPatientRepo
    {

        private readonly AppDbContext _context;
        private readonly DbSet<UserPatient> entities;

        public UserPatientRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<UserPatient>();
        }

        public async Task<List<UserPatient>> GetAllAsync(string userId, int take, int lastPatientId)
        {
            try
            {
                List<UserPatient> patients = new();

                if (userId != null)
                {
                    patients = await entities
                        .Where(p => p.User.Id == userId && p.Id < lastPatientId)
                        .Include(p => p.User)
                        .Include(p => p.Patient)
                        .ThenInclude(p => p.Gender)
                        .OrderByDescending(p => p.Id)
                        .Take(take)
                        .ToListAsync();
                }
                else
                {
                    patients = await entities
                        .Where(p => p.Id < lastPatientId)
                        .Include(p => p.User)
                        .Include(p => p.Patient)
                        .ThenInclude(p => p.Gender)
                        .OrderByDescending(p => p.Id)
                        .Take(take)
                        .ToListAsync();
                }

                return patients;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
