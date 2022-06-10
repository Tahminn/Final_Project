using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.PatientDTOs
{
    public class TriageDTO
    {
        public string Name { get; set; }
        public ICollection<PatientTriageDTO> PatientTriages { get; set; }
    }
}
