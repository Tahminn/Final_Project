using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.DTOs.ControllerPropDTOs.PatientDTOs.CreatePatients;
using Service.DTOs.ControllerPropDTOs.PatientDTOs.PutPatients;
using Service.DTOs.EntityDTOs.PatientDTOs;
using Service.Services.Interfaces;
using Service.Utilities.Helpers;
using Service.Utilities.Pagination;

namespace Service.Services.PatientServices
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;
        private readonly IUserPatientRepo _userPatientRepo;
        private readonly IPatientRepo _patientRepo;
        private readonly IMapper _mapper;

        public PatientService(IMapper mapper,
                              IUserPatientRepo userPatientRepo,
                              AppDbContext context,
                              IPatientRepo patientRepo)
        {
            _mapper = mapper;
            _userPatientRepo = userPatientRepo;
            _context = context;
            _patientRepo = patientRepo;
        }

        public async Task Create(CreatePatientsDTO createPatients)
        {
            foreach (var patientTriages in createPatients.PatientTriages)
            {
                patientTriages.TriageId = MeasureTriageLevel(patientTriages.BloodPressure, patientTriages.SugarLevel, patientTriages.HeartBeat);
            }
            var patient = _mapper.Map<Patient>(createPatients);

            //var patientTriage = _mapper.Map<ICollection<PatientTriage>>(createPatients.PatientTriages);

            await _patientRepo.Create(patient/*, patientTriage*/);
        }

        public async Task<Paginate<UserPatientDTO>> GetAll(string userId, int take, int lastPatientId, int page)
        {
            
            List<UserPatient> patients = await _userPatientRepo.GetAllAsync(userId, take, lastPatientId);

            var patientDTO = _mapper.Map<List<UserPatientDTO>>(patients);

            int totalPage = Helper.GetPageCount(patients.Count(), take);

            Paginate<UserPatientDTO> paginatedUserPatient = new Paginate<UserPatientDTO>(patientDTO, page, totalPage);
            
            return paginatedUserPatient;
        }

        public async Task<PatientDTO> GetById(int id)
        {
            Patient patient = await _patientRepo.GetById(id);

            var patientDTO = _mapper.Map<PatientDTO>(patient);

            return patientDTO;
        }

        public async Task Put(PutPatientsDTO putPatientsDTO)
        {
            foreach (var patientTriages in putPatientsDTO.PatientTriages)
            {
                patientTriages.TriageId = MeasureTriageLevel(patientTriages.BloodPressure, patientTriages.SugarLevel, patientTriages.HeartBeat);
            }
            var patient = _mapper.Map<Patient>(putPatientsDTO);

            //var patientTriage = _mapper.Map<ICollection<PatientTriage>>(putPatientsDTO.PatientTriages);

            await _patientRepo.Put(patient/*, patientTriage*/);
        }

        public async Task Delete(int id)
        {
            await _patientRepo.Delete(id);
        }


        //Measures Triage Level Of Patients
        private int MeasureTriageLevel(int bloodPressure, int sugarLevel, int heartBeat)
        {
            int result = (bloodPressure + sugarLevel + heartBeat) / 3;

            switch (result)
            {
                case > 80:
                    return 1;
                case > 60:
                    return 2;
                case > 40:
                    return 3;
                case > 20:
                    return 4;
                default:
                    return 1;
            }
        }
    }
}
