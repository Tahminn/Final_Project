using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Helpers;
using Repository.Repositories.Interfaces;
using System.Linq.Expressions;

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
        //public async new Task<IEnumerable<Patient>> FindAllAsync(Expression<Func<Patient, bool>> predicate)
        //{
        //    if (predicate is null)
        //    {
        //        return await entities
        //            .Include(t => t.Gender)
        //            .Include(t => t.PatientBills)
        //            .Include(t => t.PatientTests)
        //            .Include(t => t.PatientTriages)
        //            .ThenInclude(t => t.Triage)
        //            .Include(t => t.Payments)
        //            .OrderByDescending(t => t.Id)
        //            .ToListAsync();
        //    }
        //    else
        //    {
        //        return await entities
        //            .Where(predicate)
        //            .Include(t => t.Gender)
        //            .Include(t => t.PatientBills)
        //            .Include(t => t.PatientTests)
        //            .Include(t => t.PatientTriages)
        //            .ThenInclude(t => t.Triage)
        //            .Include(t => t.Payments)
        //            .OrderByDescending(t => t.Id)
        //            .ToListAsync();

        //            //int totalPage = PageCount.Ge    tPageCount(count, take);
        //            //Paginate<TeacherListVM> paginatedTeacher = new Paginate<TeacherListVM>(teachersVM, page, totalPage);
        //    }
        //}

        public async Task<List<Patient>> GetAllAsync(int? appUserId, int take, int lastPatientId)
        {
            try
            {
                if (appUserId != null)
                {
                    List<Patient> patients = await _context.Patients
                        .Where(t => t.Id < lastPatientId && t.PatientTests.)
                        .Include(t => t.Gender)
                        .Include(t => t.PatientBills)
                        .Include(t => t.PatientTests)
                        .Include(t => t.PatientTriages)
                        .ThenInclude(t => t.Triage)
                        .Include(t => t.Payments)
                        .OrderByDescending(t => t.Id)
                        .Take(take)
                        .ToListAsync();
                }
                else
                {
                    List<Patient> patients = await _context.Patients
                        .Where(t => t.Id < lastPatientId)
                        .Include(t => t.Gender)
                        .Include(t => t.PatientBills)
                        .Include(t => t.PatientTests)
                        .Include(t => t.PatientTriages)
                        .ThenInclude(t => t.Triage)
                        .Include(t => t.Payments)
                        .OrderByDescending(t => t.Id)
                        .Take(take)
                        .ToListAsync();
                }

                

                if (take > 0) teachers = teachers.Take(take).ToList();
                var teachersVM = GetMapDatas(teachers);
                
                return paginatedTeacher;
            }
            catch (Exception)
            {
                throw;
            }
            //var patients = await _patientRepo.FindAllAsync(null);

            //var patientDTO = _mapper.Map<List<PatientDTO>>(patients);

            //return patientDTO;
        }

    }
}
