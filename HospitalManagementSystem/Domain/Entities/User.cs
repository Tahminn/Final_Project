using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
        }
        public User(string userName) : base(userName)
        {
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public bool? IsMarried { get; set; }
        public Gender Gender { get; set; }
        public int? GenderId { get; set; }
        public Occupation Occupation { get; set; }
        public int? OccupationId { get; set; }
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
        public ICollection<UserPatient> UserPatients { get; set; }
        //public ICollection<Role> Roles { get; set; }
    }
}
