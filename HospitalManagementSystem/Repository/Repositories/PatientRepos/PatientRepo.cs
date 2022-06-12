using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.PatientRepos
{
    public class PatientRepo : Repo<Patient>, IPatientRepo
    {

        private readonly AppDbContext _context;
        private readonly DbSet<Patient> entities;

        public PatientRepo(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Patient>();
        }

        public async Task<Patient> GetById(int id)
        {
            try
            {
                return await entities
                    .Include(t => t.Gender)
                    .Include(t => t.PatientBills)
                    .Include(t => t.PatientTests)
                    .Include(t => t.PatientTriages)
                    .ThenInclude(t => t.Triage)
                    .Include(t => t.Payments)
                    .Include(t => t.UserPatients)
                    .ThenInclude(t => t.User)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var patient = await entities
                    .Include(t => t.Gender)
                    .Include(t => t.PatientBills)
                    .Include(t => t.PatientTests)
                    .Include(t => t.PatientTriages)
                    .ThenInclude(t => t.Triage)
                    .Include(t => t.Payments)
                    .Include(t => t.UserPatients)
                    .FirstOrDefaultAsync(x => x.Id == id);

                entities.Remove(patient);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Create(Patient patient/*, ICollection<PatientTriage> patientTriages*/)
        {
            try
            {
                entities.Add(patient);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task Put(Patient patient/*, ICollection<PatientTriage> patientTriages*/)
        {
            try
            {
                var patientTriag = await _context.PatientTriage.AsNoTracking().FirstOrDefaultAsync(m => m.PatientId == patient.Id);

                patient.PatientTriages.FirstOrDefault().Id = patientTriag.Id;

                _context.PatientTriage.Update(patient.PatientTriages.FirstOrDefault());
                //var currentPatient = await entities.FirstOrDefaultAsync(e => e.Id == id);
                entities.Update(patient);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
