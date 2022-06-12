using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.EntityDTOs.PatientDTOs
{
    public class TriageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PatientTriageDTO> PatientTriages { get; set; }
    }
}
