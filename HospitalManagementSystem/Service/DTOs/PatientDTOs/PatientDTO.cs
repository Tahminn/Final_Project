namespace Service.DTOs.PatientDTOs
{
    public class PatientDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public GenderDTO Gender { get; set; }
        //public int GenderId { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsMarried { get; set; }
        public string Passport { get; set; }
        public string Symptom_Sickness { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string CreatedBy { get; set; }
        public string Image { get; set; }
    }
}
