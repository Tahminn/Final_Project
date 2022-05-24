using Domain.Common;

namespace Domain.Entities
{
    public class Bed : BaseEntity
    {
        public int RoomNumber { get; set; }
        public bool IsEmpty { get; set; }
        public Patient Patient { get; set; }
        //public int PatientId { get; set; }
        public DateTime AllocatedTime { get; set; }
        public DateTime DischargeTime { get; set; }

    }
}
