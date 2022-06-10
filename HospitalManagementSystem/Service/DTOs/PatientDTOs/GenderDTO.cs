namespace Service.DTOs.PatientDTOs
{
    public class GenderDTO
    {
        public string Name { get; set; }
        public ICollection<PatientDTO> Patients { get; set; }
    }
}
