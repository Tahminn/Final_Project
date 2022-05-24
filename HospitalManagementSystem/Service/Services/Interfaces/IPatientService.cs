using Service.DTOs.PatientDTOs;

namespace Service.Services.Interfaces
{
    public interface IPatientService
    {
        Task<List<PatientDTO>> GetPatients();
    }
}
