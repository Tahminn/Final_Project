using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IPatientRepo : IRepo<Patient>
    {
        Task<List<Patient>> GetAllAsync(int take, int lastPatientId);
        Task<Patient> GetById(int id);
        Task Delete(int id);
        Task Put(Patient patient);
        Task Create(Patient patient/*, ICollection<PatientTriage> patientTriages*/);
    }
}
