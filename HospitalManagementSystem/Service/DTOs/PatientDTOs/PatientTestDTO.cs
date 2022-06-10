using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.PatientDTOs
{
    public class PatientTestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PatientDTO Patient { get; set; }
        //public int PatientId { get; set; }
        public UserDTO AppUser { get; set; }
        //public int AppUserId { get; set; }
        public DateTime Date { get; set; }
        public string TestResult { get; set; }
        public string Comment { get; set; }
        public int Fee { get; set; }
    }
}
