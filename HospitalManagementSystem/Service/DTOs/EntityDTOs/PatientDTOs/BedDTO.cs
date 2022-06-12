using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.EntityDTOs.PatientDTOs
{
    public class BedDTO
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public bool IsEmpty { get; set; }
        public PatientDTO Patient { get; set; }
        //public int PatientId { get; set; }
        public DateTime AllocatedTime { get; set; }
        public DateTime DischargeTime { get; set; }
    }
}
