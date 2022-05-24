using Domain.Common;

namespace Domain.Entities
{
    public class PatientTest : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Patient Patient { get; set; }
        //public int PatientId { get; set; }
        public AppUser AppUser { get; set; }
        //public int AppUserId { get; set; }
        public DateTime Date { get; set; }
        public string TestResult { get; set; }
        public string Comment { get; set; }
        public int Fee { get; set; }
    }
}
