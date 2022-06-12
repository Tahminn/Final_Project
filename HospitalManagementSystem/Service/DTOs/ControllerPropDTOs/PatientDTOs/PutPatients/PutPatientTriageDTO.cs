using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.ControllerPropDTOs.PatientDTOs.PutPatients
{
    public class PutPatientTriageDTO
    {
        public int TriageId { get; set; }
        public int BloodPressure { get; set; }
        public int HeartBeat { get; set; }
        public int SugarLevel { get; set; }
        public decimal Height { get; set; }
        public int Weight { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string Comment { get; set; }
        public int Fee { get; set; }
    }
}
