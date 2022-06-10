using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.DTOs.PatientDTOs;
using Service.Services.Interfaces;

namespace Service.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;
        private readonly IPatientRepo _patientRepo;
        private readonly IMapper _mapper;

        public PatientService(IMapper mapper,
                              IPatientRepo patientRepo,
                              AppDbContext context)
        {
            _mapper = mapper;
            _patientRepo = patientRepo;
            _context = context;
        }

        public async Task<List<PatientDTO>> GetPatients(int take, int after)
        {
            try
            {
                List<Patient> patients = await _context.Patients
                    .Where(t => t.Id < after)
                    .Include(t => t.Gender)
                    .Include(t => t.PatientBills)
                    .Include(t => t.PatientTests)
                    .Include(t => t.PatientTriages)
                    .ThenInclude(t=> t.Triage)
                    .Include(t => t.Payments)
                    .OrderByDescending(t => t.Id)
                    .ToListAsync();

                if (take > 0) teachers = teachers.Take(take).ToList();
                var teachersVM = GetMapDatas(teachers);
                int totalPage = Helper.GetPageCount(count, take);
                Paginate<TeacherListVM> paginatedTeacher = new Paginate<TeacherListVM>(teachersVM, page, totalPage);
                return paginatedTeacher;
            }
            catch (Exception)
            {
                throw;
            }
            var patients = await _patientRepo.FindAllAsync(null);

            var patientDTO = _mapper.Map<List<PatientDTO>>(patients);

            return patientDTO;
        }
    }
}
