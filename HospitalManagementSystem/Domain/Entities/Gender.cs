using Domain.Common;

namespace Domain.Entities
{
    public class Gender : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
