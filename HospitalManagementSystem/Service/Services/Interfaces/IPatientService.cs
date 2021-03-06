using Service.DTOs.ControllerPropDTOs.PatientDTOs;
using Service.DTOs.ControllerPropDTOs.PatientDTOs.CreatePatients;
using Service.DTOs.ControllerPropDTOs.PatientDTOs.PutPatients;
using Service.DTOs.EntityDTOs.PatientDTOs;
using Service.Utilities.Pagination;

namespace Service.Services.Interfaces
{
    public interface IPatientService
    {
        Task Create(CreatePatientsDTO createPatients);
        Task<Paginate<UserPatientDTO>> GetAllFromUserPatient(string userId, int take, int lastPatientId, int page);
        Task<Paginate<PatientDTO>> GetAll(int take, int lastPatientId, int page);
        Task<PatientDTO> GetById(int id);
        Task Put(int id, PutPatientsDTO putPatientsDTO);
        Task Delete(int id);
    }
}
