using Domain.Common;

namespace Domain.Entities
{
    public class Birth : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Patient Patient { get; set; }
        //public int PatientId { get; set; }
        public AppUser AppUser { get; set; }
        //public int AppUserId { get; set; }
    }
}
