namespace Service.DTOs.EntityDTOs.PatientDTOs
{
    public class GenderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PatientDTO> Patients { get; set; }
    }
}
