using Service.DTOs.EntityDTOs.PatientDTOs;

namespace Service.DTOs.EntityDTOs.AccountDTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsMarried { get; set; }
        public GenderDTO Gender { get; set; }
        public OccupationDTO Occupation { get; set; }
        public DepartmentDTO Department { get; set; }
        public ICollection<UserPatientDTO> UserPatients { get; set; }
    }
}
