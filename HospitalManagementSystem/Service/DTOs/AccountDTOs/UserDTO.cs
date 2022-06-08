namespace Service.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsMarried { get; set; }
    }
}
