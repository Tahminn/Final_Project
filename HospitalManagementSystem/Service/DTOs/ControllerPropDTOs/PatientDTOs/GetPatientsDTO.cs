using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.ControllerPropDTOs.PatientDTOs
{
    public class GetPatientsDTO
    {
        public string UserId { get; set; }
        public int Take { get; set; }
        public int LastPatientId { get; set; }
        public int Page { get; set; }
    }
}
