using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.DTOs.PatientDTOs;
using Service.Services.Interfaces;

namespace Service.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _patientRepo;
        private readonly IMapper _mapper;

        public PatientService(IMapper mapper,
                              IPatientRepo patientRepo)
        {
            _mapper = mapper;
            _patientRepo = patientRepo;
        }

        public async Task<List<PatientDTO>> GetPatients()
        {
            var patients = await _patientRepo.FindAllAsync(null);

            var patientDTO = _mapper.Map<List<PatientDTO>>(patients);

            return patientDTO;
        }
    }
}
