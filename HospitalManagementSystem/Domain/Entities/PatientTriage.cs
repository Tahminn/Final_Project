using Domain.Common;

namespace Domain.Entities
{
    public class PatientTriage : BaseEntity
    {
        public Patient Patient { get; set; }
        //public int PatientId { get; set; }
        public Triage Triage { get; set; }
        //public int TriageId { get; set; }
        public string BloodPressure { get; set; }
        public int HeartBeat { get; set; }
        public string SugarLevel { get; set; }
        public decimal Height { get; set; }
        public int Weight { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string Comment { get; set; }
        public int Fee { get; set; }
    }
}
