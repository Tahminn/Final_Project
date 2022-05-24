using Domain.Common;

namespace Domain.Entities
{
    public class Triage : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PatientTriage> PatientTriages { get; set; }
    }
}
