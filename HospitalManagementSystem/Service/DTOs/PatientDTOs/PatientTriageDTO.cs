using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.PatientDTOs
{
    public class PatientTriageDTO
    {
        public PatientDTO Patient { get; set; }
        //public int PatientId { get; set; }
        public TriageDTO Triage { get; set; }
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
