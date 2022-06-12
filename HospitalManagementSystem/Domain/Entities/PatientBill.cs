using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class PatientBill : BaseEntity
    {
        [Required]
        public Patient Patient { get; set; }
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
