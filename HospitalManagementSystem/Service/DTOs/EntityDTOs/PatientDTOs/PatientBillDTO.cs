using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.EntityDTOs.PatientDTOs
{
    public class PatientBillDTO
    {
        public int Id { get; set; }
        public PatientDTO Patient { get; set; }
        //public int PatientId { get; set; }
        public int DoctorCharge { get; set; }
        public int MedicineCharge { get; set; }
        public int RoomCharge { get; set; }
        public int OperationCharge { get; set; }
        public int NursingCharge { get; set; }
        public int LabCharge { get; set; }
        public int TotalFee { get; set; }
    }
}
